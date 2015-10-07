using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImgExif
{
    public static class DBHelper
    {
        public static SqlConnection GetCon(string connectionString)
        {
            try
            {
                return new SqlConnection(connectionString);
            }
            catch (Exception ex)
            {
                throw new Exception("获取数据库连接失败", ex);
            }
        }

        public static SqlConnection GetOpenCon(string connectionString)
        {
            try
            {
                var con = GetCon(connectionString);
                if (con.State != ConnectionState.Open)
                {
                    con.Open();
                }
                return con;
            }
            catch (Exception ex)
            {
                throw new Exception("获取打开的连接失败", ex);
            }
        }

        public static DataTable GetTable(string connectionString, string sqlCommentText, params SqlParameter[] paras)
        {
            try
            {
                DataTable table = null;
                using (var con = GetCon(connectionString))
                {
                    var sqlCmd = new SqlCommand(sqlCommentText, con);
                    if (paras != null && paras.Length > 0)
                    {
                        sqlCmd.Parameters.AddRange(paras);
                    }
                    var dataAdapter = new SqlDataAdapter(sqlCmd);
                    table = new DataTable();
                    dataAdapter.Fill(table);
                }
                return table;
            }
            catch (Exception ex)
            {
                throw new Exception("读取数据失败", ex);
            }
        }

        public static int Execute(string connectionString, string sqlCommentText, params SqlParameter[] paras)
        {
            try
            {
                using (var con = GetOpenCon(connectionString))
                {
                    var cmd = new SqlCommand(sqlCommentText, con);
                    if (paras != null && paras.Length > 0)
                    {
                        cmd.Parameters.AddRange(paras);
                    }
                    return cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("执行语句失败", ex);
            }
        }

        public static object ExecuteScalar(string connectionString, string sqlCommentText, params SqlParameter[] paras) 
        {
            try
            {
                using (var con = GetOpenCon(connectionString))
                {
                    var cmd = new SqlCommand(sqlCommentText, con);
                    if (paras != null && paras.Length > 0)
                    {
                        cmd.Parameters.AddRange(paras);
                    }
                    return cmd.ExecuteScalar();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("查询失败", ex);
            }
        }
    }
}
