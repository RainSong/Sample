using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace LabelPrinter.Printers
{
    abstract class Printer
    {
        public virtual void Print(IEnumerable<IPrintData> printDatas, Graphics graphics)
        {
            if (printDatas == null) throw new Exception("no data to print");
            foreach (var data in printDatas)
            {
                PrintItem(data, graphics);
            }
        }

        public abstract void PrintItem(IPrintData data, Graphics graphics);
    }
}
