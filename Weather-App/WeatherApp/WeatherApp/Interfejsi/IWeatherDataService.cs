using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static WeatherApp.Klase.WeatherInfo;

namespace WeatherApp.Interfejsi
{
    internal interface IWeatherDataService
    {
        public event Action<WeatherData> WeatherDataUpdated;

        Task<bool> checkCityExistence(string grad);
        Task<WeatherData> getWeatherDataAsync(string city);
        Task<WeatherData> getWeatherAsync(string city);
    }
}
