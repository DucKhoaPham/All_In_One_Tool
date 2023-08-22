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

namespace QrCodePrint
{
    public partial class FrmQrMultilineBlockUpdate : Form
    {
        /// <summary>
        /// 	Logger
        /// </summary>
        private static readonly ILog _logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public QrCodeBlockSetting BlockSettingSelected { get; set; }

        public FrmQrMultilineBlockUpdate()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                BlockSettingSelected.FontSetting = this.ucFontFormat.GetSetting();
                BlockSettingSelected.FontSetting.SampleText = this.txtSampleText.Text;
                BlockSettingSelected.OffsetX = Convert.ToInt32(this.nudLocationX.Value);
                BlockSettingSelected.OffsetY = Convert.ToInt32(this.nudLocationY.Value);
                BlockSettingSelected.Width = Convert.ToInt32(this.nudBlockWidth.Value);
                BlockSettingSelected.Height = Convert.ToInt32(this.nudBlockHeight.Value);
                BlockSettingSelected.ShowBorder = chkShowBorder.Checked;
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
                BlockSettingSelected = null;
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                MessageBox.Show(ex.Message, "Error !!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FrmBarcodeMultilineDetailUpdate_Load(object sender, EventArgs e)
        {
            try
            {
                if (BlockSettingSelected == null) 
                {
                    BlockSettingSelected = new QrCodeBlockSetting();
                    BlockSettingSelected.FontSetting = this.ucFontFormat.GetSetting();
                }

                this.ucFontFormat.UpdateSettings(BlockSettingSelected.FontSetting);
                this.txtSampleText.Text = this.BlockSettingSelected.FontSetting.SampleText;

                this.nudLocationX.Value = BlockSettingSelected.OffsetX;
                this.nudLocationY.Value = BlockSettingSelected.OffsetY;
                this.nudBlockWidth.Value = BlockSettingSelected.Width;
                this.nudBlockHeight.Value = BlockSettingSelected.Height;
                this.chkShowBorder.Checked = BlockSettingSelected.ShowBorder;
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                MessageBox.Show(ex.Message, "Error !!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
