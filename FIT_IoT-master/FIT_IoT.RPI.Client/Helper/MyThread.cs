using System.Threading;

namespace FIT_IoT.RPI.Client.Helper
{
    public class MyHelper
    {
        public static void pauziraj(int millisecondsToWait)
        {
            Thread.Sleep(millisecondsToWait); //so processor can rest for a while
        }
    }
}