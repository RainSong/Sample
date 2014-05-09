using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebSample
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        [WebMethod]
        public static void SaveFile() 
        {
            //if (this.file1.HasFile)
            //{
            //    var fileName = this.file1.FileName;
            //    var path = Server.MapPath("~/UserUplad/");
            //    file1.SaveAs(path + fileName);
            //    return fileName;
            //}
            //return "there no file to save";
        }
    }
}