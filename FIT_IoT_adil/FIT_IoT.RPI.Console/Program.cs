using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using FIT_IoT.SharedAll;
using Newtonsoft.Json;

namespace FIT_IoT.RPI.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            WebClient wc = new WebClient();


            string json = wc.DownloadString("http://adins.iot.app.fit.ba/Komanda/Get");


            KomandaGetVM[] xArray = JsonConvert.DeserializeObject<KomandaGetVM[]>(json);

            KomandaGetVM k = xArray[0];

            //if (k.Code == 5841)
        }
    }
}
