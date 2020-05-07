using LabelPrinter.Common;
using LabelPrinter.Domain;
using LabelPrinter.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LabelPrinter
{
    public partial class LabelStyleItemPropertyAddEditForm : Form
    {
        private DataHelper dataHelper = null;

        public LabelStyleItemProperty itemProperty = null;
        public LabelStyleItemPropertyAddEditForm()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterParent;

            dataHelper = new DataHelper();
        }

        private void LabelStyleItemPropertyAddEditForm_Load(object sender, EventArgs e)
        {
            this.cboPropertyType.BindEnum<LabelStyleItemPropertyType>();
            this.cboPropertyValueType.BindEnum<LabelStyleItemPropertyValueType>();
            ShowDetail();
        }

        private void ShowDetail()
        {
            if (this.itemProperty != null)
            {
                this.cboPropertyType.SelectedValue = this.itemProperty.PropertyType;
                this.cboPropertyValueType.SelectedValue = this.itemProperty.PropertyValueType;
                this.txtPropertyValue.Text = this.itemProperty.PropertyValue;
                this.txtRemark.Text = this.itemProperty.Remark;
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


        private void linkAddEditScript_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var form = new ScriptSelectForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
                this.txtPropertyValue.Text = form.ScriptID.ToString();
            }
        }

        private bool SaveDate()
        {
            if (this.itemProperty == null) return false;
            if (this.itemProperty.ID > 0)
            {
                return this.dataHelper.UpdateLabelStyleItemProperty(this.itemProperty);
            }
            else 
            {
                return this.dataHelper.AddLabelStyleItemProperty(this.itemProperty);
            }
        }

        private bool ValidateInput()
        {
            if (this.itemProperty == null) return false;
            if (this.itemProperty.PropertyType == LabelStyleItemPropertyType.Unknown)
            {
                MessageBox.Show("请选择属性类型", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (this.itemProperty.PropertyValueType == LabelStyleItemPropertyValueType.Unknown)
            {
                MessageBox.Show("请选择属性值类型", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrEmpty(this.itemProperty.PropertyValue))
            {
                MessageBox.Show("属性值不能为空", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private void PickUpData()
        {
            this.itemProperty.PropertyType = (LabelStyleItemPropertyType)this.cboPropertyType.SelectedValue;
            this.itemProperty.PropertyValueType = (LabelStyleItemPropertyValueType)this.cboPropertyValueType.SelectedValue;
            this.itemProperty.PropertyValue = this.txtPropertyValue.Text.Trim();
            this.itemProperty.Remark = this.txtRemark.Text;
        }
    }
}
