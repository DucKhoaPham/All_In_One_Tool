namespace BarcodePrint
{
    partial class FrmConfigMassBarcode
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmConfigMassBarcode));
            this.btnPrintPreview = new System.Windows.Forms.Button();
            this.pctPicture = new System.Windows.Forms.PictureBox();
            this.cboPrinter = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSavePageSetting = new System.Windows.Forms.Button();
            this.btnLoadPageSetting = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.nudBarcodeOffsetTop = new System.Windows.Forms.NumericUpDown();
            this.label11 = new System.Windows.Forms.Label();
            this.nudBarcodeOffsetLeft = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.grpBlockSetting = new System.Windows.Forms.GroupBox();
            this.dgvBlockSetting = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnAddBlock = new System.Windows.Forms.Button();
            this.btnRemoveBlock = new System.Windows.Forms.Button();
            this.btnEditBlock = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.cboBarcodePrinter = new System.Windows.Forms.ComboBox();
            this.nudNumberStamp = new System.Windows.Forms.NumericUpDown();
            this.nudBarCodeWidth = new System.Windows.Forms.NumericUpDown();
            this.nudBarCodeHeight = new System.Windows.Forms.NumericUpDown();
            this.nudPaperSizeH = new System.Windows.Forms.NumericUpDown();
            this.nudPaperSizeW = new System.Windows.Forms.NumericUpDown();
            this.nudMarginRight = new System.Windows.Forms.NumericUpDown();
            this.nudMarginLeft = new System.Windows.Forms.NumericUpDown();
            this.nudMarginBottom = new System.Windows.Forms.NumericUpDown();
            this.nudMarginTop = new System.Windows.Forms.NumericUpDown();
            this.label12 = new System.Windows.Forms.Label();
            this.txtBarCode = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.btnPrint = new System.Windows.Forms.Button();
            this.chkShowBorder = new System.Windows.Forms.CheckBox();
            this.grpPreview = new System.Windows.Forms.GroupBox();
            this.num2 = new System.Windows.Forms.NumericUpDown();
            this.num1 = new System.Windows.Forms.NumericUpDown();
            this.label16 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.nudCopies = new System.Windows.Forms.NumericUpDown();
            this.btnPreviewImage = new System.Windows.Forms.Button();
            this.grpTemplate = new System.Windows.Forms.GroupBox();
            this.label15 = new System.Windows.Forms.Label();
            this.btnDeleteTemplate = new System.Windows.Forms.Button();
            this.btnAddTemplate = new System.Windows.Forms.Button();
            this.cboTemplate = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtTemplatePath = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pctPicture)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudBarcodeOffsetTop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudBarcodeOffsetLeft)).BeginInit();
            this.grpBlockSetting.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBlockSetting)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudNumberStamp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudBarCodeWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudBarCodeHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPaperSizeH)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPaperSizeW)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMarginRight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMarginLeft)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMarginBottom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMarginTop)).BeginInit();
            this.grpPreview.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.num2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCopies)).BeginInit();
            this.grpTemplate.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnPrintPreview
            // 
            this.btnPrintPreview.Location = new System.Drawing.Point(356, 11);
            this.btnPrintPreview.Name = "btnPrintPreview";
            this.btnPrintPreview.Size = new System.Drawing.Size(75, 23);
            this.btnPrintPreview.TabIndex = 0;
            this.btnPrintPreview.Text = "Xem";
            this.btnPrintPreview.UseVisualStyleBackColor = true;
            this.btnPrintPreview.Click += new System.EventHandler(this.btnPrintPreview_Click);
            // 
            // pctPicture
            // 
            this.pctPicture.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pctPicture.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pctPicture.Location = new System.Drawing.Point(570, 119);
            this.pctPicture.Name = "pctPicture";
            this.pctPicture.Size = new System.Drawing.Size(888, 410);
            this.pctPicture.TabIndex = 1;
            this.pctPicture.TabStop = false;
            // 
            // cboPrinter
            // 
            this.cboPrinter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPrinter.FormattingEnabled = true;
            this.cboPrinter.Location = new System.Drawing.Point(60, 13);
            this.cboPrinter.Name = "cboPrinter";
            this.cboPrinter.Size = new System.Drawing.Size(290, 25);
            this.cboPrinter.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "Cỡ giấy (mm)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 17);
            this.label2.TabIndex = 7;
            this.label2.Text = "Lề trái/ phải (mm)";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 68);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(125, 17);
            this.label4.TabIndex = 11;
            this.label4.Text = "Lề trên/ dưới (mm)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(404, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 17);
            this.label3.TabIndex = 17;
            this.label3.Text = "Tem/ Trang";
            // 
            // btnSavePageSetting
            // 
            this.btnSavePageSetting.Location = new System.Drawing.Point(91, 70);
            this.btnSavePageSetting.Name = "btnSavePageSetting";
            this.btnSavePageSetting.Size = new System.Drawing.Size(75, 23);
            this.btnSavePageSetting.TabIndex = 19;
            this.btnSavePageSetting.Text = "Save";
            this.btnSavePageSetting.UseVisualStyleBackColor = true;
            this.btnSavePageSetting.Click += new System.EventHandler(this.btnSavePageSetting_Click);
            // 
            // btnLoadPageSetting
            // 
            this.btnLoadPageSetting.Location = new System.Drawing.Point(169, 70);
            this.btnLoadPageSetting.Name = "btnLoadPageSetting";
            this.btnLoadPageSetting.Size = new System.Drawing.Size(75, 23);
            this.btnLoadPageSetting.TabIndex = 20;
            this.btnLoadPageSetting.Text = "Load";
            this.btnLoadPageSetting.UseVisualStyleBackColor = true;
            this.btnLoadPageSetting.Click += new System.EventHandler(this.btnLoadPageSetting_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(234, 43);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(109, 17);
            this.label5.TabIndex = 22;
            this.label5.Text = "Ngang mã (mm)";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(234, 68);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(93, 17);
            this.label8.TabIndex = 25;
            this.label8.Text = "Cao mã (mm)";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 16);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(47, 17);
            this.label9.TabIndex = 27;
            this.label9.Text = "Máy in";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this.nudBarcodeOffsetTop);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.nudBarcodeOffsetLeft);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.grpBlockSetting);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.cboBarcodePrinter);
            this.groupBox1.Controls.Add(this.nudNumberStamp);
            this.groupBox1.Controls.Add(this.nudBarCodeWidth);
            this.groupBox1.Controls.Add(this.nudBarCodeHeight);
            this.groupBox1.Controls.Add(this.nudPaperSizeH);
            this.groupBox1.Controls.Add(this.nudPaperSizeW);
            this.groupBox1.Controls.Add(this.nudMarginRight);
            this.groupBox1.Controls.Add(this.nudMarginLeft);
            this.groupBox1.Controls.Add(this.nudMarginBottom);
            this.groupBox1.Controls.Add(this.nudMarginTop);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(11, 119);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(553, 410);
            this.groupBox1.TabIndex = 28;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Barcode Page";
            // 
            // nudBarcodeOffsetTop
            // 
            this.nudBarcodeOffsetTop.DecimalPlaces = 1;
            this.nudBarcodeOffsetTop.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nudBarcodeOffsetTop.Location = new System.Drawing.Point(489, 64);
            this.nudBarcodeOffsetTop.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudBarcodeOffsetTop.Name = "nudBarcodeOffsetTop";
            this.nudBarcodeOffsetTop.Size = new System.Drawing.Size(57, 24);
            this.nudBarcodeOffsetTop.TabIndex = 58;
            this.nudBarcodeOffsetTop.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudBarcodeOffsetTop.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudBarcodeOffsetTop.ValueChanged += new System.EventHandler(this.Preview_ValueChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(384, 68);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(130, 17);
            this.label11.TabIndex = 57;
            this.label11.Text = "Canh trên mã (mm)";
            // 
            // nudBarcodeOffsetLeft
            // 
            this.nudBarcodeOffsetLeft.DecimalPlaces = 1;
            this.nudBarcodeOffsetLeft.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nudBarcodeOffsetLeft.Location = new System.Drawing.Point(489, 39);
            this.nudBarcodeOffsetLeft.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudBarcodeOffsetLeft.Name = "nudBarcodeOffsetLeft";
            this.nudBarcodeOffsetLeft.Size = new System.Drawing.Size(57, 24);
            this.nudBarcodeOffsetLeft.TabIndex = 56;
            this.nudBarcodeOffsetLeft.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudBarcodeOffsetLeft.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudBarcodeOffsetLeft.ValueChanged += new System.EventHandler(this.Preview_ValueChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(384, 43);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(124, 17);
            this.label7.TabIndex = 55;
            this.label7.Text = "Canh trái mã (mm)";
            // 
            // grpBlockSetting
            // 
            this.grpBlockSetting.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpBlockSetting.Controls.Add(this.dgvBlockSetting);
            this.grpBlockSetting.Controls.Add(this.panel1);
            this.grpBlockSetting.Location = new System.Drawing.Point(6, 118);
            this.grpBlockSetting.Name = "grpBlockSetting";
            this.grpBlockSetting.Size = new System.Drawing.Size(541, 286);
            this.grpBlockSetting.TabIndex = 54;
            this.grpBlockSetting.TabStop = false;
            this.grpBlockSetting.Text = "Cấu hình khối";
            // 
            // dgvBlockSetting
            // 
            this.dgvBlockSetting.AllowUserToAddRows = false;
            this.dgvBlockSetting.AllowUserToDeleteRows = false;
            this.dgvBlockSetting.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvBlockSetting.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBlockSetting.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn4});
            this.dgvBlockSetting.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvBlockSetting.Location = new System.Drawing.Point(3, 49);
            this.dgvBlockSetting.Name = "dgvBlockSetting";
            this.dgvBlockSetting.ReadOnly = true;
            this.dgvBlockSetting.RowHeadersWidth = 51;
            this.dgvBlockSetting.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBlockSetting.Size = new System.Drawing.Size(535, 234);
            this.dgvBlockSetting.TabIndex = 52;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "OrderNum";
            this.dataGridViewTextBoxColumn2.HeaderText = "Thứ tự";
            this.dataGridViewTextBoxColumn2.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 80;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "SampleText";
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn3.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewTextBoxColumn3.HeaderText = "Test mẫu";
            this.dataGridViewTextBoxColumn3.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 94;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "BlockDisplay";
            this.dataGridViewTextBoxColumn1.HeaderText = "Thông tin khối";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 125;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "FontSettingDisplay";
            this.dataGridViewTextBoxColumn4.HeaderText = "Kiểu chữ";
            this.dataGridViewTextBoxColumn4.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 90;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnAddBlock);
            this.panel1.Controls.Add(this.btnRemoveBlock);
            this.panel1.Controls.Add(this.btnEditBlock);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 20);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(535, 29);
            this.panel1.TabIndex = 53;
            // 
            // btnAddBlock
            // 
            this.btnAddBlock.Location = new System.Drawing.Point(3, 3);
            this.btnAddBlock.Name = "btnAddBlock";
            this.btnAddBlock.Size = new System.Drawing.Size(75, 23);
            this.btnAddBlock.TabIndex = 49;
            this.btnAddBlock.Text = "Thêm khối";
            this.btnAddBlock.UseVisualStyleBackColor = true;
            this.btnAddBlock.Click += new System.EventHandler(this.btnAddBlock_Click);
            // 
            // btnRemoveBlock
            // 
            this.btnRemoveBlock.Location = new System.Drawing.Point(162, 3);
            this.btnRemoveBlock.Name = "btnRemoveBlock";
            this.btnRemoveBlock.Size = new System.Drawing.Size(75, 23);
            this.btnRemoveBlock.TabIndex = 51;
            this.btnRemoveBlock.Text = "Xóa khối";
            this.btnRemoveBlock.UseVisualStyleBackColor = true;
            this.btnRemoveBlock.Click += new System.EventHandler(this.btnRemoveBlock_Click);
            // 
            // btnEditBlock
            // 
            this.btnEditBlock.Location = new System.Drawing.Point(81, 3);
            this.btnEditBlock.Name = "btnEditBlock";
            this.btnEditBlock.Size = new System.Drawing.Size(75, 23);
            this.btnEditBlock.TabIndex = 50;
            this.btnEditBlock.Text = "Sửa khối";
            this.btnEditBlock.UseVisualStyleBackColor = true;
            this.btnEditBlock.Click += new System.EventHandler(this.btnEditBlock_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(234, 94);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(47, 17);
            this.label10.TabIndex = 41;
            this.label10.Text = "Máy in";
            // 
            // cboBarcodePrinter
            // 
            this.cboBarcodePrinter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBarcodePrinter.FormattingEnabled = true;
            this.cboBarcodePrinter.Location = new System.Drawing.Point(322, 91);
            this.cboBarcodePrinter.Name = "cboBarcodePrinter";
            this.cboBarcodePrinter.Size = new System.Drawing.Size(224, 25);
            this.cboBarcodePrinter.TabIndex = 40;
            // 
            // nudNumberStamp
            // 
            this.nudNumberStamp.Location = new System.Drawing.Point(489, 15);
            this.nudNumberStamp.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudNumberStamp.Name = "nudNumberStamp";
            this.nudNumberStamp.Size = new System.Drawing.Size(57, 24);
            this.nudNumberStamp.TabIndex = 42;
            this.nudNumberStamp.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudNumberStamp.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.nudNumberStamp.ValueChanged += new System.EventHandler(this.Preview_ValueChanged);
            // 
            // nudBarCodeWidth
            // 
            this.nudBarCodeWidth.DecimalPlaces = 1;
            this.nudBarCodeWidth.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nudBarCodeWidth.Location = new System.Drawing.Point(322, 40);
            this.nudBarCodeWidth.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudBarCodeWidth.Name = "nudBarCodeWidth";
            this.nudBarCodeWidth.Size = new System.Drawing.Size(58, 24);
            this.nudBarCodeWidth.TabIndex = 40;
            this.nudBarCodeWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudBarCodeWidth.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.nudBarCodeWidth.ValueChanged += new System.EventHandler(this.Preview_ValueChanged);
            // 
            // nudBarCodeHeight
            // 
            this.nudBarCodeHeight.DecimalPlaces = 1;
            this.nudBarCodeHeight.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nudBarCodeHeight.Location = new System.Drawing.Point(322, 64);
            this.nudBarCodeHeight.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudBarCodeHeight.Name = "nudBarCodeHeight";
            this.nudBarCodeHeight.Size = new System.Drawing.Size(58, 24);
            this.nudBarCodeHeight.TabIndex = 39;
            this.nudBarCodeHeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudBarCodeHeight.Value = new decimal(new int[] {
            7,
            0,
            0,
            0});
            this.nudBarCodeHeight.ValueChanged += new System.EventHandler(this.Preview_ValueChanged);
            // 
            // nudPaperSizeH
            // 
            this.nudPaperSizeH.Location = new System.Drawing.Point(171, 14);
            this.nudPaperSizeH.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudPaperSizeH.Name = "nudPaperSizeH";
            this.nudPaperSizeH.Size = new System.Drawing.Size(57, 24);
            this.nudPaperSizeH.TabIndex = 38;
            this.nudPaperSizeH.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudPaperSizeH.Value = new decimal(new int[] {
            22,
            0,
            0,
            0});
            this.nudPaperSizeH.ValueChanged += new System.EventHandler(this.Preview_ValueChanged);
            // 
            // nudPaperSizeW
            // 
            this.nudPaperSizeW.Location = new System.Drawing.Point(108, 14);
            this.nudPaperSizeW.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudPaperSizeW.Name = "nudPaperSizeW";
            this.nudPaperSizeW.Size = new System.Drawing.Size(57, 24);
            this.nudPaperSizeW.TabIndex = 37;
            this.nudPaperSizeW.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudPaperSizeW.Value = new decimal(new int[] {
            110,
            0,
            0,
            0});
            this.nudPaperSizeW.ValueChanged += new System.EventHandler(this.Preview_ValueChanged);
            // 
            // nudMarginRight
            // 
            this.nudMarginRight.DecimalPlaces = 1;
            this.nudMarginRight.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nudMarginRight.Location = new System.Drawing.Point(171, 39);
            this.nudMarginRight.Name = "nudMarginRight";
            this.nudMarginRight.Size = new System.Drawing.Size(57, 24);
            this.nudMarginRight.TabIndex = 36;
            this.nudMarginRight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudMarginRight.ValueChanged += new System.EventHandler(this.Preview_ValueChanged);
            // 
            // nudMarginLeft
            // 
            this.nudMarginLeft.DecimalPlaces = 1;
            this.nudMarginLeft.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nudMarginLeft.Location = new System.Drawing.Point(108, 39);
            this.nudMarginLeft.Name = "nudMarginLeft";
            this.nudMarginLeft.Size = new System.Drawing.Size(57, 24);
            this.nudMarginLeft.TabIndex = 35;
            this.nudMarginLeft.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudMarginLeft.ValueChanged += new System.EventHandler(this.Preview_ValueChanged);
            // 
            // nudMarginBottom
            // 
            this.nudMarginBottom.DecimalPlaces = 1;
            this.nudMarginBottom.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nudMarginBottom.Location = new System.Drawing.Point(171, 64);
            this.nudMarginBottom.Name = "nudMarginBottom";
            this.nudMarginBottom.Size = new System.Drawing.Size(57, 24);
            this.nudMarginBottom.TabIndex = 34;
            this.nudMarginBottom.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudMarginBottom.ValueChanged += new System.EventHandler(this.Preview_ValueChanged);
            // 
            // nudMarginTop
            // 
            this.nudMarginTop.DecimalPlaces = 1;
            this.nudMarginTop.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nudMarginTop.Location = new System.Drawing.Point(108, 64);
            this.nudMarginTop.Name = "nudMarginTop";
            this.nudMarginTop.Size = new System.Drawing.Size(57, 24);
            this.nudMarginTop.TabIndex = 33;
            this.nudMarginTop.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudMarginTop.ValueChanged += new System.EventHandler(this.Preview_ValueChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(327, 43);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(63, 17);
            this.label12.TabIndex = 33;
            this.label12.Text = "Kí tự đầu";
            this.label12.Visible = false;
            // 
            // txtBarCode
            // 
            this.txtBarCode.Location = new System.Drawing.Point(381, 38);
            this.txtBarCode.Name = "txtBarCode";
            this.txtBarCode.Size = new System.Drawing.Size(131, 24);
            this.txtBarCode.TabIndex = 32;
            this.txtBarCode.Text = "1001";
            this.txtBarCode.Visible = false;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(6, 43);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(61, 17);
            this.label14.TabIndex = 37;
            this.label14.Text = "Số trang";
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(437, 11);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(75, 23);
            this.btnPrint.TabIndex = 38;
            this.btnPrint.Text = "In thử";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // chkShowBorder
            // 
            this.chkShowBorder.AutoSize = true;
            this.chkShowBorder.Checked = true;
            this.chkShowBorder.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkShowBorder.Location = new System.Drawing.Point(136, 42);
            this.chkShowBorder.Name = "chkShowBorder";
            this.chkShowBorder.Size = new System.Drawing.Size(149, 21);
            this.chkShowBorder.TabIndex = 39;
            this.chkShowBorder.Text = "Hiển thị đường viền";
            this.chkShowBorder.UseVisualStyleBackColor = true;
            // 
            // grpPreview
            // 
            this.grpPreview.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpPreview.Controls.Add(this.num2);
            this.grpPreview.Controls.Add(this.num1);
            this.grpPreview.Controls.Add(this.label16);
            this.grpPreview.Controls.Add(this.label6);
            this.grpPreview.Controls.Add(this.nudCopies);
            this.grpPreview.Controls.Add(this.label9);
            this.grpPreview.Controls.Add(this.chkShowBorder);
            this.grpPreview.Controls.Add(this.label14);
            this.grpPreview.Controls.Add(this.btnPrintPreview);
            this.grpPreview.Controls.Add(this.cboPrinter);
            this.grpPreview.Controls.Add(this.btnPrint);
            this.grpPreview.Controls.Add(this.label12);
            this.grpPreview.Controls.Add(this.txtBarCode);
            this.grpPreview.Location = new System.Drawing.Point(570, 12);
            this.grpPreview.Name = "grpPreview";
            this.grpPreview.Size = new System.Drawing.Size(888, 72);
            this.grpPreview.TabIndex = 42;
            this.grpPreview.TabStop = false;
            this.grpPreview.Text = "Preview";
            this.grpPreview.Enter += new System.EventHandler(this.grpPreview_Enter);
            // 
            // num2
            // 
            this.num2.Location = new System.Drawing.Point(640, 34);
            this.num2.Maximum = new decimal(new int[] {
            276447232,
            23283,
            0,
            0});
            this.num2.Name = "num2";
            this.num2.Size = new System.Drawing.Size(120, 24);
            this.num2.TabIndex = 43;
            this.num2.Value = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            // 
            // num1
            // 
            this.num1.Increment = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.num1.Location = new System.Drawing.Point(479, 36);
            this.num1.Maximum = new decimal(new int[] {
            1215752192,
            23,
            0,
            0});
            this.num1.Name = "num1";
            this.num1.Size = new System.Drawing.Size(120, 24);
            this.num1.TabIndex = 43;
            this.num1.Value = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(603, 38);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(31, 17);
            this.label16.TabIndex = 42;
            this.label16.Text = "đến";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(423, 41);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 17);
            this.label6.TabIndex = 41;
            this.label6.Text = "STT từ";
            // 
            // nudCopies
            // 
            this.nudCopies.Location = new System.Drawing.Point(61, 41);
            this.nudCopies.Name = "nudCopies";
            this.nudCopies.Size = new System.Drawing.Size(52, 24);
            this.nudCopies.TabIndex = 40;
            this.nudCopies.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnPreviewImage
            // 
            this.btnPreviewImage.Location = new System.Drawing.Point(570, 90);
            this.btnPreviewImage.Name = "btnPreviewImage";
            this.btnPreviewImage.Size = new System.Drawing.Size(75, 23);
            this.btnPreviewImage.TabIndex = 42;
            this.btnPreviewImage.Text = "Xem hình";
            this.btnPreviewImage.UseVisualStyleBackColor = true;
            this.btnPreviewImage.Click += new System.EventHandler(this.btnPreviewImage_Click);
            // 
            // grpTemplate
            // 
            this.grpTemplate.Controls.Add(this.label15);
            this.grpTemplate.Controls.Add(this.btnDeleteTemplate);
            this.grpTemplate.Controls.Add(this.btnAddTemplate);
            this.grpTemplate.Controls.Add(this.cboTemplate);
            this.grpTemplate.Controls.Add(this.btnSavePageSetting);
            this.grpTemplate.Controls.Add(this.btnLoadPageSetting);
            this.grpTemplate.Controls.Add(this.label13);
            this.grpTemplate.Controls.Add(this.txtTemplatePath);
            this.grpTemplate.Location = new System.Drawing.Point(11, 13);
            this.grpTemplate.Name = "grpTemplate";
            this.grpTemplate.Size = new System.Drawing.Size(553, 100);
            this.grpTemplate.TabIndex = 43;
            this.grpTemplate.TabStop = false;
            this.grpTemplate.Text = "Template";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(9, 20);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(64, 17);
            this.label15.TabIndex = 65;
            this.label15.Text = "Template";
            // 
            // btnDeleteTemplate
            // 
            this.btnDeleteTemplate.Location = new System.Drawing.Point(298, 15);
            this.btnDeleteTemplate.Name = "btnDeleteTemplate";
            this.btnDeleteTemplate.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteTemplate.TabIndex = 64;
            this.btnDeleteTemplate.Text = "Xóa";
            this.btnDeleteTemplate.UseVisualStyleBackColor = true;
            this.btnDeleteTemplate.Click += new System.EventHandler(this.btnDeleteTemplate_Click);
            // 
            // btnAddTemplate
            // 
            this.btnAddTemplate.Location = new System.Drawing.Point(217, 15);
            this.btnAddTemplate.Name = "btnAddTemplate";
            this.btnAddTemplate.Size = new System.Drawing.Size(75, 23);
            this.btnAddTemplate.TabIndex = 63;
            this.btnAddTemplate.Text = "Thêm";
            this.btnAddTemplate.UseVisualStyleBackColor = true;
            this.btnAddTemplate.Click += new System.EventHandler(this.btnAddTemplate_Click);
            // 
            // cboTemplate
            // 
            this.cboTemplate.DisplayMember = "TemplateName";
            this.cboTemplate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTemplate.FormattingEnabled = true;
            this.cboTemplate.Location = new System.Drawing.Point(90, 15);
            this.cboTemplate.Name = "cboTemplate";
            this.cboTemplate.Size = new System.Drawing.Size(121, 25);
            this.cboTemplate.TabIndex = 62;
            this.cboTemplate.ValueMember = "TemplateName";
            this.cboTemplate.SelectedIndexChanged += new System.EventHandler(this.cboTemplate_SelectedIndexChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(9, 48);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(96, 17);
            this.label13.TabIndex = 61;
            this.label13.Text = "Template path";
            // 
            // txtTemplatePath
            // 
            this.txtTemplatePath.Location = new System.Drawing.Point(91, 45);
            this.txtTemplatePath.Name = "txtTemplatePath";
            this.txtTemplatePath.ReadOnly = true;
            this.txtTemplatePath.Size = new System.Drawing.Size(453, 24);
            this.txtTemplatePath.TabIndex = 60;
            // 
            // FrmConfigMassBarcode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1470, 541);
            this.Controls.Add(this.grpTemplate);
            this.Controls.Add(this.btnPreviewImage);
            this.Controls.Add(this.grpPreview);
            this.Controls.Add(this.pctPicture);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmConfigMassBarcode";
            this.ShowIcon = false;
            this.Text = "Test in ấn barcode";
            this.Load += new System.EventHandler(this.FrmConfigMassBarcode_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pctPicture)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudBarcodeOffsetTop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudBarcodeOffsetLeft)).EndInit();
            this.grpBlockSetting.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBlockSetting)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudNumberStamp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudBarCodeWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudBarCodeHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPaperSizeH)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPaperSizeW)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMarginRight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMarginLeft)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMarginBottom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMarginTop)).EndInit();
            this.grpPreview.ResumeLayout(false);
            this.grpPreview.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.num2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCopies)).EndInit();
            this.grpTemplate.ResumeLayout(false);
            this.grpTemplate.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnPrintPreview;
        private System.Windows.Forms.PictureBox pctPicture;
        private System.Windows.Forms.ComboBox cboPrinter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnSavePageSetting;
        private System.Windows.Forms.Button btnLoadPageSetting;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtBarCode;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.CheckBox chkShowBorder;
        private System.Windows.Forms.GroupBox grpPreview;
        private System.Windows.Forms.NumericUpDown nudMarginBottom;
        private System.Windows.Forms.NumericUpDown nudMarginTop;
        private System.Windows.Forms.NumericUpDown nudMarginRight;
        private System.Windows.Forms.NumericUpDown nudMarginLeft;
        private System.Windows.Forms.NumericUpDown nudPaperSizeH;
        private System.Windows.Forms.NumericUpDown nudPaperSizeW;
        private System.Windows.Forms.NumericUpDown nudBarCodeHeight;
        private System.Windows.Forms.NumericUpDown nudBarCodeWidth;
        private System.Windows.Forms.NumericUpDown nudNumberStamp;
        private System.Windows.Forms.Button btnPreviewImage;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cboBarcodePrinter;
        private System.Windows.Forms.DataGridView dgvBlockSetting;
        private System.Windows.Forms.Button btnRemoveBlock;
        private System.Windows.Forms.Button btnEditBlock;
        private System.Windows.Forms.Button btnAddBlock;
        private System.Windows.Forms.GroupBox grpBlockSetting;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.NumericUpDown nudBarcodeOffsetTop;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.NumericUpDown nudBarcodeOffsetLeft;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox grpTemplate;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtTemplatePath;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button btnDeleteTemplate;
        private System.Windows.Forms.Button btnAddTemplate;
        private System.Windows.Forms.ComboBox cboTemplate;
        private System.Windows.Forms.NumericUpDown nudCopies;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown num2;
        private System.Windows.Forms.NumericUpDown num1;
    }
}

