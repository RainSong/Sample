using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.SqlServer.Management.Smo;
using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Sdk.Sfc;

namespace CodeGenerator
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnConnect_Click(object sender, EventArgs e)
        {
            try
            {

                ServerConnection con = new ServerConnection(this.txtSerName.Text,
                    this.txtUName.Text,
                    this.txtUpwd.Text);
                Session.Add("ServerName", this.txtSerName.Text);
                Session.Add("UName", this.txtUName.Text);
                Session.Add("Upwd", this.txtUpwd.Text);
                Response.Redirect("default.aspx");
            }
            catch (Exception ex) 
            {
                Response.Write("<script>alert('" + ex.Message + "')</script>");
            }
        }

        protected void btnComparison_Click(object sender, EventArgs e)
        {
            try
            {
                ServerConnection conTar = new ServerConnection(this.txtTarServer.Text,
                    this.txtTarUid.Text,
                    this.txtTarPwd.Text);
                conTar.Connect();
                Session.Add("TarServerName", this.txtTarServer.Text);
                Session.Add("TarUName", this.txtTarUid.Text);
                Session.Add("TarUpwd", this.txtTarPwd.Text);
                ServerConnection conSour = new ServerConnection(this.txgSourName.Text,
                    this.txtSourUid.Text,
                    this.txtSourPwd.Text);
                conSour.Connect();
                Session.Add("SourServerName", this.txgSourName.Text);
                Session.Add("SourUName", this.txtSourUid.Text);
                Session.Add("SourUpwd", this.txtSourPwd.Text);
                Response.Redirect("DatabasesPage.aspx");
            }
            catch (Exception ex) 
            {
                Response.Write("<script>alert('" + ex.Message + "')</script>");
            }
        }
    }
}