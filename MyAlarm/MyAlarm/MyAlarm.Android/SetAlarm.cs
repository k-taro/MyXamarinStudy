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
using MyAlarm.Droid;
using MyAlarm.Services;
using Xamarin.Forms;

[assembly: Dependency(typeof(SetAlarm))]

namespace MyAlarm.Droid
{
    class SetAlarm : ISetAlarm
    {
        public void StopAlarm()
        {
            Intent intent = new Intent(Android.App.Application.Context, typeof(StartAlarmService));
            intent.PutExtra("alarm", false);
            PendingIntent pendingIntent = PendingIntent.GetService(Android.App.Application.Context, 0, intent, PendingIntentFlags.UpdateCurrent);
            pendingIntent.Send();
        }

        void ISetAlarm.SetAlarm(DateTimeOffset dateTimeOffs)
        {
            Intent intent = new Intent(Android.App.Application.Context, typeof(StartAlarmService));
            intent.PutExtra("alarm", true);
            PendingIntent pendingIntent = PendingIntent.GetService(Android.App.Application.Context, 0, intent, PendingIntentFlags.UpdateCurrent);

            AlarmManager am;
            am = (AlarmManager)global::Android.App.Application.Context.GetSystemService(Context.AlarmService);
            am.Set(AlarmType.RtcWakeup, dateTimeOffs.ToUnixTimeMilliseconds(), pendingIntent);
        }
    }
}