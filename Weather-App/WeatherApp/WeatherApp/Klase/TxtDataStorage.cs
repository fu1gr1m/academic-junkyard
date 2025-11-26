using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Interfejsi;

namespace WeatherApp.Klase
{
    public class TxtDataStorage : IDataStorage
    {
        private static TxtDataStorage _instance;
        private static readonly object _lockObject = new object();
        private readonly string filePath = System.IO.Path.Combine(Environment.CurrentDirectory, "weather_data.txt");

        public static TxtDataStorage Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_lockObject)
                    {
                        if (_instance == null)
                        {
                            _instance = new TxtDataStorage();
                        }
                    }
                }

                return _instance;
            }
        }

        public async Task SaveDataAsync(string data)
        {
            try
            {
                await File.AppendAllTextAsync(filePath, data);
                MessageBox.Show("Podaci su uspesno sacuvani!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Greška prilikom čuvanja podataka u .txt fajl: {ex.Message}");
            }
        }

        public async Task<string> ReadDataAsync()
        {
            try
            {
                if (File.Exists(filePath))
                {
                    string[] lines = await File.ReadAllLinesAsync(filePath);
                    return string.Join(Environment.NewLine, lines);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Greška prilikom čitanja podataka iz .txt fajla: {ex.Message}");
            }

            return string.Empty;
        }
    }


}
