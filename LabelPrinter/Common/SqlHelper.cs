using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

using Dapper;
using static Dapper.SqlMapper;

namespace LabelPrinter.Common
{
    public class SqlHelper
    {
        public string GetConnectionString()
        {
            var config = ConfigurationManager.ConnectionStrings["HYMES_TEST"];
            if (config == null)
                throw new Exception("no connection string named “HYMES_TEST”");
            return config.ConnectionString;
        }

        public SqlConnection GetConnection()
        {
            var connectionString = GetConnectionString();
            return new SqlConnection(connectionString);
        }

        public SqlConnection GetOpenConnection()
        {
            var con = GetConnection();
            if (con.State != ConnectionState.Open)
            {
                try
                {
                    con.Open();
                }
                catch (Exception ex)
                {
                    throw new Exception("open connection faield", ex);
                }
            }
            return con;

        }

        public int Execute(string sqlCmdText, object param = null, CommandType commandType = CommandType.Text) 
        {
            using (var con = GetOpenConnection()) 
            {
                return con.Execute(sqlCmdText, param, commandType: commandType);
            }
        }

        public IEnumerable<T> Query<T>(string sqlCmdText, object param = null, CommandType commandType = CommandType.Text)
        {
            using (var con = GetOpenConnection())
            {
                return con.Query<T>(sqlCmdText, param, commandType: commandType);
            }
        }

        public void Query<T1, T2>(out IEnumerable<T1> t1s, out IEnumerable<T2> t2s, string sqlCmdText, object param, CommandType commandType = CommandType.Text)
        {
            using (var con = GetOpenConnection())
            {
                var query = con.QueryMultiple(sqlCmdText, param, commandType: commandType);
                t1s = query.Read<T1>();
                t2s = query.Read<T2>();
            }
        }
        public void Query<T1, T2,T3>(out IEnumerable<T1> t1s, out IEnumerable<T2> t2s,out IEnumerable<T3> t3s,
            string sqlCmdText, object param, CommandType commandType = CommandType.Text)
        {
            using (var con = GetOpenConnection())
            {
                var query = con.QueryMultiple(sqlCmdText, param, commandType: commandType);
                t1s = query.Read<T1>();
                t2s = query.Read<T2>();
                t3s = query.Read<T3>();
            }
        }
    }
}
