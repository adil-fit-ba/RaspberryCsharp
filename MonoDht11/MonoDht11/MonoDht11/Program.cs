using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoDht11
{
    class Program
    {
        static void Main(string[] args)
        {
            DHT11 mDHT;
            mDHT = new DHT11(11, 30);
            mDHT.mTimer_Elapsed(null, null);


        }
        static void mDHT_EventNewData(object sender, NewDataArgs e)
        {
            Console.WriteLine("Temp: " + e.Temperature + ", Hum: " + e.Humidity);
        }
    }
}
