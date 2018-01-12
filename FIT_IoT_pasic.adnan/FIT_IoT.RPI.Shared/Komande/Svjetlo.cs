using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RaspberryPiDotNet;

namespace FIT_IoT.RPI.Shared.Komande
{
    public class Svjetlo
    {
     //   static GPIOFile lightReelay;

        public static void initRaspberry()
        {
       //     lightReelay = new GPIOFile(GPIOPins.V2_Pin_P1_11, GPIODirection.Out);
        }

        public static void lightControll(bool onState)
        {
       //     lightReelay.Write(onState);
               Console.WriteLine("  PIN za svjetlo: " + onState);
        }

    }
}
