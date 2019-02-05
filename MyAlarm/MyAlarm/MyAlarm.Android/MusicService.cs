using MyAlarm.Droid;
using Xamarin.Forms;
using MyAlarm.Services;
using Android.Media;
using Android.Provider;

[assembly: Dependency(typeof(MusicService))]

namespace MyAlarm.Droid
{
    public class MusicService : IMusicService
    {
        private MediaPlayer mediaPlayer;

        public void PlayMusic(string fileName)
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

        public void StopMusic()
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