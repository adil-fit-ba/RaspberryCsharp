using System.Collections.Generic;
using System.Linq;
using Android.App;
using Android.Widget;
using Android.OS;
using FIT_IoT.SharedAll;
using FIT_IoT.SharedAll.Helper;
using FIT_IoT.SharedAll.ViewModels;
using FIT_IoT.SharedAll.ViewModels.ApiAndroid;

namespace FIT_IoT.XamarinAndroid
{
    [Activity(Label = "FIT_IoT.XamarinAndroid", MainLauncher = true)]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            ListView listView = FindViewById<ListView>(Resource.Id.listView1);

            ApiResult<KomandaNewVM> podaci = MyApiRequests.Get<KomandaNewVM>("AndroidKomanda", "GetAll");
            listView.Adapter = new ArrayAdapter(this, Android.Resource.Layout.SimpleListItem1, podaci.value.Rows.Select(a=>a.KomandaText).ToList());

            listView.ItemClick += delegate(object sender, AdapterView.ItemClickEventArgs args){


                KomandaNewVM.Row row= podaci.value.Rows[args.Position];
                Toast.MakeText(this, row.KomandaText, ToastLength.Long).Show();

            };
        }
    }
}

