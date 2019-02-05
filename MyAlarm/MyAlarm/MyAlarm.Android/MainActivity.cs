using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Media;
using Android.Provider;


namespace MyAlarm.Droid
{
    [Activity(Label = "MyAlarm", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        private MediaPlayer mediaPlayer;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);

            App app = new App();
            app.ChildAdded += App_ChildAdded;

            LoadApplication(app);

            if (this.Intent != null && this.Intent.GetBooleanExtra("alarm", false))
            {
                mediaPlayer = MediaPlayer.Create(global::Android.App.Application.Context, Settings.System.DefaultAlarmAlertUri);
                mediaPlayer.Completion +=
                    (object sender, System.EventArgs e) =>
                    {
                        mediaPlayer.Release();
                        mediaPlayer.Start();
                    };
                mediaPlayer.Start();
            }
        }

        private void App_ChildAdded(object sender, Xamarin.Forms.ElementEventArgs e)
        {
            if (sender is Button)
            {
                Button btn = (Button)sender;
                if (String.Equals(btn.Id, "btn_stop_alarm"))
                {
                    btn.Click += Stop_Button_Click;
                }
            }
        }

         private void Stop_Button_Click(object sender, EventArgs e)
        {
            if (mediaPlayer != null && mediaPlayer.IsPlaying)
            {
                mediaPlayer.Stop();
                mediaPlayer.Reset();
                mediaPlayer.Release();
                mediaPlayer = null;
            }
;
        }
    }
}