using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebFormSample
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        public string FileName;
        public string Msg;
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void Unnamed1_Click(object sender, EventArgs e)
        {
            this.FileName = this.file1.FileName;
            this.Msg = this.txt1.Text;
            Response.Write("<script>alert('abc');showMsg();alert('acba')</script>");
        }
    }
}