using System;
using System.Collections.Generic;
using System.Text;

namespace MyAlarm.Services
{
    public interface IMusicService
    {
        void PlayMusic(string fileName);
        void StopMusic();
    }
}
