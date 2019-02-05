using MyMapApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MyMapApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void Button_ClickedAsync(object sender, EventArgs e)
        {
            var location = await DependencyService.Get<ILocationService>().GetGeoCoordinatesAsync();
            await DisplayAlert("GPS", "Lat:" + location.Latitude.ToString() + "\nLon:" + location.Longitude.ToString(), "OK");
        }
    }
}
