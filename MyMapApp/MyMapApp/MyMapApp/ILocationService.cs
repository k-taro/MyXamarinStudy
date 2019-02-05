using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyMapApp.Services
{
    public delegate void OnLocationChangedDelegate(GeoCoords location);
    public delegate void OnLocationErrorDelegate(string error);

    public interface ILocationService
    {
        /// <summary>
        /// 位置情報取得
        /// </summary>
        /// 
        Task<GeoCoords> GetGeoCoordinatesAsync();
    }
}
