using System;
using System.Collections.Generic;
using System.Text;

namespace MyMusicApp.Services
{
    public interface IWebBrowserService
    {
        void Open(Uri uri);
    }
}
