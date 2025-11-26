using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Interfejsi;

namespace WeatherApp.Klase
{
    public class SaveDataCommand : ICommand
    {
        private readonly TxtDataStorage txtData;
        private readonly string dataToSave;

        public SaveDataCommand(TxtDataStorage txtData, string dataToSave)
        {
            this.txtData = txtData;
            this.dataToSave = dataToSave;
        }

        public void Execute()
        {
            txtData.SaveDataAsync(dataToSave).Wait(); //mora da se ceka na izvrsenje zbog async metode
        }
    }

}
