using FIT_IoT.Core.Helper;
using FIT_IoT.RPI.Client.APIs;
using FIT_IoT.RPI.Client.Helper;
using FIT_IoT.RPI.Core.ViewModels;
using FIT_IoT.RPI.Core.ViewModels.Enums;

namespace FIT_IoT.RPI.Client.Komande
{
    public class GlavniProgram
    {
        public static void Run()
        {
            //GPIO inicijalizacija
            GPIODevices.initRaspberry();

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
                            GPIODevices.lightControll(true);

                            break;
                        case VrstaKomande.SVJETLO_UGASI:
                            GPIODevices.lightControll(false);
                            break;
                        case VrstaKomande.OTVORI_VRATA:
                            break;
                        default:
                            break;
                    }
                    KomandaApi.IzvrsenaKomanda(command.value.Id);
                }                

                double temp = GPIODevices.readTemperature();

                if (temp != -1) {
                    System.Console.Write("Temperatura je: " + temp.ToString());

                }
            }
        }
    }
}
