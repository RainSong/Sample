using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace logDiffFileByLeavel
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var log = LogManage.GetLogger();
                log.Info("开始记录日志");
                var ex = new Exception("这是一个测试用的异常");
                log.Error("这是一个测试异常", ex);
                log.Info("记录完成");
                Console.ReadKey();
            }
            catch(Exception ex) 
            {
                var msg = ex.Message;
            }
        }
    }
}
