using System;
using Android.Content;
using MyMusicApp.Services;
using OpenWebBrowserSample.Android;
using Xamarin.Forms;

[assembly: Dependency(typeof(WebBrowserService))]

namespace OpenWebBrowserSample.Android
{
    public class WebBrowserService : IWebBrowserService
    {
        public void Open (Uri uri)
        {
            Context context = Forms.Context;
            context.StartActivity (
                new Intent(Intent.ActionView,
                    global::Android.Net.Uri.Parse(uri.AbsoluteUri) ));
        }
    }
}