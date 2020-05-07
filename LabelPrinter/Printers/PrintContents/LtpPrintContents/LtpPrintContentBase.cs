using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace LabelPrinter.Printers.PrintContents.LtpPrintContents
{
    public abstract class LtpPrintContentBase : IPrintContent
    {
        public PrintContentType ContentType { get; set; }
        public object Content { get; set; }

        public abstract void Draw(Graphics graphics,float offsetX = 0,float offsetY = 0);
    }
}
