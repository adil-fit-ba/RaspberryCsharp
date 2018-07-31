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
    [Activity(Label = "MeasurementsActivity", MainLauncher = true)]
    public class MeasurementsActivity : Activity
    {
       

        private EditText editText;
        private Button button;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Measurements);

            editText = FindViewById<EditText>(Resource.Id.editText1);
            button = FindViewById<Button>(Resource.Id.button1);


            toaster("started");

            //A a = new A(this);
            //a.Start();

            button.Click += delegate
            {
              //  a.doIt();
            };

                   var intent = new Intent(this, typeof(MyService));
                   this.StartService(intent);
        }

        private void toaster(string s)
        {
            Toast.MakeText(this, s, ToastLength.Long).Show();
        }

      
    }
}