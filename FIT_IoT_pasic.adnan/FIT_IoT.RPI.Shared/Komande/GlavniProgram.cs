using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FIT_IoT.RPI.Console.Helper;
using FIT_IoT.RPI.Shared.APIs;
using FIT_IoT.SharedAll.Enums;
using FIT_IoT.SharedAll.ViewModels;

namespace FIT_IoT.RPI.Shared.Komande
{
    public class GlavniProgram
    {
        public static void Run()
        {
            //GPIO inicijalizacija
            Svjetlo.initRaspberry();

            int i = 0;
            while (true)
            {
                MyHelper.pauziraj(1000);
                ApiResult<KomandaGetVM> command = KomandaApi.GetOne();
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
