using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace WindowsFormsProjekat.Klase
{
    public class Racun
    {
        public List<Racun> stavkeRacuna;
        public string Naziv { get; set; }
        public double Kolicina { get; set; }
        public string datum { get; set; }
        string putanja_json = Application.StartupPath + @"\Fajlovi\racun.json";

        public Racun()
        {
            stavkeRacuna = new List<Racun>();
        }

        public void SacuvajRacun()
        {

            string json = JsonConvert.SerializeObject(stavkeRacuna, Formatting.Indented);
            File.WriteAllText(putanja_json, json);
        }

        public List<Racun> UcitajRacun()
        {
            List<Racun> ucitaniRacuni = new List<Racun>();

            if (File.Exists(putanja_json))
            {
                string json = File.ReadAllText(putanja_json);
                if (!string.IsNullOrEmpty(json))
                {
                    ucitaniRacuni = JsonConvert.DeserializeObject<List<Racun>>(json);
                }
            }

            return ucitaniRacuni;
        }

    }
}
