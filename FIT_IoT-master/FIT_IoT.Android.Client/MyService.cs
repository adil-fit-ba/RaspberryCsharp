using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace FIT_IoT.Android.Client
{
    [Service]
    public class MyService : Service
    {

        public override IBinder OnBind(Intent intent)
        {
           return new Binder();
        }

        public override StartCommandResult OnStartCommand(Intent intent, StartCommandFlags flags, int startId)
        {
            A a = new A(this);
            a.Start();

            return StartCommandResult.Sticky;
        }

       
    }
}