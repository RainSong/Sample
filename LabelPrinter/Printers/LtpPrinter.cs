using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing.Printing;
using System.Drawing;

using LabelPrinter.Printers.PrintContents;

namespace LabelPrinter.Printers
{
    public class LtpPrinter : PrinterBase
    {
        private PrintDocument printDocument;
        /// <summary>
        /// 
        /// </summary>
        public LtpPrinter() { }

        private float offsetX = 0;
        private float offsetY = 0;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="printerName"></param>
        public LtpPrinter(string printerName)
        {
            this.PrinterName = printerName;
            this.PrinterType = Printers.PrinterType.LTP;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="printerName"></param>
        /// <param name="labelWidth"></param>
        /// <param name="labelHeight"></param>
        public LtpPrinter(string printerName, float labelWidth, float labelHeight)
        {
            this.PrinterName = printerName;
            this.PrinterType = Printers.PrinterType.LTP;

            SetPrinter(labelWidth, labelHeight);
        }
        /// <summary>
        /// 
        /// </summary>
        public override void Print(float offsetX = 0, float offsetY = 0)
        {
            this.offsetX = offsetX;
            this.offsetY = offsetY;
            if (this.Contents == null || this.Contents.Count == 0)
                throw new Exception("Nothing to print");
            this.printDocument.Print();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void printDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            Draw(e.Graphics, offsetX, offsetY);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="graphics"></param>
        /// <param name="img"></param>
        /// <param name="point"></param>
        /// <param name="size"></param>
        private void DrawImage(Graphics graphics, Bitmap img, PointF point, SizeF size)
        {
            graphics.DrawImage(img, point.X, point.Y, size.Width, size.Height);
        }

        private void Draw(Graphics graphics, float offsetX, float offsetY)
        {
            foreach (var content in this.Contents)
            {
                content.Draw(graphics, offsetX, offsetY);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public void SetPrinter()
        {

            this.printDocument = new PrintDocument();
            this.printDocument.PrinterSettings.DefaultPageSettings.PrinterSettings.PrinterName = this.PrinterName;

            PrintController pc = new StandardPrintController();
            this.printDocument.PrintController = pc;


            this.printDocument.PrintPage += new PrintPageEventHandler(printDocument_PrintPage);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="labelWidth"></param>
        /// <param name="labelHeight"></param>
        public void SetPrinter(float labelWidth, float labelHeight)
        {
            SetPrinter();
            this.printDocument.PrinterSettings.DefaultPageSettings.PaperSize = new PaperSize("Custom", (int)Math.Round(labelWidth / 0.254), (int)Math.Round(labelHeight / 0.254));
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override Bitmap Preview(float labelWidth, float labelHeight, float offsetX, float offsetY)
        {
            Bitmap bitmap = new Bitmap((int)Math.Round(labelWidth / 0.254), (int)Math.Round(labelHeight / 0.254));
            var graphics = Graphics.FromImage(bitmap);
            graphics.DrawLine(Pens.Black, new Point(0, 0), new Point(bitmap.Width, 0));
            graphics.DrawLine(Pens.Black, new Point(0, 0), new Point(0, bitmap.Height));
            Draw(graphics, offsetX, offsetY);
            return bitmap;
        }
    }
}
