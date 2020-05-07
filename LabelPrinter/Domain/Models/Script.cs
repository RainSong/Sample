using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LabelPrinter.Domain.Models
{
    public class Script
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string KeyCode { get; set; }

        public string ScriptContent { get; set; }

        public string Remark { get; set; }

    }
}
