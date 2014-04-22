using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ILSample
{
    public class Dictionary
    {
        public static void Foo1()
        {
            Dictionary<int, string> dic = new Dictionary<int, string>();
            dic.Add(1, "value1");
	    dic.Add(2, "value2");

            dic.ContainsKey(1);

            string value;
            dic.TryGetValue(1, out value);
        }
    }
}
