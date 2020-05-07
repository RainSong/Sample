using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace LabelPrinter.Printers
{
    class SP2MainCircuitPrinter : CircuitPrinter
    {
        //private Size pageSize;

        public Point Offset { get; set; }

        public SP2MainCircuitPrinter() 
        {
            //this.pageSize = new Size(101, 27);
        }
    }
}
