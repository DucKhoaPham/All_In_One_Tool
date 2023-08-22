using log4net;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;

namespace BarcodePrint
{
    public partial class FrmBarcodePageSetup : Form
    {
        /// <summary>
        /// 	Logger
        /// </summary>
        private static readonly ILog _logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public FrmBarcodePageSetup()
        {
            InitializeComponent();
        }

        private Bitmap ShowBitmapBarcodePreview()
        {
            Bitmap singlePage = BarcodeService.GetInstance().GenerateBitmapBarCode(
                    GetBarcodePageSetting(),
                    this.txtBarCode.Text, this.txtTopLine.Text, this.txtSecondLine.Text, this.txtSideText.Text,
                    chkShowBorder.Checked,
                    this.txtBarCodeDescription.Text);

            this.pctPicture.Image = singlePage;
            this.pctPicture.Refresh();
            return singlePage;
        }

        private void btnPrintPreview_Click(object sender, EventArgs e)
        {
            try
            {
                Bitmap singlePage = ShowBitmapBarcodePreview();

                singlePage = BarcodeService.GetInstance().GenerateBitmapBarCode(
                    GetBarcodePageSetting(),
                    this.txtBarCode.Text, this.txtTopLine.Text, this.txtSecondLine.Text, this.txtSideText.Text);

                List<Bitmap> bitmapPages = new List<Bitmap>();
                bitmapPages.Add(singlePage);

                for (int i = 1; i < Convert.ToInt32(txtNumberPage.Text); i++)
                {
                    Bitmap extraPage = BarcodeService.GetInstance().GenerateBitmapBarCode(
                        GetBarcodePageSetting(),
                        this.txtBarCode.Text,
                        this.txtTopLine.Text + "-" + i,
                        this.txtSecondLine.Text + "-" + i,
                        this.txtSideText.Text + "-" + i);

                    bitmapPages.Add(extraPage);
                }

                PrintService printService = new PrintService(
                    (string)this.cboPrinter.Items[this.cboPrinter.SelectedIndex]);
                printService.SetPages(bitmapPages);
                printService.PrintPreview();
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                MessageBox.Show(ex.Message, "Error !!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                Bitmap singlePage = BarcodeService.GetInstance().GenerateBitmapBarCode(
                GetBarcodePageSetting(),
                this.txtBarCode.Text, this.txtTopLine.Text, this.txtSecondLine.Text, this.txtSideText.Text);

                this.pctPicture.Image = singlePage;

                List<Bitmap> bitmapPages = new List<Bitmap>();
                bitmapPages.Add(singlePage);

                for (int i = 1; i < Convert.ToInt32(txtNumberPage.Text); i++)
                {
                    Bitmap extraPage = BarcodeService.GetInstance().GenerateBitmapBarCode(
                        GetBarcodePageSetting(),
                        this.txtBarCode.Text,
                        this.txtTopLine.Text + "-" + i,
                        this.txtSecondLine.Text + "-" + i,
                        this.txtSideText.Text + "-" + i);

                    bitmapPages.Add(extraPage);
                }

                PrintService printService = new PrintService(
                    (string)this.cboPrinter.Items[this.cboPrinter.SelectedIndex]);
                printService.SetPages(bitmapPages);
                printService.Print();
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                MessageBox.Show(ex.Message, "Error !!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ThumbnailCallback()
        {
            return true;
        }

        private void LoadHorizontalAlignment()
        {
            foreach (var item in Enum.GetValues(typeof(StringAlignment)))
            {
                this.cboAlignment.Items.Add(item);
                this.cboBarcodeAlign.Items.Add(item);
            }

            this.cboAlignment.SelectedIndex = 0;
            this.cboBarcodeAlign.SelectedIndex = 0;
        }

        private void LoadPrinter()
        {
            foreach (var printerName in PrinterSettings.InstalledPrinters)
            {
                cboPrinter.Items.Add(printerName);
            }

            if (cboPrinter.Items.Count > 0)
            {
                cboPrinter.SelectedIndex = 0;
            }
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            try
            {
                LoadPrinter();
                LoadHorizontalAlignment();

                //check no settings, create a new then save it
                BarcodePageSetting settings = BarcodeService.GetInstance().LoadSettings(BarcodeService.DefaultSettingsFileName);
                if (settings != null)
                {
                    ApplyPageSettings(settings);
                }
                else
                {
                    BarcodeService.GetInstance().SaveSettings(settings, BarcodeService.DefaultSettingsFileName);
                }

                this.ShowBitmapBarcodePreview();
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                MessageBox.Show(ex.Message, "Error !!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ApplyPageSettings(BarcodePageSetting pageSettings)
        {
            if (pageSettings != null)
            {
                this.nudPaperSizeW.Value = Convert.ToDecimal(pageSettings.PaperSizeW);
                this.nudPaperSizeH.Value = Convert.ToDecimal(pageSettings.PaperSizeH);
                this.nudDPI.Value = Convert.ToDecimal(pageSettings.DPI);
                this.nudNumberStamp.Value = Convert.ToDecimal(pageSettings.StampsPerPage);
                this.nudBarCodeHeight.Value = Convert.ToDecimal(pageSettings.BarCodeHeight);
                this.nudMarginLeft.Value = Convert.ToDecimal(pageSettings.MarginLeft);
                this.nudMarginRight.Value = Convert.ToDecimal(pageSettings.MarginRight);
                this.nudMarginTop.Value = Convert.ToDecimal(pageSettings.MarginTop);
                this.nudMarginBottom.Value = Convert.ToDecimal(pageSettings.MarginBottom);
                this.nudGeneralFontSize.Value = Convert.ToDecimal(pageSettings.FontSize);
                this.nudMMPerChar.Value = Convert.ToDecimal(pageSettings.MMPerChar);
                this.cboAlignment.SelectedItem = pageSettings.HorizontalAlign;
                this.cboBarcodeAlign.SelectedItem = pageSettings.BarcodeAlign;

                this.ucFontFormatFirstLine.UpdateSettings(pageSettings.FirstLineFontSetting);
                this.ucFontFormatSecondLine.UpdateSettings(pageSettings.SecondLineFontSetting);
                this.ucFontFormatDescriptionLine.UpdateSettings(pageSettings.DescriptionFontSetting);
                this.ucFontFormatSideText.UpdateSettings(pageSettings.SideFontSetting);
            }
        }

        private BarcodePageSetting GetBarcodePageSetting()
        {
            BarcodePageSetting settings = new BarcodePageSetting()
            {
                PaperSizeW = Convert.ToDouble(this.nudPaperSizeW.Value),
                PaperSizeH = Convert.ToDouble(this.nudPaperSizeH.Value),
                DPI = Convert.ToDouble(this.nudDPI.Value),
                StampsPerPage = Convert.ToInt32(this.nudNumberStamp.Value),

                MarginLeft = Convert.ToDouble(this.nudMarginLeft.Value),
                MarginRight = Convert.ToDouble(this.nudMarginRight.Value),
                MarginTop = Convert.ToDouble(this.nudMarginTop.Value),
                MarginBottom = Convert.ToDouble(this.nudMarginBottom.Value),
                FontSize = Convert.ToDouble(this.nudGeneralFontSize.Value),
                MMPerChar = Convert.ToDouble(this.nudMMPerChar.Value),
                BarCodeHeight = Convert.ToDouble(nudBarCodeHeight.Value),
                HorizontalAlign = (StringAlignment)this.cboAlignment.Items[this.cboAlignment.SelectedIndex],
                BarcodeAlign = (StringAlignment)this.cboAlignment.Items[this.cboBarcodeAlign.SelectedIndex],

                FirstLineFontSetting = this.ucFontFormatFirstLine.GetSetting(),
                SecondLineFontSetting = this.ucFontFormatSecondLine.GetSetting(),
                DescriptionFontSetting = this.ucFontFormatDescriptionLine.GetSetting(),
                SideFontSetting = this.ucFontFormatSideText.GetSetting(),
            };

            return settings;
        }

        private void SaveSettings()
        {
            BarcodePageSetting settings = GetBarcodePageSetting();
            BarcodeService.GetInstance().SaveSettings(settings, BarcodeService.DefaultSettingsFileName);
        }

        private void LoadSettings()
        {
            BarcodePageSetting settings = BarcodeService.GetInstance().LoadSettings(BarcodeService.DefaultSettingsFileName);
            ApplyPageSettings(settings);
        }

        private void btnSavePageSetting_Click(object sender, EventArgs e)
        {
            try
            {
                SaveSettings();
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                MessageBox.Show(ex.Message, "Error !!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLoadPageSetting_Click(object sender, EventArgs e)
        {
            try
            {
                LoadSettings();
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                MessageBox.Show(ex.Message, "Error !!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void nudGeneralFontSize_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                this.ucFontFormatFirstLine.Settings.FontSize = Convert.ToInt32(nudGeneralFontSize.Value);
                this.ucFontFormatSecondLine.Settings.FontSize = Convert.ToInt32(nudGeneralFontSize.Value);
                this.ucFontFormatDescriptionLine.Settings.FontSize = Convert.ToInt32(nudGeneralFontSize.Value);
                this.ucFontFormatSideText.Settings.FontSize = Convert.ToInt32(nudGeneralFontSize.Value);

                this.ucFontFormatFirstLine.ReloadConfig();
                this.ucFontFormatSecondLine.ReloadConfig();
                this.ucFontFormatDescriptionLine.ReloadConfig();
                this.ucFontFormatSideText.ReloadConfig();

                this.ShowBitmapBarcodePreview();
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                MessageBox.Show(ex.Message, "Error !!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cboAlignment_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                StringAlignment alignment = (StringAlignment)this.cboAlignment.Items[this.cboAlignment.SelectedIndex];

                this.ucFontFormatFirstLine.Settings.Align = alignment;
                this.ucFontFormatSecondLine.Settings.Align = alignment;
                this.ucFontFormatDescriptionLine.Settings.Align = alignment;
                this.ucFontFormatSideText.Settings.Align = alignment;

                this.ucFontFormatFirstLine.ReloadConfig();
                this.ucFontFormatSecondLine.ReloadConfig();
                this.ucFontFormatDescriptionLine.ReloadConfig();
                this.ucFontFormatSideText.ReloadConfig();
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                MessageBox.Show(ex.Message, "Error !!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPreviewImage_Click(object sender, EventArgs e)
        {
            try
            {
                ShowBitmapBarcodePreview();
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                MessageBox.Show(ex.Message, "Error !!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Preview_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                ShowBitmapBarcodePreview();
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                MessageBox.Show(ex.Message, "Error !!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
