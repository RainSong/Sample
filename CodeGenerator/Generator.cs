using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeGenerator
{
    public class Generator
    {
        public string Templete = "";
        public string GeneratorCode<T>(T model)
        {
            return RazorEngine.Razor.Parse(this.Templete, model);
        }
    }
}
