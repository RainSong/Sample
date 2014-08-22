using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using log4net;

namespace log4netTest_RollingLogFileAppender
{
    class Program
    {
        static void Main(string[] args)
        {
            ILog logger = log4net.LogManager.GetLogger("logger");
            for (int i = 0; i < 10; i++) 
            {
                logger.Error(string.Format("第{0}条日志", i));
            }
           
            Console.WriteLine("OK");
            Console.ReadKey();
        }
    }
}
