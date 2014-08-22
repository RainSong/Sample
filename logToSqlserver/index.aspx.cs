using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using log4net;

namespace logToSqlserver
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            log4net.ILog log = log4net.LogManager.GetLogger("testLogger");
            for (int i = 0; i < 130; i++)
            {
                log.Info("我写日志了");
            }
            
            Response.Write("<script>alert('添加成功')</script>");
        }
    }
}