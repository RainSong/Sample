using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace ListViewSample
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            BindDataToListView();
        }

        private void BindDataToListView()
        {
            try
            {
                var connectionString = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=sample;Data Source=.";
                var dt = new DataTable();
                using(var conn = new SqlConnection(connectionString))
                {
                    var sqlCommandText = @"select Name,
	                                          case Sex
                                                  when 0 then '女'
                                                  when 1 then '男'
	                                              else '--'
                                              end as Sex,
	                                          CONVERT(VARCHAR(10), Brithday, 120) as Brithday
                                        from students";
                    var adapter = new SqlDataAdapter(sqlCommandText, conn);
                    adapter.Fill(dt);
                }
                this.listView1.BeginUpdate();
                foreach (DataRow dr in dt.Rows)
                {

                    var listItem = new ListViewItem(dr.Field<string>("Name"));
                    listItem.SubItems.Add(dr.Field<string>("Sex"));
                    listItem.SubItems.Add(dr.Field<string>("Brithday"));
                    this.listView1.Items.Add(listItem);
                }

                this.listView1.Items[this.listView1.Items.Count - 1].EnsureVisible();
                this.listView1.EndUpdate();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "异常", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
