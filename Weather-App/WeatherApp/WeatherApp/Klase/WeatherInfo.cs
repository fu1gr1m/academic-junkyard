using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp.Klase
{
    internal class WeatherInfo
    {
        public class Coord
        {
            public double Lon { get; set; }
            public double Lat { get; set; }
        }

        public class Weather
        {
            public string Main { get; set; }
            public string Description { get; set; }
            public string Icon { get; set; }
        }

        public class Main
        {
            public double Temp { get; set; }
            public double Temp_min { get; set; }
            public double Temp_max { get; set; }
            public double Pressure { get; set; }
            public double Humidity { get; set; }
        }

        public class Wind
        {
            public double Speed { get; set; }
        }

        public class Sys
        {
            public long Sunrise { get; set; }
            public long Sunset { get; set; }
        }

        public class WeatherData
        {
            public Coord Coord { get; set; }
            public List<Weather> Weather { get; set; }
            public Main Main { get; set; }
            public Wind Wind { get; set; }
            public Sys Sys { get; set; }
        }
    }
}
