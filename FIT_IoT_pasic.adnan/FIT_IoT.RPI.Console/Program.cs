using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using FIT_IoT.SharedAll;
using Newtonsoft.Json;
using FIT_IoT.Server.Shared.EntityModel;
using RaspberryPiDotNet;

namespace FIT_IoT.RPI.Console
{
    class Program
    {
        static GPIOFile lightReelay;
        private static void initRaspberry() {
            lightReelay = new GPIOFile(GPIOPins.V2_Pin_P1_11, GPIODirection.Out);
        }

        private static void lightControll(bool onState = false) {
           lightReelay.Write(onState);
        }

        static void Main(string[] args)
        {
            WebClient wc = new WebClient();

            //GPIO inicijalizacija
            initRaspberry();

            while(true)
            {
                string json = wc.DownloadString("http://pasica.app.fit.ba/Komanda/Get");

                KomandaGetVM command = JsonConvert.DeserializeObject<KomandaGetVM>(json);

                if (command != null)
                {
                    json = wc.DownloadString("http://pasica.app.fit.ba/Komanda/IzvrsiKomandu/" + command.Id.ToString());
                    SuccessVW success = JsonConvert.DeserializeObject<SuccessVW>(json);

                    if(success.success)
                    {
                        switch (command.VrstaKomande)
                        {
                            case VrstaKomande.SVJETLO_UPALI:
                                lightControll(true);
                                break;
                            case VrstaKomande.SVJETLO_UGASI:
                                lightControll(false);
                                break;
                            case VrstaKomande.OTVORI_VRATA:
                                break;
                            default:
                                break;
                        }
                    }
                }

                Thread.Sleep(5000);
            }

        }
    }
}
