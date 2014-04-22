using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ImportData
{
    public partial class _Default : System.Web.UI.Page
    {
        public string FileName = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["Test_Upload"] == null || Session["Test_Upload"] == string.Empty)
            {
                FileName = Guid.NewGuid() + ".xls";
                Session["Test_Upload"] = FileName;
            }
            DataTable dt = GetTableFormFile(Server.MapPath("/UploadFiles/TestImport.xls"), ".xls");

        }

        protected void btnDownload_Click(object sender, EventArgs e)
        {
            Response.ContentType = "application/x-zip-compressed";
            Response.AddHeader("Content-Disposition", "attachment;filename=Templet.xls");
            string filename = Server.MapPath("App_Data/Templet.xls");
            Response.TransmitFile(filename);
        }

        private DataTable GetTableFormFile(string fileName, string fileType)
        {
            DataTable dt = new DataTable();
            string connStr;
            if (fileType == ".xls")
                connStr = "Provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source=" + fileName + ";" + ";Extended Properties=\"Excel 8.0;HDR=YES;IMEX=1\"";
            else
                connStr = "Provider=Microsoft.ACE.OLEDB.12.0;" + "Data Source=" + fileName + ";" + ";Extended Properties=\"Excel 12.0;HDR=YES;IMEX=1\"";

            using (OleDbConnection conn = new OleDbConnection(connStr))
            {
                conn.Open();
                DataTable schemaTable = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });
                string sheetName = schemaTable.Rows[0]["tABLE_NAME"].ToString();
                OleDbDataAdapter adapter = new OleDbDataAdapter(string.Format("SELECT * FROM [{0}]", sheetName), conn);
                adapter.Fill(dt);
            }
            return dt;
        }
    }
}