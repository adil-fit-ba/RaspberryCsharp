using System.Linq;
using Android.App;
using Android.Widget;
using Android.OS;
using FIT_IoT.Android.Core.ViewModels;
using FIT_IoT.Client.Helper;
using FIT_IoT.Core.Helper;

namespace FIT_IoT.Android.Client
{
    [Activity(Label = "CommandsActivity")]
    public class CommandsActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Commands);

            ListView listView = FindViewById<ListView>(Resource.Id.listView1);

            ApiResult<CommandNewVM> podaci = MyApiRequests.Get<CommandNewVM>(CommandNewVM.Action_GetAll);
            listView.Adapter = new ArrayAdapter(this, global::Android.Resource.Layout.SimpleListItem1, podaci.value.Rows.Select(a => a.CommandText).ToList());

            listView.ItemClick += delegate (object sender, AdapterView.ItemClickEventArgs args) {


                CommandNewVM.Row row = podaci.value.Rows[args.Position];
                Toast.MakeText(this, row.CommandText, ToastLength.Long).Show();


            };
        }
    }
}

