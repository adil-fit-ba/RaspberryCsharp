using System;
using System.Net;
using FIT.RaspberryMono.Helper.Motori;
using Newtonsoft.Json;
using RaspberryPiDotNet;

namespace FIT.RaspberryMono.App
{
    class Program
    {
        static void Main(string[] args)
        {
            WebClient wc = new WebClient();

            Console.WriteLine("ok");
            GPIOFile s1 = new GPIOFile(GPIOPins.V2_Pin_P1_11, GPIODirection.Out);
            GPIOFile s2 = new GPIOFile(GPIOPins.V2_Pin_P1_12, GPIODirection.Out);
            GPIOFile s3 = new GPIOFile(GPIOPins.V2_Pin_P1_13, GPIODirection.Out);
            GPIOFile s4 = new GPIOFile(GPIOPins.V2_Pin_P1_15, GPIODirection.Out);


            StepMotor m = new StepMotor(s1, s2, s3, s4);


            while (true)
            {
                string json = wc.DownloadString("http://a.wrd.app.fit.ba/home/getcommand?take=1");


                WebRezultat[] xArray = JsonConvert.DeserializeObject<WebRezultat[]>(json);


                var x = xArray[0];
                if (x.vrijednost == "Neretva_10_Plavo")
                {
                    wc.DownloadString("http://a.wrd.app.fit.ba/home?pozicija=Odgovor_na_komandu&vrijednost=Neterva_99_Zeleno");
                    m.PokreniMotor(400, Direkcija.Naprijed);
                }
                else if (x.vrijednost == "Neretva_20_Plavo")
                {
                    m.PokreniMotor(400, Direkcija.Nazad);
                }

                // System.Threading.Thread.Sleep(500);
            }
        }
    }
}
