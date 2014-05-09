using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 泛型
{
    class Program
    {
        static void Main(string[] args)
        {
            object[] arr = new object[] { };
            var list = arr.ToList<object>();
            Action<object> act = o => { };
            list.ForEach(act);

            var ca = new classA();
            var type = typeof(classA);

        }

        static void Fun<T>(object o) 
        {
            
        }
    }

    class classA { }
}
