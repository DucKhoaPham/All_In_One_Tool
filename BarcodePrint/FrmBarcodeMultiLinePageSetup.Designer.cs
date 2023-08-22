namespace BarcodePrint
{
    partial class FrmBarcodeMultiLinePageSetup
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmBarcodeMultiLinePageSetup));
            this.btnPrintPreview = new System.Windows.Forms.Button();
            this.pctPicture = new System.Windows.Forms.PictureBox();
            this.cboPrinter = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSavePageSetting = new System.Windows.Forms.Button();
            this.btnLoadPageSetting = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.grpBlockSetting = new System.Windows.Forms.GroupBox();
            this.btnAddBlock = new System.Windows.Forms.Button();
            this.btnEditBlock = new System.Windows.Forms.Button();
            this.dgvBlockSetting = new System.Windows.Forms.DataGridView();
            this.btnRemoveBlock = new System.Windows.Forms.Button();
            this.grpLineSetting = new System.Windows.Forms.GroupBox();
            this.dgvLineSetting = new System.Windows.Forms.DataGridView();
            this.colZoneDisplay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTextOrder = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSampleText = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFontFormat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAddLine = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.cboBarcodePrinter = new System.Windows.Forms.ComboBox();
            this.label16 = new System.Windows.Forms.Label();
            this.cboBarcodeAlign = new System.Windows.Forms.ComboBox();
            this.nudNumberStamp = new System.Windows.Forms.NumericUpDown();
            this.nudDPI = new System.Windows.Forms.NumericUpDown();
            this.nudMMPerChar = new System.Windows.Forms.NumericUpDown();
            this.nudBarCodeHeight = new System.Windows.Forms.NumericUpDown();
            this.nudPaperSizeH = new System.Windows.Forms.NumericUpDown();
            this.nudPaperSizeW = new System.Windows.Forms.NumericUpDown();
            this.nudMarginRight = new System.Windows.Forms.NumericUpDown();
            this.nudMarginLeft = new System.Windows.Forms.NumericUpDown();
            this.nudMarginBottom = new System.Windows.Forms.NumericUpDown();
            this.nudMarginTop = new System.Windows.Forms.NumericUpDown();
            this.nudGeneralFontSize = new System.Windows.Forms.NumericUpDown();
            this.label15 = new System.Windows.Forms.Label();
            this.cboAlignment = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtBarCode = new System.Windows.Forms.TextBox();
            this.txtNumberPage = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.btnPrint = new System.Windows.Forms.Button();
            this.chkShowBorder = new System.Windows.Forms.CheckBox();
            this.grpPreview = new System.Windows.Forms.GroupBox();
            this.btnPreviewImage = new System.Windows.Forms.Button();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.pctPicture)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.grpBlockSetting.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBlockSetting)).BeginInit();
            this.grpLineSetting.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLineSetting)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudNumberStamp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDPI)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMMPerChar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudBarCodeHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPaperSizeH)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPaperSizeW)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMarginRight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMarginLeft)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMarginBottom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMarginTop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudGeneralFontSize)).BeginInit();
            this.grpPreview.SuspendLayout();
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
            this.pctPicture.Location = new System.Drawing.Point(556, 119);
            this.pctPicture.Name = "pctPicture";
            this.pctPicture.Size = new System.Drawing.Size(518, 410);
            this.pctPicture.TabIndex = 1;
            this.pctPicture.TabStop = false;
            // 
            // cboPrinter
            // 
            this.cboPrinter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPrinter.FormattingEnabled = true;
            this.cboPrinter.Location = new System.Drawing.Point(60, 13);
            this.cboPrinter.Name = "cboPrinter";
            this.cboPrinter.Size = new System.Drawing.Size(290, 21);
            this.cboPrinter.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Cỡ giấy (mm)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Lề trái/ phải (mm)";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 68);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Lề trên/ dưới (mm)";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(292, 17);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(24, 13);
            this.label6.TabIndex = 16;
            this.label6.Text = "DPI";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(404, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "Tem/ Trang";
            // 
            // btnSavePageSetting
            // 
            this.btnSavePageSetting.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSavePageSetting.Location = new System.Drawing.Point(6, 484);
            this.btnSavePageSetting.Name = "btnSavePageSetting";
            this.btnSavePageSetting.Size = new System.Drawing.Size(75, 23);
            this.btnSavePageSetting.TabIndex = 19;
            this.btnSavePageSetting.Text = "Save";
            this.btnSavePageSetting.UseVisualStyleBackColor = true;
            this.btnSavePageSetting.Click += new System.EventHandler(this.btnSavePageSetting_Click);
            // 
            // btnLoadPageSetting
            // 
            this.btnLoadPageSetting.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnLoadPageSetting.Location = new System.Drawing.Point(84, 484);
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
            this.label5.Location = new System.Drawing.Point(265, 42);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 13);
            this.label5.TabIndex = 22;
            this.label5.Text = "mm/Ký tự";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(386, 42);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(81, 13);
            this.label7.TabIndex = 24;
            this.label7.Text = "Cỡ chữ (chung)";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(259, 68);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(58, 13);
            this.label8.TabIndex = 25;
            this.label8.Text = "Độ cao Mã";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 16);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(38, 13);
            this.label9.TabIndex = 27;
            this.label9.Text = "Máy in";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this.grpBlockSetting);
            this.groupBox1.Controls.Add(this.grpLineSetting);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.cboBarcodePrinter);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.cboBarcodeAlign);
            this.groupBox1.Controls.Add(this.nudNumberStamp);
            this.groupBox1.Controls.Add(this.nudDPI);
            this.groupBox1.Controls.Add(this.nudMMPerChar);
            this.groupBox1.Controls.Add(this.nudBarCodeHeight);
            this.groupBox1.Controls.Add(this.nudPaperSizeH);
            this.groupBox1.Controls.Add(this.nudPaperSizeW);
            this.groupBox1.Controls.Add(this.nudMarginRight);
            this.groupBox1.Controls.Add(this.nudMarginLeft);
            this.groupBox1.Controls.Add(this.nudMarginBottom);
            this.groupBox1.Controls.Add(this.nudMarginTop);
            this.groupBox1.Controls.Add(this.nudGeneralFontSize);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.cboAlignment);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnLoadPageSetting);
            this.groupBox1.Controls.Add(this.btnSavePageSetting);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Location = new System.Drawing.Point(11, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(539, 517);
            this.groupBox1.TabIndex = 28;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Barcode Page";
            // 
            // grpBlockSetting
            // 
            this.grpBlockSetting.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.grpBlockSetting.Controls.Add(this.btnAddBlock);
            this.grpBlockSetting.Controls.Add(this.btnEditBlock);
            this.grpBlockSetting.Controls.Add(this.dgvBlockSetting);
            this.grpBlockSetting.Controls.Add(this.btnRemoveBlock);
            this.grpBlockSetting.Location = new System.Drawing.Point(6, 316);
            this.grpBlockSetting.Name = "grpBlockSetting";
            this.grpBlockSetting.Size = new System.Drawing.Size(527, 162);
            this.grpBlockSetting.TabIndex = 54;
            this.grpBlockSetting.TabStop = false;
            this.grpBlockSetting.Text = "Cấu hình khối";
            // 
            // btnAddBlock
            // 
            this.btnAddBlock.Location = new System.Drawing.Point(0, 20);
            this.btnAddBlock.Name = "btnAddBlock";
            this.btnAddBlock.Size = new System.Drawing.Size(75, 23);
            this.btnAddBlock.TabIndex = 49;
            this.btnAddBlock.Text = "Thêm khối";
            this.btnAddBlock.UseVisualStyleBackColor = true;
            this.btnAddBlock.Click += new System.EventHandler(this.btnAddBlock_Click);
            // 
            // btnEditBlock
            // 
            this.btnEditBlock.Location = new System.Drawing.Point(78, 20);
            this.btnEditBlock.Name = "btnEditBlock";
            this.btnEditBlock.Size = new System.Drawing.Size(75, 23);
            this.btnEditBlock.TabIndex = 50;
            this.btnEditBlock.Text = "Sửa khối";
            this.btnEditBlock.UseVisualStyleBackColor = true;
            this.btnEditBlock.Click += new System.EventHandler(this.btnEditBlock_Click);
            // 
            // dgvBlockSetting
            // 
            this.dgvBlockSetting.AllowUserToAddRows = false;
            this.dgvBlockSetting.AllowUserToDeleteRows = false;
            this.dgvBlockSetting.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dgvBlockSetting.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvBlockSetting.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBlockSetting.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn4});
            this.dgvBlockSetting.Location = new System.Drawing.Point(6, 49);
            this.dgvBlockSetting.Name = "dgvBlockSetting";
            this.dgvBlockSetting.ReadOnly = true;
            this.dgvBlockSetting.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBlockSetting.Size = new System.Drawing.Size(515, 107);
            this.dgvBlockSetting.TabIndex = 52;
            // 
            // btnRemoveBlock
            // 
            this.btnRemoveBlock.Location = new System.Drawing.Point(159, 20);
            this.btnRemoveBlock.Name = "btnRemoveBlock";
            this.btnRemoveBlock.Size = new System.Drawing.Size(75, 23);
            this.btnRemoveBlock.TabIndex = 51;
            this.btnRemoveBlock.Text = "Xóa khối";
            this.btnRemoveBlock.UseVisualStyleBackColor = true;
            this.btnRemoveBlock.Click += new System.EventHandler(this.btnRemoveBlock_Click);
            // 
            // grpLineSetting
            // 
            this.grpLineSetting.Controls.Add(this.dgvLineSetting);
            this.grpLineSetting.Controls.Add(this.btnAddLine);
            this.grpLineSetting.Controls.Add(this.btnUpdate);
            this.grpLineSetting.Controls.Add(this.btnDelete);
            this.grpLineSetting.Location = new System.Drawing.Point(6, 118);
            this.grpLineSetting.Name = "grpLineSetting";
            this.grpLineSetting.Size = new System.Drawing.Size(527, 192);
            this.grpLineSetting.TabIndex = 53;
            this.grpLineSetting.TabStop = false;
            this.grpLineSetting.Text = "Cấu hình dòng";
            // 
            // dgvLineSetting
            // 
            this.dgvLineSetting.AllowUserToAddRows = false;
            this.dgvLineSetting.AllowUserToDeleteRows = false;
            this.dgvLineSetting.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dgvLineSetting.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvLineSetting.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLineSetting.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colZoneDisplay,
            this.colTextOrder,
            this.colSampleText,
            this.colFontFormat});
            this.dgvLineSetting.Location = new System.Drawing.Point(6, 49);
            this.dgvLineSetting.Name = "dgvLineSetting";
            this.dgvLineSetting.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLineSetting.Size = new System.Drawing.Size(515, 137);
            this.dgvLineSetting.TabIndex = 45;
            // 
            // colZoneDisplay
            // 
            this.colZoneDisplay.DataPropertyName = "ZoneDisplay";
            this.colZoneDisplay.HeaderText = "Khu vực";
            this.colZoneDisplay.Name = "colZoneDisplay";
            this.colZoneDisplay.ReadOnly = true;
            this.colZoneDisplay.Width = 71;
            // 
            // colTextOrder
            // 
            this.colTextOrder.DataPropertyName = "OrderNum";
            this.colTextOrder.HeaderText = "Thứ tự";
            this.colTextOrder.Name = "colTextOrder";
            this.colTextOrder.ReadOnly = true;
            this.colTextOrder.Width = 65;
            // 
            // colSampleText
            // 
            this.colSampleText.DataPropertyName = "SampleText";
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.colSampleText.DefaultCellStyle = dataGridViewCellStyle2;
            this.colSampleText.HeaderText = "Test mẫu";
            this.colSampleText.Name = "colSampleText";
            this.colSampleText.Width = 76;
            // 
            // colFontFormat
            // 
            this.colFontFormat.DataPropertyName = "FontSettingDisplay";
            this.colFontFormat.HeaderText = "Kiểu chữ";
            this.colFontFormat.Name = "colFontFormat";
            this.colFontFormat.ReadOnly = true;
            this.colFontFormat.Width = 73;
            // 
            // btnAddLine
            // 
            this.btnAddLine.Location = new System.Drawing.Point(6, 20);
            this.btnAddLine.Name = "btnAddLine";
            this.btnAddLine.Size = new System.Drawing.Size(75, 23);
            this.btnAddLine.TabIndex = 46;
            this.btnAddLine.Text = "Thêm dòng";
            this.btnAddLine.UseVisualStyleBackColor = true;
            this.btnAddLine.Click += new System.EventHandler(this.btnAddLine_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(84, 20);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnUpdate.TabIndex = 47;
            this.btnUpdate.Text = "Chỉnh sửa";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(165, 20);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 48;
            this.btnDelete.Text = "Xóa dòng";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(202, 94);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(38, 13);
            this.label10.TabIndex = 41;
            this.label10.Text = "Máy in";
            // 
            // cboBarcodePrinter
            // 
            this.cboBarcodePrinter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBarcodePrinter.FormattingEnabled = true;
            this.cboBarcodePrinter.Location = new System.Drawing.Point(246, 91);
            this.cboBarcodePrinter.Name = "cboBarcodePrinter";
            this.cboBarcodePrinter.Size = new System.Drawing.Size(287, 21);
            this.cboBarcodePrinter.TabIndex = 40;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(31, 94);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(85, 13);
            this.label16.TabIndex = 44;
            this.label16.Text = "Canh lề barcode";
            // 
            // cboBarcodeAlign
            // 
            this.cboBarcodeAlign.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBarcodeAlign.FormattingEnabled = true;
            this.cboBarcodeAlign.Location = new System.Drawing.Point(122, 91);
            this.cboBarcodeAlign.Name = "cboBarcodeAlign";
            this.cboBarcodeAlign.Size = new System.Drawing.Size(57, 21);
            this.cboBarcodeAlign.TabIndex = 43;
            // 
            // nudNumberStamp
            // 
            this.nudNumberStamp.Location = new System.Drawing.Point(476, 15);
            this.nudNumberStamp.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudNumberStamp.Name = "nudNumberStamp";
            this.nudNumberStamp.Size = new System.Drawing.Size(57, 21);
            this.nudNumberStamp.TabIndex = 42;
            this.nudNumberStamp.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudNumberStamp.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.nudNumberStamp.ValueChanged += new System.EventHandler(this.Preview_ValueChanged);
            // 
            // nudDPI
            // 
            this.nudDPI.Location = new System.Drawing.Point(323, 15);
            this.nudDPI.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudDPI.Name = "nudDPI";
            this.nudDPI.Size = new System.Drawing.Size(57, 21);
            this.nudDPI.TabIndex = 41;
            this.nudDPI.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudDPI.Value = new decimal(new int[] {
            203,
            0,
            0,
            0});
            this.nudDPI.ValueChanged += new System.EventHandler(this.Preview_ValueChanged);
            // 
            // nudMMPerChar
            // 
            this.nudMMPerChar.DecimalPlaces = 2;
            this.nudMMPerChar.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.nudMMPerChar.Location = new System.Drawing.Point(323, 40);
            this.nudMMPerChar.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudMMPerChar.Name = "nudMMPerChar";
            this.nudMMPerChar.Size = new System.Drawing.Size(57, 21);
            this.nudMMPerChar.TabIndex = 40;
            this.nudMMPerChar.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudMMPerChar.Value = new decimal(new int[] {
            276,
            0,
            0,
            131072});
            this.nudMMPerChar.ValueChanged += new System.EventHandler(this.Preview_ValueChanged);
            // 
            // nudBarCodeHeight
            // 
            this.nudBarCodeHeight.Location = new System.Drawing.Point(323, 64);
            this.nudBarCodeHeight.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudBarCodeHeight.Name = "nudBarCodeHeight";
            this.nudBarCodeHeight.Size = new System.Drawing.Size(57, 21);
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
            this.nudPaperSizeH.Location = new System.Drawing.Point(185, 14);
            this.nudPaperSizeH.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudPaperSizeH.Name = "nudPaperSizeH";
            this.nudPaperSizeH.Size = new System.Drawing.Size(57, 21);
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
            this.nudPaperSizeW.Location = new System.Drawing.Point(122, 14);
            this.nudPaperSizeW.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudPaperSizeW.Name = "nudPaperSizeW";
            this.nudPaperSizeW.Size = new System.Drawing.Size(57, 21);
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
            this.nudMarginRight.Location = new System.Drawing.Point(185, 39);
            this.nudMarginRight.Name = "nudMarginRight";
            this.nudMarginRight.Size = new System.Drawing.Size(57, 21);
            this.nudMarginRight.TabIndex = 36;
            this.nudMarginRight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudMarginRight.ValueChanged += new System.EventHandler(this.Preview_ValueChanged);
            // 
            // nudMarginLeft
            // 
            this.nudMarginLeft.Location = new System.Drawing.Point(122, 39);
            this.nudMarginLeft.Name = "nudMarginLeft";
            this.nudMarginLeft.Size = new System.Drawing.Size(57, 21);
            this.nudMarginLeft.TabIndex = 35;
            this.nudMarginLeft.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudMarginLeft.ValueChanged += new System.EventHandler(this.Preview_ValueChanged);
            // 
            // nudMarginBottom
            // 
            this.nudMarginBottom.Location = new System.Drawing.Point(185, 64);
            this.nudMarginBottom.Name = "nudMarginBottom";
            this.nudMarginBottom.Size = new System.Drawing.Size(57, 21);
            this.nudMarginBottom.TabIndex = 34;
            this.nudMarginBottom.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudMarginBottom.ValueChanged += new System.EventHandler(this.Preview_ValueChanged);
            // 
            // nudMarginTop
            // 
            this.nudMarginTop.Location = new System.Drawing.Point(122, 64);
            this.nudMarginTop.Name = "nudMarginTop";
            this.nudMarginTop.Size = new System.Drawing.Size(57, 21);
            this.nudMarginTop.TabIndex = 33;
            this.nudMarginTop.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudMarginTop.ValueChanged += new System.EventHandler(this.Preview_ValueChanged);
            // 
            // nudGeneralFontSize
            // 
            this.nudGeneralFontSize.Location = new System.Drawing.Point(476, 39);
            this.nudGeneralFontSize.Name = "nudGeneralFontSize";
            this.nudGeneralFontSize.Size = new System.Drawing.Size(57, 21);
            this.nudGeneralFontSize.TabIndex = 2;
            this.nudGeneralFontSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudGeneralFontSize.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudGeneralFontSize.ValueChanged += new System.EventHandler(this.nudGeneralFontSize_ValueChanged);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(383, 68);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(83, 13);
            this.label15.TabIndex = 28;
            this.label15.Text = "Canh lề (chung)";
            // 
            // cboAlignment
            // 
            this.cboAlignment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAlignment.FormattingEnabled = true;
            this.cboAlignment.Location = new System.Drawing.Point(476, 65);
            this.cboAlignment.Name = "cboAlignment";
            this.cboAlignment.Size = new System.Drawing.Size(57, 21);
            this.cboAlignment.TabIndex = 27;
            this.cboAlignment.SelectedIndexChanged += new System.EventHandler(this.cboAlignment_SelectedIndexChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(327, 43);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(48, 13);
            this.label12.TabIndex = 33;
            this.label12.Text = "BarCode";
            // 
            // txtBarCode
            // 
            this.txtBarCode.Location = new System.Drawing.Point(381, 38);
            this.txtBarCode.Name = "txtBarCode";
            this.txtBarCode.Size = new System.Drawing.Size(131, 21);
            this.txtBarCode.TabIndex = 32;
            this.txtBarCode.Text = "1001";
            // 
            // txtNumberPage
            // 
            this.txtNumberPage.Location = new System.Drawing.Point(60, 40);
            this.txtNumberPage.Name = "txtNumberPage";
            this.txtNumberPage.Size = new System.Drawing.Size(70, 21);
            this.txtNumberPage.TabIndex = 36;
            this.txtNumberPage.Text = "1";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(6, 43);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(48, 13);
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
            this.chkShowBorder.Size = new System.Drawing.Size(119, 17);
            this.chkShowBorder.TabIndex = 39;
            this.chkShowBorder.Text = "Hiển thị đường viền";
            this.chkShowBorder.UseVisualStyleBackColor = true;
            // 
            // grpPreview
            // 
            this.grpPreview.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpPreview.Controls.Add(this.label9);
            this.grpPreview.Controls.Add(this.chkShowBorder);
            this.grpPreview.Controls.Add(this.label14);
            this.grpPreview.Controls.Add(this.txtNumberPage);
            this.grpPreview.Controls.Add(this.btnPrintPreview);
            this.grpPreview.Controls.Add(this.cboPrinter);
            this.grpPreview.Controls.Add(this.btnPrint);
            this.grpPreview.Controls.Add(this.label12);
            this.grpPreview.Controls.Add(this.txtBarCode);
            this.grpPreview.Location = new System.Drawing.Point(556, 12);
            this.grpPreview.Name = "grpPreview";
            this.grpPreview.Size = new System.Drawing.Size(518, 72);
            this.grpPreview.TabIndex = 42;
            this.grpPreview.TabStop = false;
            this.grpPreview.Text = "Preview";
            // 
            // btnPreviewImage
            // 
            this.btnPreviewImage.Location = new System.Drawing.Point(556, 90);
            this.btnPreviewImage.Name = "btnPreviewImage";
            this.btnPreviewImage.Size = new System.Drawing.Size(75, 23);
            this.btnPreviewImage.TabIndex = 42;
            this.btnPreviewImage.Text = "Xem hình";
            this.btnPreviewImage.UseVisualStyleBackColor = true;
            this.btnPreviewImage.Click += new System.EventHandler(this.btnPreviewImage_Click);
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "OrderNum";
            this.dataGridViewTextBoxColumn2.HeaderText = "Thứ tự";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 65;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "SampleText";
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn3.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewTextBoxColumn3.HeaderText = "Test mẫu";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 76;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "BlockDisplay";
            this.dataGridViewTextBoxColumn1.HeaderText = "Thông tin khối";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 99;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "FontSettingDisplay";
            this.dataGridViewTextBoxColumn4.HeaderText = "Kiểu chữ";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 73;
            // 
            // FrmBarcodeMultiLinePageSetup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1086, 541);
            this.Controls.Add(this.btnPreviewImage);
            this.Controls.Add(this.grpPreview);
            this.Controls.Add(this.pctPicture);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmBarcodeMultiLinePageSetup";
            this.ShowIcon = false;
            this.Text = "Test in ấn barcode";
            this.Load += new System.EventHandler(this.FrmBarcodeMultiLinePageSetup_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pctPicture)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.grpBlockSetting.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBlockSetting)).EndInit();
            this.grpLineSetting.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLineSetting)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudNumberStamp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDPI)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMMPerChar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudBarCodeHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPaperSizeH)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPaperSizeW)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMarginRight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMarginLeft)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMarginBottom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMarginTop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudGeneralFontSize)).EndInit();
            this.grpPreview.ResumeLayout(false);
            this.grpPreview.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnPrintPreview;
        private System.Windows.Forms.PictureBox pctPicture;
        private System.Windows.Forms.ComboBox cboPrinter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnSavePageSetting;
        private System.Windows.Forms.Button btnLoadPageSetting;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtBarCode;
        private System.Windows.Forms.TextBox txtNumberPage;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ComboBox cboAlignment;
        private System.Windows.Forms.CheckBox chkShowBorder;
        private System.Windows.Forms.GroupBox grpPreview;
        private System.Windows.Forms.NumericUpDown nudGeneralFontSize;
        private System.Windows.Forms.NumericUpDown nudMarginBottom;
        private System.Windows.Forms.NumericUpDown nudMarginTop;
        private System.Windows.Forms.NumericUpDown nudMarginRight;
        private System.Windows.Forms.NumericUpDown nudMarginLeft;
        private System.Windows.Forms.NumericUpDown nudPaperSizeH;
        private System.Windows.Forms.NumericUpDown nudPaperSizeW;
        private System.Windows.Forms.NumericUpDown nudBarCodeHeight;
        private System.Windows.Forms.NumericUpDown nudMMPerChar;
        private System.Windows.Forms.NumericUpDown nudDPI;
        private System.Windows.Forms.NumericUpDown nudNumberStamp;
        private System.Windows.Forms.Button btnPreviewImage;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.ComboBox cboBarcodeAlign;
        private System.Windows.Forms.DataGridView dgvLineSetting;
        private System.Windows.Forms.Button btnAddLine;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colZoneDisplay;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTextOrder;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSampleText;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFontFormat;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cboBarcodePrinter;
        private System.Windows.Forms.DataGridView dgvBlockSetting;
        private System.Windows.Forms.Button btnRemoveBlock;
        private System.Windows.Forms.Button btnEditBlock;
        private System.Windows.Forms.Button btnAddBlock;
        private System.Windows.Forms.GroupBox grpBlockSetting;
        private System.Windows.Forms.GroupBox grpLineSetting;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
    }
}

