using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLogSample
{
    class Program
    {
        static void Main(string[] args)
        {
            Test1();
        }

        static void Fun()
        {
            string a = null;
            a.Equals("abc");
        }

        static void Test1()
        {
            Console.WriteLine("使用不同的Logger对象记录日志");
            var elogger = NLog.LogManager.GetLogger("ErrorToFileLogger");
            var ilogger = NLog.LogManager.GetLogger("InfoToFileLogger");
            elogger.Info("记录一条日志信息");
            try
            {
                Fun();
            }
            catch (Exception ex)
            {
                elogger.Error(ex, "捕获异常");
            }
            Console.ReadKey();
        }
        static void Test2()
        {
            Console.WriteLine("使用Filter记录不同日志");
            var logger = NLog.LogManager.GetCurrentClassLogger();
            logger.Info("记录一条日志信息");
            try
            {
                Fun();
            }
            catch (Exception ex)
            {
                logger.Error(ex, "捕获异常");
            }
            Console.ReadKey();
        }
    }
}
