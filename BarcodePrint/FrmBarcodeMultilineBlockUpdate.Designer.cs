namespace BarcodePrint
{
    partial class FrmBarcodeMultilineBlockUpdate
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
            this.ucFontFormat = new BarcodePrint.UcFontFormat();
            this.txtOrderNum = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSampleText = new System.Windows.Forms.TextBox();
            this.nudLocationX = new System.Windows.Forms.NumericUpDown();
            this.nudBlockWidth = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.nudBlockHeight = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.nudLocationY = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.chkShowBorder = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.nudLocationX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudBlockWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudBlockHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLocationY)).BeginInit();
            this.SuspendLayout();
            // 
            // ucFontFormat
            // 
            this.ucFontFormat.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ucFontFormat.Location = new System.Drawing.Point(12, 97);
            this.ucFontFormat.Name = "ucFontFormat";
            this.ucFontFormat.Size = new System.Drawing.Size(486, 56);
            this.ucFontFormat.TabIndex = 6;
            // 
            // txtOrderNum
            // 
            this.txtOrderNum.Location = new System.Drawing.Point(412, 12);
            this.txtOrderNum.Name = "txtOrderNum";
            this.txtOrderNum.ReadOnly = true;
            this.txtOrderNum.Size = new System.Drawing.Size(93, 20);
            this.txtOrderNum.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Canh trái (mm)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(368, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Thứ tự";
            // 
            // btnSave
            // 
            this.btnSave.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnSave.Location = new System.Drawing.Point(84, 159);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(165, 159);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(344, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Sample text";
            // 
            // txtSampleText
            // 
            this.txtSampleText.Location = new System.Drawing.Point(412, 37);
            this.txtSampleText.Name = "txtSampleText";
            this.txtSampleText.Size = new System.Drawing.Size(164, 20);
            this.txtSampleText.TabIndex = 5;
            // 
            // nudLocationX
            // 
            this.nudLocationX.Location = new System.Drawing.Point(100, 12);
            this.nudLocationX.Name = "nudLocationX";
            this.nudLocationX.Size = new System.Drawing.Size(77, 20);
            this.nudLocationX.TabIndex = 9;
            this.nudLocationX.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // nudBlockWidth
            // 
            this.nudBlockWidth.Location = new System.Drawing.Point(100, 38);
            this.nudBlockWidth.Name = "nudBlockWidth";
            this.nudBlockWidth.Size = new System.Drawing.Size(77, 20);
            this.nudBlockWidth.TabIndex = 11;
            this.nudBlockWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 40);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Rộng (mm)";
            // 
            // nudBlockHeight
            // 
            this.nudBlockHeight.Location = new System.Drawing.Point(273, 38);
            this.nudBlockHeight.Name = "nudBlockHeight";
            this.nudBlockHeight.Size = new System.Drawing.Size(65, 20);
            this.nudBlockHeight.TabIndex = 15;
            this.nudBlockHeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(189, 40);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "Cao (mm)";
            // 
            // nudLocationY
            // 
            this.nudLocationY.Location = new System.Drawing.Point(273, 12);
            this.nudLocationY.Name = "nudLocationY";
            this.nudLocationY.Size = new System.Drawing.Size(65, 20);
            this.nudLocationY.TabIndex = 13;
            this.nudLocationY.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(189, 15);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(78, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Canh trên (mm)";
            // 
            // chkShowBorder
            // 
            this.chkShowBorder.AutoSize = true;
            this.chkShowBorder.Location = new System.Drawing.Point(100, 64);
            this.chkShowBorder.Name = "chkShowBorder";
            this.chkShowBorder.Size = new System.Drawing.Size(95, 17);
            this.chkShowBorder.TabIndex = 16;
            this.chkShowBorder.Text = "Hiển thị khung";
            this.chkShowBorder.UseVisualStyleBackColor = true;
            // 
            // FrmBarcodeMultilineBlockUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(590, 197);
            this.Controls.Add(this.chkShowBorder);
            this.Controls.Add(this.nudBlockHeight);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.nudLocationY);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.nudBlockWidth);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.nudLocationX);
            this.Controls.Add(this.txtSampleText);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtOrderNum);
            this.Controls.Add(this.ucFontFormat);
            this.Name = "FrmBarcodeMultilineBlockUpdate";
            this.Text = "Cấu hình khối hiển thị";
            this.Load += new System.EventHandler(this.FrmBarcodeMultilineDetailUpdate_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudLocationX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudBlockWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudBlockHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLocationY)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private UcFontFormat ucFontFormat;
        private System.Windows.Forms.TextBox txtOrderNum;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSampleText;
        private System.Windows.Forms.NumericUpDown nudLocationX;
        private System.Windows.Forms.NumericUpDown nudBlockWidth;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown nudBlockHeight;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown nudLocationY;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox chkShowBorder;
    }
}