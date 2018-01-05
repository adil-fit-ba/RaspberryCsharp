using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using LibPiGpio;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            int inc = 1, t = 7, last = 0;
            RpiGpio.SetOutputPins(new[] { 7, 8, 9, 10, 11 });

            while (!Console.KeyAvailable)
            {
                if (last != 0)
                {
                    t = t + inc;
                    if (t >= 11 || t <= 7) inc *= -1;
                    RpiGpio.Pins[last] = false;
                }
                RpiGpio.Pins[t] = true;
                last = t;
                Thread.Sleep(250);
            }
            Console.ReadKey();
        }
    }
}
