using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Interfejsi;
using static WeatherApp.Klase.WeatherInfo;

namespace WeatherApp.Klase
{
    internal class WeatherDataService : IWeatherDataService
    {
        private static WeatherDataService _instance;
        private readonly HttpClient _httpClient;
        string APIKey = "944d5a87058b13b2a9218c8e729d1fc9";

        public event Action<WeatherData> WeatherDataUpdated;

        private WeatherDataService()
        {
            _httpClient = new HttpClient();
        }

        public static WeatherDataService Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new WeatherDataService();
                return _instance;
            }
        }

        public async Task<bool> checkCityExistence(string grad)
        {
            using (HttpClient client = new HttpClient())
            {
                string url = $"https://api.openweathermap.org/data/2.5/weather?q={grad}&appid={APIKey}";

                try
                {
                    var json = await client.GetStringAsync(url);
                    return true;
                }
                catch (HttpRequestException)
                {
                    return false;
                }
            }
        }

        public async Task<WeatherData> getWeatherDataAsync(string grad)
        {
            if (await checkCityExistence(grad))
            {
                WeatherData weatherData = await getWeatherAsync(grad);
                Console.WriteLine("Pozivam WeatherDataUpdated događaj.");
                WeatherDataUpdated?.Invoke(weatherData);
                return weatherData;
            }
            else
            {
                MessageBox.Show("Uneseni grad ne postoji. Molimo unesite ispravan grad.", "Greška", MessageBoxButtons.OK);
                return null;
            }
        }

        public async Task<WeatherData> getWeatherAsync(string grad)
        {
            string url = $"https://api.openweathermap.org/data/2.5/weather?q={grad}&appid={APIKey}";
            var json = await _httpClient.GetStringAsync(url);
            return JsonConvert.DeserializeObject<WeatherData>(json);
        }
    }
}
