using log4net;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace BarcodePrint
{
    public partial class FrmBarcodeMultilineDetailUpdate : Form
    {
        /// <summary>
        /// 	Logger
        /// </summary>
        private static readonly ILog _logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public FontSetting FontSettingSelected { get; set; }

        public BarcodeMultilineZoneEnum ZoneSelected { get; set; }

        public string OrderNumSelected { get; set; }

        public string SampleTextSelected { get; set; }

        public FrmBarcodeMultilineDetailUpdate()
        {
            InitializeComponent();
            LoadZone();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                FontSettingSelected = this.ucFontFormat.GetSetting();
                FontSettingSelected.SampleText = this.txtSampleText.Text;

                ZoneSelected = (BarcodeMultilineZoneEnum)this.cboZone.Items[this.cboZone.SelectedIndex];
                OrderNumSelected = this.txtOrderNum.Text;
                SampleTextSelected = this.txtSampleText.Text;
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                MessageBox.Show(ex.Message, "Error !!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                FontSettingSelected = null;
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                MessageBox.Show(ex.Message, "Error !!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadZone()
        {
            foreach (var item in Enum.GetValues(typeof(BarcodeMultilineZoneEnum)))
            {
                this.cboZone.Items.Add(item);
            }
            this.cboZone.SelectedIndex = 0;
        }

        private void FrmBarcodeMultilineDetailUpdate_Load(object sender, EventArgs e)
        {
            try
            {
                if(FontSettingSelected == null) 
                {
                    FontSettingSelected = this.ucFontFormat.GetSetting();
                }

                this.ucFontFormat.UpdateSettings(FontSettingSelected);
                this.cboZone.SelectedItem = ZoneSelected;
                this.txtOrderNum.Text = OrderNumSelected;
                this.txtSampleText.Text = SampleTextSelected;
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                MessageBox.Show(ex.Message, "Error !!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
