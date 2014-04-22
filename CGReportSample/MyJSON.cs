using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using fastJSON;

namespace CGReportSample
{
    public static class MyJSON
    {
        public static string ToJSON(object obj)
        {
            JSONParameters para = new JSONParameters();
            para.EnableAnonymousTypes = true;//不输出$type
            para.UseUTCDateTime = false;//不转换为UTC时间    
            return fastJSON.JSON.Instance.ToJSON(obj, para);
        }
        public static string ToDefaultJSON(object obj)
        {
            return fastJSON.JSON.Instance.ToJSON(obj);
        }
        public static object ToObject(string json)
        {
            return fastJSON.JSON.Instance.ToObject(json);
        }
        public static object ToObject(string json, Type type)
        {
            return fastJSON.JSON.Instance.ToObject(json, type);
        }
        public static T ToObject<T>(string json)
        {
            return fastJSON.JSON.Instance.ToObject<T>(json);
        }

    }
}