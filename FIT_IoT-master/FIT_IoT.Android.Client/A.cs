﻿using System;
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
    public class A
    {
        public Context Context { get; }

        public A(Context context)
        {
            Context = context;
        }

        public void Start()
        {
            new Task(() =>
            {
                while (true)
                {
                    doIt();
                    Thread.Sleep(3000);
                }

            }).Start();
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

                        MyAlarm("Nema protoka već " + (DateTime.Now - x.Time).Value.TotalMinutes + " min");
                    }
                    if (x.Value < 500)
                    {
                        MyAlarm("Brzina protoka je " + x.Value);
                    }
                }
                else
                {
                    s += "?";
                }
                PrikaziNotifikaciju(s);

            }
            else
            {
                MyAlarm(podaci.exceptionMessage);
            }
        }

        private DateTime LastAlarm;
        private void MyAlarm(string text)
        {
            if (LastAlarm.AddMinutes(3) > DateTime.Now)
                return;

            LastAlarm = DateTime.Now;

            var builder = new Notification.Builder(Context)
                .SetContentTitle("Upozorenje")
                .SetContentText(text)
                .SetSmallIcon(Resource.Drawable.ic_stat_button_click)
                .SetContentIntent(BuildIntentToShowMainActivity())
                .SetAutoCancel(true)
                .SetOngoing(true)
                //    .AddAction(AkcijaPauseStop())
                .SetSound(RingtoneManager.GetDefaultUri(RingtoneType.Ringtone));

            ;

            //   Vibrator v = (Vibrator)GetSystemService(Context.VibratorService); // Make phone vibrate
            //     v.Vibrate(5000);

            NotificationManager notificationManager =
                (NotificationManager)Context.GetSystemService(Context.NotificationService);
            Notification notification = builder.Build();

            // Turn on vibrate:
            notification.Defaults |= NotificationDefaults.Vibrate;

            notificationManager.Notify(1001, notification);
        }


        private void PrikaziNotifikaciju(string text)
        {
            var builder = new Notification.Builder(Context)
                    .SetContentTitle("protok vode")
                    .SetContentText(text)
                    .SetSmallIcon(Resource.Drawable.ic_stat_button_click)
                    .SetContentIntent(BuildIntentToShowMainActivity())
                    .SetOngoing(true)
                //   .AddAction(BuildRestartTimerAction())
                //   .AddAction(BuildStopServiceAction())
                ;

            NotificationManager notificationManager =
                (NotificationManager)Context.GetSystemService(Context.NotificationService);
            notificationManager.Notify(1000, builder.Build());

        }
    }
}