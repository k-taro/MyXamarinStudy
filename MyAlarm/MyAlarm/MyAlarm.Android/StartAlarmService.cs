using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Media;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Provider;

namespace MyAlarm.Droid
{
    [Service]
    class StartAlarmService : IntentService
    {
        static private MediaPlayer mediaPlayer;

        public override IBinder OnBind(Intent intent)
        {
            return null;
        }

        public void onCrate()
        {
            /*
            mediaPlayer = MediaPlayer.Create(global::Android.App.Application.Context, Settings.System.DefaultAlarmAlertUri);
            mediaPlayer.Start();
            */
        }

        public void onDestroy()
        {
            /*
            mediaPlayer.Stop();
            */
        }

        protected override void OnHandleIntent(Intent intent)
        {
            if (intent != null && intent.GetBooleanExtra("alarm", false))
            {
                mediaPlayer = MediaPlayer.Create(this, Settings.System.DefaultAlarmAlertUri);
                mediaPlayer.Looping = true;
                mediaPlayer.Start();
                Intent newintent = new Intent(this, typeof(MainActivity));
                newintent.SetFlags(ActivityFlags.NewTask);
                StartActivity(newintent);
            }
            else
            {
                if (mediaPlayer != null && mediaPlayer.IsPlaying)
                {
                    mediaPlayer.Stop();
                    mediaPlayer.Reset();
                    mediaPlayer.Release();
                    mediaPlayer = null;
                }

            }
        }
    }
}