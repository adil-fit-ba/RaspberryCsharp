using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;

using System.Collections.Generic;

using System.Linq;

using System.Runtime.InteropServices;

using System.Text;



using System.Timers;



namespace MonoDht11
{
   

 

        public class NewDataArgs

        {

            public NewDataArgs(float temp, float hum)

            { Temperature = temp; Humidity = hum; }

            public float Temperature { get; private set; }

            public float Humidity { get; private set; }

        }




        class DHT11

        {

            //bool InitDHT(int pinval)

            [DllImport("libDHT11.so", EntryPoint = "InitDHT")]

            static extern bool InitDHT(int pinval);

            //float getTemp()

            [DllImport("libDHT11.so", EntryPoint = "getTemp")]

            static extern float getTemp();

            //float getHumidity()

            [DllImport("libDHT11.so", EntryPoint = "getHumidity")]

            static extern float getHumidity();

            //bool dht11_read_val()

            [DllImport("libDHT11.so", EntryPoint = "dht11_read_val")]

            static extern bool dht11_read_val();




            // private values

            private int mPin;

            private int mSec;

            private Timer mTimer = new Timer();




            public delegate void NewData(object sender, NewDataArgs e);

            public event NewData EventNewData;




            // to get temperature and humidity

            public float Temperature { get; internal set; }

            public float Humidity { get; internal set; }




            public DHT11(int pin, int seconds = 0)

            {

                mPin = pin;

                mSec = seconds;

                if (!InitDHT((int)pin))

                    throw new Exception("Error initalizing DHT11");

                mTimer.Elapsed += mTimer_Elapsed;

            }


            public void mTimer_Elapsed(object sender, ElapsedEventArgs e)

            {

                if (dht11_read_val())

                {

                    Temperature = getTemp();

                    Humidity = getHumidity();
                    Console.WriteLine("Temp: " + Temperature + ", Hum: " + Humidity);
                if (EventNewData != null)

                        EventNewData(this, new NewDataArgs(Temperature, Humidity));

                }

            }




            public void Start()

            {

                if (mSec != 0)

                {

                    mTimer.Interval = mSec * 1000;

                    mTimer.Start();

                }

            }




            public void Stop()

            {

                mTimer.Stop();

            }




            public bool ReadDHT11()

            {

                return (dht11_read_val());

            }




        }

    }
