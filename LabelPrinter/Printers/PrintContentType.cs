using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LabelPrinter.Printers
{
    public enum PrintContentType
    {
        Unkown = 0,
        String = 1,
        BarCode = 2,
        DataMatrix = 3,
        QRCode = 4,
        Line = 5
    }
}
