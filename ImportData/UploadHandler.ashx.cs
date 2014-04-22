using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace ImportData
{
    /// <summary>
    /// UploadHandler 的摘要说明
    /// </summary>
    public class UploadHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            context.Response.Charset = "utf-8";

            HttpPostedFile file = context.Request.Files["FileData"];
            //TODO 存在文件被别人覆盖风险
            string upLoadPath = HttpContext.Current.Server.MapPath(context.Request["folder"] ?? "/UploadFiles") + "\\";

            if (file != null)
            {
                if (!Directory.Exists(upLoadPath))
                {
                    Directory.CreateDirectory(upLoadPath);
                }
                file.SaveAs(upLoadPath + file.FileName);
                context.Response.Write("1");
            }
            else
            {
                context.Response.Write("0");
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}