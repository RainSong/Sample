using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace LabelPrinter.Printers
{
    class CircuitPrinter : Printer
    {
        Font fontPartNo { get; set; }
        PointF pointPartNo { get; set; }
        PointF pointPartNo2 { get; set; }

        PointF pointBarCode { get; set; }
        SizeF sizeBarCode { get; set; }

        Font fontCompany { get; set; }
        PointF pointCompany { get; set; }

        Font fontLot;
        PointF pointLot { get; set; }
        PointF pointEo { get; set; }
        PointF pointDate { get; set; }
        PointF pointSeq { get; set; }
        PointF pointTimes { get; set; }
        PointF pointCarName { get; set; }

        Font fontCarItemName { get; set; }
        PointF pointCarItemName { get; set; }

        Font fontAlcRightTop { get; set; }
        PointF pointAlcRightTop { get; set; }

        PointF pointAlcBarCodeRight { get; set; }
        SizeF sizeAlcBarCodeRight { get; set; }

        PointF pointAlcBarCodeLeft { get; set; }
        SizeF sizeAlcBarCodeLeft { get; set; }

        Font fontAlcRightBottom { get; set; }
        PointF pointAlcRightBottom { get; set; }
        PointF pointAlcRightBottom2 { get; set; }

        Bitmap imgBarCode = null;
        Bitmap imgAlcBarCode = null;
        Bitmap imgSeq = null;

        public override void PrintItem(IPrintData data, Graphics graphics)
        {
            throw new NotImplementedException();
        }
    }
}
