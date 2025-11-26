using Newtonsoft.Json;
using System.Net;
using WeatherApp.Klase;
using static System.Net.WebRequestMethods;
using static WeatherApp.Klase.WeatherInfo;
using static WeatherApp.Klase.TxtDataStorage;
using System.Data;
using System.Windows.Forms;
using WeatherApp.Interfejsi;

namespace WeatherApp
{
    public partial class WeatherApp : Form
    {
        TxtDataStorage txtData = TxtDataStorage.Instance;
        public WeatherApp()
        {
            InitializeComponent();
            this.MaximizeBox = false;
            WeatherDataService.Instance.WeatherDataUpdated += WeatherDataUpdatedHandler;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGrid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGrid.ReadOnly = true;
            UcitajPodatkeUDatagrid();
        }


        private async void UcitajPodatkeUDatagrid()
        {
            try
            {

                string data = await txtData.ReadDataAsync();

                if (!string.IsNullOrEmpty(data))
                {
                    string[] redovi = data.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

                    DataTable dataTable = new DataTable();
                    dataTable.Columns.Add("Datum", typeof(string));
                    dataTable.Columns.Add("Grad", typeof(string));
                    dataTable.Columns.Add("Vreme", typeof(string));
                    dataTable.Columns.Add("Temperatura", typeof(string));
                    dataTable.Columns.Add("IzlazakSunca", typeof(string));
                    dataTable.Columns.Add("ZalazakSunca", typeof(string));


                    foreach (string red in redovi)
                    {

                        string[] delovi = red.Split('|');


                        dataTable.Rows.Add(delovi[0].Trim(), delovi[1].Trim(), delovi[2].Trim(), delovi[3].Trim(), delovi[4].Trim(), delovi[5].Trim());
                    }
                    dataGrid.DataSource = dataTable;
                }
                else
                {
                    MessageBox.Show("Nema podataka za prikazivanje.", "Informacija", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Došlo je do greške prilikom učitavanja podataka: {ex.Message}", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private async void btPretrazi_Click(object sender, EventArgs e)
        {
            string uneseniGrad = tbGrad.Text;

            if (!string.IsNullOrEmpty(uneseniGrad))
            {
                WeatherData weatherData = await WeatherDataService.Instance.getWeatherDataAsync(uneseniGrad);

            }
            else
            {
                MessageBox.Show("Molimo unesite grad.", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void UpdateUI(WeatherData weatherData)
        {
            if (weatherData != null)
            {
                lbVremeValue.Text = weatherData.Weather[0].Main;
                lbDetaljiValue.Text = weatherData.Weather[0].Description;
                lbISValue.Text = convertDateTime(weatherData.Sys.Sunrise).ToShortTimeString();
                lbZSValue.Text = convertDateTime(weatherData.Sys.Sunset).ToShortTimeString();

                lbBV.Text = weatherData.Wind.Speed.ToString();
                lbPritisak.Text = weatherData.Main.Pressure.ToString();
                lbTemp.Text = Math.Round((weatherData.Main.Temp - 273.15), 2).ToString();
                lbTempMin.Text = Math.Round((weatherData.Main.Temp_min - 273.15), 2).ToString();
                lbTempMax.Text = Math.Round((weatherData.Main.Temp_max - 273.15), 2).ToString();
            }
        }
        private void WeatherDataUpdatedHandler(WeatherData weatherData)
        {
            UpdateUI(weatherData);
        }

        DateTime convertDateTime(long milisekunde)
        {
            DateTime day = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc).ToLocalTime();
            day = day.AddSeconds(milisekunde).ToLocalTime();
            return day;
        }

        private async void btSacuvaj_Click(object sender, EventArgs e)
        {
            if (tbGrad.Text == "")
            {
                MessageBox.Show("Prvo pretrazite grad da bi ste sacuvali podatke!");
            }
            else
            {
                string Datum = DateTime.Now.Day + "." + DateTime.Now.Month + "." + DateTime.Now.Year + ".";
                string dataToSave = string.Format("{0}|{1}| Vreme: {2}| Temperatura: {3} | Izlazak sunca: {4} | Zalazak sunca: {5}\n", Datum, tbGrad.Text, lbVremeValue.Text, lbTemp.Text, lbISValue.Text, lbZSValue.Text);
                ICommand saveCommand = new SaveDataCommand(txtData, dataToSave);
                CommandInvoker invoker = new CommandInvoker();
                invoker.SetCommand(saveCommand);
                await Task.Run(() => invoker.ExecuteCommand());
            }
        }
    }
}