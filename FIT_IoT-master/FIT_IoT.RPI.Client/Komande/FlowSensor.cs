using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using FIT_IoT.Core.Enums;
using FIT_IoT.RPI.Client.APIs;
using Raspberry.IO.GeneralPurpose;

namespace ConsoleApp1
{
    public class FlowSensor
    {
        private readonly ConnectorPin _sensorPin;
        private int brojac = 0;

        public FlowSensor(ConnectorPin sensorPin)
        {
            _sensorPin = sensorPin;

            Console.WriteLine("start flow sensor");
            var pushButton = sensorPin.Input().PullUp();

            //Create the settings for the connection
            var settings = new GpioConnectionSettings();

            //Interval between pin checks. This is *really* important - higher values lead to missed values/borking. Lower 
            //values are apparently possible, but may have 'severe' performance impact. Further testing needed.
            settings.PollInterval = TimeSpan.FromMilliseconds(1);

            var connection = new GpioConnection(settings, pushButton);


            connection.PinStatusChanged += (sender, eventArgs) => brojac++;

        }

        public void Start()
        {
            new Thread(() =>
            {
                while (true)
                {
                    Console.WriteLine("brojac + " + brojac);
                    new Thread((br) =>
                        {
                            int b;
                        try
                        {
                            b= int.Parse(br.ToString());
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e);
                            throw;
                        }
                    MeasurementApi.CommandExecuted(b, "Flow sensor: " + br, SensorType.protok_vode);
                }
                ).Start(brojac);
                    brojac = 0;
                    delay(5000);
                }

            }).Start();
        }


        private void delay(int i)
        {
            Thread.Sleep(i);
        }
    }
}
