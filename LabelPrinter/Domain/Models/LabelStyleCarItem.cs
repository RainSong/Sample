using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LabelPrinter.Domain.Models
{
    public class LabelStyleCarItem
    {
        public int ID { get; set; }
        public int StyleID { get; set; }
        public int CarSeqn { get; set; }
        public string CarName { get; set; }
        public int CarItemSeqn { get; set; }
        public string CarItemName { get; set; }
    }
}
