
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;

using LabelPrinter.Common;
using LabelPrinter.Domain;
using LabelPrinter.Domain.Models;

namespace LabelPrinter
{
    public partial class TestForm : Form
    {
        DataHelper dataHelper = null;

        private int carSeqn = 0;
        private int carItemSeqn = 0;

        private float labelWidth = 0F;
        private float labelHeight = 0F;

        private float offsetX = 0F;
        private float offsetY = 0F;

        private List<LabelStyle> labelStyles = null;
        public TestForm()
        {
            InitializeComponent();
            dataHelper = new DataHelper();
            labelStyles = new List<LabelStyle>();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            BindCombobox();
            SetEvents();

            this.cboCar.SelectedValue = 48;
            this.cboCarItem.SelectedValue = 131;

            this.carSeqn = (int)(this.cboCar.SelectedValue ?? 0);
            this.carItemSeqn = (int)(this.cboCarItem.SelectedValue ?? 0);
            this.labelWidth = (float)this.nudLabelWidth.Value;
            this.labelHeight = (float)this.nudLabelHeight.Value;
            this.offsetX = (float)this.nudOffsetX.Value;
            this.offsetY = (float)this.nudOffsetY.Value;
        }

        private void SetEvents()
        {
            this.cboCar.SelectedIndexChanged += (sender, args) =>
            {
                this.carSeqn = (int)(this.cboCar.SelectedValue ?? 0);
            };
            this.cboCar.SelectedIndexChanged += (sender, args) =>
            {
                this.carItemSeqn = (int)(this.cboCarItem.SelectedValue ?? 0);
            };

            this.nudLabelWidth.ValueChanged += (sender, args) =>
            {
                this.labelWidth = (float)this.nudLabelWidth.Value;
            };
            this.nudLabelHeight.ValueChanged += (sender, args) =>
            {
                this.labelHeight = (float)this.nudLabelHeight.Value;
            };

            this.nudOffsetX.ValueChanged += (sender, args) =>
            {
                this.offsetX = (float)this.nudOffsetX.Value;
            };
            this.nudOffsetY.ValueChanged += (sender, args) =>
            {
                this.offsetY = (float)this.nudOffsetY.Value;
            };
        }

        private void BindCombobox()
        {
            try
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
            catch (Exception ex)
            {
                Logger.Error("query faild.", ex);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            var style = labelStyles.FirstOrDefault(o => o.CarItems != null && o.CarItems.Any(c => c.CarSeqn == carSeqn && c.CarItemSeqn == carItemSeqn));

            if (style == null)
            {
                style = dataHelper.GetLabelStyle(carSeqn, carItemSeqn);
                labelStyles.Add(style);
            }

            var data = new Dictionary<string, object>
            {
                { "SUPPLIER_CODE", "ALZY" },
                { "TRANSFER_PARTNO", "ABCDE-FGHIJ KLM" },
                { "TRANSFER_ALC", "ALCALCAL" },
                { "TRANSFER_EONO", "EONOEONO" },
                { "SERVER_DATE", DateTime.Now },
                { "LINE_SEQ", "A" },
                { "INSPECT_SEQ", 0001 },
                { "FIRST_INPUT", false },
                { "CAR_NAME", this.cboCar.Text },
                { "CAR_ITEM_NAME", this.cboCarItem.Text}
            };

            var printer = new LtpPrinterBuilder().Build(data, style, "");
            this.picPreview.BackgroundImage = printer.Preview(this.labelWidth, this.labelHeight, this.offsetX, this.offsetY);
        }
    }
}
