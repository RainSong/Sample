using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeGenerator
{
    public class EntityField
    {
        /// <summary>
        /// 
        /// </summary>
        public string Description { get; set; }
        public bool DbNullAbel { get; set; }
        public string Name { get; set; }
        public string DataType { get; set; }
    }
}
