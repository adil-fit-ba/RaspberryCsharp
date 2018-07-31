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
    public class MeasurementLogic
    {
        public Context Context { get; }
        public int DonjaGranicaZaUpozorenje { get; }
        public int RefreshTime { get; }

        public MeasurementLogic(Context context, int DonjaGranicaZaUpozorenje, int RefreshTime)
        {
            Context = context;
            this.DonjaGranicaZaUpozorenje = DonjaGranicaZaUpozorenje;
            this.RefreshTime = RefreshTime;
        }

        private bool IsFinished = false;
        private Task task;
        public void Start()
        {
            IsFinished = false;
            task = new Task(() =>
            {
                while (!IsFinished)
                {
                    doIt();
                    Thread.Sleep(RefreshTime*1000);
                }

            });
            task.Start();
        }


        public PendingIntent BuildIntentToShowMainActivity()
        {
            var uri = global::Android.Net.Uri.Parse("http://a1.iot.app.fit.ba/WebArea/Measurement");
            Intent intent = new Intent(Intent.ActionView);
            intent.SetData(uri);

            PendingIntent pendingIntent =
                PendingIntent.GetActivity(Context.ApplicationContext, 0, intent, PendingIntentFlags.UpdateCurrent);
            return pendingIntent;
        }

        public void doIt()
        {

            ApiResult<MeasurementVM> podaci = MyApiRequests.Get<MeasurementVM>(MeasurementVM.Action_GetLast);

            if (!podaci.isException)
            {
                string s = string.Empty;
                MeasurementVM.Row x = podaci.value.Rows.FirstOrDefault();

                if (x?.Time != null)
                {
                    s += (x.Time?.ToString("HH:mm:ss")) + "----------> " + x.Value + "";
                    if (DateTime.Now > x.Time.Value.AddMinutes(1))
                    {

                        MyWarningAlarm("Senzor ne šalje podatke već " + (DateTime.Now - x.Time).Value.TotalMinutes.ToString("##0.00") + " min");
                    }
                    if (x.Value < DonjaGranicaZaUpozorenje)
                    {
                        MyWarningAlarm("Brzina protoka je " + x.Value);
                    }
                    LastMeasurement = DateTime.Now;
                }
                else
                {
                    s += "?";
                }
                PrikaziNotifikaciju(s);

            }
            else
            {
                PrikaziNotifikaciju("Nema komunikacije sa serverom već " + (DateTime.Now - LastMeasurement).TotalMinutes.ToString("##0.00") + " min");
            }
        }

   

        private DateTime LastMeasurement;
        private DateTime LastAlarm;
        private void MyWarningAlarm(string text)
        {
            if (LastAlarm.AddMinutes(3) > DateTime.Now)
                return;

            if (IsFinished)
                return;

            LastAlarm = DateTime.Now;

            var builder = new Notification.Builder(Context)
                .SetContentTitle("Upozorenje")
                .SetContentText(text)
                .SetSmallIcon(Resource.Drawable.ic_stat_button_click)
                .SetContentIntent(BuildIntentToShowMainActivity())
                .SetAutoCancel(true)
                .SetOngoing(true)
                .SetSound(RingtoneManager.GetDefaultUri(RingtoneType.Ringtone));

            ;


            NotificationManager notificationManager =
                (NotificationManager)Context.GetSystemService(Context.NotificationService);
            Notification notification = builder.Build();

            // Turn on vibrate:
            notification.Defaults |= NotificationDefaults.Vibrate;

            notificationManager.Notify(1001, notification);
        }


        private void PrikaziNotifikaciju(string text)
        {
            if (IsFinished)
                return;
            var builder = new Notification.Builder(Context)
                    .SetContentTitle("protok vode @ " + DonjaGranicaZaUpozorenje)
                    .SetContentText(text)
                    .SetSmallIcon(Resource.Drawable.ic_stat_button_click)
                    .SetContentIntent(BuildIntentToShowMainActivity())
                    .SetOngoing(true)
                ;

            NotificationManager notificationManager =
                (NotificationManager)Context.GetSystemService(Context.NotificationService);
            notificationManager.Notify(1000, builder.Build());

        }

        public void End()
        {
            if (task != null)
            {
                IsFinished = true;
                task = null;
                NotificationManager notificationManager =
                    (NotificationManager)Context.GetSystemService(Context.NotificationService);
                notificationManager.Cancel(1000);
                notificationManager.Cancel(1001);
            }
        }
    }
}