using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace BarcodePrint
{
    public enum BarcodeMultilineZoneEnum
    {
        [Description("Trên barcode")]
        TopPane,

        [Description("Dưới barcode")]
        BottomPane,

        [Description("Cạnh barcode")]
        SidePane, 
    }
}
