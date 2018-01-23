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
        }

        static void Fun()
        {
            string a = null;
            a.Equals("abc");
        }
    }
}
