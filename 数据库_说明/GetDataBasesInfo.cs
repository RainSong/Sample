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
    public class GetDataBasesInfo
    {
       /// <summary>
       /// 服务器名称
       /// </summary>
        public string Name;
        /// <summary>
        /// 用户名
        /// </summary>
        private string uid;
        /// <summary>
        /// 密码
        /// </summary>
        private string pwd;
        /// <summary>
        /// 服务器实例
        /// </summary>
        private Server ser;
        private Dictionary<string, Type> para;
        public GetDataBasesInfo(string _name,string _uid,string _pwd) 
        {
            this.Name = _name;
            this.uid = _uid;
            this.pwd = _pwd;
            connect();
        }
        /// <summary>
        /// 打开连接的方法
        /// </summary>
        private void connect()
        {
            ser = new Server();
            ser.ConnectionContext.ServerInstance = this.Name;
            ServerConnection sc = ser.ConnectionContext;
            sc.LoginSecure = false;
            sc.Login = uid;
            sc.Password = pwd;
        }
        /// <summary>
        /// 获取服务器下的数据库列表
        /// </summary>
        /// <param name="uid"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        public List<string> getDataBase(string uid,string pwd) 
        {
            List<string> list = new List<string>();
            foreach (Database db in ser.Databases)
            {
                if (db.IsAccessible && !db.IsSystemObject)
                {
                    list.Add(db.Name);
                }
            }
            return list;
        }
        /// <summary>
        /// 获得数据库下的所有用户表
        /// </summary>
        /// <param name="dbName"></param>
        /// <returns></returns>
        public List<string> getTables(string dbName)
        {

            List<string> list = new List<string>();
            Database db = ser.Databases[dbName];
            if (db.IsAccessible)
            {
                foreach (Table table in ser.Databases[dbName].Tables)
                {
                    if (!table.IsSystemObject)
                    {
                        list.Add(table.Name);
                    }
                }
            }

            return list;
        }
        /// <summary>
        /// 获得数据库下的所有用户视图
        /// </summary>
        /// <param name="dbName"></param>
        /// <returns></returns>
        public List<string> getViews(string dbName)
        {
            List<string> list = new List<string>();
            Database db = ser.Databases[dbName];
            if (db.IsAccessible)
            {
                foreach (View v in ser.Databases[dbName].Views)
                {
                    if (!v.IsSystemObject)
                    {
                        list.Add(v.Name);
                    }
                }
            }

            return list;
        }
        /// <summary>
        /// 获取数据库中的存储过程
        /// </summary>
        /// <param name="dbName"></param>
        /// <returns></returns>
        public List<string> getProcedures(string dbName) 
        {
            List<string> list = new List<string>();
            StoredProcedureCollection Procedures = ser.Databases[dbName].StoredProcedures;
            foreach (StoredProcedure p in Procedures) 
            {
                if (!p.IsSystemObject)
                {
                    list.Add(p.Name);
                }
            }
            return list;
        }

        public List<string> getFunctions(string dbName) 
        {
            List<string> list = new List<string>();
            foreach (UserDefinedFunction fun in ser.Databases[dbName].UserDefinedFunctions) 
            {
                if (!fun.IsSystemObject)
                {
                    list.Add(fun.Name);
                }
            }
            return list;
        }
        /// <summary>
        /// 获取表的列信息
        /// </summary>
        /// <param name="dbName"></param>
        /// <param name="tName"></param>
        /// <returns></returns>
        public DataTable getTableClomns(string dbName, string tName)
        {
            DataTable dt = new DataTable();
            
            BuildColumnsInfoTable(dt);
          
            Table table = ser.Databases[dbName].Tables[tName];
            if (!table.IsSystemObject)
            {
                foreach (Column col in table.Columns)
                {
                    DataRow dr = dt.NewRow();
                    dr["Name"] = col.Name;
                    dr["DataType"] = col.DataType.ToString();
                    dr["AllowNull"] = col.Nullable ? "是" : "否";
                    dr["MaxLength"] = col.DataType.MaximumLength;
                    dr["Des"] = col.ExtendedProperties.Count > 0 ? col.ExtendedProperties[0].Value : "--";
                    dt.Rows.Add(dr);
                }
            }
            return dt;
        }

        public DataTable getViewColmns(string dbName, string vName) 
        {
            DataTable dt = new DataTable();
            BuildColumnsInfoTable(dt);
            View view = ser.Databases[dbName].Views[vName];
            if (!view.IsSystemObject) 
            {
                foreach (Column col in view.Columns) 
                {
                    DataRow dr = dt.NewRow();
                    dr["Name"] = col.Name;
                    dr["DataType"] = col.DataType.ToString();
                    dr["AllowNull"] = col.Nullable ? "是" : "否";
                    dr["MaxLength"] = col.DataType.MaximumLength;
                    dr["Des"] = col.ExtendedProperties.Count > 0 ? col.ExtendedProperties[0].Value : "--";
                    dt.Rows.Add(dr);
                }
            }
            return dt;
        }
        /// <summary>
        /// 获取键相关信息
        /// </summary>
        /// <param name="dbName"></param>
        /// <param name="tName"></param>
        /// <returns></returns>
        public DataTable getTableKeys(string dbName, string tName) 
        {
            DataTable dt = new DataTable();
            BuildKeysInfoTable(dt);
            Table table=ser.Databases[dbName].Tables[tName];

            foreach (ForeignKey key in table.ForeignKeys)
            {
                DataRow dr = dt.NewRow();
                dr["name"] = key.Name;
                dr["execute"] = (key.DeleteAction != ForeignKeyAction.NoAction ? "Delete "+key.DeleteAction.ToString() : "")
                    + "\r\n"
                    + (key.UpdateAction != ForeignKeyAction.NoAction ? "Update "+key.UpdateAction.ToString() : "");
                string cols = string.Empty;

                foreach (ForeignKeyColumn col in key.Columns)
                {
                    cols += col.Name;
                }
                
                Table rtable = ser.Databases[dbName].Tables[key.ReferencedTable];
                string Referenced = rtable.Schema + "." + rtable.Name;
                Index pk = table.Indexes.Cast<Index>().SingleOrDefault(x => x.IndexKeyType == IndexKeyType.DriPrimaryKey);
                string colName = string.Empty;
                foreach (IndexedColumn col in pk.IndexedColumns) 
                {
                    if (colName.Length > 0) 
                    {
                        colName += "\r\n";
                    }
                    colName += Referenced+"."+col.Name;
                }
                dr["pertinentCol"] = cols + "-->" + colName;
                dt.Rows.Add(dr);
            }
            return dt;
        }

        /// <summary>
        /// 获取表的脚本
        /// </summary>
        /// <param name="dbName"></param>
        /// <param name="tName"></param>
        /// <returns></returns>
        public string getTableScript(string dbName, string tName) 
        {
            StringBuilder sb = new StringBuilder();
            Table table = ser.Databases[dbName].Tables[tName];
            Scripter script = getScripter();
            UrnCollection urns = new UrnCollection();
            urns.Add(table.Urn);
            StringCollection sqlScript = script.Script(urns);

            for (int i = 0; i < sqlScript.Count; i++)
            {
                sb.Append(sqlScript[i]);
                sb.Append("\r\nGO\r\n");
            }
            //sb.Append(sqlScript[3]);
            return sb.ToString(); 
        }
        /// <summary>
        /// 获取视图的脚本
        /// </summary>
        /// <param name="dbName"></param>
        /// <param name="vName"></param>
        /// <returns></returns>
        public string getViewScript(string dbName, string vName) 
        {
            StringBuilder sb = new StringBuilder();
            View view = ser.Databases[dbName].Views[vName];
            Scripter script = getScripter();
            UrnCollection urns = new UrnCollection();
            urns.Add(view.Urn);
            StringCollection sqlScript = script.Script(urns);

            for (int i = 0; i < sqlScript.Count; i++)
            {
                sb.Append(sqlScript[i]);
                sb.Append("\r\nGO\r\n");
            }
            return sb.ToString();
        }
        public Scripter getScripter() 
        {
            Scripter script = new Scripter(ser);

            //预发布的布尔属性值确定声明的引用完成性约束条件是否都包括在生成的脚本中。
            script.Options.Add(ScriptOption.DriAllConstraints);

            //预发布的布尔属性值确定被声明的全部引用完整性关键词定义的依赖关系是否都包括在生成的脚本中。
            script.Options.Add(ScriptOption.DriAllKeys);

            //预发布的布尔属性值确定被引用对象的创造物是否包括在生成的脚本中。
            script.Options.Add(ScriptOption.Default);

            //预发布的布尔属性值确定在一个错误出现后此脚本运行（执行）是否继续存在。
            script.Options.Add(ScriptOption.ContinueScriptingOnError);

            //预发布的布尔属性值确定在生成脚本时，用户自定义数据类型是否转换为最合适SQL服务器的基础数据类型。
            script.Options.Add(ScriptOption.ConvertUserDefinedDataTypesToBaseType);

            script.Options.Add(ScriptOption.ExtendedProperties);
            return script;
        }
        /// <summary>
        /// 构建承载表中列信息的数据表
        /// </summary>
        /// <param name="dt"></param>
        private void BuildColumnsInfoTable(DataTable dt) 
        {
            para = new Dictionary<string, Type>();
            para.Add("Name", typeof(string));
            para.Add("DataType", typeof(string));
            para.Add("AllowNull", typeof(string));
            para.Add("MaxLength", typeof(int));
            para.Add("Des", typeof(string));
            BuildTable(para,dt);
        }
        /// <summary>
        /// 构建承载外键键信息的数据表
        /// </summary>
        /// <param name="dt"></param>
        private void BuildKeysInfoTable(DataTable dt) 
        {
            para = new Dictionary<string, Type>();
            para.Add("name", typeof(string));//名称
            para.Add("execute", typeof(string));//操纵
            para.Add("pertinentCol", typeof(string));//相关列，外键名称
            BuildTable(para, dt);
        }
        /// <summary>
        /// 构建表结构
        /// </summary>
        /// <param name="list">列需要的参数，列名和列数据类型</param>
        /// <param name="dt">需要构建的DataTable</param>
        private void BuildTable(Dictionary<string,Type> list,DataTable dt) 
        {
            
            foreach (var item in list) 
            {
                DataColumn dc = new DataColumn(item.Key,list[item.Key]);
                dt.Columns.Add(dc);
            }
        }
        /// <summary>
        /// 获取表的属性
        /// </summary>
        /// <param name="dbName"></param>
        /// <param name="tName"></param>
        /// <returns></returns>
        public DataTable GetTableProperties(string dbName, string tName) 
        {
            DataTable dt = new DataTable();
            BuildPropertiesTable(dt);
            Database db = ser.Databases[dbName];
            Table table = db.Tables[tName];
            DataRow drCollation = dt.NewRow();
            drCollation["Property"] = "排序规则";
            drCollation["Value"] = db.Collation;
            DataRow drRowCount = dt.NewRow();
            drRowCount["Property"] = "行数";
            drRowCount["Value"] = table.RowCount.ToString();
            DataRow drCreateDate = dt.NewRow();
            drCreateDate["Property"] = "创建时间";
            drCreateDate["Value"] = table.CreateDate.ToString(); 
            DataRow drLastModifiedDate = dt.NewRow();
            drLastModifiedDate["Property"] = "最后修改时间";
            drLastModifiedDate["Value"] = table.DateLastModified.ToString();
            dt.Rows.Add(drCollation);
            dt.Rows.Add(drRowCount);
            dt.Rows.Add(drCreateDate);
            dt.Rows.Add(drLastModifiedDate);
            return dt;
        }
        /// <summary>
        /// 获取视图的属性
        /// </summary>
        /// <param name="dbName"></param>
        /// <param name="vName"></param>
        /// <returns></returns>
        public DataTable GetViewProperties(string dbName, string vName) 
        {
            DataTable dt = new DataTable();
            BuildPropertiesTable(dt);
            Database db = ser.Databases[dbName];
            View view = db.Views[vName];
            DataRow drCollation = dt.NewRow();
            drCollation["Property"] = "排序规则";
            drCollation["Value"] = db.Collation;
            DataRow drRowCount = dt.NewRow();
            drRowCount["Property"] = "行数";
            drRowCount["Value"] = "--";
            DataRow drCreateDate = dt.NewRow();
            drCreateDate["Property"] = "创建时间";
            drCreateDate["Value"] = view.CreateDate.ToString();
            DataRow drLastModifiedDate = dt.NewRow();
            drLastModifiedDate["Property"] = "最后修改时间";
            drLastModifiedDate["Value"] = view.DateLastModified.ToString();
            dt.Rows.Add(drCollation);
            dt.Rows.Add(drRowCount);
            dt.Rows.Add(drCreateDate);
            dt.Rows.Add(drLastModifiedDate);
            return dt;
        }
        
        /// <summary>
        /// 获取表相关索引
        /// </summary>
        /// <param name="dbName"></param>
        /// <param name="tName"></param>
        /// <returns></returns>
        public DataTable getTableIndex(string dbName, string tName) 
        {
            DataTable dt = new DataTable();
            BuildIndexTable(dt);
            IndexCollection indexs = ser.Databases[dbName].Tables[tName].Indexes;
            foreach (Index index in indexs) 
            {
                DataRow dr = dt.NewRow();
                dr["Name"] = index.Name;
                string strColumns = string.Empty;
                foreach (IndexedColumn col in index.IndexedColumns) 
                {
                    if (strColumns.Length > 0) 
                    {
                        strColumns += ",";
                    }
                    strColumns += col.Name;
                }
                dr["Columns"] = strColumns;
                dr["Unique"] = index.IsUnique ? "是" : "否";
                dt.Rows.Add(dr);
            }
            return dt;
        }
        /// <summary>
        /// 获取视图相关索引
        /// </summary>
        /// <param name="dbName"></param>
        /// <param name="vName"></param>
        /// <returns></returns>
        public DataTable getViewIndex(string dbName, string vName) 
        {
            DataTable dt = new DataTable();
            BuildIndexTable(dt);
            IndexCollection indexs = ser.Databases[dbName].Views[vName].Indexes;
            foreach (Index index in indexs)
            {
                DataRow dr = dt.NewRow();
                dr["Name"] = index.Name;
                string strColumns = string.Empty;
                foreach (IndexedColumn col in index.IndexedColumns)
                {
                    if (strColumns.Length > 0)
                    {
                        strColumns += ",";
                    }
                    strColumns += col.Name;
                }
                dr["Columns"] = strColumns;
                dr["Unique"] = index.IsUnique ? "是" : "否";
                dt.Rows.Add(dr);
            }
            return dt;
        }
        private void BuildIndexTable(DataTable dt) 
        {
            para = new Dictionary<string, Type>();
            para.Add("Name", typeof(string));
            para.Add("Columns", typeof(string));
            para.Add("Unique", typeof(string));
            BuildTable(para, dt);
        }
        /// <summary>
        /// 获取存储过程的属性
        /// </summary>
        /// <param name="dbName"></param>
        /// <param name="pName"></param>
        /// <returns></returns>
        public DataTable GetProcedureProperties(string dbName, string pName) 
        {
            DataTable dt = new DataTable();
            BuildPropertiesTable(dt);
            Database db = ser.Databases[dbName];
            StoredProcedure procedure = db.StoredProcedures[pName];
            DataRow drCollation = dt.NewRow();
            drCollation["Property"] = "排序规则";
            drCollation["Value"] = db.Collation;
            DataRow drRowCount = dt.NewRow();
            drRowCount["Property"] = "返回值";
            drRowCount["Value"] = "--";
            DataRow drCreateDate = dt.NewRow();
            drCreateDate["Property"] = "创建时间";
            drCreateDate["Value"] = procedure.CreateDate.ToString();
            DataRow drLastModifiedDate = dt.NewRow();
            drLastModifiedDate["Property"] = "最后修改时间";
            drLastModifiedDate["Value"] = procedure.DateLastModified.ToString();
            dt.Rows.Add(drCollation);
            dt.Rows.Add(drRowCount);
            dt.Rows.Add(drCreateDate);
            dt.Rows.Add(drLastModifiedDate);
            return dt;
        }

        public DataTable getProcedureParamters(string dbName, string pName) 
        {
            DataTable dt = new DataTable();
            BuildParamtersTable(dt);
            StoredProcedureParameterCollection paramters = ser.Databases[dbName].StoredProcedures[pName].Parameters;
            foreach (StoredProcedureParameter parameter in paramters) 
            {
                DataRow dr = dt.NewRow();
                dr["name"] = parameter.Name;
                dr["dataType"] = parameter.DataType;
                dr["maxLength"] = parameter.DataType.MaximumLength;
                dr["inOrOut"] = parameter.IsOutputParameter ? "OutPut" : "Input";
                dt.Rows.Add(dr);
            }
            return dt;
        }


        public DataTable getFunctionProperties(string dbName, string fName) 
        {
            DataTable dt = new DataTable();
            BuildPropertiesTable(dt);
            Database db = ser.Databases[dbName];
            UserDefinedFunction fun = db.UserDefinedFunctions[fName];
            DataRow drCollation = dt.NewRow();
            drCollation["Property"] = "排序规则";
            drCollation["Value"] = db.Collation;
            DataRow drRowCount = dt.NewRow();
            drRowCount["Property"] = "返回值";
            drRowCount["Value"] = "--";
            DataRow drCreateDate = dt.NewRow();
            drCreateDate["Property"] = "创建时间";
            drCreateDate["Value"] = fun.CreateDate == null ? "" : fun.CreateDate.ToString();
            DataRow drLastModifiedDate = dt.NewRow();
            drLastModifiedDate["Property"] = "最后修改时间";
            drLastModifiedDate["Value"] = fun.DateLastModified == null ? "" : fun.DateLastModified.ToString();
            dt.Rows.Add(drCollation);
            dt.Rows.Add(drRowCount);
            dt.Rows.Add(drCreateDate);
            dt.Rows.Add(drLastModifiedDate);
            return dt;
        }

        public DataTable getFunctionParameters(string dbName, string fName) 
        {
            DataTable dt = new DataTable();
            BuidFunParaTable(dt);
            foreach (UserDefinedFunctionParameter para in ser.Databases[dbName].UserDefinedFunctions[fName].Parameters) 
            {
                DataRow dr = dt.NewRow();
                dr["name"] = para.Name;
                dr["dataType"] = para.DataType;
                dr["maxLength"] = para.DataType.MaximumLength;
                dt.Rows.Add(dr);
            }
            return dt;
        }
        /// <summary>
        /// 定义属性表
        /// </summary>
        /// <param name="dt">需要定义的表</param>
        private void BuildPropertiesTable(DataTable dt)
        {
            para = new Dictionary<string, Type>();
            para.Add("Property", typeof(string));
            para.Add("Value", typeof(string));
            BuildTable(para, dt);
        }
        /// <summary>
        /// 构建参数属性表
        /// </summary>
        /// <param name="dt"></param>
        private void BuildParamtersTable(DataTable dt) 
        {
            para = new Dictionary<string, Type>();
            para.Add("name", typeof(string));
            para.Add("dataType", typeof(string));
            para.Add("maxLength", typeof(int));
            para.Add("inOrOut", typeof(string));
            BuildTable(para, dt);
        }


        private void BuidFunParaTable(DataTable dt) 
        {
            para = new Dictionary<string, Type>();
            para.Add("name", typeof(string));
            para.Add("dataType", typeof(string));
            para.Add("maxLength", typeof(int));
            BuildTable(para, dt);
        }

        public string getProcedureScript(string dbName, string pName) 
        {
            StringBuilder sb = new StringBuilder();
            StoredProcedure procedure = ser.Databases[dbName].StoredProcedures[pName];
            Scripter script = getScripter();
            UrnCollection urns = new UrnCollection();
            urns.Add(procedure.Urn);
            StringCollection sqlScript = script.Script(urns);
            foreach (string str in sqlScript) 
            {
                sb.Append(str);
                sb.Append("\r\nGO\r\n");
            }
            return sb.ToString();
        }

        public string getFunctionScript(string dbName, string fName) 
        {
            StringBuilder sb = new StringBuilder();
            UserDefinedFunction fun = ser.Databases[dbName].UserDefinedFunctions[fName];
            Scripter script = getScripter();
            UrnCollection urns = new UrnCollection();
            urns.Add(fun.Urn);
            StringCollection sqlScript = script.Script(urns);
            foreach (string str in sqlScript) 
            {
                sb.Append(str);
                sb.Append("\r\nGO\n\r");
            }
            return sb.ToString();
        }

        
    }
}