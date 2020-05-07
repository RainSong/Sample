using CSScriptLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LabelPrinter.Domain.Models
{
    public class LabelStyleItem
    {
        public int ID { get; set; }

        public int StyleID { get; set; }

        public string Data { get; set; }

        public LabelStyleItemType ItemType { get; set; }

        public LabelStyleItemValueType ValueType { get; set; }

        public string Remark { get; set; }

        public MethodDelegate<string> Func { get; set; }

        public IEnumerable<LabelStyleItemProperty> Properties { get; set; }

    }
}
