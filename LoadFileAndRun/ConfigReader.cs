using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LoadFileAndRun
{
    public static class ConfigReader
    {
        public static ConfigInfo GetConfigInfo()
        {
            ConfigInfo configInfo = new ConfigInfo
            {
                BaseUrl = @"E:\WorkSpace\Sample\Packges\",
                AssemblyInfos = new List<AssemblyInfo>
                {
                    new AssemblyInfo
                    {
                        FileName = "multiplication table.zip",
                        IsEntry = true
                    },
                    new AssemblyInfo
                    {
                        FileName = "MyCore.zip"
                    }
                }
            };
            return configInfo;
        }

    }

    public class AssemblyInfo
    {
        public AssemblyInfo()
        {
            IsEntry = false;
        }

        public string FileName { get; set; }
        public bool IsEntry { get; set; }
    }

    public class ConfigInfo
    {
        public string BaseUrl { get; set; }
        public List<AssemblyInfo> AssemblyInfos { get; set; }
    }
}
