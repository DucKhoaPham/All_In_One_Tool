using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BarcodePrint
{
    public partial class FrmTemplate : Form
    {
        public string TemplateName
        {
            get
            {
                return this.txtTemplateName.Text;
            }
            set
            {
                this.txtTemplateName.Text = value;
            }
        }

        public BarcodeBlockTemplateSetting CurrentTemplateSetting { get; set; }

        public FrmTemplate()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if(CurrentTemplateSetting != null)
            {
                var selectedTemplate = (from t in CurrentTemplateSetting.ListDetail
                                    where t.TemplateName == TemplateName
                                    select t).FirstOrDefault();

                if(selectedTemplate != null)
                {
                    MessageBox.Show("Tên template đã tồn tại, vui lòng chọn tên khác !!!", "Cảnh báo", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            else
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}
