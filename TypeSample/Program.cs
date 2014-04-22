using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TypeSample
{
    class Program
    {
        static void Main(string[] args)
        {
            var type = typeof (Test);
            var properties = type.GetProperties();
            foreach (PropertyInfo property in properties)
            {
                var pType = property.PropertyType;
                if (pType.IsGenericType)
                {
                    var gType = pType.GetGenericArguments();
                }
            }
        }
    }

    public class Test
    {
        public Nullable<int> id { get; set; }
        public List<Nullable<DateTime>> times { get; set; }
        public Dictionary<string, int> dic { get; set; }
    }
}
