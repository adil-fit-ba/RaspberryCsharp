using System;
using System.Threading;
using WiringPiNet;
using WiringPiNet.Wrapper;

namespace WiringPi_NET_evil_ConsoleApp3
{
    class Program
    {
        private const int BUTTON = 5;
        private const int LED = 0;
        static void Main(string[] args)
        {
          
            WiringPi.WiringPiSetup();

            blinkaj(10);

            //Ne radi - callback
            WiringPi.WiringPiISR(BUTTON, 2, Callback);

            
        }

        private static void Callback()
        {
            Console.WriteLine("Button pressed");
            blinkaj(10);
        }

        static void  blinkaj(int trajanje)
        {
            for (int i = 0; i < trajanje; i++)
            {
                WiringPi.DigitalWrite(LED, 1);
                Thread.Sleep(200);
                WiringPi.DigitalWrite(LED, 0);
                Thread.Sleep(200);
            }
        }

    }
}
