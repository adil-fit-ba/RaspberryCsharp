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
                GlavniProgram.Run();
        }
    }
}
