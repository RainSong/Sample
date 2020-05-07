using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace LabelPrinter.Printers.PrintContents
{
    public interface IPrintContent
    {
        void Draw(Graphics graphics, float offsetX = 0, float offsetY = 0);
    }
}
