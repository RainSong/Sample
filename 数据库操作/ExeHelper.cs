using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.SqlServer.Management.Smo;
using Microsoft.SqlServer.Management.Sdk.Sfc;
using Microsoft.SqlServer.Management.Common;
using System.Data;
using System.Data.Sql;

namespace 数据库操作
{
    public class ExeHelper
    {
        private const string strSerName = @"XJL\SQLEXPRESS";
        private const string strUName = "sa";
        private const string strPwd = "sa";
        private const string dbName = "SMOTESTDB";
        private const string tName = "SMOTESTABLE";

        Server ser;
        public ExeHelper() 
        {
            ser = new Server();
            ser.ConnectionContext.ServerInstance = strSerName;
            ServerConnection con = ser.ConnectionContext;
            con.LoginSecure = false;
            con.Login = strUName;
            con.Password = strPwd;
            con.Connect();
        }
        public void createDB() 
        {
            Database db = new Database(ser, dbName);
            db.Create();
        }
        public void createrTable() 
        {
            Table table=new Table(ser.Databases[dbName],tName);
            Column colID=new Column(table,"UID",new DataType(SqlDataType.Int));
            
            Column colName = new Column(table, "UNAME", new DataType(SqlDataType.VarChar, 50));
            Column colSex = new Column(table, "USEX", new DataType(SqlDataType.Bit));
            Column colBrithday = new Column(table, "UBRITHDAY", new DataType(SqlDataType.DateTime));
            Column colAddress = new Column(table, "UADDRESS", new DataType(SqlDataType.VarChar, 200));
            table.Columns.Add(colID);
            table.Columns.Add(colName);
            table.Columns.Add(colSex);
            table.Columns.Add(colBrithday);
            table.Columns.Add(colAddress);
            table.Create();
        }
        public void alterTable() 
        {
            Table table = ser.Databases[dbName].Tables[tName];
            table.Columns["UID"].Nullable = false;
            table.Alter();
        }
    }
}