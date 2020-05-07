using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

using LabelPrinter.Printers.PrintContents;

namespace LabelPrinter.Printers
{
    public abstract class PrinterBase
    {
        protected List<IPrintContent> Contents = null;
        public string PrinterName { get; set; }
        public PrinterType PrinterType { get; set; }
        public PrinterBase()
        {
            this.Contents = new List<IPrintContent>();
        }

        public void AddContent(IPrintContent content)
        {
            this.Contents.Add(content);
        }

        public void AddContentRange(IEnumerable<IPrintContent> printContents)
        {
            this.Contents.AddRange(printContents);
        }

        public void RemoveContent(IPrintContent content)
        {
            this.Contents.Remove(content);
        }
        public void ClearContents()
        {
            this.Contents.Clear();
        }

        public abstract void Print(float offsetX, float offsetY);

        public abstract Bitmap Preview(float labelWidth, float labelHeight, float offsetX, float offsetY);
    }


}
