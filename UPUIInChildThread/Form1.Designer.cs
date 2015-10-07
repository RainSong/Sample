namespace UPUIInChildThread
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.panelTop = new System.Windows.Forms.Panel();
            this.labPath = new System.Windows.Forms.Label();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.btnBrowser = new System.Windows.Forms.Button();
            this.btnGenMD5 = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.colFileName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMD5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.btnGetFile = new System.Windows.Forms.Button();
            this.panelTop.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.btnGetFile);
            this.panelTop.Controls.Add(this.btnGenMD5);
            this.panelTop.Controls.Add(this.btnBrowser);
            this.panelTop.Controls.Add(this.txtPath);
            this.panelTop.Controls.Add(this.labPath);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(762, 44);
            this.panelTop.TabIndex = 0;
            // 
            // labPath
            // 
            this.labPath.AutoSize = true;
            this.labPath.Location = new System.Drawing.Point(13, 14);
            this.labPath.Name = "labPath";
            this.labPath.Size = new System.Drawing.Size(41, 12);
            this.labPath.TabIndex = 0;
            this.labPath.Text = "路径：";
            // 
            // txtPath
            // 
            this.txtPath.Location = new System.Drawing.Point(60, 11);
            this.txtPath.Name = "txtPath";
            this.txtPath.Size = new System.Drawing.Size(407, 21);
            this.txtPath.TabIndex = 1;
            // 
            // btnBrowser
            // 
            this.btnBrowser.Location = new System.Drawing.Point(484, 9);
            this.btnBrowser.Name = "btnBrowser";
            this.btnBrowser.Size = new System.Drawing.Size(75, 23);
            this.btnBrowser.TabIndex = 2;
            this.btnBrowser.Text = "浏览..";
            this.btnBrowser.UseVisualStyleBackColor = true;
            this.btnBrowser.Click += new System.EventHandler(this.btnBrowser_Click);
            // 
            // btnGenMD5
            // 
            this.btnGenMD5.Location = new System.Drawing.Point(655, 9);
            this.btnGenMD5.Name = "btnGenMD5";
            this.btnGenMD5.Size = new System.Drawing.Size(75, 23);
            this.btnGenMD5.TabIndex = 3;
            this.btnGenMD5.Text = "生成MD5";
            this.btnGenMD5.UseVisualStyleBackColor = true;
            this.btnGenMD5.Click += new System.EventHandler(this.btnGenMD5_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 360);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(762, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(131, 17);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colFileName,
            this.colMD5});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 44);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(762, 316);
            this.dataGridView1.TabIndex = 2;
            // 
            // colFileName
            // 
            this.colFileName.HeaderText = "文件名";
            this.colFileName.Name = "colFileName";
            this.colFileName.Width = 380;
            // 
            // colMD5
            // 
            this.colMD5.HeaderText = "MD5";
            this.colMD5.Name = "colMD5";
            this.colMD5.Width = 260;
            // 
            // btnGetFile
            // 
            this.btnGetFile.Location = new System.Drawing.Point(572, 9);
            this.btnGetFile.Name = "btnGetFile";
            this.btnGetFile.Size = new System.Drawing.Size(75, 23);
            this.btnGetFile.TabIndex = 4;
            this.btnGetFile.Text = "获取文件";
            this.btnGetFile.UseVisualStyleBackColor = true;
            this.btnGetFile.Click += new System.EventHandler(this.btnGetFile_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(762, 382);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.panelTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "Form1";
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Button btnGenMD5;
        private System.Windows.Forms.Button btnBrowser;
        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.Label labPath;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFileName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMD5;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button btnGetFile;
    }
}

