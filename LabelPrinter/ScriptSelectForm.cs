using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

using ScintillaNET;

using LabelPrinter.Domain;
using LabelPrinter.Domain.Models;

namespace LabelPrinter
{
    public partial class ScriptSelectForm : Form
    {
        public int ScriptID { get; set; }

        private DataHelper dataHelper;
        private Script selectedScript;
        public ScriptSelectForm()
        {
            InitializeComponent();
            InitSyntaxColoring();

            this.StartPosition = FormStartPosition.CenterParent;
            this.gridScript.AutoGenerateColumns = false;

            dataHelper = new DataHelper();
        }

        private void ScriptSelectForm_Load(object sender, EventArgs e)
        {
            BindScriptGrid();
        }

        private void btnSure_Click(object sender, EventArgs e)
        {
            var selectedScript = GetSelectedScript();
            if(selectedScript == null)
            {
                MessageBox.Show("请选择脚本", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            this.ScriptID = selectedScript.ID;
            this.DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private Script GetSelectedScript() 
        {
            if (this.gridScript.SelectedRows.Count == 0)
                return null;
            return this.gridScript.SelectedRows[0].DataBoundItem as Script;
        }

        private void BindScriptGrid() 
        {
            Action<IEnumerable<Script>> ac = dataSource => 
            {
                this.gridScript.DataSource = dataSource;
            };
            Task task = new Task(() =>
            {
                var scripts = dataHelper.GetScripts();
                if (this.gridScript.InvokeRequired)
                {
                    this.gridScript.Invoke(ac, scripts);
                }
                else {
                    ac(scripts);
                }
            });
            task.Start();
        }

        private void InitSyntaxColoring()
        {

            // Configure the default style
            this.txtScript.StyleResetDefault();
            this.txtScript.Styles[Style.Default].Font = "Consolas";
            this.txtScript.Styles[Style.Default].Size = 12;
            //this.txtScript.Styles[Style.Default].BackColor = IntToColor(0x212121);
            this.txtScript.Styles[Style.Default].ForeColor = IntToColor(0xFFFFFF);
            this.txtScript.StyleClearAll();

            // Configure the CPP (C#) lexer styles
            
            this.txtScript.Styles[Style.Cpp.Identifier].ForeColor = IntToColor(0x000000);
            this.txtScript.Styles[Style.Cpp.Number].ForeColor = IntToColor(0x000000);
            this.txtScript.Styles[Style.Cpp.String].ForeColor = IntToColor(0xA31515);
            this.txtScript.Styles[Style.Cpp.Character].ForeColor = IntToColor(0xA31515);
            this.txtScript.Styles[Style.Cpp.Preprocessor].ForeColor = IntToColor(0x0000FF);
            this.txtScript.Styles[Style.Cpp.Operator].ForeColor = IntToColor(0x000000);
            this.txtScript.Styles[Style.Cpp.Word].ForeColor = IntToColor(0x0000FF);
            this.txtScript.Styles[Style.Cpp.Word2].ForeColor = IntToColor(0x2B91AF);

            this.txtScript.Styles[Style.Cpp.Comment].ForeColor = IntToColor(0x008000);
            this.txtScript.Styles[Style.Cpp.CommentLine].ForeColor = IntToColor(0x008000);
            this.txtScript.Styles[Style.Cpp.CommentLineDoc].ForeColor = IntToColor(0x808080);

            this.txtScript.Styles[Style.Cpp.CommentDoc].ForeColor = IntToColor(0x2FAE35);
            this.txtScript.Styles[Style.Cpp.CommentDocKeyword].ForeColor = IntToColor(0xB3D991);
            this.txtScript.Styles[Style.Cpp.CommentDocKeywordError].ForeColor = IntToColor(0xFF0000);

            this.txtScript.Styles[Style.Cpp.GlobalClass].ForeColor = IntToColor(0x48A8EE);
            this.txtScript.Styles[Style.Cpp.Regex].ForeColor = IntToColor(0xff00ff);

            this.txtScript.Lexer = Lexer.Cpp;

            this.txtScript.SetKeywords(0, "class extends implements import interface new case do while else if for in switch throw get set function var try catch finally while with default break continue delete return each const namespace package include use is as instanceof typeof author copy default deprecated eventType example exampleText exception haxe inheritDoc internal link mtasc mxmlc param private return see serial serialData serialField since throws usage version langversion playerversion productversion dynamic private public partial static intrinsic internal native override protected AS3 final super this arguments null Infinity NaN undefined true false abstract as base bool break by byte case catch char checked class const continue decimal default delegate do double descending explicit event extern else enum false finally fixed float for foreach from goto group if implicit in int interface internal into is lock long new null namespace object operator out override orderby params private protected public readonly ref return switch struct sbyte sealed short sizeof stackalloc static string select this throw true try typeof uint ulong unchecked unsafe ushort using var virtual volatile void while where yield Regex");
            this.txtScript.SetKeywords(1, "void Null ArgumentError arguments Array Boolean Class Date DefinitionError Error EvalError Function int Math Namespace Number Object RangeError ReferenceError RegExp SecurityError String SyntaxError TypeError uint XML XMLList Boolean Byte Char DateTime Decimal Double Int16 Int32 Int64 IntPtr SByte Single UInt16 UInt32 UInt64 UIntPtr Void Path File Array Windows Forms ScintillaNET");

        }
        public static Color IntToColor(int rgb)
        {
            return Color.FromArgb(255, (byte)(rgb >> 16), (byte)(rgb >> 8), (byte)rgb);
        }

        private void gridScript_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                this.selectedScript = GetSelectedScript();
            ShowDetail();
        }

        private void btnInit_Click(object sender, EventArgs e)
        {
            this.selectedScript = null;
            ClearRegControls();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            PickUpData();
            if (ValidateInput())
            {
                if (SaveDate())
                {
                    this.selectedScript = null;
                    ClearRegControls();

                    BindScriptGrid();
                }
                else
                {
                    MessageBox.Show("发生错误，保存失败", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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

        private bool SaveDate()
        {
            if(this.selectedScript.ID > 0)
            {
                return dataHelper.UpdateScript(this.selectedScript);
            }
            else
            {
                return dataHelper.AddScript(this.selectedScript);
            }
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrEmpty(this.selectedScript.Name))
            {
                MessageBox.Show("请输入脚本名称", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrEmpty(this.selectedScript.KeyCode))
            {
                MessageBox.Show("请输入脚本关键字", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrEmpty(this.selectedScript.ScriptContent))
            {
                MessageBox.Show("请输入脚本内容", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private void PickUpData()
        {
            if (this.selectedScript == null)
                this.selectedScript = new Script();
            this.selectedScript.Name = this.txtName.Text.Trim();
            this.selectedScript.KeyCode = this.txtKeyCode.Text.Trim();
            this.selectedScript.ScriptContent = this.txtScript.Text.Trim();
            this.selectedScript.Remark = this.txtRemark.Text.Trim();
        }

        private void ClearRegControls() 
        {
            this.txtKeyCode.Clear();
            this.txtName.Clear();
            this.txtScript.Text  = string.Empty;
            this.txtRemark.Clear();
        }

        private void ShowDetail()
        {
            ClearRegControls();
            if (this.selectedScript != null)
            {
                this.txtName.Text = this.selectedScript.Name;
                this.txtKeyCode.Text = this.selectedScript.KeyCode;
                this.txtScript.Text = this.selectedScript.ScriptContent;
                this.txtRemark.Text = this.selectedScript.Remark;
            }
        }

    }
}
