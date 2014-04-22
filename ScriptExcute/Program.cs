using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MSScriptControl;

namespace ScriptExcute
{
    class Program
    {
        static void Main(string[] args)
        {
            string script = 
                @"function getOnlineRate(carNum,onlineNum){
                         if(carNum==0)return 0;
                         if(onlineNum>=carNum)return 1;
                         return (onlineNum*1.0)/carNum;
                       }";
            

        }
    }
}
