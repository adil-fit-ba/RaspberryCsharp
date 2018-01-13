using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FIT_IoT.RPI.Console_.Helper
{
    public class MyHelper
    {
        public static void pauziraj(int millisecondsToWait)
        {
            Thread.Sleep(millisecondsToWait); //so processor can rest for a while
        }
    }
}