using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RaspberryPiDotNet;
using System.IO;

namespace FIT_IoT.RPI.Shared.Komande
{
    public class GPIODevices
    {
        static GPIOFile lightReelay;
        static GPIOFile temperatureSensor;

        public static void initRaspberry()
        {
           lightReelay = new GPIOFile(GPIOPins.V2_Pin_P1_11, GPIODirection.Out);
           temperatureSensor = new GPIOFile(GPIOPins.V2_Pin_P1_12, GPIODirection.In);
        }

        public static void lightControll(bool onState)
        {
            lightReelay.Write(onState);
            System.Console.WriteLine("  PIN za svjetlo: " + onState);
        }

        public static double readTemperature() {
            temperatureSensor.Read();

            DirectoryInfo devicesDir = new DirectoryInfo("/sys/bus/w1/devices");

            foreach (var deviceDir in devicesDir.EnumerateDirectories("28*"))
            {
                var w1slavetext =
                    deviceDir.GetFiles("w1_slave").FirstOrDefault().OpenText().ReadToEnd();
                string temptext =
                    w1slavetext.Split(new string[] { "t=" }, StringSplitOptions.RemoveEmptyEntries)[1];

                double temp = double.Parse(temptext) / 1000;

                return temp;
            }

            return -1;
        }

    }
}
