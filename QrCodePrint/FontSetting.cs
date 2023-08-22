using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace QrCodePrint
{
    public class FontSetting : ICloneable
    {
        public double FontSize { get; set; }
        public double LeftIndent { get; set; }
        public double RightIndent { get; set; }
        public bool IsBold { get; set; }
        public bool IsItalic { get; set; }
        public StringAlignment Align { get; set; }

        public string SampleText { get; set; }

        public FontSetting()
        {
            this.FontSize = 3;
            this.Align = StringAlignment.Center;
        }

        public void CopyValue(FontSetting setting)
        {
            this.FontSize = setting.FontSize;
            this.LeftIndent = setting.LeftIndent;
            this.RightIndent = setting.RightIndent;
            this.IsBold = setting.IsBold;
            this.IsItalic = setting.IsItalic;
            this.Align = setting.Align;
            this.SampleText = setting.SampleText;
        }

        public object Clone()
        {
            return new FontSetting()
            {
                FontSize = this.FontSize,
                LeftIndent = this.LeftIndent,
                RightIndent = this.RightIndent,
                IsBold = this.IsBold,
                IsItalic = this.IsItalic,
                Align = this.Align,
                SampleText = this.SampleText,
            };
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();

            builder.AppendFormat("FontSize: {0}|", FontSize);
            builder.AppendFormat("LeftIndent: {0}|", LeftIndent);
            builder.AppendFormat("RightIndent: {0}|", RightIndent);
            builder.AppendFormat("IsBold: {0}|", IsBold);
            builder.AppendFormat("IsItalic: {0}|", IsItalic);
            builder.AppendFormat("Align: {0}|", Align);
            builder.AppendFormat("SampleText: {0}", SampleText);

            return builder.ToString();
        }
    }
}
