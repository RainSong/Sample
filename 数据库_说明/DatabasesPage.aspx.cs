using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CodeGenerator
{
    public partial class DatabasesPage : System.Web.UI.Page
    {
        DBComparison dc;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["TarServerName"] != null &&
                Session["TarUName"] != null &&
                Session["TarUpwd"] != null &&
                !string.IsNullOrEmpty(Session["TarServerName"].ToString()) &&
                !string.IsNullOrEmpty(Session["TarUName"].ToString()) &&
                !string.IsNullOrEmpty(Session["SourUpwd"].ToString()) &&
                Session["SourServerName"] != null &&
                Session["SourUName"] != null &&
                Session["SourUpwd"] != null &&
                !string.IsNullOrEmpty(Session["SourServerName"].ToString()) &&
                !string.IsNullOrEmpty(Session["SourUName"].ToString()) &&
                !string.IsNullOrEmpty(Session["SourUpwd"].ToString())) 
            {
                dc = new DBComparison(Session["TarServerName"].ToString(),
                    Session["TarUName"].ToString(),
                    Session["TarUpwd"].ToString(),
                    Session["SourServerName"].ToString(),
                    Session["SourUName"].ToString(),
                    Session["SourUpwd"].ToString());
            }
            sourDBS.Items.Clear();
            
            tarDBS.Items.Clear();
            foreach (string str in dc.getTargetDBS()) 
            {
                tarDBS.Items.Add(str);
            }
            foreach (string str in dc.getSourceDBS()) 
            {
                sourDBS.Items.Add(str);
            }
        }

        protected void btnComparison_Click(object sender, EventArgs e)
        {
            //string tarDb = this.tarDBS.SelectedItem.Text;
            //string sourDb = this.sourDBS.SelectedItem.Text;
            //Response.Redirect("Comparison.aspx?tarDb=" + tarDb + "&sourDb=" + sourDb);
        }
    }
}