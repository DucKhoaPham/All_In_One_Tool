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
    public partial class FrmBarcodeMultiLinePageSetup : Form
    {
        /// <summary>
        /// 	Logger
        /// </summary>
        private static readonly ILog _logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        private class FontSettingRowViewComparer : IComparer<FontSettingRowView>
        {
            public int Compare(FontSettingRowView x, FontSettingRowView y)
            {
                int compare = x.Zone.CompareTo(y.Zone);
                if (compare == 0)
                {
                    compare = x.OrderNum.CompareTo(y.OrderNum);
                }
                return compare;
            }
        }

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

        public class FontSettingRowView
        {
            public BarcodeMultilineZoneEnum Zone { get; set; }

            public string ZoneDisplay
            {
                get
                {
                    return Zone.ToString();
                }
            }

            public int OrderNum { get; set; }

            public FontSetting FontSetting { get; set; }

            public string FontSettingDisplay
            {
                get
                {
                    if (FontSetting != null)
                    {
                        return FontSetting.ToString();
                    }

                    return string.Empty;
                }
            }

            public string SampleText 
            {
                get
                {
                    if (FontSetting != null)
                    {
                        return FontSetting.SampleText;
                    }

                    return string.Empty;
                }
                set
                {
                    if (FontSetting != null)
                    {
                        FontSetting.SampleText = value;
                    }
                }
            }
        }

        private List<FontSettingRowView> _listFontSetting = new List<FontSettingRowView>();
        private BindingList<FontSettingRowView> _listFontSettingRowView = new BindingList<FontSettingRowView>();
        private BindingList<BarcodeBlockSettingView> _listBlockSettingRowView = new BindingList<BarcodeBlockSettingView>();

        public FrmBarcodeMultiLinePageSetup()
        {
            InitializeComponent();
            this.dgvLineSetting.AutoGenerateColumns = false;
            this.dgvBlockSetting.AutoGenerateColumns = false;
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

        private List<string> GetPaneDisplayString(BarcodeMultilineZoneEnum zoneSelected)
        {
            List<string> result = new List<string>();
            foreach (FontSettingRowView item in _listFontSettingRowView)
            {
                if (item.Zone == zoneSelected)
                {
                    result.Add(item.SampleText);
                }
            }
            return result;
        }

        private List<string> GetTopPaneDisplayString()
        {
            List<string> result = new List<string>();
            foreach (FontSettingRowView item in _listFontSettingRowView)
            {
                if (item.Zone == BarcodeMultilineZoneEnum.TopPane)
                {
                    result.Add(item.SampleText);
                }
            }
            return result;
        }

        private List<string> GetBottomPaneDisplayString()
        {
            List<string> result = new List<string>();
            foreach (FontSettingRowView item in _listFontSettingRowView)
            {
                if (item.Zone == BarcodeMultilineZoneEnum.BottomPane)
                {
                    result.Add(item.SampleText);
                }
            }
            return result;
        }

        private Bitmap ShowBitmapBarcodePreview()
        {
            Bitmap singlePage = BarcodeMultilineService.GetInstance().GenerateBitmapBarCode(
                    GetBarcodePageSetting(), this.txtBarCode.Text,
                    GetPaneDisplayString(BarcodeMultilineZoneEnum.TopPane), 
                    GetPaneDisplayString(BarcodeMultilineZoneEnum.SidePane), 
                    GetPaneDisplayString(BarcodeMultilineZoneEnum.BottomPane), 
                    GetBlockDisplayString(),
                    chkShowBorder.Checked);

            this.pctPicture.Image = singlePage;
            this.pctPicture.Refresh();
            return singlePage;
        }

        private void btnPrintPreview_Click(object sender, EventArgs e)
        {
            try
            {
                Bitmap singlePage = ShowBitmapBarcodePreview();

                singlePage = BarcodeMultilineService.GetInstance().GenerateBitmapBarCode(
                    GetBarcodePageSetting(),
                    this.txtBarCode.Text,
                    GetPaneDisplayString(BarcodeMultilineZoneEnum.TopPane),
                    GetPaneDisplayString(BarcodeMultilineZoneEnum.SidePane),
                    GetPaneDisplayString(BarcodeMultilineZoneEnum.BottomPane),
                    GetBlockDisplayString(),
                    false);

                List<Bitmap> bitmapPages = new List<Bitmap>();
                bitmapPages.Add(singlePage);

                for (int i = 1; i < Convert.ToInt32(txtNumberPage.Text); i++)
                {
                    Bitmap extraPage = BarcodeMultilineService.GetInstance().GenerateBitmapBarCode(
                        GetBarcodePageSetting(),
                        this.txtBarCode.Text,
                        GetPaneDisplayString(BarcodeMultilineZoneEnum.TopPane),
                        GetPaneDisplayString(BarcodeMultilineZoneEnum.SidePane),
                        GetPaneDisplayString(BarcodeMultilineZoneEnum.BottomPane),
                        GetBlockDisplayString(),
                        false);

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
                Bitmap singlePage = BarcodeMultilineService.GetInstance().GenerateBitmapBarCode(
                    GetBarcodePageSetting(),
                    this.txtBarCode.Text, 
                    GetPaneDisplayString(BarcodeMultilineZoneEnum.TopPane),
                    GetPaneDisplayString(BarcodeMultilineZoneEnum.SidePane),
                    GetPaneDisplayString(BarcodeMultilineZoneEnum.BottomPane), 
                    GetBlockDisplayString(),
                    false);

                this.pctPicture.Image = singlePage;

                List<Bitmap> bitmapPages = new List<Bitmap>();
                bitmapPages.Add(singlePage);

                for (int i = 1; i < Convert.ToInt32(txtNumberPage.Text); i++)
                {
                    Bitmap extraPage = BarcodeMultilineService.GetInstance().GenerateBitmapBarCode(
                        GetBarcodePageSetting(),
                        this.txtBarCode.Text,
                        GetPaneDisplayString(BarcodeMultilineZoneEnum.TopPane), 
                        GetPaneDisplayString(BarcodeMultilineZoneEnum.SidePane), 
                        GetPaneDisplayString(BarcodeMultilineZoneEnum.BottomPane),
                        GetBlockDisplayString(),
                        false);

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

        private void FrmBarcodeMultiLinePageSetup_Load(object sender, EventArgs e)
        {
            try
            {
                LoadPrinter();
                LoadHorizontalAlignment();

                this.dgvLineSetting.DataSource = this._listFontSettingRowView;
                this.dgvBlockSetting.DataSource = this._listBlockSettingRowView;

                //check no settings, create a new then save it
                BarcodeMultilinePageSetting settings = BarcodeMultilineService.GetInstance().LoadSettings(BarcodeMultilineService.DefaultSettingsFileName);
                if (settings != null)
                {
                    ApplyPageSettings(settings);
                }
                else
                {
                    BarcodeMultilineService.GetInstance().SaveSettings(settings, BarcodeMultilineService.DefaultSettingsFileName);
                }

                this.ShowBitmapBarcodePreview();
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                MessageBox.Show(ex.Message, "Error !!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ApplyPageSettings(BarcodeMultilinePageSetting pageSettings)
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

                this._listFontSetting.Clear();
                AddListFontSetting(pageSettings.TopPaneFontSettings, BarcodeMultilineZoneEnum.TopPane);
                AddListFontSetting(pageSettings.BottomPaneFontSettings, BarcodeMultilineZoneEnum.BottomPane);
                AddListFontSetting(pageSettings.SidePaneFontSettings, BarcodeMultilineZoneEnum.SidePane);

                this._listBlockSettingRowView.Clear();
                AddListBlockSetting(pageSettings.BarcodeBlockSettings);

                RefreshGrid();
            }
        }

        private void RefreshGrid()
        {
            this._listFontSetting.Sort(new FontSettingRowViewComparer());
            this._listFontSettingRowView = new BindingList<FontSettingRowView>(_listFontSetting);
            this.dgvLineSetting.DataSource = this._listFontSettingRowView;

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

        private void AddListFontSetting(List<FontSetting> listFontSetting, BarcodeMultilineZoneEnum selectedZone)
        {
            for (int i = 0; i < listFontSetting.Count; i++)
            {
                this._listFontSetting.Add(new FontSettingRowView()
                {
                    FontSetting = listFontSetting[i],
                    Zone = selectedZone,
                    OrderNum = i + 1,
                    SampleText = listFontSetting[i].SampleText
                });
            }
        }

        private BarcodeMultilinePageSetting GetBarcodePageSetting()
        {
            BarcodeMultilinePageSetting settings = new BarcodeMultilinePageSetting()
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

                TopPaneFontSettings = GetFontSetting(BarcodeMultilineZoneEnum.TopPane),
                BottomPaneFontSettings = GetFontSetting(BarcodeMultilineZoneEnum.BottomPane), 
                SidePaneFontSettings = GetFontSetting(BarcodeMultilineZoneEnum.SidePane),

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

        private List<FontSetting> GetFontSetting(BarcodeMultilineZoneEnum zoneSelected)
        {
            List<FontSetting> result = new List<FontSetting>();
            foreach (var item in this._listFontSetting)
            {
                if (item.Zone == zoneSelected)
                {
                    result.Add(item.FontSetting);
                }
            }

            return result;
        }

        private void SaveSettings()
        {
            BarcodeMultilinePageSetting settings = GetBarcodePageSetting();
            BarcodeMultilineService.GetInstance().SaveSettings(settings, BarcodeMultilineService.DefaultSettingsFileName);
        }

        private void LoadSettings()
        {
            BarcodeMultilinePageSetting settings = BarcodeMultilineService.GetInstance().LoadSettings(BarcodeMultilineService.DefaultSettingsFileName);
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

        private void btnAddLine_Click(object sender, EventArgs e)
        {
            try
            {
                using (var frm = new FrmBarcodeMultilineDetailUpdate())
                {
                    if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        var fontSetting = frm.FontSettingSelected;
                        var zoneSelected = frm.ZoneSelected;
                        var orderNum = 1;

                        for (int i = 0; i < this._listFontSetting.Count; i++)
                        {
                            var item = this._listFontSetting[i];
                            if (item.Zone == frm.ZoneSelected)
                            {
                                orderNum++;
                            }
                        }

                        _listFontSetting.Add(new FontSettingRowView()
                        {
                            Zone = frm.ZoneSelected,
                            OrderNum = orderNum,
                            FontSetting = fontSetting
                        });

                        RefreshGrid();
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

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                FontSettingRowView selectedRow = null;
                if (this.dgvLineSetting.SelectedRows.Count > 0)
                {
                    selectedRow = (FontSettingRowView)this.dgvLineSetting.SelectedRows[0].DataBoundItem;
                }

                if (selectedRow != null)
                {
                    using (var frm = new FrmBarcodeMultilineDetailUpdate())
                    {
                        frm.ZoneSelected = selectedRow.Zone;
                        frm.OrderNumSelected = selectedRow.OrderNum.ToString();
                        frm.SampleTextSelected = selectedRow.SampleText;
                        frm.FontSettingSelected = selectedRow.FontSetting;

                        if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                        {
                            selectedRow.FontSetting.CopyValue(frm.FontSettingSelected);
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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                List<FontSettingRowView> deleteList = new List<FontSettingRowView>();
                for (int i = 0; i < this.dgvLineSetting.SelectedRows.Count; i++)
                {
                    var selectedRow = (FontSettingRowView)this.dgvLineSetting.SelectedRows[i].DataBoundItem;
                    deleteList.Add(selectedRow);
                }

                foreach (FontSettingRowView deleteItem in deleteList)
                {
                    _listFontSetting.Remove(deleteItem);
                }

                int orderNum = 0;
                BarcodeMultilineZoneEnum checkingZone = BarcodeMultilineZoneEnum.BottomPane;
                for (int i = 0; i < _listFontSetting.Count; i++)
                {
                    if (i == 0)
                    {
                        checkingZone = _listFontSetting[i].Zone;
                    }

                    if (checkingZone != _listFontSetting[i].Zone)
                    {
                        checkingZone = _listFontSetting[i].Zone;
                        orderNum = 1;
                        _listFontSetting[i].OrderNum = orderNum;
                    }
                    else
                    {
                        orderNum++;
                        _listFontSetting[i].OrderNum = orderNum;
                    }
                }

                RefreshGrid();
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
                using (var frm = new FrmBarcodeMultilineBlockUpdate())
                {
                    if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        var blockSetting = frm.BlockSettingSelected;
                        _listBlockSettingRowView.Add(new BarcodeBlockSettingView(blockSetting)
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
                    using (var frm = new FrmBarcodeMultilineBlockUpdate())
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
    }
}
