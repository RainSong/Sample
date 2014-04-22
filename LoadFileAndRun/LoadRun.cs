using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace LoadFileAndRun
{
    public static class LoadRun
    {
        public static void RunFiles(ConfigInfo configInfo)
        {
            foreach (var assInfo in configInfo.AssemblyInfos)
            {
                if (assInfo.IsEntry)
                {
                    RunExeFile(assInfo.FileName);
                }
                else
                {
                    ExecuteDLLFile(assInfo.FileName);
                }
            }
        }

        private static void RunExeFile(string fileName)
        {
            try
            {
                int index = fileName.LastIndexOf(".", System.StringComparison.Ordinal) + 1;
                fileName = fileName.Remove(index) + "exe";
                Process.Start(fileName);
                Console.WriteLine(string.Format("运行程序{0}", fileName));
            }
            catch (Exception e)
            {

            }
        }

        private static void ExecuteDLLFile(string fileName)
        {
            try
            {
                int index = fileName.LastIndexOf(".", System.StringComparison.Ordinal) + 1;
                fileName = fileName.Remove(index) + "dll";
                Assembly assembly = Assembly.LoadFile(Directory.GetCurrentDirectory() + "\\" + fileName);
                var type = assembly.GetType("MyCore.Security");
                if (type == null)
                {
                    Console.WriteLine("未找到类型MyCore.Security");
                    return;
                }

                var enMethod = type.GetMethod("DesEncrypt");
                if (enMethod == null)
                {
                    Console.WriteLine("未找到方法DesEncrypt");
                    return;
                }
                string pwd = "000";
                Console.WriteLine(pwd);
                string strKey = "$$$$$$$$";
                object value;
                try
                {
                    value = enMethod.Invoke(null, new object[] {pwd, strKey});
                }
                catch (TargetInvocationException ex)
                {
                    value = ex.InnerException;
                }
                Console.WriteLine(value);
                var desMethod = type.GetMethod("DesDecrypt");
                if (desMethod == null)
                {
                    Console.WriteLine("未找到方法DesDecrypt");
                    return;
                }
                try
                {
                    value = desMethod.Invoke(null, new object[] { value.ToString(), strKey });
                }
                catch (TargetInvocationException ex)
                {
                    value = ex.InnerException.Message;
                }
                Console.WriteLine(value);
            }
            catch (Exception ex)
            {
            }
        }
    }
}
