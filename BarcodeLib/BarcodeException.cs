using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BarcodeLib
{
    public class BarcodeException : Exception
    {
        public BarcodeException(string message) : base(message)
        {

        }
    }
}
