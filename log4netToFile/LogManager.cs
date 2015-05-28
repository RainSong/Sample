using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.IO;
using System.Text;
using System.Web;

namespace log4netToFile
{
    /// <summary>
    /// LogManager 的摘要说明
    /// </summary>
    public class LogManager
    {
        private static log4net.ILog logger;
        private static object _lock = new object();
        private LogManager()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }
        public static log4net.ILog GetLogger()
        {
            if (logger == null)
            {
                lock (_lock)
                {
                    if (logger == null)
                    {
                        string path = "D:\\workspace\\git\\Sample\\log4netToFile\\bin\\Debug\\log4netConfig.xml";
                        FileInfo fi = new FileInfo(path);
                        log4net.Config.XmlConfigurator.Configure(fi);
                        logger = log4net.LogManager.GetLogger("logger");
                    }
                }
            }
            return logger;
        }


        public static void LogError(Exception ex)
        {
            log4net.ILog logger = LogManager.GetLogger();
            logger.Error(ex);
        }

        public static void LogInfo(object msg)
        {
            log4net.ILog logger = LogManager.GetLogger();
            logger.Info(msg);
        }

        public static void LogError(string messsage, Exception ex)
        {
            log4net.ILog logger = LogManager.GetLogger();
            logger.Error(new Exception(messsage, ex));
        }
    }
}
