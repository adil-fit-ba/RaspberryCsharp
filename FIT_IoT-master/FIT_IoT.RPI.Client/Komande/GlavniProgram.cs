using ConsoleApp1;
using FIT_IoT.Core.Helper;
using FIT_IoT.RPI.Client.APIs;
using FIT_IoT.RPI.Client.Helper;
using FIT_IoT.RPI.Core.ViewModels;
using FIT_IoT.RPI.Core.ViewModels.Enums;
using Raspberry.IO.GeneralPurpose;

namespace FIT_IoT.RPI.Client.Komande
{
    public class GlavniProgram
    {
        public static void Run()
        {
           // gpio_devices();
            new FlowSensor(ConnectorPin.P1Pin11).Start();
        }

        private static void gpio_devices()
        {
//GPIO inicijalizacija
            GPIODevices.initRaspberry();
            GPIODevices.lightControll(true);
            int i = 0;
            while (true)
            {
                MyHelper.pauziraj(1000);
                ApiResult<CommandVM> command = CommandApi.GetOne();
                i++;
                System.Console.Write(i + ". ");
                if (!command.isException)
                {
                    if (command.value == null)
                    {
                        System.Console.WriteLine("Nema komande ");
                        continue;
                    }
                    System.Console.WriteLine("Preuzeta komanda " + command.value.Id + ": " +
                                             command.value.CommandType.MyDescription());
                    switch (command.value.CommandType)
                    {
                        case CommandType.LIGHT_ON:
                            GPIODevices.lightControll(true);

                            break;
                        case CommandType.LIGHT_OF:
                            GPIODevices.lightControll(false);
                            break;
                        case CommandType.DOOR_OPEN:
                            break;
                        default:
                            break;
                    }
                    CommandApi.CommandExecuted(command.value.Id);
                }

                double temp = GPIODevices.readTemperature();

                if (temp != -1)
                {
                    System.Console.Write("Temperatura je: " + temp.ToString());
                }
            }
        }
    }
}
