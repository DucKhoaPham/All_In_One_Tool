using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using log4net;
using System.Reflection;

namespace QrCodePrint
{
    public partial class UcFontFormat : UserControl
    {
        /// <summary>
        /// 	Logger
        /// </summary>
        private static readonly ILog _logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public FontSetting Settings { get; private set; }

        //[Description("Value changed of any detail item")]
        //public event EventHandler ValueChanged;

        private class SelectComboboxAlignment
        {
            public StringAlignment Alignment { get; set; }
            public string DisplayName
            {
                get
                {
                    return Alignment.ToString();
                }
            }
        }

        public UcFontFormat()
        {
            Settings = new FontSetting(); 
            InitializeComponent();
        }

        public void ReloadConfig()
        {
            this.nudFontSize.DataBindings.Clear();
            this.cboAlign.DataBindings.Clear();
            this.chkBold.DataBindings.Clear();
            this.chkItalic.DataBindings.Clear();
            this.nudLeftIndent.DataBindings.Clear();
            this.nudRightIndent.DataBindings.Clear();

            this.nudFontSize.DataBindings.Add("Value", Settings, "FontSize");
            this.cboAlign.DataBindings.Add("SelectedValue", Settings, "Align");
            this.chkBold.DataBindings.Add("Checked", Settings, "IsBold");
            this.chkItalic.DataBindings.Add("Checked", Settings, "IsItalic");
            this.nudLeftIndent.DataBindings.Add("Value", Settings, "LeftIndent");
            this.nudRightIndent.DataBindings.Add("Value", Settings, "RightIndent");
        }

        public FontSetting GetSetting()
        {
            return (FontSetting)Settings.Clone();
        }

        public void UpdateSettings(FontSetting setting)
        {
            if (setting != null)
            {
                Settings.CopyValue(setting);
                this.ReloadConfig();
            }
        }

        private void LoadHorizontalAlignment()
        {
            this.cboAlign.DisplayMember = "DisplayName";
            this.cboAlign.ValueMember = "Alignment";

            BindingList<SelectComboboxAlignment> listData = new BindingList<SelectComboboxAlignment>();
            foreach (var item in Enum.GetValues(typeof(StringAlignment)))
            {
                listData.Add(new SelectComboboxAlignment()
                {
                    Alignment = (StringAlignment)item
                });
            }
            this.cboAlign.DataSource = listData;
        }

        private void UcFontFormat_Load(object sender, EventArgs e)
        {
            try
            {
                LoadHorizontalAlignment();
                ReloadConfig();
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                MessageBox.Show(ex.Message, "Error !!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ItemValueChanged(object sender, EventArgs e)
        {
            try
            {
                //if (ValueChanged != null)
                //{
                //    ValueChanged(sender, e);
                //}
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                MessageBox.Show(ex.Message, "Error !!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cboAlign_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //if (cboAlign.SelectedIndex != -1 && cboAlign.SelectedValue != null)
                //{
                //    if (ValueChanged != null)
                //    {
                //        ValueChanged(sender, e);
                //    }
                //}
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                MessageBox.Show(ex.Message, "Error !!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
