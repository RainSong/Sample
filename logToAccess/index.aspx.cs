using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using log4net;
using log4net.Config;
using System.Configuration;
using System.Web.Configuration;
using System.Data;
using System.Data.OleDb;

namespace logToAccess
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
      

        protected void add_Click(object sender, EventArgs e)
        {
            log4net.ILog log = log4net.LogManager.GetLogger("testLogger");
            log.Error("a new log");
            GetCount();
        }

        protected void testConnection_Click(object sender, EventArgs e)
        {

            string connString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=F:\\kuaipan\\C#Test\\log4netTest\\logToAccess\\App_Data\\Testlog.accdb";
            try
            {
                OleDbConnection oleCon = new OleDbConnection(connString);
                if (oleCon.State == ConnectionState.Open)
                {
                    oleCon.Close();
                }
                oleCon.Open();
                this.Label1.Text = "连接已打开";
                oleCon.Close();
            }
            catch (OleDbException ex) 
            {
                this.Label1.Text = "发生错误：" + ex.Message;

            }
        }

        protected void AddTest_Click(object sender, EventArgs e)
        {
            string connString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=F:\\kuaipan\\C#Test\\log4netTest\\logToAccess\\App_Data\\Testlog.accdb";
            try
            {
                OleDbConnection oleCon = new OleDbConnection(connString);
                if (oleCon.State == ConnectionState.Open)
                {
                    oleCon.Close();
                }
                oleCon.Open();
                string strInsertSql = "INSERT INTO Log ([Date],[Thread],[Level],[Logger],[Message],[Exception]) VALUES ('2011-11-11','@thread', '@log_level', '@logger', '@message','@exception');";
                OleDbCommand oleCom = new OleDbCommand(strInsertSql, oleCon);
                if (oleCom.ExecuteNonQuery() > 0) 
                {
                    this.Label2.Text = "成功添加一条数据";
                }
                GetCount();
            }
            catch (OleDbException ex)
            {
                this.Label2.Text = "发生错误：" + ex.Message;

            }
        }
       
        private void GetCount() 
        {
            string connString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=F:\kuaipan\C#Test\log4netTest\logToAccess\App_Data\Testlog.accdb";
            try
            {
                OleDbConnection oleCon = new OleDbConnection(connString);
                if (oleCon.State == ConnectionState.Open)
                {
                    oleCon.Close();
                }
                oleCon.Open();
                string strInsertSql = "select count(*) from Log";
                OleDbCommand oleCom = new OleDbCommand(strInsertSql, oleCon);
                string count = oleCom.ExecuteScalar().ToString();
                this.Label3.Text = "共有" + count + "调数据";
            }
            catch (OleDbException ex)
            {
                this.Label2.Text = "发生错误：" + ex.Message;

            }
        }
    }
}