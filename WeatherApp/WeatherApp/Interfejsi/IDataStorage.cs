using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp.Interfejsi
{
    internal interface IDataStorage
    {
        Task SaveDataAsync(string data);
        Task<string> ReadDataAsync();
    }
}
