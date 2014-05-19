using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExportXLS
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.dataGridView1.ReadOnly = true;
        }

        public void Form_Load(object sender, EventArgs e)
        {
            var path = string.Format(@"{0}data\custom.json", PublicMethod.CurrentPath);
            if (File.Exists(path))
            {
                var json = File.ReadAllText(path);
                var list = PublicMethod.ConvertJsonToObject<List<dynamic>>(json);
                this.dataGridView1.DataSource = list;
            }
        }
    }
}
