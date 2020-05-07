using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace LabelPrinter.Printers.PrintContents.LtpPrintContents
{
    public class LtpPrintImageContent : LtpPrintContentBase
    {
        public PointF Point { get; set; }

        public SizeF Size { get; set; }
        public int RotationAngle { get; set; }

        public override void Draw(Graphics graphics, float offsetX, float offsetY)
        {
            var img = this.Content as Image;
            if (graphics == null)
                throw new ArgumentNullException("none graphics");
            if (this.Content == null)
                throw new Exception("nothing to darw.");
            if (img == null)
                return;
            if (RotationAngle == 0)
                graphics.DrawImage(img, this.Point.X + offsetX, this.Point.Y + offsetY, this.Size.Width, this.Size.Height);
            else
                DrawImage(graphics, img, this.Point.X + offsetX, this.Point.Y + offsetY, this.Size.Width, this.Size.Height, this.RotationAngle);
        }

        private void DrawImage(Graphics graphics, Image img, float locationX, float locationY, float width, float height, int rotationAngle)
        {
            //TODO YGJ 
        }
    }
}
