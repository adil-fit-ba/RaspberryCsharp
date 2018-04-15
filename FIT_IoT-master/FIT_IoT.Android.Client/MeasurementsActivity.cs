using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
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
           // new Task(() => { doIt(); }).Start();
            doIt();

            button.Click += delegate
            {
                doIt();
            };


        }

        private void toaster(string s)
        {
            Toast.MakeText(this, s, ToastLength.Long).Show();
        }

        private void doIt()
        {
           
                ApiResult<MeasurementVM> podaci = MyApiRequests.Get<MeasurementVM>(MeasurementVM.Action_GetLast);
            
                if (!podaci.isException)
                {
                    string s = string.Empty;
                    foreach (var x in podaci.value.Rows)
                    {
                        if (x.Time != null)
                            s += (x.Time?.ToString("dd.MM.yyyy HH:mm:ss")) + "\t" + x.Value + "\n";
                    }
                //editText.Text = s;

                    toaster(s);

            }
                else
                {
                       toaster(podaci.exceptionMessage);
                }
            }
        }
    }
