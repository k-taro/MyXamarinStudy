using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using MyMusicApp.iOS;
using MyMusicApp.Services;
using UIKit;
using Xamarin.Forms;

[assembly: Dependency(typeof(WebBrowserService))]

namespace MyMusicApp.iOS
{
    class WebBrowserService : IWebBrowserService
    {
        public void Open(Uri uri)
        {
            UIApplication.SharedApplication.OpenUrl(uri);
        }
    }
}