using System.Linq;
using Android.App;
using Android.Widget;
using Android.OS;
using FIT_IoT.Android.Core.ViewModels;
using FIT_IoT.Client.Helper;
using FIT_IoT.Core.Helper;

namespace FIT_IoT.Android.Client
{
    [Activity(Label = "FIT_IoT.Android.Client", MainLauncher = true)]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);


            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            ListView listView = FindViewById<ListView>(Resource.Id.listView1);

            ApiResult<KomandaNewVM> podaci = MyApiRequests.Get<KomandaNewVM>("AndroidKomanda", "GetAll");
            listView.Adapter = new ArrayAdapter(this, global::Android.Resource.Layout.SimpleListItem1, podaci.value.Rows.Select(a => a.KomandaText).ToList());

            listView.ItemClick += delegate (object sender, AdapterView.ItemClickEventArgs args) {


                KomandaNewVM.Row row = podaci.value.Rows[args.Position];
                Toast.MakeText(this, row.KomandaText, ToastLength.Long).Show();

                StartActivity(typeof(PregledActivity));

            };
        }
    }
}

