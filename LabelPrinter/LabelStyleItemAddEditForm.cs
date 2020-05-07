using System;
using System.Windows.Forms;

using LabelPrinter.Common;
using LabelPrinter.Domain;
using LabelPrinter.Domain.Models;

namespace LabelPrinter
{
    public partial class LabelStyleItemAddEditForm : Form
    {
        public LabelStyleItem LabelStyleItem { get; set; }

        private DataHelper dataHelper;
        public LabelStyleItemAddEditForm()
        {
            InitializeComponent();
            dataHelper = new DataHelper();
            this.StartPosition = FormStartPosition.CenterParent;
        }

        private void LabelStyleItemAddEditForm_Load(object sender, EventArgs e)
        {
            BindCombobox();
            ShowDetial();
        }

        private void ShowDetial()
        {
            if (this.LabelStyleItem.ID > 0) 
            {
                this.cboItemType.SelectedValue = this.LabelStyleItem.ItemType;
                this.cboValueType.SelectedValue = this.LabelStyleItem.ValueType;
                this.txtData.Text = this.LabelStyleItem.Data;
                this.txtRemark.Text = this.LabelStyleItem.Remark;
            }
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
                if (SaveData())
                {
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("发生错误，保存失败", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private bool SaveData()
        {
            if(this.LabelStyleItem.ID > 0)
            {
                return dataHelper.UpdateLabelStyleItem(this.LabelStyleItem);
            }
            else
            {
                return dataHelper.AddLabelStyleItem(this.LabelStyleItem);
            }
        }

        private bool ValidateInput()
        {
            if(this.LabelStyleItem.ItemType == LabelStyleItemType.Unknown)
            {
                MessageBox.Show("请选择项目类型", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (this.LabelStyleItem.ItemType != LabelStyleItemType.Line 
                && this.LabelStyleItem.ValueType == LabelStyleItemValueType.Unknown)
            {
                MessageBox.Show("请选择项目值类型", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrEmpty(this.LabelStyleItem.Data))
            {
                MessageBox.Show("请输入项目值", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private void PickUpData()
        {
            this.LabelStyleItem.ItemType = (LabelStyleItemType)(this.cboItemType.SelectedValue ?? LabelStyleItemType.Unknown);
            this.LabelStyleItem.ValueType = (LabelStyleItemValueType)(this.cboValueType.SelectedValue ?? LabelStyleItemValueType.Unknown);
            this.LabelStyleItem.Data = this.txtData.Text.Trim();
            this.LabelStyleItem.Remark = this.txtRemark.Text.Trim();
        }

        private void BindCombobox() 
        {
            this.cboItemType.BindEnum<LabelStyleItemType>();
            this.cboValueType.BindEnum<LabelStyleItemValueType>();
        }

        private void linkAddEditScript_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var form = new ScriptSelectForm();
            if (form.ShowDialog() == DialogResult.OK) 
            {
                this.txtData.Text = form.ScriptID.ToString();
            }
        }
    }
}
