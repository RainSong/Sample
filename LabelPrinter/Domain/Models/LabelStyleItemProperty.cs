using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace LabelPrinter.Domain.Models
{
    public class LabelStyleItemProperty
    {
        public int ID { get; set; }
        public int StyleID { get; set; }
        public int ItemID { get; set; }
        public LabelStyleItemPropertyType PropertyType { get; set; }

        public string PropertyDisplayValue
        {
            get
            {
                if (PropertyType == LabelStyleItemPropertyType.FontStyle)
                {
                    if (int.TryParse(PropertyValue, out int val))
                    {
                        return ((FontStyle)val).ToString();
                    }
                }
                return PropertyValue;
            }
        }
        public string PropertyValue { get; set; }

        public LabelStyleItemPropertyValueType PropertyValueType { get; set; }

        public string Remark { get; set; }

    }
}
