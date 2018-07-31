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
           return null;
        }

        private MeasurementLogic _measurementLogic;
        public override StartCommandResult OnStartCommand(Intent intent, StartCommandFlags flags, int startId)
        {
            int mivrijemenP =intent.GetIntExtra("vrijeme", 2);
            int minProtok= intent.GetIntExtra("minProtok",500);
            _measurementLogic = new MeasurementLogic(this, minProtok, mivrijemenP);
            _measurementLogic.Start();

            var builder = new Notification.Builder(this)
                    .SetContentTitle("protok vode")
                    .SetContentText("...")
                    .SetSmallIcon(Resource.Drawable.ic_stat_button_click)
                    .SetOngoing(true)
                ;

            // Enlist this instance of the service as a foreground service
            StartForeground(1000, builder.Build());

            return StartCommandResult.Sticky;
        }

        public override void OnDestroy()
        {
            if (_measurementLogic != null)
            {
                _measurementLogic.End();
            }
        }
    }
}