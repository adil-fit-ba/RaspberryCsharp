using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.Media;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using FIT_IoT.Android.Core.ViewModels;
using FIT_IoT.Client.Helper;
using FIT_IoT.Core.Helper;

namespace FIT_IoT.Android.Client
{
    //FIT_IoT.Android.Client
    [Activity(Label = "MeasurementsActivity", MainLauncher = true)]
    public class MeasurementsActivity : Activity
    {
       


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Measurements);

            var txtMinProtok = FindViewById<EditText>(Resource.Id.txtMinProtok);
            var txtVrijeme = FindViewById<EditText>(Resource.Id.txtVrijeme);
            var btnStart = FindViewById<Button>(Resource.Id.btnStart);
            var btnEnd = FindViewById<Button>(Resource.Id.btnEnd);


          

         
            btnStart.Click += delegate
            {
                try
                {
                    Intent intent = new Intent(this, typeof(MyService));
                    int minProtok = int.Parse(txtMinProtok.Text);
                    int vrijeme = int.Parse(txtVrijeme.Text);
                    intent.PutExtra("vrijeme", vrijeme);
                    intent.PutExtra("minProtok", minProtok);
                    StartService(intent);
                    toaster("started");
                }
                catch (Exception e)
                {
                    toaster(e.Message);
                }
               
            };


            btnEnd.Click += delegate {
                StopService(new Intent(this, typeof(MyService)));
                toaster("stopped");
            };
            
        }

        private void toaster(string s)
        {
            Toast.MakeText(this, s, ToastLength.Long).Show();
        }

      
    }
}