using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Windows.Forms;

namespace WindowsFormsProjekat.Klase
{
    public class Artikal
    {
        public List<Artikal> artikali;
        public string Naziv { get; set; }
        public int IdKategorije { get; set; }
        public double Cena { get; set; }
        public string JedinicaMere { get; set; }
        string putanja_json = Application.StartupPath + @"/Fajlovi/artikli.json";

        public Artikal()
        {
            artikali = new List<Artikal>();
        }

        public void dodajArtikal(Artikal artikal)
        {
            artikali.Add(artikal);
        }

        public void obrisiArtikal(Artikal artikal)
        {
            artikali.Remove(artikal);
        }

        public List<Artikal> UcitajArtikleIzFajla()
        {
            List<Artikal> ucitaniArtikli = new List<Artikal>();

            if (File.Exists(putanja_json))
            {
                string json = File.ReadAllText(putanja_json);
                if (!string.IsNullOrEmpty(json))
                {
                    ucitaniArtikli = JsonConvert.DeserializeObject<List<Artikal>>(json);
                }
            }

            return ucitaniArtikli;
        }


        public void SacuvajArtikleUFajl()
        {

            string json = JsonConvert.SerializeObject(artikali, Formatting.Indented);
            File.WriteAllText(putanja_json, json);

        }

        


        public void snimiPokusajUnosa(string kategorija, DateTime vreme_unosa)
        {
            string poruka = $"Покушај уноса артикла из категорије '{kategorija}' након 22 часа. Време уноса: {vreme_unosa}.";
            string putanjaFajla = Application.StartupPath + @"\Fajlovi\PokusajKupovine.txt";
            using (StreamWriter writer = File.AppendText(putanjaFajla))
            {
                writer.WriteLine(poruka);
            }
        }


        public override string ToString()
        {
            return $"{Naziv} {Cena}/{JedinicaMere}";
        }
    }
}
