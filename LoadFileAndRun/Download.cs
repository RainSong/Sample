using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Ionic.Zip;

namespace LoadFileAndRun
{
    public static class Download
    {

        private static List<string> CheckFile(ConfigInfo config)
        {
            List<string> newFileNames = new List<string>();
            foreach (var assInfo in config.AssemblyInfos)
            {
                string fileName = assInfo.FileName;
                FileInfo rFileinfo = new FileInfo(config.BaseUrl + fileName);
                FileInfo lFileInfo = new FileInfo(fileName);
                if (!rFileinfo.Exists)
                {
                    try
                    {
                        File.Delete(assInfo.FileName);
                        File.Delete(assInfo.FileName.ToUpper().Replace("ZIP", "DLL"));
                        File.Delete(assInfo.FileName.Replace("ZIP", "EXE"));
                    }
                    catch (Exception ex)
                    {


                    }
                }
                if (!lFileInfo.Exists || lFileInfo.LastWriteTime < rFileinfo.LastWriteTime)
                {
                    try
                    {
                        newFileNames.Add(assInfo.FileName);
                        rFileinfo.CopyTo(assInfo.FileName, true);
                    }
                    catch (Exception ex)
                    {
                    }
                }
            }
            return newFileNames;
        }

        /// <summary>
        /// 及压缩文件
        /// </summary>
        /// <param name="sourceFilePath"></param>
        /// <param name="targetDirectory"></param>
        private static void Unpackage(string sourceFilePath, string targetDirectory)
        {
            using (ZipFile zip = ZipFile.Read(sourceFilePath))
            {
                foreach (ZipEntry entry in zip)
                {
                    entry.Extract(targetDirectory, ExtractExistingFileAction.OverwriteSilently);
                }
            }
        }
        /// <summary>
        /// 检查更新新文件
        /// </summary>
        /// <param name="configInfo"></param>
        public static void CheckUpdate(ConfigInfo configInfo)
        {
            string targetDirectory = Directory.GetCurrentDirectory();
            List<string> newFileNames = CheckFile(configInfo);
            newFileNames.ForEach(fileName =>
            {
                try
                {
                    Unpackage(fileName, targetDirectory);
                    Console.WriteLine(string.Format("更新文件：{0}",fileName));
                }
                catch (Exception ex)
                {
                }
            });
        }



    }
}
