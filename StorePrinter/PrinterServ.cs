﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorePrinter
{
    class PrinterServ : IPrinterServ
    {
        public void Print(string text)
        {
            Console.WriteLine(text);
        }
    }
}
