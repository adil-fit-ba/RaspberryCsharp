using System.Threading;
using WiringPiNet;
using WiringPiNet.Wrapper;

namespace WiringPi_NET_evil_ConsoleApp1
{
    class Program
    {
        private const int PIN = 0;
        static void Main(string[] args)
        {
            WiringPi.WiringPiSetup();
            

            while (true)
            {
                WiringPi.DigitalWrite(PIN, 1);
                Thread.Sleep(500);
                WiringPi.DigitalWrite(PIN, 0);
                Thread.Sleep(500);
            }
        }

    }
}
