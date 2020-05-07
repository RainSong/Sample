using LabelPrinter.Domain;
using LabelPrinter.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LabelPrinter
{
    public partial class ManageForm : Form
    {
        private DataHelper dataHelper = null;
        public ManageForm()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            dataHelper = new DataHelper();

            this.gridStyle.AutoGenerateColumns
                = this.gridStyleCarItem.AutoGenerateColumns
                = this.gridStyleItem.AutoGenerateColumns
                = this.gridProperty.AutoGenerateColumns
                = false;
        }

        private void ManageForm_Load(object sender, EventArgs e)
        {
            BindStyleGrid();
        }

        private void gridStyle_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                var data = this.gridStyle.Rows[e.RowIndex].DataBoundItem as LabelStyle;
                if (data != null)
                {
                    BindCarItemGrid(data.ID);
                    BindStyleItemGrid(data.ID);
                }
            }
        }

        private void gridStyleItem_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                var data = this.gridStyleItem.Rows[e.RowIndex].DataBoundItem as LabelStyleItem;
                if (data != null)
                {
                    BindPropertyGrid(data.ID);
                }
            }
        }

        private void CustomButton_Click(object sender, EventArgs e)
        {
            var btn = sender as Button;
            if (btn == null) return;
            var tag = btn.Tag?.ToString();
            if (string.IsNullOrEmpty(tag)) return;
            switch (tag)
            {
                case "ADD_STYLE":
                    ShowAddStyle();
                    break;
                case "EDIT_STYLE":
                    ShowEditStyle();
                    break;
                case "DELETE_STYLE":
                    DelteStyle();
                    break;
                case "ADD_CARITEM":
                    ShowAddCarItem();
                    break;
                case "EDIT_CARITEM":
                    ShowEditCarItem();
                    break;
                case "DELETE_CARITEM":
                    DeleteCarItem();
                    break;
                case "ADD_ITEM":
                    ShowAddStyleItem();
                    break;
                case "EDIT_ITEM":
                    ShowEditStyleItem();
                    break;
                case "DELETE_ITEM":
                    DeleteStyleItem();
                    break;
                case "ADD_PROPERTY":
                    ShowAddStyleItemProperty();
                    break;
                case "EDIT_PROPERTY":
                    ShowEditStyleItemProperty();
                    break;
                case "DELETE_PROPERTY":
                    DeleteStyleItemProperty();
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// 在行标头中添加编号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void grid_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            // https://stackoverflow.com/questions/9581626/show-row-number-in-row-header-of-a-datagridview
            var grid = sender as DataGridView;
            var rowIdx = (e.RowIndex + 1).ToString();

            var centerFormat = new StringFormat()
            {
                // right alignment might actually make more sense for numbers
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };

            var headerBounds = new Rectangle(e.RowBounds.Left, e.RowBounds.Top, grid.RowHeadersWidth, e.RowBounds.Height);
            e.Graphics.DrawString(rowIdx, this.Font, SystemBrushes.ControlText, headerBounds, centerFormat);
        }

        private void BindStyleGrid()
        {
            Action<IEnumerable<LabelStyle>> bind = (data) =>
            {
                this.gridStyle.DataSource = data;
            };
            Task task = new Task(() =>
            {
                var labelStyles = dataHelper.GetLabelStyles();
                if (this.gridStyle.InvokeRequired)
                {
                    this.gridStyle.Invoke(bind, labelStyles);
                }
                else
                {
                    bind(labelStyles);
                }
            });
            task.Start();
        }

        private void BindCarItemGrid(int styleId)
        {
            Action<IEnumerable<LabelStyleCarItem>> bind = (data) =>
            {
                this.gridStyleCarItem.DataSource = data;
            };
            Task task = new Task(() =>
            {
                var styleCarItems = dataHelper.GetStyleCarItemsByStyle(styleId);
                if (this.gridStyle.InvokeRequired)
                {
                    this.gridStyle.Invoke(bind, styleCarItems);
                }
                else
                {
                    bind(styleCarItems);
                }
            });
            task.Start();
        }

        private void BindStyleItemGrid(int styleId)
        {
            Action<IEnumerable<LabelStyleItem>> bind = (data) =>
            {
                this.gridStyleItem.DataSource = data;
            };
            Task task = new Task(() =>
            {
                var styleItems = dataHelper.GetItemsByStyle(styleId);
                if (this.gridStyle.InvokeRequired)
                {
                    this.gridStyleItem.Invoke(bind, styleItems);
                }
                else
                {
                    bind(styleItems);
                }
            });
            task.Start();
        }

        private void BindPropertyGrid(int itemId)
        {
            Action<IEnumerable<LabelStyleItemProperty>> bind = (data) =>
            {
                this.gridProperty.DataSource = data;
            };
            Task task = new Task(() =>
            {
                var properties = dataHelper.GetPropertiesByItem(itemId);
                if (this.gridStyle.InvokeRequired)
                {
                    this.gridProperty.Invoke(bind, properties);
                }
                else
                {
                    bind(properties);
                }
            });
            task.Start();
        }

        #region 标签样式增删改
        private void ShowAddStyle()
        {
            var form = new LabelStyleAddEditForm
            {
                Text = "添加标签样式"
            };
            if (form.ShowDialog() == DialogResult.OK)
            {
                this.gridStyle.DataSource = null;
                this.gridStyleCarItem.DataSource = null;
                this.gridStyleItem.DataSource = null;
                this.gridProperty.DataSource = null;

                BindStyleGrid();
            }
        }

        private void ShowEditStyle()
        {
            var style = GetSelectedStyle();
            if (style == null)
            {
                MessageBox.Show("请选择标要修改签样式", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var form = new LabelStyleAddEditForm
            {
                Text = "修改标签样式",
                LabelStyle = style
            };
            if (form.ShowDialog() == DialogResult.OK)
            {
                this.gridStyle.DataSource = null;
                this.gridStyleCarItem.DataSource = null;
                this.gridStyleItem.DataSource = null;
                this.gridProperty.DataSource = null;

                BindStyleGrid();
            }
        }

        private void DelteStyle()
        {
            var style = GetSelectedStyle();
            if (style == null)
            {
                MessageBox.Show("请选择标删除改签样式", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                var text = "确定要删除这个标签样式吗";
                var caption = "提示";
                if (MessageBox.Show(text, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (dataHelper.DeleteLabelStyle(style.ID))
                    {
                        this.gridStyle.DataSource = null;
                        this.gridStyleCarItem.DataSource = null;
                        this.gridStyleItem.DataSource = null;
                        this.gridProperty.DataSource = null;

                        BindStyleGrid();
                    }
                }
            }
        }

        private LabelStyle GetSelectedStyle()
        {
            if (this.gridStyle.SelectedRows.Count == 0)
            {
                return null;
            }
            var style = this.gridStyle.SelectedRows[0].DataBoundItem as LabelStyle;
            return style;
        }
        #endregion

        #region 标签适用车种增删改

        private void ShowAddCarItem()
        {
            var style = GetSelectedStyle();
            var styleId = style == null ? 0 : style.ID;
            var form = new LabelStyleCarItemAddEditForm
            {
                Text = "添加标签适用车种",
                LabelStyleCarItem = new LabelStyleCarItem
                {
                    StyleID = styleId
                }
            };
            if (form.ShowDialog() == DialogResult.OK)
            {
                this.gridStyleCarItem.DataSource = null;
                if (styleId > 0)
                    BindCarItemGrid(styleId);
            }
        }

        private void ShowEditCarItem()
        {
            var styleCarItem = GetSelectLabelStyleCarItem();
            if (styleCarItem == null)
            {
                MessageBox.Show("请选择标要修改的车种", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var form = new LabelStyleCarItemAddEditForm
            {
                Text = "修改标签适用车种",
                LabelStyleCarItem = styleCarItem
            };
            if (form.ShowDialog() == DialogResult.OK)
            {
                this.gridStyleCarItem.DataSource = null;

                BindCarItemGrid(styleCarItem.StyleID);
            }
        }

        private void DeleteCarItem()
        {
            var styleCarItem = GetSelectLabelStyleCarItem();
            if (styleCarItem == null)
            {
                MessageBox.Show("请选择标删除车种", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                var text = "请选择标删除车种";
                var caption = "提示";
                if (MessageBox.Show(text, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (dataHelper.DeleteLabelStleCarItem(styleCarItem.ID))
                    {
                        this.gridStyleCarItem.DataSource = null;

                        BindCarItemGrid(styleCarItem.StyleID);
                    }
                }
            }
        }

        private LabelStyleCarItem GetSelectLabelStyleCarItem()
        {
            if (this.gridStyleCarItem.SelectedRows.Count == 0)
            {
                return null;
            }
            var styleCarItem = this.gridStyleCarItem.SelectedRows[0].DataBoundItem as LabelStyleCarItem;
            return styleCarItem;
        }
        #endregion

        #region 标签适用车种增删改

        private void ShowAddStyleItem()
        {
            var style = GetSelectedStyle();
            var styleId = style == null ? 0 : style.ID;
            var form = new LabelStyleItemAddEditForm
            {
                Text = "添加标签适用车种",
                LabelStyleItem = new LabelStyleItem
                {
                    StyleID = styleId
                }
            };
            if (form.ShowDialog() == DialogResult.OK)
            {
                this.gridStyleItem.DataSource = null;
                if (styleId > 0)
                    BindStyleItemGrid(styleId);
            }
        }

        private void ShowEditStyleItem()
        {
            var styleItem = GetSelectLabelStyleItem();
            if (styleItem == null)
            {
                MessageBox.Show("请选择标要修改项", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var form = new LabelStyleItemAddEditForm
            {
                Text = "修改标签项",
                LabelStyleItem = styleItem
            };
            if (form.ShowDialog() == DialogResult.OK)
            {
                this.gridStyleItem.DataSource = null;
                if (styleItem.StyleID > 0)
                    BindStyleItemGrid(styleItem.StyleID);
            }
        }

        private void DeleteStyleItem()
        {
            var styleItem = GetSelectLabelStyleItem();
            if (styleItem == null)
            {
                MessageBox.Show("请选择标要删除的项目", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                var text = "确定要删除";
                var caption = "提示";
                if (MessageBox.Show(text, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (dataHelper.DeleteLabelStleItem(styleItem.ID))
                    {
                        this.gridStyleItem.DataSource = null;
                        BindStyleItemGrid(styleItem.StyleID);
                    }
                }
            }
        }

        private LabelStyleItem GetSelectLabelStyleItem()
        {
            if (this.gridStyleItem.SelectedRows.Count == 0)
            {
                return null;
            }
            var styleCarItem = this.gridStyleItem.SelectedRows[0].DataBoundItem as LabelStyleItem;
            return styleCarItem;
        }
        #endregion

        #region 标签项属性增删改
        private void ShowAddStyleItemProperty()
        {
            var style = GetSelectedStyle();
            if (style == null)
            {
                MessageBox.Show("请选择标签样式", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var item = GetSelectLabelStyleItem();
            if (item == null)
            {
                MessageBox.Show("请选择标签项", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var form = new LabelStyleItemPropertyAddEditForm
            {
                Text = "添加标签适用车种",
                itemProperty = new LabelStyleItemProperty
                {
                    StyleID = style.ID,
                    ItemID = item.ID
                }
            };
            if (form.ShowDialog() == DialogResult.OK)
            {
                this.gridProperty.DataSource = null;
                BindPropertyGrid(item.ID);
            }
        }

        private void ShowEditStyleItemProperty()
        {
            var styleItemProperty = GetSelecetLabelStyleItemProperty();
            if (styleItemProperty == null)
            {
                MessageBox.Show("请选择标要修改项", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var form = new LabelStyleItemPropertyAddEditForm
            {
                Text = "修改标属性",
                itemProperty = styleItemProperty
            };
            if (form.ShowDialog() == DialogResult.OK)
            {
                this.gridProperty.DataSource = null;
                if (styleItemProperty.ItemID > 0)
                    BindPropertyGrid(styleItemProperty.ItemID);
            }
        }

        private void DeleteStyleItemProperty()
        {
            var styleItemProperty = GetSelecetLabelStyleItemProperty();
            if (styleItemProperty == null)
            {
                MessageBox.Show("请选择标要删除的属性", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                var text = "确定要删除";
                var caption = "提示";
                if (MessageBox.Show(text, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (dataHelper.DeleteLabelStyleItemProperty(styleItemProperty.ID))
                    {
                        this.gridProperty.DataSource = null;
                        BindPropertyGrid(styleItemProperty.ItemID);
                    }
                }
            }
        }

        private LabelStyleItemProperty GetSelecetLabelStyleItemProperty()
        {
            if (this.gridProperty.SelectedRows.Count == 0) return null;
            return this.gridProperty.SelectedRows[0].DataBoundItem as LabelStyleItemProperty;
        }
        #endregion

    }
}
