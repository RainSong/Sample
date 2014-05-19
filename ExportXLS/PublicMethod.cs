using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft;

namespace ExportXLS
{
    public class PublicMethod
    {
        public static T ConvertJsonToObject<T>(string json)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(json);
        }

        public static string CurrentPath
        {
            get { return System.AppDomain.CurrentDomain.BaseDirectory; }
        }
    }
}
