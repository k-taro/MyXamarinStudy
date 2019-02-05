using MyMusicApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MyMusicApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        void OnXamarinButtonClicked(object sender, EventArgs args)
        {
            DependencyService.Get<IWebBrowserService>().Open(new Uri("https://docs.microsoft.com/ja-jp/xamarin/"));
        }

        void OnMusicButtonClicked(object sender, EventArgs args)
        {
            DependencyService.Get<IMusicService>().PlayMusic(null);
        }
    }
}
