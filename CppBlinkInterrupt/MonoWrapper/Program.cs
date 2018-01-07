using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MonoWrapper
{
        class NekaKlasa
        {

            [DllImport("./main.so", EntryPoint = "main")]
            public static extern int main();

        }
        class Program
        {

            static void Main(string[] args)
            {
                Console.WriteLine("Hello World from Main in dotnet core");
                NekaKlasa.main();
            }

    }
}
