using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SessionInSqlserver
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            var strKey = this.txtKey.Text.Trim();
            if (string.IsNullOrEmpty(strKey))
            {
                ShowMessageInClient("SessionKey不能为空！");
                return;
            }
            var strValue = this.txtValue.Text.Trim();
            if (string.IsNullOrEmpty(strValue))
            {
                ShowMessageInClient("SessionValue不能空！");
                return;
            }
            Session[strKey] = strValue;
        }

        protected void btnGet_Click(object sender, EventArgs e)
        {
            var strKey = this.txtKey.Text.Trim();
            if (string.IsNullOrEmpty(strKey))
            {
                ShowMessageInClient("SessionKey不能为空！");
                return;
            }
            var value = (Session[strKey] ?? string.Empty).ToString();
            if (string.IsNullOrEmpty(value))
            {
                ShowMessageInClient("Session中" + strKey + "为空！");
            }
            else
            {
                ShowMessageInClient(value);
            }
        }

        private void ShowMessageInClient(string msg)
        {
            var script = "<script type=\"text/javascript\">alert('" + msg + "');</script>";
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), Guid.NewGuid().ToString(), script, false);
        }

    }
}