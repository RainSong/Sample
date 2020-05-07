
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

using LabelPrinter.Domain.Models;
using LabelPrinter.Printers;
using LabelPrinter.Printers.PrintContents.LtpPrintContents;
using ZXing;
using ZXing.Datamatrix;
using ZXing.Datamatrix.Encoder;

namespace LabelPrinter.Domain
{
    public class LtpPrinterBuilder
    {
        public LtpPrinter Build(Dictionary<string, object> data, LabelStyle style, string printName)
        {
            LtpPrinter printer = new LtpPrinter
            {
                PrinterName = printName
            };
            var contents = BuildContents(data, style);
            printer.AddContentRange(contents);
            return printer;
        }

        public IEnumerable<LtpPrintContentBase> BuildContents(Dictionary<string, object> data, LabelStyle style)
        {
            List<LtpPrintContentBase> listContents = new List<LtpPrintContentBase>();
            foreach (var item in style.Items)
            {
                switch (item.ItemType)
                {
                    case LabelStyleItemType.String:
                        listContents.Add(BuildStringContent(data, item));
                        break;
                    case LabelStyleItemType.BarCode:
                    case LabelStyleItemType.QRCode:
                    case LabelStyleItemType.DataMatrix:
                        listContents.Add(BuildImageContent(data, item));
                        break;
                    case LabelStyleItemType.Line:
                        listContents.Add(BuildLineContent(item));
                        break;
                    default:
                        break;
                }
            }
            return listContents;
        }

        public LtpPrintStringContent BuildStringContent(Dictionary<string, object> data, LabelStyleItem item)
        {
            return new LtpPrintStringContent
            {
                Font = GetFont(item),
                Point = GetPoint(item),
                RotationAngle = GetRotationAngle(item),
                Content = GetValue(data, item)
            };
        }

        public LtpPrintImageContent BuildImageContent(Dictionary<string, object> data, LabelStyleItem item)
        {
            var size = GetSize(item);
            var imgContent = new LtpPrintImageContent
            {
                Point = GetPoint(item),
                Size = size,
            };
            var strContent = item.Func(data);
            Bitmap img;
            switch (item.ItemType)
            {
                case LabelStyleItemType.BarCode:
                    img = GetBarCode(size, strContent);
                    break;
                case LabelStyleItemType.QRCode:
                    img = GetQRCode(size, strContent);
                    break;
                case LabelStyleItemType.DataMatrix:
                    img = GetDataMatrix(size, strContent);
                    break;
                default:
                    img = GetBarCode(size, strContent);
                    break;
            }
            imgContent.Content = img;
            return imgContent;
        }

        public LtpPrintLineContent BuildLineContent(LabelStyleItem item) 
        {
            return null;
        }

        public PointF GetPoint(LabelStyleItem item)
        {
            return new PointF(0F, 0F)
            {
                X = GetPropertyValue<float>(item, LabelStyleItemPropertyType.LocationX),
                Y = GetPropertyValue<float>(item, LabelStyleItemPropertyType.LocationY)
            };
        }

        public PointF GetPoint2(LabelStyleItem item)
        {
            return new PointF(0F, 0F)
            {
                X = GetPropertyValue<float>(item, LabelStyleItemPropertyType.Location2X),
                Y = GetPropertyValue<float>(item, LabelStyleItemPropertyType.Location2Y)
            };
        }

        public SizeF GetSize(LabelStyleItem item)
        {
            return new SizeF(0F, 0F)
            {
                Width = GetPropertyValue<float>(item, LabelStyleItemPropertyType.Width),
                Height = GetPropertyValue<float>(item, LabelStyleItemPropertyType.Height)
            };
        }

        public T GetPropertyValue<T>(LabelStyleItem item, LabelStyleItemPropertyType type)
        {
            var value = default(T);
            var property = item.Properties.FirstOrDefault(o => o.PropertyType == type && !string.IsNullOrEmpty(o.PropertyValue));
            if (property != null)
            {
                var valueType = typeof(T);
                object objValue = Convert.ChangeType(property.PropertyValue, valueType);
                value = (T)objValue;
            }
            return value;
        }

        public Font GetFont(LabelStyleItem item)
        {
            var font = default(Font);
            var propertyFontName = item.Properties.FirstOrDefault(o => o.PropertyType == LabelStyleItemPropertyType.FontName && !string.IsNullOrEmpty(o.PropertyValue));
            var fontSize = GetPropertyValue<float>(item, LabelStyleItemPropertyType.FontSize);
            var fontSytle = (FontStyle)GetPropertyValue<int>(item, LabelStyleItemPropertyType.FontStyle);
            if (propertyFontName != null && fontSize > 0F)
            {
                var fontName = propertyFontName.PropertyValue;
                font = new Font(fontName, fontSize, fontSytle);
            }
            return font;
        }

        public int GetRotationAngle(LabelStyleItem item)
        {
            return GetPropertyValue<int>(item, LabelStyleItemPropertyType.RotationAngle);
        }

        public string GetValue(Dictionary<string, object> data, LabelStyleItem item)
        {
            var value = string.Empty;
            if (item.ValueType == LabelStyleItemValueType.Input)
            {
                if (data.ContainsKey(item.Data))
                {
                    var objValue = data[item.Data];
                    if (objValue != null)
                        value = objValue.ToString();
                }
            }
            else if (item.ValueType == LabelStyleItemValueType.Compute)
            {
                if (item.Func != null)
                    value = item.Func(data);
            }
            else
            {
                value = item.Data;
            }
            return value;
        }

        public Bitmap GetBarCode(SizeF size, string content)
        {
            DatamatrixEncodingOptions en = new DatamatrixEncodingOptions()
            {
                Height = (int)size.Height,
                Width = (int)size.Width,
                PureBarcode = true,
                Margin = 0,
                SymbolShape = SymbolShapeHint.FORCE_SQUARE
            };
            BarcodeWriter bw2 = new BarcodeWriter()
            {
                Options = en,
                Format = BarcodeFormat.CODE_128
            };
            return bw2.Write(content);
        }

        public Bitmap GetQRCode(SizeF size, string content)
        {
            DatamatrixEncodingOptions en = new DatamatrixEncodingOptions()
            {
                Height = (int)size.Height,
                Width = (int)size.Width,
                PureBarcode = true,
                Margin = 0,
                SymbolShape = SymbolShapeHint.FORCE_SQUARE
            };
            BarcodeWriter bw2 = new BarcodeWriter()
            {
                Options = en,
                Format = BarcodeFormat.QR_CODE
            };
            return bw2.Write(content);
        }

        public Bitmap GetDataMatrix(SizeF size, string content)
        {
            DatamatrixEncodingOptions en = new DatamatrixEncodingOptions()
            {
                //Height = (int)size.Height,
                //Width = (int)size.Width,
                PureBarcode = true,
                Margin = 0,
                SymbolShape = SymbolShapeHint.FORCE_SQUARE
            };
            BarcodeWriter bw2 = new BarcodeWriter()
            {
                Options = en,
                Format = BarcodeFormat.DATA_MATRIX
            };
            return bw2.Write(content);
        }
    }
}
