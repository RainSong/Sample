
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LabelPrinter.Common;
using LabelPrinter.Domain;
using LabelPrinter.Domain.Models;

namespace LabelPrinter
{
    public partial class LabelStyleAddEditForm : Form
    {
        public LabelStyle LabelStyle { get; set; }

        private DataHelper dataHelper = null;
        public LabelStyleAddEditForm()
        {
            InitializeComponent();
            dataHelper = new DataHelper();
            StartPosition = FormStartPosition.CenterParent;
        }
        private void LabelStyleAddEditForm_Load(object sender, EventArgs e)
        {
            this.cboType.BindEnum<LabelType>();
            ShowDetial();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            PickUpData();
            if (ValidateInput()) 
            {
                if (SaveDate())
                {
                    this.DialogResult = DialogResult.OK;
                }
                else 
                {
                    MessageBox.Show("发生错误，保存失败", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void PickUpData() 
        {
            if (this.LabelStyle == null)
                this.LabelStyle = new LabelStyle();
            this.LabelStyle.Width = (int)this.nudWidth.Value;
            this.LabelStyle.Height = (int)this.nudHeight.Value;
            this.LabelStyle.LabelType = (LabelType)((int)this.cboType.SelectedValue);
            this.LabelStyle.Remark = this.txtRemark.Text.Trim();
            this.LabelStyle.Name = this.txtName.Text.Trim();
        }

        private bool ValidateInput() 
        {
            if (this.LabelStyle == null) return false;
            if (string.IsNullOrEmpty(this.LabelStyle.Name))
            {
                MessageBox.Show("标签名称不能为空", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (this.LabelStyle.Width <= 0)
            {
                MessageBox.Show("标签宽度必须大于0", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (this.LabelStyle.Width <= 0)
            {
                MessageBox.Show("标签高度必须大于0", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        private bool SaveDate() 
        {
            if (this.LabelStyle.ID > 0)
            {
                return dataHelper.UpdateLabelStyle(this.LabelStyle);
            }
            else
            {
                return dataHelper.AddLabelStyle(this.LabelStyle);
            }
        }

        private void ShowDetial() 
        {
            if (this.LabelStyle == null) return;
            this.nudWidth.Value = (decimal)this.LabelStyle.Width;
            this.nudHeight.Value = (decimal)this.LabelStyle.Height;
            this.cboType.SelectedValue = this.LabelStyle.LabelType;
            this.txtRemark.Text = this.LabelStyle.Remark;
            this.txtName.Text = this.LabelStyle.Name;
        }

    }
}
