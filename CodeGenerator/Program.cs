using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Microsoft.SqlServer.Management.Smo;

namespace CodeGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            string templete = File.ReadAllText("templete2.txt");

            var dbName = "AdventureWorks2012";
            var dbInfo = new DataBasesInfo();
            var tables = dbInfo.GetTables(dbName);

            var generator = new Generator();
            generator.Templete = templete;
            var code = string.Empty;

            foreach (var table in tables) 
            {
                var em = new EntityModel();
                em.NameSpace = "DAL";
                em.Name = table.Name;
                em.Comments = new string[] { "author:YGJ" };
                var fields = new List<EntityField>();
                //var columns = dbInfo.GetTableClomns(dbName, table);
                
                foreach (Column col in table.Columns) 
                {
                    var ef = new EntityField();
                    ef.Name = col.Name;
                    ef.DataType = col.DataType.ToString();
                    ef.DbNullAbel = col.Nullable;
                    ef.Description = col.ExtendedProperties.Contains("MS_Description") ? col.ExtendedProperties["MS_Description"].Value.ToString() : string.Empty;
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
