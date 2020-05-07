using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LabelPrinter.Domain.Models
{
    public class LabelStyle
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public float Width { get; set; }

        public float Height { get; set; }

        public string Remark { get; set; }

        public LabelType LabelType { get; set; }

        public IEnumerable<LabelStyleItem> Items { get; set; }
        public IEnumerable<LabelStyleCarItem> CarItems { get; set; }
    }
}
