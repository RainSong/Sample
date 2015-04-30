using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeGenerator
{
    public class EntityModel
    {
        public EntityField Key { get; set; }
        public IEnumerable<string> Comments { get; set; }
        public IEnumerable<string> Refrences { get; set; }
        public IEnumerable<EntityField> Fields { get; set; }
        public string Name { get; set; }

        public string NameSpace { get; set; }
    }
}
