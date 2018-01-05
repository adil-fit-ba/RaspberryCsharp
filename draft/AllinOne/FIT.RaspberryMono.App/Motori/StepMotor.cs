using RaspberryPiDotNet;

namespace FIT.RaspberryMono.Helper.Motori
{
    public class StepMotor
    {
        public readonly GPIOFile S1;
        public readonly GPIOFile S2;
        public readonly GPIOFile S3;
        public readonly GPIOFile S4;

        public StepMotor(GPIOFile s1, GPIOFile s2, GPIOFile s3, GPIOFile s4)
        {
            S1 = s1;
            S2 = s2;
            S3 = s3;
            S4 = s4;
        }


        public void PokreniMotor(int stepen, Direkcija direkcija)
        {
            int pauza = 2;
            if (direkcija == Direkcija.Naprijed)
            {
                for (int i = 0; i < stepen; i++)
                {
                    this.S1.Write(true);
                    System.Threading.Thread.Sleep(pauza);
                    this.S1.Write(false);
                    this.S2.Write(true);
                    System.Threading.Thread.Sleep(pauza);
                    this.S2.Write(false);
                    this.S3.Write(true);
                    System.Threading.Thread.Sleep(pauza);
                    this.S3.Write(false);
                    this.S4.Write(true);
                    System.Threading.Thread.Sleep(pauza);
                    this.S4.Write(false);
                }
            }
            if (direkcija == Direkcija.Nazad)
            {
                for (int i = 0; i < stepen; i++)
                {
                    this.S4.Write(true);
                    System.Threading.Thread.Sleep(pauza);
                    this.S4.Write(false);
                    this.S3.Write(true);
                    System.Threading.Thread.Sleep(pauza);
                    this.S3.Write(false);
                    this.S2.Write(true);
                    System.Threading.Thread.Sleep(pauza);
                    this.S2.Write(false);
                    this.S1.Write(true);
                    System.Threading.Thread.Sleep(pauza);
                    this.S1.Write(false);
                }
            }
        }
    }
}