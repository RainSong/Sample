using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace LabelPrinter.Printers.PrintContents.LtpPrintContents
{
    public class LtpPrintLineContent : LtpPrintContentBase
    {
        public Pen Pen { get; set; }
        public PointF StartPoint { get; set; }
        public PointF EndPoint { get; set; }
        public override void Draw(Graphics graphics, float offsetX = 0, float offsetY = 0)
        {
            if (graphics == null)
                throw new ArgumentNullException("none graphics");
            var spoint = new PointF(this.StartPoint.X + offsetX, this.StartPoint.Y + offsetY);
            var epoint = new PointF(this.EndPoint.X + offsetX, this.EndPoint.Y + offsetY);
            graphics.DrawLine(this.Pen, spoint, epoint);
        }
    }
}
