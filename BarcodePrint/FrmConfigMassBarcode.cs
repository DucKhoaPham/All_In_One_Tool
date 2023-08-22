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
    public partial class FrmConfigMassBarcode : Form
    {
        /// <summary>
        /// 	Logger
        /// </summary>
        private static readonly ILog _logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        const string TemplateFile = @"Config\Barcode\TemplateConfig.xml";

        const string TemplateBarcodeDetailTemplatePath = @"Config\Barcode\BarcodeConfig_{0}.xml";

        public class BarcodeBlockSettingView
        {
            public BarcodeBlockSetting Setting { get; set; }

            public BarcodeBlockSettingView(BarcodeBlockSetting setting)
            {
                this.Setting = setting;
            }

            public string BlockDisplay
            {
                get
                {
                    if (Setting != null)
                    {
                        return string.Format("X:{0}|Y:{1}|Width:{2}|Height:{3}",
                            Setting.OffsetX, Setting.OffsetY,
                            Setting.Width, Setting.Height);
                    }

                    return string.Empty;
                }
            }

            public int OrderNum { get; set; }

            public string FontSettingDisplay
            {
                get
                {
                    if (Setting != null && Setting.FontSetting != null)
                    {
                        return Setting.FontSetting.ToString();
                    }

                    return string.Empty;
                }
            }

            public string SampleText
            {
                get
                {
                    if (Setting != null && Setting.FontSetting != null)
                    {
                        return Setting.FontSetting.SampleText;
                    }

                    return string.Empty;
                }
                set
                {
                    if (Setting != null && Setting.FontSetting != null)
                    {
                        Setting.FontSetting.SampleText = value;
                    }
                }
            }
        }

        private BindingList<BarcodeBlockSettingView> _listBlockSettingRowView = new BindingList<BarcodeBlockSettingView>();

        private BarcodeBlockTemplateSetting _settingTemplate = null;

        private BindingList<BarcodeBlockTemplateSettingDetail> _listBindingTemplate = new BindingList<BarcodeBlockTemplateSettingDetail>();


        public string SettingFile { get; set; }

        public FrmConfigMassBarcode()
        {
            InitializeComponent();
            this.dgvBlockSetting.AutoGenerateColumns = false;
            this.cboTemplate.DataSource = _listBindingTemplate;
        }

        private List<string> GetBlockDisplayString()
        {
            List<string> result = new List<string>();
            foreach (BarcodeBlockSettingView item in _listBlockSettingRowView)
            {
                result.Add(item.SampleText);
            }
            return result;
        }

        private Bitmap ShowBitmapBarcodePreview()
        {
            var settings = GetBarcodePageSetting();

            double zoomRatio = pctPicture.Width / settings.PaperSizeW;
            double barcodePageW = BarcodeBlockService.GetInstance().ConvertFromMmToPixelDot(
                settings.PaperSizeW, zoomRatio);
            double barcodePageH = BarcodeBlockService.GetInstance().ConvertFromMmToPixelDot(
                settings.PaperSizeH, zoomRatio);

            Bitmap pidImage = new Bitmap((int)barcodePageW, (int)barcodePageH);
            using (Graphics canvas = Graphics.FromImage(pidImage))
            {
                //double ratio = pctPicture.Width / settings.PaperSizeW;
                BarcodeBlockService.GetInstance().Draw(GetBarcodePageSetting(), zoomRatio, canvas, this.txtBarCode.Text,
                    GetBlockDisplayString(),
                    chkShowBorder.Checked);
                canvas.Save();
            }

            this.pctPicture.Image = pidImage;
            this.pctPicture.Refresh();
            return pidImage;
        }

        private void btnPrintPreview_Click(object sender, EventArgs e)
        {
            try
            {

                int N = int.Parse(num2.Value.ToString());
                int step = int.Parse(num1.Value.ToString());
                for (int i = step; i <= N; i++)
                {
                    string BarCode = txtBarCode.Text + "-" + i;
                    BarcodeBlockPrintHelper.PrintPreview(
                GetBarcodePageSetting(),
                (string)this.cboPrinter.Items[this.cboPrinter.SelectedIndex],
                txtBarCode.Text, GetBlockDisplayString(GetBarcodePageSetting()), Convert.ToInt16(nudCopies.Value));
                }

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
                int N = int.Parse(num2.Value.ToString());
                int step = int.Parse(num1.Value.ToString());

                List<string> blockCode = new List<string>();
                blockCode = GetBlockDisplayString(GetBarcodePageSetting());
               
                for (int i = step; i <= N; i++)
                {
                    string BarCode =  i.ToString();
                    blockCode[blockCode.Count - 1] = BarCode;
                    BarcodeBlockPrintHelper.Print(
                       GetBarcodePageSetting(),
                       (string)this.cboPrinter.Items[this.cboPrinter.SelectedIndex],
                       BarCode, blockCode, Convert.ToInt16(nudCopies.Value));
                }

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


        private void LoadPrinter()
        {
            foreach (var printerName in PrinterSettings.InstalledPrinters)
            {
                cboPrinter.Items.Add(printerName);
                cboBarcodePrinter.Items.Add(printerName);
            }

            if (cboPrinter.Items.Count > 0)
            {
                cboPrinter.SelectedIndex = 0;
            }

            if (cboBarcodePrinter.Items.Count > 0)
            {
                cboBarcodePrinter.SelectedIndex = 0;
            }
        }

        private List<string> GetBlockDisplayString(BarcodeMultiZoneSetting settings)
        {
            List<string> result = new List<string>();
            foreach (var item in settings.BarcodeBlockSettings)
            {
                result.Add(item.FontSetting.SampleText);
            }
            return result;
        }

        private void FrmConfigMassBarcode_Load(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(SettingFile))
                {
                    SettingFile = BarcodeBlockService.DefaultSettingsFileName;
                }

                this.txtTemplatePath.Text = SettingFile;

                _settingTemplate = LoadTemplateSettings(TemplateFile);
                if (_settingTemplate == null)
                {
                    _settingTemplate = new BarcodeBlockTemplateSetting();
                }
                SaveTemplateSettings(_settingTemplate, TemplateFile);

                LoadPrinter();

                foreach (var item in _settingTemplate.ListDetail)
                {
                    _listBindingTemplate.Add(item);
                }
                _listBindingTemplate.ResetBindings();
                this.cboTemplate.SelectedItem = null;


                this.dgvBlockSetting.DataSource = this._listBlockSettingRowView;

                //check no settings, create a new then save it
                BarcodeMultiZoneSetting settings = BarcodeBlockService.GetInstance().LoadSettings(
                    SettingFile);
                if (settings != null)
                {
                    ApplyPageSettings(settings);
                }
                else
                {
                    BarcodeBlockService.GetInstance().SaveSettings(settings,
                        SettingFile);
                }

                this.ShowBitmapBarcodePreview();
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                MessageBox.Show(ex.Message, "Error !!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ApplyPageSettings(BarcodeMultiZoneSetting pageSettings)
        {
            if (pageSettings != null)
            {
                this.nudPaperSizeW.Value = Convert.ToDecimal(pageSettings.PaperSizeW);
                this.nudPaperSizeH.Value = Convert.ToDecimal(pageSettings.PaperSizeH);
                //this.nudDPI.Value = Convert.ToDecimal(pageSettings.DPI);
                this.nudNumberStamp.Value = Convert.ToDecimal(pageSettings.StampsPerPage);
                this.nudMarginLeft.Value = Convert.ToDecimal(pageSettings.MarginLeft);
                this.nudMarginRight.Value = Convert.ToDecimal(pageSettings.MarginRight);
                this.nudMarginTop.Value = Convert.ToDecimal(pageSettings.MarginTop);
                this.nudMarginBottom.Value = Convert.ToDecimal(pageSettings.MarginBottom);

                this.nudBarCodeWidth.Value = Convert.ToDecimal(pageSettings.BarCodeWidth);
                this.nudBarCodeHeight.Value = Convert.ToDecimal(pageSettings.BarCodeHeight);
                this.nudBarcodeOffsetLeft.Value = Convert.ToDecimal(pageSettings.BarcodeOffsetLeft);
                this.nudBarcodeOffsetTop.Value = Convert.ToDecimal(pageSettings.BarcodeOffsetTop);

                //this.cboBarcodeAlign.SelectedItem = pageSettings.BarcodeAlign;
                this.txtBarCode.Text = pageSettings.SamplpeBarcode;

                if (!string.IsNullOrEmpty(pageSettings.BarcodePrinterName))
                {
                    bool foundBarCodePrinter = false;
                    for (int i = 0; i < cboBarcodePrinter.Items.Count && !foundBarCodePrinter; i++)
                    {
                        if (cboBarcodePrinter.Items[i].ToString() == pageSettings.BarcodePrinterName)
                        {
                            cboBarcodePrinter.SelectedIndex = i;
                            foundBarCodePrinter = true;
                        }
                    }
                }

                this._listBlockSettingRowView.Clear();
                AddListBlockSetting(pageSettings.BarcodeBlockSettings);

                RefreshGrid();
            }
        }

        private void RefreshGrid()
        {
            this.dgvBlockSetting.Refresh();
        }

        private void AddListBlockSetting(List<BarcodeBlockSetting> listSetting)
        {
            for (int i = 0; i < listSetting.Count; i++)
            {
                this._listBlockSettingRowView.Add(new BarcodeBlockSettingView(listSetting[i])
                {
                    OrderNum = i + 1,
                });
            }
        }

        private BarcodeMultiZoneSetting GetBarcodePageSetting()
        {
            var settings = new BarcodeMultiZoneSetting()
            {
                PaperSizeW = Convert.ToDouble(this.nudPaperSizeW.Value),
                PaperSizeH = Convert.ToDouble(this.nudPaperSizeH.Value),
                //DPI = Convert.ToDouble(this.nudDPI.Value),
                StampsPerPage = Convert.ToInt32(this.nudNumberStamp.Value),

                MarginLeft = Convert.ToDouble(this.nudMarginLeft.Value),
                MarginRight = Convert.ToDouble(this.nudMarginRight.Value),
                MarginTop = Convert.ToDouble(this.nudMarginTop.Value),
                MarginBottom = Convert.ToDouble(this.nudMarginBottom.Value),
                BarCodeWidth = Convert.ToDouble(this.nudBarCodeWidth.Value),
                BarCodeHeight = Convert.ToDouble(nudBarCodeHeight.Value),
                BarcodeOffsetLeft = Convert.ToDouble(nudBarcodeOffsetLeft.Value),
                BarcodeOffsetTop = Convert.ToDouble(nudBarcodeOffsetTop.Value),
                //BarcodeAlign = (StringAlignment)this.cboBarcodeAlign.Items[this.cboBarcodeAlign.SelectedIndex],
                SamplpeBarcode = this.txtBarCode.Text,

                BarcodeBlockSettings = GetBlockSetting(),
            };

            if (this.cboBarcodePrinter.SelectedItem != null)
            {
                settings.BarcodePrinterName = this.cboBarcodePrinter.SelectedItem.ToString();
            }
            else
            {
                settings.BarcodePrinterName = string.Empty;
            }

            return settings;
        }

        private List<BarcodeBlockSetting> GetBlockSetting()
        {
            List<BarcodeBlockSetting> result = new List<BarcodeBlockSetting>();
            foreach (var item in this._listBlockSettingRowView)
            {
                result.Add(item.Setting);
            }

            return result;
        }

        private void SaveSettings()
        {
            BarcodeMultiZoneSetting settings = GetBarcodePageSetting();
            BarcodeBlockService.GetInstance().SaveSettings(settings,
                SettingFile);
        }

        private void LoadSettings()
        {
            BarcodeMultiZoneSetting settings = BarcodeBlockService.GetInstance().LoadSettings(
                SettingFile);
            ApplyPageSettings(settings);
            ShowBitmapBarcodePreview();
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

                this.ShowBitmapBarcodePreview();
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

        private void btnAddBlock_Click(object sender, EventArgs e)
        {
            try
            {
                using (var frm = new FrmBarcodeBlockUpdate())
                {
                    if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        var blockSetting = frm.BlockSettingSelected;
                        _listBlockSettingRowView.Add(new BarcodeBlockSettingView(blockSetting)
                        {
                            OrderNum = _listBlockSettingRowView.Count + 1,
                        });

                        ShowBitmapBarcodePreview();
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                MessageBox.Show(ex.Message, "Error !!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRemoveBlock_Click(object sender, EventArgs e)
        {
            try
            {
                List<BarcodeBlockSettingView> deleteList = new List<BarcodeBlockSettingView>();
                for (int i = 0; i < this.dgvBlockSetting.SelectedRows.Count; i++)
                {
                    if (this.dgvBlockSetting.SelectedRows[i] != null &&
                        this.dgvBlockSetting.SelectedRows[i].DataBoundItem != null)
                    {
                        var selectedRow = this.dgvBlockSetting.SelectedRows[i].DataBoundItem as BarcodeBlockSettingView;
                        if (selectedRow != null)
                        {
                            deleteList.Add(selectedRow);
                        }
                    }
                }

                foreach (BarcodeBlockSettingView deleteItem in deleteList)
                {
                    _listBlockSettingRowView.Remove(deleteItem);
                }

                for (int i = 0; i < _listBlockSettingRowView.Count; i++)
                {
                    _listBlockSettingRowView[i].OrderNum = i + 1;
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                MessageBox.Show(ex.Message, "Error !!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEditBlock_Click(object sender, EventArgs e)
        {
            try
            {
                BarcodeBlockSettingView selectedRow = null;
                if (this.dgvBlockSetting.SelectedRows.Count > 0)
                {
                    selectedRow = this.dgvBlockSetting.SelectedRows[0].DataBoundItem as BarcodeBlockSettingView;
                }

                if (selectedRow != null)
                {
                    using (var frm = new FrmBarcodeBlockUpdate())
                    {
                        frm.BlockSettingSelected = selectedRow.Setting.Clone() as BarcodeBlockSetting;
                        if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                        {
                            selectedRow.Setting.CopyValue(frm.BlockSettingSelected);
                            RefreshGrid();
                            ShowBitmapBarcodePreview();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                MessageBox.Show(ex.Message, "Error !!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public BarcodeBlockTemplateSetting LoadTemplateSettings(string fileName)
        {
            FileInfo file = new FileInfo(fileName);

            if (!Directory.Exists(file.DirectoryName))
            {
                Directory.CreateDirectory(file.DirectoryName);
            }

            BarcodeBlockTemplateSetting result = null;
            string fullPath = fileName;
            if (!File.Exists(fullPath))
            {
                fullPath = string.Format("{0}\\{1}",
                    System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location),
                    fileName);
            }

            if (File.Exists(fullPath))
            {
                using (TextReader readFileStream = new StreamReader(fullPath))
                {
                    string data = readFileStream.ReadToEnd();
                    result = BarcodeBlockTemplateSetting.Deserialize(data);
                }
            }

            return result;
        }

        public void SaveTemplateSettings(BarcodeBlockTemplateSetting settings, string fileName)
        {
            FileInfo file = new FileInfo(fileName);

            if (!Directory.Exists(file.DirectoryName))
            {
                Directory.CreateDirectory(file.DirectoryName);
            }

            using (FileStream fileStream = File.Create(fileName))
            {
                string data = BarcodeBlockTemplateSetting.Serialize(settings);
                byte[] rawData = UTF8Encoding.UTF8.GetBytes(data);
                fileStream.Write(rawData, 0, rawData.Length);
            }
        }

        private void btnAddTemplate_Click(object sender, EventArgs e)
        {
            try
            {
                using (var frm = new FrmTemplate())
                {
                    frm.CurrentTemplateSetting = _settingTemplate;
                    if (frm.ShowDialog(this) == DialogResult.OK)
                    {
                        string fullPath = string.Format(TemplateBarcodeDetailTemplatePath, frm.TemplateName);
                        if (!File.Exists(fullPath))
                        {
                            fullPath = string.Format("{0}\\{1}",
                                System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location),
                                fullPath);
                        }

                        var templateDetail = new BarcodeBlockTemplateSettingDetail()
                        {
                            TemplateName = frm.TemplateName,
                            TemplatePath = fullPath
                        };

                        _settingTemplate.ListDetail.Add(templateDetail);
                        SaveTemplateSettings(_settingTemplate, TemplateFile);

                        SettingFile = templateDetail.TemplatePath;
                        _listBindingTemplate.Add(templateDetail);
                        _listBindingTemplate.ResetBindings();
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                MessageBox.Show(ex.Message, "Error !!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cboTemplate_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                var templateDetail = cboTemplate.SelectedItem as BarcodeBlockTemplateSettingDetail;
                if (templateDetail != null)
                {
                    SettingFile = templateDetail.TemplatePath;
                    LoadSettings();
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                MessageBox.Show(ex.Message, "Error !!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDeleteTemplate_Click(object sender, EventArgs e)
        {
            try
            {
                var templateDetail = cboTemplate.SelectedItem as BarcodeBlockTemplateSettingDetail;
                if (templateDetail != null)
                {
                    _settingTemplate.ListDetail.Remove(templateDetail);
                    SaveTemplateSettings(_settingTemplate, TemplateFile);

                    _listBindingTemplate.Remove(templateDetail);
                    _listBindingTemplate.ResetBindings();
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                MessageBox.Show(ex.Message, "Error !!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnTestPrint_Click(object sender, EventArgs e)
        {

        }

        private void grpPreview_Enter(object sender, EventArgs e)
        {

        }
    }
}
