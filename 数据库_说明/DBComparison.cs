using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Data;
using System.Text;
using Microsoft.SqlServer.Management.Smo;
using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Sdk.Sfc;

namespace CodeGenerator
{
    public class DBComparison
    {
        
        private Server tarSer;
        private Server sourSer;
        public DBComparison(string _tarSerName, string _tarUid, string _tarPwd,
            string _sourSerName, string _sourUid, string _sourPwd) 
        {
            tarSer = new Server();
            ServerConnection scTar = tarSer.ConnectionContext;
            scTar.LoginSecure = false;
            scTar.ServerInstance = _tarSerName;
            scTar.Login = _tarUid;
            scTar.Password = _tarPwd;
            sourSer = new Server();
            ServerConnection scSour = sourSer.ConnectionContext;
            scSour.LoginSecure = false;
            scSour.ServerInstance = _sourSerName;
            scSour.Login = _sourUid;
            scSour.Password = _sourPwd;
        }

        public List<string> getTargetDBS() 
        {
            List<string> list = new List<string>();
            foreach (Database db in tarSer.Databases) 
            {
                if (db.IsAccessible && !db.IsSystemObject) 
                {
                    list.Add(db.Name);
                }
            }
            return list;
        }

        public List<string> getSourceDBS() 
        {
            List<string> list = new List<string>();
            foreach (Database db in sourSer.Databases) 
            {
                if (db.IsAccessible && !db.IsSystemObject) 
                {
                    list.Add(db.Name);
                }
            }
            return list;
        }
    }
}