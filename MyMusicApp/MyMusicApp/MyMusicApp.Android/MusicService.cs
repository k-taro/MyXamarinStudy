using MyMusicApp.Droid;
using Xamarin.Forms;
using MyMusicApp.Services;
using Android.Media;
using Android.Provider;

[assembly: Dependency(typeof(MusicService))]

namespace MyMusicApp.Droid
{
    public class MusicService : IMusicService
    {
        private MediaPlayer mediaPlayer;

        /* 1回呼ぶと鳴る。もう1回呼ぶと止まる。 */
        public void PlayMusic(string fileName)
        {
            if (mediaPlayer != null)
            {
                if (mediaPlayer.IsPlaying)
                {
                    mediaPlayer.Stop();
                    return;
                }
            }
            /* stop()しない限り鳴り続ける */
            mediaPlayer = MediaPlayer.Create(global::Android.App.Application.Context, Settings.System.DefaultAlarmAlertUri);
            mediaPlayer.Start();
        }

    }
}