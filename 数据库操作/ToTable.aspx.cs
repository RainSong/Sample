using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace 数据库操作
{
    public partial class ToTable : System.Web.UI.Page
    {
        ExeHelper exeHelper = new ExeHelper();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        private void Msg(string msg) 
        {
            Response.Write("<script>alert('" + msg + "')</script>");
        }
        protected void btnCreateDB_Click(object sender, EventArgs e)
        {
            try
            {
                exeHelper.createDB();
                Msg("数据库创建成功");
            }
            catch (Exception ex) 
            {
                Msg(ex.Message);
            }
        }

        protected void btnCreateTable_Click(object sender, EventArgs e)
        {
            
            try
            {
                exeHelper.createrTable();
                Msg("表创建成功");
            }
            catch (Exception ex)
            {
                Msg(ex.Message);
            }
        }

        protected void btnAlterTable_Click(object sender, EventArgs e)
        {
            try
            {
                exeHelper.alterTable();
                Msg("表修改成功");
            }
            catch (Exception ex)
            {
                Msg(ex.Message);
            }
        }
    }
}