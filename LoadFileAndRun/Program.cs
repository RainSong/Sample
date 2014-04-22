
using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using Ionic.Zip;

namespace LoadFileAndRun
{
    class Program
    {

        static void Main(string[] args)
        {
            ConfigInfo configInfo = ConfigReader.GetConfigInfo();
            Download.CheckUpdate(configInfo);
            LoadRun.RunFiles(configInfo);
            Console.ReadLine();
        }
    }
}
