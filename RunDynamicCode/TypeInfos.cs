using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RunDynamicCode
{
    public class CustomTypeInfo
    {
        public List<string> BaseTypes { get; set; }
        public string Name { get; set; }
        public List<CustomFieldInfo> FieldInfos { get; set; }      
        public string ToString(string space)
        {
            var sb = new StringBuilder(space + "public class ");
            sb.Append(this.Name+"\r\n");

            sb.AppendLine(space + "{");
            foreach (var filedInfo in this.FieldInfos)
            {
                if (!string.IsNullOrEmpty(filedInfo.Description))
                {
                    sb.AppendLine(space + "\t/// <summary>");
                    sb.AppendLine(string.Format("{0}\t/// {1}", space, filedInfo.Description));
                    sb.AppendLine(space + "\t/// <summary>");
                }
                sb.AppendLine(string.Format("{0}\tpublic {1} {2} {3}", space, filedInfo.DataType, filedInfo.Name, "{ get; set; }"));
            }
            sb.AppendLine(space + "}");
            return sb.ToString();
        }

        public CustomTypeInfo()
        {
        }

        public CustomTypeInfo(string typeName)
        {
            this.Name = typeName;
        }
    }

    public class CustomFieldInfo
    {
        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set; }
        public string DataType { get; set; }
        public string Description { get; set; }
    }

    public class CustomNameSpace
    {
        public List<string> UsingNameSpaces { get; set; }
        public List<CustomTypeInfo> CustomTypes { get; set; }
        public string Name { get; set; }
        public override string ToString()
        {
            var sb = new StringBuilder();
            foreach (var strUsing in UsingNameSpaces)
            {
                sb.AppendLine("using " + strUsing + ";");
            }
            sb.AppendLine("\r\nnamespace " + this.Name);
            sb.AppendLine("{");
            foreach (var ctype in this.CustomTypes)
            {
                sb.AppendLine(ctype.ToString("\t"));
            }
            sb.AppendLine("}");
            return sb.ToString();
        }
    }
}
