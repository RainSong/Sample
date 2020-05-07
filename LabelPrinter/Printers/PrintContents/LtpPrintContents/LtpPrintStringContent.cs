using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace LabelPrinter.Printers.PrintContents.LtpPrintContents
{
    public class LtpPrintStringContent : LtpPrintContentBase
    {
        public Font Font { get; set; }
        public PointF Point { get; set; }
        public int RotationAngle { get; set; }
        public Brush Brush { get; set; }
        public StringFormat Format { get; set; }

        public override void Draw(Graphics graphics,float offsetX = 0,float offsetY = 0)
        {
            if (this.Brush == null)
                this.Brush = Brushes.Black;
            var str = this.Content as string;
            if (graphics == null)
                throw new ArgumentNullException("none graphics");
            if (this.Content == null)
                throw new Exception("nothing to darw.");
            if (string.IsNullOrEmpty(str))
                return;
            var npoint = new PointF(this.Point.X + offsetX, this.Point.Y + offsetY);
            if (RotationAngle == 0)
                graphics.DrawString(str, this.Font, this.Brush, npoint, this.Format);
            else
                DrawString(graphics, str, this.Font, this.Brush, npoint, this.Format, this.RotationAngle);
        }

        private void DrawString(Graphics graphics, string s, Font font, Brush brush, PointF point, StringFormat format, int rotationAngle)
        {
            //TODO YGJ 
        }
    }
}
