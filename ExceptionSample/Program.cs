using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionSample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //ClassA.Foo3();
                Class1.Foo2();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            Console.ReadKey();
        }


    }
    internal class Class1
    {
        public static void Foo1()
        {
            var ex = new Exception("error in foo1");
            ex.Data.Add("ErrorMsg", "msg append in foo1");
            throw ex;
        }
        public static void Foo2()
        {
            Foo1();
        }
    }
    internal static class ClassA
    {
        private static void Foo1()
        {

            throw new Exception("this excetion thorw at foo1");

        }
        private static void Foo2()
        {
            try
            {
                Foo1();
            }
            catch (Exception ex)
            {
                throw new Exception("this excetion thorw at foo2", ex);
            }
        }
        internal static void Foo3()
        {
            try
            {
                Foo2();
            }
            catch (Exception ex)
            {
                throw new Exception("this excetion thorw at foo3", ex);
            }
        }
    }
}
