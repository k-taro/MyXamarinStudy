using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AVFoundation;
using Foundation;
using MyMusicApp.iOS;
using MyMusicApp.Services;
using UIKit;
using Xamarin.Forms;

[assembly: Dependency(typeof(MusicService))]

namespace MyMusicApp.iOS
{
    class MusicService : IMusicService
    {
        private AVAudioPlayer audioPlayer;

        public void PlayMusic(string fileName)
        {
            var url = NSUrl.FromString("/System/Library/Audio/UISounds/alarm.caf");

            NSError outError;
            NSUrl fileURL = new NSUrl(fileName);
            audioPlayer = new AVAudioPlayer(url: fileURL, fileTypeHint: "alarm.caf", outError: out outError);
            audioPlayer.FinishedPlaying += (object sender, AVStatusEventArgs e) => audioPlayer = null;
            audioPlayer.Play();
        }
    }
}