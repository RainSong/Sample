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
    public partial class LabelStyleCarItemAddEditForm : Form
    {
        public LabelStyleCarItem LabelStyleCarItem { get; set; }

        private DataHelper dataHelper = null;
        public LabelStyleCarItemAddEditForm()
        {
            InitializeComponent();
            dataHelper = new DataHelper();
            this.StartPosition = FormStartPosition.CenterParent;
        }

        private void LabelStyleCarItemAddEditForm_Load(object sender, EventArgs e)
        {
            BindCombobox();
            DisplayDetail();
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
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private bool SaveDate()
        {
            if (this.LabelStyleCarItem.ID > 0)
            {
                return dataHelper.UpdateLabelStyleCarItem(LabelStyleCarItem);
            }
            else
            {
                return dataHelper.AddLabelStyleCarItem(LabelStyleCarItem);
            }
        }

        private bool ValidateInput()
        {
            if (this.LabelStyleCarItem.CarSeqn <= 0)
            {
                MessageBox.Show("请选择车种", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (this.LabelStyleCarItem.CarItemSeqn <= 0)
            {
                MessageBox.Show("请选择品名", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void PickUpData()
        {
            if (this.LabelStyleCarItem == null)
                this.LabelStyleCarItem = new LabelStyleCarItem();
            this.LabelStyleCarItem.CarSeqn = (int)(this.cboCar.SelectedValue ?? 0);
            this.LabelStyleCarItem.CarItemSeqn = (int)(this.cboCarItem.SelectedValue ?? 0);
        }

        private void BindCombobox()
        {
            var cars = dataHelper.GetCars();
            this.cboCar.DataSource = cars;
            this.cboCar.DisplayMember = "CarName";
            this.cboCar.ValueMember = "CarSeqn";

            var carItems = dataHelper.GetCarItems();
            this.cboCarItem.DataSource = carItems;
            this.cboCarItem.DisplayMember = "CarItemName";
            this.cboCarItem.ValueMember = "CarItemSeqn";
        }

        private void DisplayDetail()
        {
            if (this.LabelStyleCarItem == null) return;
            this.cboCar.SelectedValue = this.LabelStyleCarItem.CarSeqn;
            this.cboCarItem.SelectedValue = this.LabelStyleCarItem.CarItemSeqn;
        }

    }
}
