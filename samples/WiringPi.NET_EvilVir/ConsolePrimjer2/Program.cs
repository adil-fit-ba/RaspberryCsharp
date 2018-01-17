using System.Threading;
using WiringPiNet;
using WiringPiNet.Wrapper;

namespace WiringPi_NET_evil_ConsoleApp2
{
    class Program
    {
        private const int PIN = 0;
        static void Main(string[] args)
        {
            Gpio gpio = new Gpio(Gpio.NumberingMode.Internal);
            WiringPi.WiringPiSetup();
            

            while (true)
            {
                gpio.Write(PIN, PinValue.High);
                Thread.Sleep(500);
                gpio.Write(PIN, PinValue.Low);
                Thread.Sleep(500);
            }
        }

    }
}
