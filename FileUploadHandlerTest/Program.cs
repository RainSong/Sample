using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Security.Cryptography;
using System.IO;

namespace FileUploadHandlerTest
{
    class Program
    {
        static void Main(string[] args)
        {
            string user_name = "18039388153";
            string pwd = "yinguojie1989";
            string date = DateTime.Now.ToString("yyyyMMddHHmmssffffff");
            //加密密码
            string key = GetKey(user_name, pwd, date);
            //读取文件
            byte[] bytes = GetFileData();
            //获取请求结果
            string responseText = Request(user_name, key, date, bytes);

            Console.WriteLine(key);
            if (string.IsNullOrEmpty(responseText))
            {
                responseText = "请求返回为空";
            }
            Console.WriteLine(responseText);
            Console.ReadKey();
        }
        /// <summary>
        /// 请求文件上传接口
        /// </summary>
        /// <param name="user_name">用户名</param>
        /// <param name="key">加密后的密码</param>
        /// <param name="date">时间</param>
        /// <param name="fileBytes">文件字节</param>
        /// <returns></returns>
        static string Request(string user_name, string key, string date, byte[] fileBytes)
        {
            #region 生成请求
            var url = "http://mate.xn--g6r18kq05d.com/handlers/uploadhandler.ashx";
            //var url = "http://localhost:8086/handlers/uploadhandler.ashx";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.ContentType = "application/x-www-form-urlencoded";
            request.Method = "POST";

            string strImgBase64 = Convert.ToBase64String(fileBytes, Base64FormattingOptions.None);
            
            StringBuilder sbPara = new StringBuilder();
            sbPara.AppendFormat("user_name={0}", user_name);
            sbPara.AppendFormat("&key={0}", key);
            sbPara.AppendFormat("&date={0}", date);
            sbPara.AppendFormat("&usefor=avatar");
            sbPara.AppendFormat("&img_base64={0}", strImgBase64);

            byte[] bytesPara = System.Text.Encoding.UTF8.GetBytes(sbPara.ToString());

            using (Stream stream = request.GetRequestStream())
            {
                stream.Write(bytesPara, 0, bytesPara.Length);
            }
            #endregion
            #region 读取响应
            try
            {
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                byte[] responseBytes;
                using (Stream stream = response.GetResponseStream())
                {
                    responseBytes = new byte[response.ContentLength];
                    stream.Read(responseBytes, 0, responseBytes.Length);
                }
                return System.Text.Encoding.UTF8.GetString(responseBytes);
            }
            catch (Exception ex)
            {
                return string.Format("发生错误，{0}", ex.Message);
            }
            #endregion
        }
        /// <summary>
        /// 加密密码
        /// </summary>
        /// <param name="user_name">用户名</param>
        /// <param name="pwd">密码</param>
        /// <param name="date">时间</param>
        /// <returns></returns>
        static string GetKey(string user_name, string pwd, string date)
        {
            for (var i = 0; i < 5; i++)
            {
                pwd = MD5E(pwd);
            }

            pwd = MD5E(pwd + user_name);
            return MD5E(pwd + date);
        }
        /// <summary>
        /// MD5字符串
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        static string MD5E(String str)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] data = System.Text.Encoding.Default.GetBytes(str);
            byte[] result = md5.ComputeHash(data);
            String ret = "";
            for (int i = 0; i < result.Length; i++)
            {
                ret += result[i].ToString("x").PadLeft(2, '0');
            }
            return ret;
        }
        /// <summary>
        /// 读取文件为字节数组
        /// </summary>
        /// <returns></returns>
        static byte[] GetFileData()
        {
            string path = @"D:\imgs\00b9c60b701cd09447ccb4fe56a6c787\f7f7d7d7a74e4b4b93159cef0e7e39e9.jpg";
            byte[] bytes;
            using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                bytes = new byte[fs.Length];
                fs.Read(bytes, 0, bytes.Length);
            }
            return bytes;
        }

        static void SaveFile(string txt)
        {
            byte[] bytes = System.Text.Encoding.UTF8.GetBytes(txt);
            using (FileStream fs = new FileStream(@"D:\1.txt", FileMode.Create, FileAccess.Write, FileShare.ReadWrite))
            {
                fs.Write(bytes, 0, bytes.Length);
            }
        }

    }
}
