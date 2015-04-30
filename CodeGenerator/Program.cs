using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace CodeGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            string templete = File.ReadAllText("templete2.txt");

            var dbName = "AdventureWorks2012";
            var dbInfo = new DataBasesInfo();
            var tableNames = dbInfo.GetTables(dbName);

            var generator = new Generator();
            generator.Templete = templete;
            var code = string.Empty;

            foreach (var tableName in tableNames) 
            {
                var em = new EntityModel();
                em.NameSpace = "DAL";
                em.Name = tableName;
                em.Comments = new string[] { "author:YGJ" };
                var fields = new List<EntityField>();
                var columns = dbInfo.GetTableClomns(dbName, tableName);
                
                foreach (DataRow dr in columns.Rows) 
                {
                    var ef = new EntityField();
                    ef.Name = Convert.ToString(dr["Name"]);
                    ef.DataType = Convert.ToString(dr["DataType"]);
                    ef.DbNullAbel = Convert.ToBoolean(dr["AllowNull"]);
                    ef.Description = Convert.ToString(dr["Des"]);
                    fields.Add(ef);
                }
                em.Fields = fields;

                try
                {
                    code = generator.GeneratorCode(em);
                    string path = string.Format(@"D:\ModelTest\{0}.cs", em.Name);
                    File.WriteAllText(path, code, Encoding.Default);
                    Console.WriteLine(em.Name);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
