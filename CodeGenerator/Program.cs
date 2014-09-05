using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            string templete = File.ReadAllText("templete.txt");

            var model = new EntityModel
            {

                Name = "Entity1",
                Key = new EntityField
                {
                    Name = "ID",
                    DataType = "int"
                },
                Comments = new string[] 
                {
                    "ygj",
                    "this is test"
                },
                Refrences = new string[] 
                {
                    "System",
                    "System.ComponentModel",
                    "System.Collections.Generic"
                },
                Fields = new EntityField[] 
                {
                   
                    new EntityField
                    {
                        Name = "ID",
                        DataType = "int"
                    },
                    new EntityField
                    {
                        Name = "Name",
                        DataType = "string"
                    }
                }
            };

            var generator = new Generator();
            generator.Templete = templete;
            var code = string.Empty;
            try
            {
                code = generator.GeneratorCode(model);
                File.WriteAllText(string.Format(@"D:\ModelTest\{0}.cs", model.Name), code, Encoding.UTF8);
            }
            catch (Exception ex)
            {
                Simple.Common.LogManager.LogError(ex);
            }
            finally 
            {
                Console.ReadKey();
            }
        }
    }
}
