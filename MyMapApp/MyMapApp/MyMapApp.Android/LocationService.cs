using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

using Xamarin.Forms;
using System.Threading.Tasks;

using MyMapApp.Services;
using MyMapApp.Droid;
using MyMapApp.Droid.Services;

using Plugin.Geolocator;
using Plugin.Geolocator.Abstractions;

[assembly: Dependency(typeof(LocationService))]
namespace MyMapApp.Droid.Services
{
    class LocationService : ILocationService
    {
        public async Task<GeoCoords> GetGeoCoordinatesAsync()
        {
            var locator = CrossGeolocator.Current;
            locator.DesiredAccuracy = 30;

            var position = await locator.GetPositionAsync(30000);

            if (position == null)
            {
                var result = new GeoCoords
                {
                    Latitude = 0,
                    Longitude = 0
                };

                return result;
            }
            else
            {
                var result = new GeoCoords
                {
                    Latitude = position.Latitude,
                    Longitude = position.Longitude
                };

                return result;
            }
        }
    }
}