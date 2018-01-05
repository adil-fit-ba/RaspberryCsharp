using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unosquare.RaspberryIO;
using Unosquare.RaspberryIO.Gpio;

namespace unosquare_raspberryio
{
    class Program
    {
        static void Main(string[] args)
        {
            // Get a reference to the pin you need to use.
            // All 3 methods below are exactly equivalente
            var blinkingPin = Pi.Gpio[0];
           // blinkingPin = Pi.Gpio[WiringPiPin.Pin00];
           // blinkingPin = Pi.Gpio.Pin00;

            // Configure the pin as an output
            blinkingPin.PinMode = GpioPinDriveMode.Output;

            // perform writes to the pin by toggling the isOn variable
            var isOn = false;
            for (var i = 0; i < 20; i++)
            {
                isOn = !isOn;
                blinkingPin.Write(isOn);
                System.Threading.Thread.Sleep(500);
            }
        }
    }
}
