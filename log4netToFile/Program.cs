using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace log4netToFile
{
    class Program
    {
        static void Main(string[] args)
        {
            Action a = () =>
            {
                while (true)
                {
                    LogManager.LogError(new Exception("这是测试异常"));
                    Console.WriteLine("写入一条异常日志");
                }
            };
            for (int i = 0; i < 10; i++)
            {
                Task t = new Task(a);
                t.Start();
            }
            Console.ReadKey();
        }
    }
}
