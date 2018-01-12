using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using FIT_IoT.RPI.Console.Helper;
using FIT_IoT.RPI.Shared.APIs;
using FIT_IoT.RPI.Shared.Komande;
using FIT_IoT.SharedAll;
using FIT_IoT.SharedAll.Enums;
using FIT_IoT.SharedAll.ViewModels;
using Newtonsoft.Json;
using RaspberryPiDotNet;

namespace FIT_IoT.RPI.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            //GPIO inicijalizacija
           Svjetlo.initRaspberry();

            int i = 0;
            while(true)
            {
                MyHelper.pauziraj(1000);
                ApiResult<KomandaGetVM> command = KomandaApi.Get();
                i++;
                System.Console.Write(i + ". ");
                if (!command.isException)
                {
                    if (command.value == null)
                    {
                        System.Console.WriteLine("Nema komande ");
                        continue;
                    }
                    System.Console.WriteLine("Preuzeta komanda " + command.value.Id + ": " + command.value.VrstaKomande.MyDescription());
                        switch (command.value.VrstaKomande)
                        {
                            case VrstaKomande.SVJETLO_UPALI:
                                Svjetlo.lightControll(true);
                              
                                break;
                            case VrstaKomande.SVJETLO_UGASI:
                                Svjetlo.lightControll(false);
                                break;
                            case VrstaKomande.OTVORI_VRATA:
                                break;
                            default:
                                break;
                        }
                    KomandaApi.IzvrsenaKomanda(command.value.Id);
                }
               

            }

        }
    }
}
