using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace WindowsFormsProjekat.Klase
{
    public class Kategorija
    {
        public List<Kategorija> kategorije;
        string putanja_json = Application.StartupPath + @"\Fajlovi\kategorije.json";
        public string Naziv { get; set; }
        public int Id { get; set; }
        public Kategorija()
        {
            kategorije = new List<Kategorija>();
        }

        public void listaKategorija(List<Kategorija> kategorija)
        {
            foreach(var element in kategorije)
            {
                kategorija.Add(element); ///ovo treba da se doradi
            }
        }

        public void DodajKategoriju(Kategorija kategorija)
        {
            kategorije.Add(kategorija);
        }

        public void ObrisiKategoriju(Kategorija kategorija)
        {
            kategorije.Remove(kategorija);
        }


        public override string ToString()
        {
            return $"{Id}|{Naziv}";
        }




        public List<Kategorija> UcitajKategorijeIzFajla()
        {
            List<Kategorija> ucitaneKategorije = new List<Kategorija>();

            if (File.Exists(putanja_json))
            {
                string json = File.ReadAllText(putanja_json);
                if (!string.IsNullOrEmpty(json))
                {
                    ucitaneKategorije = JsonConvert.DeserializeObject<List<Kategorija>>(json);
                }
            }

            return ucitaneKategorije;
        }


        public void SacuvajKategorijeUFajl()
        {

            
             string json = JsonConvert.SerializeObject(kategorije, Formatting.Indented);
             File.WriteAllText(putanja_json, json);
            
        }

    }
}
