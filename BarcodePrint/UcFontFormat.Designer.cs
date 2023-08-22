namespace BarcodePrint
{
    partial class UcFontFormat
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.nudFontSize = new System.Windows.Forms.NumericUpDown();
            this.chkBold = new System.Windows.Forms.CheckBox();
            this.chkItalic = new System.Windows.Forms.CheckBox();
            this.nudLeftIndent = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.nudRightIndent = new System.Windows.Forms.NumericUpDown();
            this.cboAlign = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nudFontSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLeftIndent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRightIndent)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Cỡ chữ";
            // 
            // nudFontSize
            // 
            this.nudFontSize.Location = new System.Drawing.Point(76, 3);
            this.nudFontSize.Name = "nudFontSize";
            this.nudFontSize.Size = new System.Drawing.Size(97, 21);
            this.nudFontSize.TabIndex = 1;
            this.nudFontSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudFontSize.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudFontSize.ValueChanged += new System.EventHandler(this.ItemValueChanged);
            // 
            // chkBold
            // 
            this.chkBold.AutoSize = true;
            this.chkBold.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkBold.Location = new System.Drawing.Point(354, 7);
            this.chkBold.Name = "chkBold";
            this.chkBold.Size = new System.Drawing.Size(53, 17);
            this.chkBold.TabIndex = 2;
            this.chkBold.Text = "Đậm";
            this.chkBold.UseVisualStyleBackColor = true;
            this.chkBold.CheckedChanged += new System.EventHandler(this.ItemValueChanged);
            // 
            // chkItalic
            // 
            this.chkItalic.AutoSize = true;
            this.chkItalic.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkItalic.Location = new System.Drawing.Point(413, 7);
            this.chkItalic.Name = "chkItalic";
            this.chkItalic.Size = new System.Drawing.Size(65, 17);
            this.chkItalic.TabIndex = 3;
            this.chkItalic.Text = "Nghiêng";
            this.chkItalic.UseVisualStyleBackColor = true;
            this.chkItalic.CheckedChanged += new System.EventHandler(this.ItemValueChanged);
            // 
            // nudLeftIndent
            // 
            this.nudLeftIndent.Location = new System.Drawing.Point(76, 30);
            this.nudLeftIndent.Name = "nudLeftIndent";
            this.nudLeftIndent.Size = new System.Drawing.Size(97, 21);
            this.nudLeftIndent.TabIndex = 4;
            this.nudLeftIndent.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudLeftIndent.ValueChanged += new System.EventHandler(this.ItemValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Lề trái (mm)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(180, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Lề phải (mm)";
            // 
            // nudRightIndent
            // 
            this.nudRightIndent.Location = new System.Drawing.Point(254, 30);
            this.nudRightIndent.Name = "nudRightIndent";
            this.nudRightIndent.Size = new System.Drawing.Size(93, 21);
            this.nudRightIndent.TabIndex = 6;
            this.nudRightIndent.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudRightIndent.ValueChanged += new System.EventHandler(this.ItemValueChanged);
            // 
            // cboAlign
            // 
            this.cboAlign.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAlign.FormattingEnabled = true;
            this.cboAlign.Location = new System.Drawing.Point(254, 5);
            this.cboAlign.Name = "cboAlign";
            this.cboAlign.Size = new System.Drawing.Size(93, 21);
            this.cboAlign.TabIndex = 8;
            this.cboAlign.SelectedIndexChanged += new System.EventHandler(this.cboAlign_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(205, 8);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Canh lề";
            // 
            // UcFontFormat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cboAlign);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.nudRightIndent);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.nudLeftIndent);
            this.Controls.Add(this.chkItalic);
            this.Controls.Add(this.chkBold);
            this.Controls.Add(this.nudFontSize);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "UcFontFormat";
            this.Size = new System.Drawing.Size(486, 56);
            this.Load += new System.EventHandler(this.UcFontFormat_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudFontSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLeftIndent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRightIndent)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown nudFontSize;
        private System.Windows.Forms.CheckBox chkBold;
        private System.Windows.Forms.CheckBox chkItalic;
        private System.Windows.Forms.NumericUpDown nudLeftIndent;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown nudRightIndent;
        private System.Windows.Forms.ComboBox cboAlign;
        private System.Windows.Forms.Label label4;
    }
}
