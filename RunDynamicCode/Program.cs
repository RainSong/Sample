using System;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Xml;
using Microsoft.CSharp;

namespace RunDynamicCode
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime tiem = DateTime.Now;
            string path = AppDomain.CurrentDomain.BaseDirectory;
            string strXml = File.ReadAllText(path + "\\TypeInfo.xml");
            var ns = Serializer.Deserialize<CustomNameSpace>(strXml, Encoding.UTF8);
            string strCode;
            string errorMsg = string.Empty;
            Assembly assembly = null;
            #region 手动生成代码然后编译
            strCode = ns.ToString();

            File.WriteAllText(string.Format(@"d:\{0}.cs", ns.Name), strCode, Encoding.UTF8);

            Console.WriteLine(strCode);

            if (CompileCode(strCode, ref errorMsg, ref assembly))
            {
                Console.WriteLine("编译失败，错误原因：" + errorMsg);
            }
            else
            {
                Console.WriteLine("编译成功");
                var reportBaseType = assembly.GetType("DynamicNamespace.ReportBase");
                var propertyInfos = reportBaseType.GetProperties();
                foreach (var pro in propertyInfos)
                {
                    Console.WriteLine("Property Name:{0,-20}Property Type:{1}", pro.Name, pro.PropertyType.Name);
                }

            }
            #endregion

            strCode = string.Empty;
            assembly = null;
            #region  使用CodeDom生成代码

            var dom = GetDom(ns);
            strCode = GenerateCSharpCode(dom);
            Console.WriteLine(strCode);


            if (ComplieCode(dom, ref errorMsg, ref assembly) && assembly != null)
            {
                if (!string.IsNullOrEmpty(errorMsg))
                {
                    Console.WriteLine("编译失败，错误原因：" + errorMsg);
                }
                else
                {
                    Console.WriteLine("编译失败");
                }
            }
            else
            {
                Console.WriteLine("编译成功");
                if (assembly != null)
                {
                    var reportBaseType = assembly.GetType("DynamicNamespace.ReportBase2");
                    if (reportBaseType != null)
                    {
                        var propertyInfos = reportBaseType.GetProperties();
                        foreach (var pro in propertyInfos)
                        {
                            Console.WriteLine("Property Name:{0,-20}Property Type:{1}", pro.Name, pro.PropertyType.Name);
                        }
                    }
                }
            }
            #endregion
            Console.WriteLine("输入任何键结束......");
            Console.ReadKey();
        }
        /// <summary>
        /// 直接编译代码文本的方法
        /// </summary>
        /// <param name="strCode"></param>
        /// <param name="errorMsg"></param>
        /// <param name="assembly"></param>
        /// <returns></returns>
        private static bool CompileCode(string strCode, ref string errorMsg, ref Assembly assembly)
        {
            bool hasError = false;
            var codeProvider = new CSharpCodeProvider();

            var compilePara = new CompilerParameters();
            compilePara.ReferencedAssemblies.Add("System.dll");
            //不生成可执行文件
            compilePara.GenerateExecutable = false;
            //生成在内存中
            compilePara.GenerateInMemory = true;

            CompilerResults compilerResults = codeProvider.CompileAssemblyFromSource(compilePara, strCode);
            hasError = compilerResults.Errors.HasErrors;
            if (hasError)
            {
                var sb = new StringBuilder(compilerResults.Errors.Count);
                sb.Append("Errors");
                foreach (CompilerError error in compilerResults.Errors)
                {
                    sb.Append("\r\nLine: ");
                    sb.Append(error.Line);
                    sb.Append(" - ");
                    sb.Append(error.ErrorText);
                }
                errorMsg = sb.ToString();
                assembly = null;
            }
            else
            {
                errorMsg = string.Empty;
                assembly = compilerResults.CompiledAssembly;
            }
            return hasError;
        }

        /// <summary>
        /// 根据配置生成DOM对象
        /// </summary>
        /// <returns></returns>
        private static CodeCompileUnit GetDom(CustomNameSpace ns)
        {
            var codeDom = new CodeCompileUnit();
            var nameSpace = new CodeNamespace(ns.Name);
            codeDom.Namespaces.Add(nameSpace);
            foreach (var str in ns.UsingNameSpaces)
            {
                nameSpace.Imports.Add(new CodeNamespaceImport(str));
            }
            var arrTypes = new CodeTypeDeclaration[ns.CustomTypes.Count];
            for (int i = 0; i < ns.CustomTypes.Count; i++)
            {
                var cType = new CodeTypeDeclaration
                {
                    IsClass = true,
                    TypeAttributes = TypeAttributes.Public,
                    Name = ns.CustomTypes[i].Name + "2"
                };
                arrTypes[i] = cType;
                foreach (CustomFieldInfo f in ns.CustomTypes[i].FieldInfos)
                {
                    Type t = Type.GetType(f.DataType);

                    if (t != null)
                    {
                        var field = new CodeMemberField
                        {
                            Attributes = MemberAttributes.Private,
                            Type = new CodeTypeReference(t),
                            Name = string.Format("_{0}", f.Name)
                        };
                        cType.Members.Add(field);
                        var property = new CodeMemberProperty
                        {
                            Attributes = MemberAttributes.Public | MemberAttributes.Final,
                            Type = new CodeTypeReference(t),
                            HasGet = true,
                            HasSet = true,
                            Name = f.Name
                        };
                        property.Comments.AddRange(new[]
                        {
                            new CodeCommentStatement("<summary>",true),
                            new CodeCommentStatement("地区名", true),
                            new CodeCommentStatement("<summary>",true)
                        });
                        property.GetStatements.Add(
                            new CodeMethodReturnStatement(
                                new CodeFieldReferenceExpression(
                                    new CodeThisReferenceExpression(),
                                    string.Format("_{0}", f.Name))));
                        property.SetStatements.Add(
                            new CodeAssignStatement(
                                new CodeFieldReferenceExpression(
                                    new CodeThisReferenceExpression(),
                                    string.Format("_{0}", f.Name)), new CodePropertySetValueReferenceExpression()));
                        cType.Members.Add(property);


                    }
                }
            }
            nameSpace.Types.AddRange(arrTypes);
            return codeDom;
        }
        /// <summary>
        /// 生成代码
        /// </summary>
        /// <param name="codeDom"></param>
        /// <returns></returns>
        private static string GenerateCSharpCode(CodeCompileUnit codeDom)
        {
            var sb = new StringBuilder();
            var provider = CodeDomProvider.CreateProvider("CSharp");
            var options = new CodeGeneratorOptions
            {
                BracingStyle = "C"
            };
            using (var sw = new StringWriter(sb))
            {
                provider.GenerateCodeFromCompileUnit(codeDom, sw, options);
            }
            using (var sw = new StreamWriter(@"d:\DynamicNamespace2.cs", false))
            {
                provider.GenerateCodeFromCompileUnit(codeDom, sw, options);
            }
            return sb.ToString();
        }
        /// <summary>
        /// 编译
        /// </summary>
        /// <param name="codeDome"></param>
        /// <param name="errorMsg"></param>
        /// <param name="assembly"></param>
        /// <returns></returns>
        private static bool ComplieCode(CodeCompileUnit codeDome, ref string errorMsg, ref Assembly assembly)
        {
            var provider = new CSharpCodeProvider();

            // Build the parameters for source compilation.
            var cp = new CompilerParameters();

            // Add an assembly reference.
            cp.ReferencedAssemblies.Add("System.dll");

            // Generate an executable instead of
            // a class library.
            cp.GenerateExecutable = false;

            // Set the assembly file name to generate.

            // Save the assembly as a physical file.
            cp.GenerateInMemory = true;

            // Invoke compilation.
            CompilerResults compilerResults = provider.CompileAssemblyFromDom(cp, new[] { codeDome });

            var hasError = compilerResults.Errors.HasErrors;
            if (hasError)
            {
                var sb = new StringBuilder(compilerResults.Errors.Count);
                sb.Append("Errors");
                foreach (CompilerError error in compilerResults.Errors)
                {
                    sb.Append("\r\nLine: ");
                    sb.Append(error.Line);
                    sb.Append(" - ");
                    sb.Append(error.ErrorText);
                }
                errorMsg = sb.ToString();
                assembly = null;
            }
            else
            {
                errorMsg = string.Empty;
                assembly = compilerResults.CompiledAssembly;
            }
            return hasError;
        }

        private static Type GetType(string typeName)
        {
            if (typeName.Contains("<"))
            {
                return null;
            }
            else
            {
                return Type.GetType(typeName);
            }
        }

    }
}
