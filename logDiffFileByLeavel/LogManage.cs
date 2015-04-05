using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using log4net;
using System.IO;

namespace logDiffFileByLeavel
{
    public class LogManage
    {
        public static ILog logger;
        private static object _lock = new object();

        private LogManage()
        {
            
        }

        public static ILog GetLogger()
       {
               if(logger==null)
               {
                      lock(_lock)
                      {
                             if(logger==null)
                             {
                                 var fi = new FileInfo(@"D:\workspace\Sample\logDiffFileByLeavel\App.config");
                                 log4net.Config.XmlConfigurator.Configure(fi);
                                 logger = log4net.LogManager.GetLogger("logger");
                             }
                      }
               }
               return logger;
       }
    }
}
