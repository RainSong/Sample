using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using log4net;

namespace JQueryEasyUI.Common
{
    public static class LogManager
    {
        public static readonly ILog Logger;
        static LogManager()
        {
            Logger = log4net.LogManager.GetLogger("EUTLogger");
        }

        public static void LogInfo(object message)
        {
            if (Logger.IsInfoEnabled)
            {
                Logger.Info(message);
            }
        }

        public static void LogError(object message, Exception ex = null)
        {
            if (Logger.IsErrorEnabled)
            {
                if (ex == null)
                {
                    Logger.Error(message);
                }
                else
                {
                    Logger.Error(message, ex);
                }
            }
        }
    }
}