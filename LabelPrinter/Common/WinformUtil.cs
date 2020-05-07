
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LabelPrinter.Common
{
    public static class WinformUtil
    {
        public static void BindEnum<T>(this ComboBox cbo) 
        {
            var type = typeof(T);
            var names = Enum.GetNames(type);
            var dataSource = new List<object>();
            foreach (var name in names) 
            {
                var value = Enum.Parse(type, name);
                //cbo.Items.Add(new { Text = name, Value = (int)value });
                dataSource.Add(new { Text = name, Value = (T)value });
            }
            cbo.DataSource = dataSource;
            cbo.DisplayMember = "Text";
            cbo.ValueMember = "Value";
        }
    }
}
