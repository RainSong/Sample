using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using UPUIInChildThread.Properties;

namespace UPUIInChildThread
{
    public partial class Form1 : Form
    {
        private List<string> listFiles = new List<string>();
        public Form1()
        {
            InitializeComponent();
#if DEBUG
            this.txtPath.Text = @"D:\imgs";
#endif
        }

        private void btnGenMD5_Click(object sender, EventArgs e)
        {

            if (this.dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show(Resources.Form1_MessageBox_Message_NoFileToComputMD5, Resources.Form1_MessageBox_Caption_Warning, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            Task task = new Task(EachGridGenMD5);
            task.Start();
        }

        private void btnBrowser_Click(object sender, EventArgs e)
        {
            if (this.folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                this.txtPath.Text = this.folderBrowserDialog1.SelectedPath;
            }
        }

        private void AddRow()
        {
            BeginInvoke(new Action(() =>
            {
                listFiles.ForEach(fileName =>
                {
                    int index = this.dataGridView1.Rows.Add();
                    this.dataGridView1.Rows[index].Cells["colFileName"].Value = fileName;
                });
            }));
        }

        private void UpDateStatusLabel(string msg)
        {
            BeginInvoke(new Action(() =>
            {
                this.toolStripStatusLabel1.Text = msg;
            }));
        }

        private bool CheckDir(out string dir)
        {
            dir = this.txtPath.Text.Trim();
            if (string.IsNullOrEmpty(dir))
            {
                MessageBox.Show(Resources.Form1_MessageBox_Message_Path_None, Resources.Form1_MessageBox_Caption_Warning, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (!Directory.Exists(dir))
            {
                MessageBox.Show(string.Format(Resources.Form1_MessageBox_Message_Path_NotExists, dir), Resources.Form1_MessageBox_Caption_Warning, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void GetFiles(string path)
        {
            if (Directory.Exists(path))
            {
                var files = Directory.GetFiles(path);
                if (files.Length > 0)
                {
                    foreach (var strFile in files)
                    {
                        //AddRow(strFile);
                        listFiles.Add(strFile);
                        //UpDateStatusLabel(string.Format("共获取到{0}个文件；", this.listFiles.Count));
                    }
                }
                var dirs = Directory.GetDirectories(path);
                foreach (var strDir in dirs)
                {
                    GetFiles(strDir);
                }
            }
        }

        private void btnGetFile_Click(object sender, EventArgs e)
        {
            string dir;
            if (CheckDir(out dir))
            {
                Task task = new Task((obj) =>
                {
                    string[] arr = obj as string[];
                    if (arr == null || arr.Length == 0) return;
                    GetFiles(arr[0]);
                }, new[] {dir});

                task.ContinueWith(t =>
                {
                    AddRow();
                    UpDateStatusLabel(string.Format("共获取到{0}个文件；", this.listFiles.Count));
                });


                task.Start();
            }
        }

        private string GetFileMD5(string file)
        {
            Thread.Sleep(500);
            if (string.IsNullOrEmpty(file)) return "文件名为空，无法计算MD5值";
            if (!File.Exists(file)) return "文件不存在";
            try
            {
                FileInfo fi = new FileInfo(file);
                if (fi.Length < 5 * 1024)
                {
                    return "文件小于5KB，不计算MD5";
                }
                using (var fs = fi.Open(FileMode.Open, FileAccess.Read, FileShare.Read))
                {
                    var bytes = new byte[fi.Length];
                    fs.Read(bytes, 0, bytes.Length);

                    MD5 md5 = new MD5CryptoServiceProvider();
                    var md5Bytes = md5.ComputeHash(bytes, 0, bytes.Length);

                    var sb = new StringBuilder();
                    foreach (byte t in md5Bytes)
                    {
                        sb.Append(t.ToString("x2"));
                    }
                    return sb.ToString();
                }
            }
            catch (Exception ex)
            {
                return string.Format("发生错误，MD5计算失败，异常原因：{0}", ex.Message);
            }
        }

        private void EachGridGenMD5()
        {
            int i = 0;
            foreach (DataGridViewRow row in this.dataGridView1.Rows)
            {
                i++;
                var fileName = (row.Cells["colFileName"].Value ?? string.Empty).ToString();
                var md5 = GetFileMD5(fileName);
                BeginInvoke(new Action(() =>
                {
                    row.Cells["colMD5"].Value = md5;
                }));
                UpDateStatusLabel(string.Format("共获取到{0}个文件；已计算{1}；", listFiles.Count, i));
            }
        }
    }
}
