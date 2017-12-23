using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using WebApplication1.Models;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            WebClient wc = new WebClient();


            string json = wc.DownloadString("http://adins.iot.app.fit.ba/Podaci/Index");


            Komanda[] xArray = JsonConvert.DeserializeObject<Komanda[]>(json);

            Komanda k = xArray[0];

            //if (k.Code == 5841)



        }
    }
}
