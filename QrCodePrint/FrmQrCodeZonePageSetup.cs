using BarcodePrint;
using log4net;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;

namespace QrCodePrint
{
    public partial class FrmQrCodeZonePageSetup : Form
    {
        /// <summary>
        /// 	Logger
        /// </summary>
        private static readonly ILog _logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        const string TemplateFile = @"Config\Barcode\TemplateConfig.xml";

        const string TemplateBarcodeDetailTemplatePath = @"Config\Barcode\BarcodeConfig_{0}.xml";

        //private class FontSettingRowViewComparer : IComparer<FontSettingRowView>
        //{
        //    public int Compare(FontSettingRowView x, FontSettingRowView y)
        //    {
        //        int compare = x.Zone.CompareTo(y.Zone);
        //        if (compare == 0)
        //        {
        //            compare = x.OrderNum.CompareTo(y.OrderNum);
        //        }
        //        return compare;
        //    }
        //}

        public class QrCodeBlockSettingView
        {
            public QrCodeBlockSetting Setting { get; set; }

            public QrCodeBlockSettingView(QrCodeBlockSetting setting)
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

        //public class FontSettingRowView
        //{
        //    public BarcodeMultilineZoneEnum Zone { get; set; }

        //    public string ZoneDisplay
        //    {
        //        get
        //        {
        //            return Zone.ToString();
        //        }
        //    }

        //    public int OrderNum { get; set; }

        //    public FontSetting FontSetting { get; set; }

        //    public string FontSettingDisplay
        //    {
        //        get
        //        {
        //            if (FontSetting != null)
        //            {
        //                return FontSetting.ToString();
        //            }

        //            return string.Empty;
        //        }
        //    }

        //    public string SampleText 
        //    {
        //        get
        //        {
        //            if (FontSetting != null)
        //            {
        //                return FontSetting.SampleText;
        //            }

        //            return string.Empty;
        //        }
        //        set
        //        {
        //            if (FontSetting != null)
        //            {
        //                FontSetting.SampleText = value;
        //            }
        //        }
        //    }
        //}

        private BindingList<QrCodeBlockSettingView> _listBlockSettingRowView = new BindingList<QrCodeBlockSettingView>();

        private QrCodeBlockTemplateSetting _settingTemplate = null;

        private BindingList<QrCodeBlockTemplateSettingDetail> _listBindingTemplate = new BindingList<QrCodeBlockTemplateSettingDetail>();
        

        public string SettingFile { get; set; }

        public FrmQrCodeZonePageSetup()
        {
            InitializeComponent();
            this.dgvBlockSetting.AutoGenerateColumns = false;
            this.cboTemplate.DataSource = _listBindingTemplate;
        }

        private List<string> GetBlockDisplayString()
        {
            List<string> result = new List<string>();
            foreach (QrCodeBlockSettingView item in _listBlockSettingRowView)
            {
                result.Add(item.SampleText);
            }
            return result;
        }

        private Bitmap ShowBitmapBarcodePreview()
        {
            var settings = GetBarcodePageSetting();
            Bitmap img = null;
            List<Bitmap> bitmapPages = new List<Bitmap>();
            List<Bitmap> bitmapPrint = new List<Bitmap>();
            for(int i=0;i<nudNumberTemInRow.Value;i++)
            {
                string[] _listinfo = new string[settings.QrCodeBlockSettings.Count];

                for(int ii=0;ii< settings.QrCodeBlockSettings.Count;ii++)
                {
                    _listinfo[ii] = settings.QrCodeBlockSettings[ii].FontSetting.SampleText;
                }

                var bitmapPage = QrCodeZoneService.GetInstance().CreateBarcodeBitmap(settings, this.txtBarCode.Text,new List<string>(_listinfo));

                bitmapPages.Add(bitmapPage);
            }
            bitmapPrint.AddRange(QrCodeZoneService.GetInstance().CreateBarcodeMutiImge(bitmapPages, settings));
            if(bitmapPrint.Count>=1)
            {
                this.pctPicture.Image = bitmapPrint[0];
                this.pctPicture.Refresh();
                img= bitmapPrint[0];
            }
            return img;
        }

        private void btnPrintPreview_Click(object sender, EventArgs e)
        {
            try
            {
                QrCodePrintHelper.PrintPreview(
                    GetBarcodePageSetting(),
                    (string)this.cboPrinter.Items[this.cboPrinter.SelectedIndex],
                    txtBarCode.Text, GetBlockDisplayString(GetBarcodePageSetting()), Convert.ToInt16(nudCopies.Value));
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
                var settings = GetBarcodePageSetting();
                Bitmap img = null;
                List<Bitmap> bitmapPages = new List<Bitmap>();
                List<Bitmap> bitmapPrint = new List<Bitmap>();
                for (int i = 0; i < nudNumberTemInRow.Value; i++)
                {
                    string[] _listinfo = new string[settings.QrCodeBlockSettings.Count];

                    for (int ii = 0; ii < settings.QrCodeBlockSettings.Count; ii++)
                    {
                        _listinfo[ii] = settings.QrCodeBlockSettings[ii].FontSetting.SampleText;
                    }

                    var bitmapPage = QrCodeZoneService.GetInstance().CreateBarcodeBitmap(settings, this.txtBarCode.Text, new List<string>(_listinfo));

                    bitmapPages.Add(bitmapPage);
                }
                bitmapPrint.AddRange(QrCodeZoneService.GetInstance().CreateBarcodeMutiImge(bitmapPages, settings));
                if (bitmapPrint.Count >= 1)
                {
                    this.pctPicture.Image = bitmapPrint[0];
                    this.pctPicture.Refresh();
                    img = bitmapPrint[0];
                }
                BarcodePrintHelper.PrintImg(bitmapPrint, settings.BarcodePrinterName, (float)(settings.PaperSizeW* settings.NumberTemInRow), (float)settings.PaperSizeH, (int)settings.DPI);
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

        private List<string> GetBlockDisplayString(QrCodeZoneSetting settings)
        {
            List<string> result = new List<string>();
            foreach (var item in settings.QrCodeBlockSettings)
            {
                result.Add(item.FontSetting.SampleText);
            }
            return result;
        }

        private void FrmBarcodeMultiZonePageSetup_Load(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(SettingFile))
                {
                    SettingFile = QrCodeZoneService.DefaultSettingsFileName;
                }

                this.txtTemplatePath.Text = SettingFile;

                _settingTemplate = LoadTemplateSettings(TemplateFile);
                if(_settingTemplate == null)
                {
                    _settingTemplate = new QrCodeBlockTemplateSetting();
                }
                SaveTemplateSettings(_settingTemplate, TemplateFile);

                LoadPrinter();

                foreach(var item in _settingTemplate.ListDetail)
                {
                    _listBindingTemplate.Add(item);
                }
                _listBindingTemplate.ResetBindings();
                this.cboTemplate.SelectedItem = null;


                this.dgvBlockSetting.DataSource = this._listBlockSettingRowView;

                //check no settings, create a new then save it
                QrCodeZoneSetting settings = QrCodeZoneService.GetInstance().LoadSettings(
                    SettingFile);
                if (settings != null)
                {
                    ApplyPageSettings(settings);
                }
                else
                {
                    QrCodeZoneService.GetInstance().SaveSettings(settings,
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

        private void ApplyPageSettings(QrCodeZoneSetting pageSettings)
        {
            if (pageSettings != null)
            {
                this.nudZoom.Value = Convert.ToDecimal(pageSettings.Zoom);
                this.nudDPI.Value = Convert.ToDecimal(pageSettings.DPI);
                this.nudPaperSizeW.Value = Convert.ToDecimal(pageSettings.PaperSizeW);
                this.nudPaperSizeH.Value = Convert.ToDecimal(pageSettings.PaperSizeH);
                //this.nudDPI.Value = Convert.ToDecimal(pageSettings.DPI);
                this.nudNumberStamp.Value = Convert.ToDecimal(pageSettings.StampsPerPage);
                this.nudNumberTemInRow.Value = Convert.ToDecimal(pageSettings.NumberTemInRow);
                this.nudMarginLeft.Value = Convert.ToDecimal(pageSettings.MarginLeft);
                this.nudMarginRight.Value = Convert.ToDecimal(pageSettings.MarginRight);
                this.nudMarginTop.Value = Convert.ToDecimal(pageSettings.MarginTop);
                this.nudMarginBottom.Value = Convert.ToDecimal(pageSettings.MarginBottom);

                this.nudBarCodeWidth.Value = Convert.ToDecimal(pageSettings.BarCodeWidth);
                //this.nudBarCodeHeight.Value = Convert.ToDecimal(pageSettings.BarCodeHeight);
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
                nudBatDau.Value = pageSettings.NumberBegin;
                nudNumberEnd.Value = pageSettings.NumberEnd;
                txtTienTo.Text = pageSettings.TienTo;
                txtHauTo.Text = pageSettings.HauTo;
                nudNumberPrintTem.Value = pageSettings.NumberPrintTem;

                this._listBlockSettingRowView.Clear();
                AddListBlockSetting(pageSettings.QrCodeBlockSettings);

                RefreshGrid();
            }
        }

        private void RefreshGrid()
        {
            this.dgvBlockSetting.Refresh();
        }

        private void AddListBlockSetting(List<QrCodeBlockSetting> listSetting)
        {
            for (int i = 0; i < listSetting.Count; i++)
            {
                this._listBlockSettingRowView.Add(new QrCodeBlockSettingView(listSetting[i])
                {
                    OrderNum = i + 1,
                });
            }
        }

        private QrCodeZoneSetting GetBarcodePageSetting()
        {
            var settings = new QrCodeZoneSetting()
            {
                PaperSizeW = Convert.ToDouble(this.nudPaperSizeW.Value),
                Zoom = Convert.ToDouble(this.nudZoom.Value),
                DPI = Convert.ToDouble(this.nudDPI.Value),
                PaperSizeH = Convert.ToDouble(this.nudPaperSizeH.Value),
                //DPI = Convert.ToDouble(this.nudDPI.Value),
                StampsPerPage = Convert.ToInt32(this.nudNumberStamp.Value),
                NumberTemInRow = Convert.ToInt32(this.nudNumberTemInRow.Value),
                MarginLeft = Convert.ToDouble(this.nudMarginLeft.Value),
                MarginRight = Convert.ToDouble(this.nudMarginRight.Value),
                MarginTop = Convert.ToDouble(this.nudMarginTop.Value),
                MarginBottom = Convert.ToDouble(this.nudMarginBottom.Value),
                BarCodeWidth = Convert.ToDouble(this.nudBarCodeWidth.Value),
                //BarCodeHeight = Convert.ToDouble(nudBarCodeHeight.Value),
                BarcodeOffsetLeft = Convert.ToDouble(nudBarcodeOffsetLeft.Value),
                BarcodeOffsetTop = Convert.ToDouble(nudBarcodeOffsetTop.Value),
                //BarcodeAlign = (StringAlignment)this.cboBarcodeAlign.Items[this.cboBarcodeAlign.SelectedIndex],
                SamplpeBarcode = this.txtBarCode.Text,
                QrCodeBlockSettings = GetBlockSetting(),
                NumberBegin=Convert.ToInt32(nudBatDau.Value),
                NumberEnd = Convert.ToInt32(nudNumberEnd.Value),
                TienTo=txtTienTo.Text,
                HauTo=txtHauTo.Text,
                NumberPrintTem=Convert.ToInt32(nudNumberPrintTem.Value)
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

        private List<QrCodeBlockSetting> GetBlockSetting()
        {
            List<QrCodeBlockSetting> result = new List<QrCodeBlockSetting>();
            foreach (var item in this._listBlockSettingRowView)
            {
                result.Add(item.Setting);
            }

            return result;
        }

        private void SaveSettings()
        {
            QrCodeZoneSetting settings = GetBarcodePageSetting();
            QrCodeZoneService.GetInstance().SaveSettings(settings,
                SettingFile);
        }

        private void LoadSettings()
        {
            QrCodeZoneSetting settings = QrCodeZoneService.GetInstance().LoadSettings(
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
                using (var frm = new FrmQrMultilineBlockUpdate())
                {
                    if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        var blockSetting = frm.BlockSettingSelected;
                        _listBlockSettingRowView.Add(new QrCodeBlockSettingView(blockSetting)
                        {
                            OrderNum = _listBlockSettingRowView.Count +1,
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
                List<QrCodeBlockSettingView> deleteList = new List<QrCodeBlockSettingView>();
                for (int i = 0; i < this.dgvBlockSetting.SelectedRows.Count; i++)
                {
                    if (this.dgvBlockSetting.SelectedRows[i] != null &&
                        this.dgvBlockSetting.SelectedRows[i].DataBoundItem != null)
                    {
                        var selectedRow = this.dgvBlockSetting.SelectedRows[i].DataBoundItem as QrCodeBlockSettingView;
                        if (selectedRow != null)
                        {
                            deleteList.Add(selectedRow);
                        }
                    }
                }

                foreach (QrCodeBlockSettingView deleteItem in deleteList)
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
                QrCodeBlockSettingView selectedRow = null;
                if (this.dgvBlockSetting.SelectedRows.Count > 0)
                {
                    selectedRow = this.dgvBlockSetting.SelectedRows[0].DataBoundItem as QrCodeBlockSettingView;
                }

                if (selectedRow != null)
                {
                    using (var frm = new FrmQrMultilineBlockUpdate())
                    {
                        frm.BlockSettingSelected = selectedRow.Setting.Clone() as QrCodeBlockSetting;
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

        public QrCodeBlockTemplateSetting LoadTemplateSettings(string fileName)
        {
            FileInfo file = new FileInfo(fileName);

            if (!Directory.Exists(file.DirectoryName))
            {
                Directory.CreateDirectory(file.DirectoryName);
            }

            QrCodeBlockTemplateSetting result = null;
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
                    result = QrCodeBlockTemplateSetting.Deserialize(data);
                }
            }

            return result;
        }

        public void SaveTemplateSettings(QrCodeBlockTemplateSetting settings, string fileName)
        {
            FileInfo file = new FileInfo(fileName);

            if (!Directory.Exists(file.DirectoryName))
            {
                Directory.CreateDirectory(file.DirectoryName);
            }

            using (FileStream fileStream = File.Create(fileName))
            {
                string data = QrCodeBlockTemplateSetting.Serialize(settings);
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

                        var templateDetail = new QrCodeBlockTemplateSettingDetail()
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
                var templateDetail = cboTemplate.SelectedItem as QrCodeBlockTemplateSettingDetail;
                if(templateDetail != null)
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
                var templateDetail = cboTemplate.SelectedItem as QrCodeBlockTemplateSettingDetail;
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

        private void btnPrintAuto_Click(object sender, EventArgs e)
        {
            try
            {
                btnSavePageSetting_Click(null, null);
                var settings = GetBarcodePageSetting();
                Bitmap img = null;
                List<Bitmap> bitmapPages = new List<Bitmap>();
                List<Bitmap> bitmapPrint = new List<Bitmap>();
                string _stt = "";
                for (int i = Convert.ToInt32(nudBatDau.Value); i <= Convert.ToInt32(nudNumberEnd.Value); i++)
                {
                    _stt = i.ToString().Trim();
                    if(_stt.Length<nudNumberSTTLength.Value)
                    {
                        while(_stt.Length<nudNumberSTTLength.Value)
                        {
                            _stt = "0" + _stt;
                        }
                    }
                    string[] _listinfo = new string[settings.QrCodeBlockSettings.Count];
                    if(settings.QrCodeBlockSettings.Count>=2)
                    {
                        _listinfo[0] = _stt + txtHauTo.Text;
                        _listinfo[1] = txtTienTo.Text;
                        for (int ii = 2; ii < settings.QrCodeBlockSettings.Count; ii++)
                        {
                            _listinfo[ii] = settings.QrCodeBlockSettings[ii].FontSetting.SampleText;
                        }
                        var bitmapPage = QrCodeZoneService.GetInstance().CreateBarcodeBitmap(settings, txtTienTo.Text + _stt + txtHauTo.Text, new List<string>(_listinfo));
                        for (var j = 0; j < nudNumberPrintTem.Value; j++)
                        {
                            bitmapPages.Add(bitmapPage);
                        }
                    }
                }
                bitmapPrint.AddRange(QrCodeZoneService.GetInstance().CreateBarcodeMutiImge(bitmapPages, settings));
                if (bitmapPrint.Count >= 1)
                {
                    this.pctPicture.Image = bitmapPrint[0];
                    this.pctPicture.Refresh();
                    img = bitmapPrint[0];
                }
                BarcodePrintHelper.PrintImg(bitmapPrint, settings.BarcodePrinterName, (float)(settings.PaperSizeW * settings.NumberTemInRow), (float)settings.PaperSizeH, (int)settings.DPI);
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                MessageBox.Show(ex.Message, "Error !!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel2.Visible = !panel2.Visible;
        }
    }
}
