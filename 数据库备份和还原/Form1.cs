using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.SqlServer.Management;
using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;
using Microsoft.SqlServer.Management.Sdk;

namespace 数据库备份和还原
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.folderBrowserDialog1.Description = "\r\n选择备份文件位置";
        }
        DatabaseCollection dbs = null;
        private void panel_Paint(object sender, PaintEventArgs e)
        {
            Panel panel = sender as Panel;
            ControlPaint.DrawBorder(e.Graphics,
                panel.ClientRectangle,
                Color.LightGray,
                ButtonBorderStyle.Solid);
        }

        private void btnSelecFolder_Click(object sender, EventArgs e)
        {
            if (this.folderBrowserDialog1.ShowDialog() == DialogResult.OK) 
            {
                if (!string.IsNullOrEmpty(this.txtPath.Text = this.folderBrowserDialog1.SelectedPath)) 
                {
                    
                }
            }
        }
        /// <summary>
        /// 连接
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConnect_Click(object sender, EventArgs e)
        {
            string strServer = this.txtServerName.Text.Trim();
            string strUname = this.txtUname.Text.Trim();
            string strPwd = this.txtPwd.Text.Trim();
            if (!string.IsNullOrEmpty(strServer))
            {
                if (!string.IsNullOrEmpty(strUname)) 
                {
                    if (!string.IsNullOrEmpty(strPwd))
                    {
                        ServerConnection sc=null;
                        try
                        {
                            Server ser = new Server();
                            ser.ConnectionContext.ServerInstance = strServer;
                            sc = ser.ConnectionContext;
                            sc.LoginSecure = false;  //指定是windows身份验证还是sqlservere验证
                            sc.Login = strUname;
                            sc.Password = strPwd;
                            dbs = ser.Databases;
                            sc.Connect();
                            bindDataBaseToCombox();
                            
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(string.Format("发生错误，连接失败！\r\n错误原因：{0}", ex.Message), "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        finally 
                        {
                            if (sc != null)
                            {
                                sc.Cancel();
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("请输入密码！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else 
                {
                    MessageBox.Show("请输入用户名！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else 
            {
                MessageBox.Show("请输入服务器名称！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        void bindDataBaseToCombox() 
        {
            this.cbDatabase.Items.Clear();
            if (dbs != null && dbs.Count > 0) 
            {
                foreach (Database db in dbs) 
                {
                    if (!db.IsSystemObject)
                    {
                        this.cbDatabase.Items.Add(db.Name);
                    }
                }
            }
        }
    }
}
