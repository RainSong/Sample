namespace LabelPrinter
{
    partial class ManageForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.spcMain = new System.Windows.Forms.SplitContainer();
            this.spcLeft = new System.Windows.Forms.SplitContainer();
            this.gridStyle = new System.Windows.Forms.DataGridView();
            this.colID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLabelStyle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colWidth = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHeight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRemark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.btnDeleteStyle = new System.Windows.Forms.Button();
            this.btnEditStyle = new System.Windows.Forms.Button();
            this.btnAddStyle = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.gridStyleCarItem = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCarName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCarItemName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.spcRight = new System.Windows.Forms.SplitContainer();
            this.gridStyleItem = new System.Windows.Forms.DataGridView();
            this.colSytleItemID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStyleItemType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStyleItemValueType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStyleItemDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStyleItemRemark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.gridProperty = new System.Windows.Forms.DataGridView();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.colStyleItemPropteryID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSytleItemPropertyType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSytleItemPropertyValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colValueType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.spcMain)).BeginInit();
            this.spcMain.Panel1.SuspendLayout();
            this.spcMain.Panel2.SuspendLayout();
            this.spcMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spcLeft)).BeginInit();
            this.spcLeft.Panel1.SuspendLayout();
            this.spcLeft.Panel2.SuspendLayout();
            this.spcLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridStyle)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridStyleCarItem)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spcRight)).BeginInit();
            this.spcRight.Panel1.SuspendLayout();
            this.spcRight.Panel2.SuspendLayout();
            this.spcRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridStyleItem)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridProperty)).BeginInit();
            this.panel4.SuspendLayout();
            this.panel8.SuspendLayout();
            this.SuspendLayout();
            // 
            // spcMain
            // 
            this.spcMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spcMain.Location = new System.Drawing.Point(0, 0);
            this.spcMain.Name = "spcMain";
            // 
            // spcMain.Panel1
            // 
            this.spcMain.Panel1.Controls.Add(this.spcLeft);
            // 
            // spcMain.Panel2
            // 
            this.spcMain.Panel2.Controls.Add(this.spcRight);
            this.spcMain.Size = new System.Drawing.Size(1118, 645);
            this.spcMain.SplitterDistance = 537;
            this.spcMain.TabIndex = 1;
            // 
            // spcLeft
            // 
            this.spcLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spcLeft.Location = new System.Drawing.Point(0, 0);
            this.spcLeft.Name = "spcLeft";
            this.spcLeft.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // spcLeft.Panel1
            // 
            this.spcLeft.Panel1.Controls.Add(this.gridStyle);
            this.spcLeft.Panel1.Controls.Add(this.panel1);
            this.spcLeft.Panel1.Padding = new System.Windows.Forms.Padding(5);
            // 
            // spcLeft.Panel2
            // 
            this.spcLeft.Panel2.Controls.Add(this.gridStyleCarItem);
            this.spcLeft.Panel2.Controls.Add(this.panel2);
            this.spcLeft.Size = new System.Drawing.Size(537, 645);
            this.spcLeft.SplitterDistance = 323;
            this.spcLeft.TabIndex = 0;
            // 
            // gridStyle
            // 
            this.gridStyle.BackgroundColor = System.Drawing.SystemColors.Control;
            this.gridStyle.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gridStyle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridStyle.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colID,
            this.colName,
            this.colLabelStyle,
            this.colWidth,
            this.colHeight,
            this.colRemark});
            this.gridStyle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridStyle.Location = new System.Drawing.Point(5, 35);
            this.gridStyle.Name = "gridStyle";
            this.gridStyle.ReadOnly = true;
            this.gridStyle.RowTemplate.Height = 23;
            this.gridStyle.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridStyle.Size = new System.Drawing.Size(527, 283);
            this.gridStyle.TabIndex = 1;
            this.gridStyle.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridStyle_CellDoubleClick);
            this.gridStyle.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.grid_RowPostPaint);
            // 
            // colID
            // 
            this.colID.DataPropertyName = "ID";
            this.colID.HeaderText = "ID";
            this.colID.Name = "colID";
            this.colID.ReadOnly = true;
            this.colID.Visible = false;
            // 
            // colName
            // 
            this.colName.DataPropertyName = "Name";
            this.colName.HeaderText = "名称";
            this.colName.Name = "colName";
            this.colName.ReadOnly = true;
            // 
            // colLabelStyle
            // 
            this.colLabelStyle.DataPropertyName = "LabelType";
            this.colLabelStyle.HeaderText = "标签类型";
            this.colLabelStyle.Name = "colLabelStyle";
            this.colLabelStyle.ReadOnly = true;
            // 
            // colWidth
            // 
            this.colWidth.DataPropertyName = "Width";
            this.colWidth.HeaderText = "宽度";
            this.colWidth.Name = "colWidth";
            this.colWidth.ReadOnly = true;
            // 
            // colHeight
            // 
            this.colHeight.DataPropertyName = "Height";
            this.colHeight.HeaderText = "高度";
            this.colHeight.Name = "colHeight";
            this.colHeight.ReadOnly = true;
            // 
            // colRemark
            // 
            this.colRemark.DataPropertyName = "Remark";
            this.colRemark.HeaderText = "备注";
            this.colRemark.Name = "colRemark";
            this.colRemark.ReadOnly = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel5);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(5, 5);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(3);
            this.panel1.Size = new System.Drawing.Size(527, 30);
            this.panel1.TabIndex = 0;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.btnDeleteStyle);
            this.panel5.Controls.Add(this.btnEditStyle);
            this.panel5.Controls.Add(this.btnAddStyle);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(103, 3);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(421, 24);
            this.panel5.TabIndex = 1;
            // 
            // btnDeleteStyle
            // 
            this.btnDeleteStyle.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnDeleteStyle.Location = new System.Drawing.Point(120, 0);
            this.btnDeleteStyle.Name = "btnDeleteStyle";
            this.btnDeleteStyle.Size = new System.Drawing.Size(60, 24);
            this.btnDeleteStyle.TabIndex = 2;
            this.btnDeleteStyle.Tag = "DELETE_STYLE";
            this.btnDeleteStyle.Text = "删除";
            this.btnDeleteStyle.UseVisualStyleBackColor = true;
            this.btnDeleteStyle.Click += new System.EventHandler(this.CustomButton_Click);
            // 
            // btnEditStyle
            // 
            this.btnEditStyle.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnEditStyle.Location = new System.Drawing.Point(60, 0);
            this.btnEditStyle.Name = "btnEditStyle";
            this.btnEditStyle.Size = new System.Drawing.Size(60, 24);
            this.btnEditStyle.TabIndex = 1;
            this.btnEditStyle.Tag = "EDIT_STYLE";
            this.btnEditStyle.Text = "修改";
            this.btnEditStyle.UseVisualStyleBackColor = true;
            this.btnEditStyle.Click += new System.EventHandler(this.CustomButton_Click);
            // 
            // btnAddStyle
            // 
            this.btnAddStyle.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnAddStyle.Location = new System.Drawing.Point(0, 0);
            this.btnAddStyle.Name = "btnAddStyle";
            this.btnAddStyle.Size = new System.Drawing.Size(60, 24);
            this.btnAddStyle.TabIndex = 0;
            this.btnAddStyle.Tag = "ADD_STYLE";
            this.btnAddStyle.Text = "添加";
            this.btnAddStyle.UseVisualStyleBackColor = true;
            this.btnAddStyle.Click += new System.EventHandler(this.CustomButton_Click);
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(3, 3);
            this.label1.Margin = new System.Windows.Forms.Padding(3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "标签样式";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // gridStyleCarItem
            // 
            this.gridStyleCarItem.BackgroundColor = System.Drawing.SystemColors.Control;
            this.gridStyleCarItem.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gridStyleCarItem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridStyleCarItem.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.colCarName,
            this.colCarItemName});
            this.gridStyleCarItem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridStyleCarItem.Location = new System.Drawing.Point(0, 30);
            this.gridStyleCarItem.Name = "gridStyleCarItem";
            this.gridStyleCarItem.ReadOnly = true;
            this.gridStyleCarItem.RowTemplate.Height = 23;
            this.gridStyleCarItem.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridStyleCarItem.Size = new System.Drawing.Size(537, 288);
            this.gridStyleCarItem.TabIndex = 3;
            this.gridStyleCarItem.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.grid_RowPostPaint);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "ID";
            this.dataGridViewTextBoxColumn1.HeaderText = "ID";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Visible = false;
            // 
            // colCarName
            // 
            this.colCarName.DataPropertyName = "CarName";
            this.colCarName.FillWeight = 120F;
            this.colCarName.HeaderText = "车种";
            this.colCarName.Name = "colCarName";
            this.colCarName.ReadOnly = true;
            // 
            // colCarItemName
            // 
            this.colCarItemName.DataPropertyName = "CarItemName";
            this.colCarItemName.FillWeight = 150F;
            this.colCarItemName.HeaderText = "品名";
            this.colCarItemName.Name = "colCarItemName";
            this.colCarItemName.ReadOnly = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel7);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(3);
            this.panel2.Size = new System.Drawing.Size(537, 30);
            this.panel2.TabIndex = 2;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.button4);
            this.panel7.Controls.Add(this.button5);
            this.panel7.Controls.Add(this.button6);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel7.Location = new System.Drawing.Point(95, 3);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(439, 24);
            this.panel7.TabIndex = 2;
            // 
            // button4
            // 
            this.button4.Dock = System.Windows.Forms.DockStyle.Left;
            this.button4.Location = new System.Drawing.Point(120, 0);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(60, 24);
            this.button4.TabIndex = 2;
            this.button4.Tag = "DELETE_CARITEM";
            this.button4.Text = "删除";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.CustomButton_Click);
            // 
            // button5
            // 
            this.button5.Dock = System.Windows.Forms.DockStyle.Left;
            this.button5.Location = new System.Drawing.Point(60, 0);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(60, 24);
            this.button5.TabIndex = 1;
            this.button5.Tag = "EDIT_CARITEM";
            this.button5.Text = "修改";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.CustomButton_Click);
            // 
            // button6
            // 
            this.button6.Dock = System.Windows.Forms.DockStyle.Left;
            this.button6.Location = new System.Drawing.Point(0, 0);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(60, 24);
            this.button6.TabIndex = 0;
            this.button6.Tag = "ADD_CARITEM";
            this.button6.Text = "添加";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.CustomButton_Click);
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Left;
            this.label2.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(3, 3);
            this.label2.Margin = new System.Windows.Forms.Padding(3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 24);
            this.label2.TabIndex = 0;
            this.label2.Text = "适用车种";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // spcRight
            // 
            this.spcRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spcRight.Location = new System.Drawing.Point(0, 0);
            this.spcRight.Name = "spcRight";
            this.spcRight.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // spcRight.Panel1
            // 
            this.spcRight.Panel1.Controls.Add(this.gridStyleItem);
            this.spcRight.Panel1.Controls.Add(this.panel3);
            this.spcRight.Panel1.Padding = new System.Windows.Forms.Padding(5);
            // 
            // spcRight.Panel2
            // 
            this.spcRight.Panel2.Controls.Add(this.gridProperty);
            this.spcRight.Panel2.Controls.Add(this.panel4);
            this.spcRight.Size = new System.Drawing.Size(577, 645);
            this.spcRight.SplitterDistance = 322;
            this.spcRight.TabIndex = 1;
            // 
            // gridStyleItem
            // 
            this.gridStyleItem.BackgroundColor = System.Drawing.SystemColors.Control;
            this.gridStyleItem.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gridStyleItem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridStyleItem.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colSytleItemID,
            this.colStyleItemType,
            this.colStyleItemValueType,
            this.colStyleItemDate,
            this.colStyleItemRemark});
            this.gridStyleItem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridStyleItem.Location = new System.Drawing.Point(5, 35);
            this.gridStyleItem.Name = "gridStyleItem";
            this.gridStyleItem.ReadOnly = true;
            this.gridStyleItem.RowTemplate.Height = 23;
            this.gridStyleItem.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridStyleItem.Size = new System.Drawing.Size(567, 282);
            this.gridStyleItem.TabIndex = 1;
            this.gridStyleItem.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridStyleItem_CellDoubleClick);
            this.gridStyleItem.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.grid_RowPostPaint);
            // 
            // colSytleItemID
            // 
            this.colSytleItemID.DataPropertyName = "ID";
            this.colSytleItemID.HeaderText = "ID";
            this.colSytleItemID.Name = "colSytleItemID";
            this.colSytleItemID.ReadOnly = true;
            this.colSytleItemID.Visible = false;
            // 
            // colStyleItemType
            // 
            this.colStyleItemType.DataPropertyName = "ItemType";
            this.colStyleItemType.HeaderText = "项类型";
            this.colStyleItemType.Name = "colStyleItemType";
            this.colStyleItemType.ReadOnly = true;
            // 
            // colStyleItemValueType
            // 
            this.colStyleItemValueType.DataPropertyName = "ValueType";
            this.colStyleItemValueType.HeaderText = "数值类型";
            this.colStyleItemValueType.Name = "colStyleItemValueType";
            this.colStyleItemValueType.ReadOnly = true;
            // 
            // colStyleItemDate
            // 
            this.colStyleItemDate.DataPropertyName = "Data";
            this.colStyleItemDate.HeaderText = "数据内容";
            this.colStyleItemDate.Name = "colStyleItemDate";
            this.colStyleItemDate.ReadOnly = true;
            // 
            // colStyleItemRemark
            // 
            this.colStyleItemRemark.DataPropertyName = "Remark";
            this.colStyleItemRemark.HeaderText = "备注";
            this.colStyleItemRemark.Name = "colStyleItemRemark";
            this.colStyleItemRemark.ReadOnly = true;
            this.colStyleItemRemark.Width = 300;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.panel6);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(5, 5);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(3);
            this.panel3.Size = new System.Drawing.Size(567, 30);
            this.panel3.TabIndex = 0;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.button1);
            this.panel6.Controls.Add(this.button2);
            this.panel6.Controls.Add(this.button3);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(103, 3);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(461, 24);
            this.panel6.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Left;
            this.button1.Location = new System.Drawing.Point(120, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(60, 24);
            this.button1.TabIndex = 2;
            this.button1.Tag = "DELETE_ITEM";
            this.button1.Text = "删除";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Dock = System.Windows.Forms.DockStyle.Left;
            this.button2.Location = new System.Drawing.Point(60, 0);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(60, 24);
            this.button2.TabIndex = 1;
            this.button2.Tag = "EDIT_ITEM";
            this.button2.Text = "修改";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.CustomButton_Click);
            // 
            // button3
            // 
            this.button3.Dock = System.Windows.Forms.DockStyle.Left;
            this.button3.Location = new System.Drawing.Point(0, 0);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(60, 24);
            this.button3.TabIndex = 0;
            this.button3.Tag = "ADD_ITEM";
            this.button3.Text = "添加";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.CustomButton_Click);
            // 
            // label3
            // 
            this.label3.Dock = System.Windows.Forms.DockStyle.Left;
            this.label3.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(3, 3);
            this.label3.Margin = new System.Windows.Forms.Padding(3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 24);
            this.label3.TabIndex = 0;
            this.label3.Text = "标签项";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // gridProperty
            // 
            this.gridProperty.BackgroundColor = System.Drawing.SystemColors.Control;
            this.gridProperty.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gridProperty.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridProperty.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colStyleItemPropteryID,
            this.colSytleItemPropertyType,
            this.colSytleItemPropertyValue,
            this.colValueType});
            this.gridProperty.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridProperty.Location = new System.Drawing.Point(0, 30);
            this.gridProperty.Name = "gridProperty";
            this.gridProperty.ReadOnly = true;
            this.gridProperty.RowTemplate.Height = 23;
            this.gridProperty.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridProperty.Size = new System.Drawing.Size(577, 289);
            this.gridProperty.TabIndex = 3;
            this.gridProperty.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.grid_RowPostPaint);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.panel8);
            this.panel4.Controls.Add(this.label4);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Padding = new System.Windows.Forms.Padding(3);
            this.panel4.Size = new System.Drawing.Size(577, 30);
            this.panel4.TabIndex = 2;
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.button7);
            this.panel8.Controls.Add(this.button8);
            this.panel8.Controls.Add(this.button9);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel8.Location = new System.Drawing.Point(103, 3);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(471, 24);
            this.panel8.TabIndex = 2;
            // 
            // button7
            // 
            this.button7.Dock = System.Windows.Forms.DockStyle.Left;
            this.button7.Location = new System.Drawing.Point(120, 0);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(60, 24);
            this.button7.TabIndex = 2;
            this.button7.Tag = "DELETE_PROPERTY";
            this.button7.Text = "删除";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.CustomButton_Click);
            // 
            // button8
            // 
            this.button8.Dock = System.Windows.Forms.DockStyle.Left;
            this.button8.Location = new System.Drawing.Point(60, 0);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(60, 24);
            this.button8.TabIndex = 1;
            this.button8.Tag = "EDIT_PROPERTY";
            this.button8.Text = "修改";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.CustomButton_Click);
            // 
            // button9
            // 
            this.button9.Dock = System.Windows.Forms.DockStyle.Left;
            this.button9.Location = new System.Drawing.Point(0, 0);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(60, 24);
            this.button9.TabIndex = 0;
            this.button9.Tag = "ADD_PROPERTY";
            this.button9.Text = "添加";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.CustomButton_Click);
            // 
            // label4
            // 
            this.label4.Dock = System.Windows.Forms.DockStyle.Left;
            this.label4.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(3, 3);
            this.label4.Margin = new System.Windows.Forms.Padding(3);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 24);
            this.label4.TabIndex = 0;
            this.label4.Text = "标签项属性";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // colStyleItemPropteryID
            // 
            this.colStyleItemPropteryID.DataPropertyName = "ID";
            this.colStyleItemPropteryID.HeaderText = "ID";
            this.colStyleItemPropteryID.Name = "colStyleItemPropteryID";
            this.colStyleItemPropteryID.ReadOnly = true;
            this.colStyleItemPropteryID.Visible = false;
            // 
            // colSytleItemPropertyType
            // 
            this.colSytleItemPropertyType.DataPropertyName = "PropertyType";
            this.colSytleItemPropertyType.HeaderText = "属性类型";
            this.colSytleItemPropertyType.Name = "colSytleItemPropertyType";
            this.colSytleItemPropertyType.ReadOnly = true;
            // 
            // colSytleItemPropertyValue
            // 
            this.colSytleItemPropertyValue.DataPropertyName = "PropertyDisplayValue";
            this.colSytleItemPropertyValue.HeaderText = "属性值";
            this.colSytleItemPropertyValue.Name = "colSytleItemPropertyValue";
            this.colSytleItemPropertyValue.ReadOnly = true;
            // 
            // colValueType
            // 
            this.colValueType.DataPropertyName = "PropertyValueType";
            this.colValueType.HeaderText = "属性值类型";
            this.colValueType.Name = "colValueType";
            this.colValueType.ReadOnly = true;
            // 
            // ManageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1118, 645);
            this.Controls.Add(this.spcMain);
            this.Name = "ManageForm";
            this.Text = "ManageForm";
            this.Load += new System.EventHandler(this.ManageForm_Load);
            this.spcMain.Panel1.ResumeLayout(false);
            this.spcMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spcMain)).EndInit();
            this.spcMain.ResumeLayout(false);
            this.spcLeft.Panel1.ResumeLayout(false);
            this.spcLeft.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spcLeft)).EndInit();
            this.spcLeft.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridStyle)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridStyleCarItem)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.spcRight.Panel1.ResumeLayout(false);
            this.spcRight.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spcRight)).EndInit();
            this.spcRight.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridStyleItem)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridProperty)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer spcMain;
        private System.Windows.Forms.SplitContainer spcLeft;
        private System.Windows.Forms.DataGridView gridStyle;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView gridStyleCarItem;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.SplitContainer spcRight;
        private System.Windows.Forms.DataGridView gridStyleItem;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView gridProperty;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button btnDeleteStyle;
        private System.Windows.Forms.Button btnEditStyle;
        private System.Windows.Forms.Button btnAddStyle;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.DataGridViewTextBoxColumn colID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLabelStyle;
        private System.Windows.Forms.DataGridViewTextBoxColumn colWidth;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHeight;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRemark;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCarName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCarItemName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSytleItemID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStyleItemType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStyleItemValueType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStyleItemDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStyleItemRemark;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStyleItemPropteryID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSytleItemPropertyType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSytleItemPropertyValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn colValueType;
    }
}