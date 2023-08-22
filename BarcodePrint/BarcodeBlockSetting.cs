﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BarcodePrint
{
    public class BarcodeBlockSetting : ICloneable
    {
        public double OffsetX { get; set; }
        public double OffsetY { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
        public bool ShowBorder { get; set; }
        public FontSetting FontSetting { get; set; }

        public void CopyValue(BarcodeBlockSetting setting)
        {
            this.OffsetX = setting.OffsetX;
            this.OffsetY = setting.OffsetY;
            this.Width = setting.Width;
            this.Height = setting.Height;
            this.ShowBorder = setting.ShowBorder;
            this.FontSetting.CopyValue(setting.FontSetting);
        }

        public object Clone()
        {
            return new BarcodeBlockSetting()
            {
                OffsetX = this.OffsetX,
                OffsetY = this.OffsetY,
                Width = this.Width,
                Height = this.Height,
                ShowBorder = this.ShowBorder,
                FontSetting = this.FontSetting.Clone() as FontSetting
            };
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();

            builder.AppendFormat("OffsetX: {0}|", OffsetX);
            builder.AppendFormat("OffsetY: {0}|", OffsetY);
            builder.AppendFormat("Width: {0}|", Width);
            builder.AppendFormat("Height: {0}|", Height);
            builder.AppendFormat("ShowBorder: {0}|", ShowBorder);
            builder.AppendFormat("FontSetting: {0}", FontSetting);

            return builder.ToString();
        }
    }
}
