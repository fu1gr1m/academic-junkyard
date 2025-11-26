using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsProjekat.Klase;


namespace WindowsFormsProjekat
{
    public partial class AdministracijaIStatistika : Form
    {
        private Kategorija kategorijaManager;
        private Artikal artikalManager;
        private Racun racunManager;



        public AdministracijaIStatistika()
        {
            InitializeComponent();
            IzmeniKat.Enabled = false;
            ObrisiKat.Enabled = false;
            AAbtIzmeniArtikal.Enabled = false;
            AAbtObrisiartikal.Enabled = false;
            tabPregledStat.AutoScroll = true;
            kategorijaManager = new Kategorija();
            artikalManager = new Artikal();
            racunManager = new Racun();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
        }

        private void AdministracijaIStatistika_Load_1(object sender, EventArgs e)
        {
            kategorijaManager.kategorije = kategorijaManager.UcitajKategorijeIzFajla();
            artikalManager.artikali = artikalManager.UcitajArtikleIzFajla();
            racunManager.stavkeRacuna = racunManager.UcitajRacun();
            if(kategorijaManager.kategorije != null) { 
                foreach (Kategorija kategorija in kategorijaManager.kategorije)
                {
                    
                    AKlistbox.Items.Add(kategorija.ToString());
                    cbKategorija.Items.Add(kategorija.Naziv);
                }
            }

            if(artikalManager.artikali != null)
            {
                foreach(Artikal artik in artikalManager.artikali)
                {
                    AAlistbox.Items.Add(artik.ToString());
                }
            }



        }

        private void AdministracijaIStatistika_FormClosing(object sender, FormClosingEventArgs e)
        {
            kategorijaManager.SacuvajKategorijeUFajl();
            artikalManager.SacuvajArtikleUFajl();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void tbNaziv_TextChanged(object sender, EventArgs e)
        {

        }

        private void DodajKat_Click(object sender, EventArgs e)
        {

            if (!string.IsNullOrWhiteSpace(tbNaziv.Text))
            {
                string naziv_kategorije = tbNaziv.Text.Trim();

                if (kategorijaManager.kategorije.Any(k => k.Naziv == naziv_kategorije))
                {
                    MessageBox.Show("Category with the same name already exists!");
                    return;
                }



                int noviId = 0;
                while (kategorijaManager.kategorije.Any(k => k.Id == noviId))
                {
                    noviId++;
                }

                Kategorija novaKategorija = new Kategorija
                {
                    Id = noviId,
                    Naziv = naziv_kategorije
                };

                kategorijaManager.DodajKategoriju(novaKategorija); //dodato u listu
                AKlistbox.Items.Add(novaKategorija.ToString());
                cbKategorija.Items.Clear();
                foreach (Kategorija kategorija in kategorijaManager.kategorije)
                {
                    cbKategorija.Items.Add(kategorija.Naziv);
                }

                tbNaziv.Text = string.Empty;
                IzmeniKat.Enabled = false;
                ObrisiKat.Enabled = false;
            }
            else
            {
                MessageBox.Show("Field name is empty!");
                return;
            }
        }

      

        private void AKlistbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (AKlistbox.SelectedItem != null)
            {
                IzmeniKat.Enabled = true;
                ObrisiKat.Enabled = true;
                string izabraniTekst = AKlistbox.SelectedItem.ToString();
                string[] delovi = izabraniTekst.Split('|');

                if(delovi.Length > 1)
                {
                    string naziv = delovi[1].Trim();
                    tbNaziv.Text = naziv;
                }

            }
        }

        private void IzmeniKat_Click(object sender, EventArgs e)
        {
            if(AKlistbox.SelectedItem != null)
            {
                string nazivKat = tbNaziv.Text.Trim();
                if (!string.IsNullOrEmpty(nazivKat))
                {
                    int indeks = AKlistbox.SelectedIndex;
                    string staraStavka = AKlistbox.SelectedItem.ToString();
                    string novaStavka = $"{indeks}|{nazivKat}";

                    AKlistbox.Items[AKlistbox.SelectedIndex] = novaStavka;

                    Kategorija izabranaKategorija = kategorijaManager.kategorije[indeks];
                    izabranaKategorija.Naziv = nazivKat;
                    tbNaziv.Text = string.Empty;
                    IzmeniKat.Enabled = false;
                    ObrisiKat.Enabled = false;
                }
            }

            kategorijaManager.SacuvajKategorijeUFajl();

        }

        private void ObrisiKat_Click(object sender, EventArgs e)
        {
            int indeks = AKlistbox.SelectedIndex;

            if (indeks != -1)
            {
                Kategorija izabranaKategorija = kategorijaManager.kategorije.ElementAtOrDefault(indeks);
                if (izabranaKategorija != null)
                {


                    bool provera = false;
                    foreach(Artikal artikall in artikalManager.artikali)
                    {
                        if(artikall.IdKategorije == izabranaKategorija.Id)
                        {
                            provera = true;
                        }
                    }

                    if(provera == true)
                    {
                        MessageBox.Show("Clear all items within this category so you can delete the category!");
                        return;
                    }

                    kategorijaManager.ObrisiKategoriju(izabranaKategorija);
                    AKlistbox.Items.RemoveAt(indeks);
                    tbNaziv.Text = string.Empty;
                    IzmeniKat.Enabled = false;
                    ObrisiKat.Enabled = false;
                }
            }

        }

        private void cbKategorija_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void AAbtDodajArtikal_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(cbKategorija.Text.Trim()) && !string.IsNullOrEmpty(tbNazivArtikla.Text.Trim()) && !string.IsNullOrEmpty(tbJMArtikla.Text.Trim()) && !string.IsNullOrEmpty(tbCenaArtikla.Text.Trim()))
            {
                string naziv_artikla = tbNazivArtikla.Text.Trim();
                string cena_artikla_tekst = tbCenaArtikla.Text.Trim();
                double cena_artikla;
                string jedinica_mere = tbJMArtikla.Text.Trim();

                cena_artikla = Math.Round(double.Parse(cena_artikla_tekst), 2);

                if (artikalManager.artikali.Any(k => k.Naziv == naziv_artikla))
                {
                    MessageBox.Show("An item with the same name already exists!");
                    return;
                }

                bool provera = false;
                int idKategorije = 0;
                string odabranakat = cbKategorija.Text.Trim();
                Kategorija kategorijazaArtikal = new Kategorija();

                foreach (Kategorija kategorija in kategorijaManager.kategorije)
                {
                    if (kategorija.Naziv.Trim() == odabranakat)
                    {
                        provera = true;
                        kategorijazaArtikal = kategorija;
                    }
                }

                if(provera == false)
                {
                    MessageBox.Show("There is no valid category, please select one from the list.");
                    return;
                }
                

                idKategorije = kategorijazaArtikal.Id;

                Artikal novi_artikal = new Artikal
                {
                    Naziv = naziv_artikla,
                    Cena = cena_artikla,
                    JedinicaMere = jedinica_mere,
                    IdKategorije = idKategorije
                };


                artikalManager.dodajArtikal(novi_artikal); //dodato u listu
                AAlistbox.Items.Add(novi_artikal.ToString()); //latest change, keep in mind
                tbNazivArtikla.Text = string.Empty;
                tbCenaArtikla.Text = string.Empty;
                tbJMArtikla.Text = string.Empty;
                cbKategorija.Text = string.Empty;
                AAbtIzmeniArtikal.Enabled = false;
                AAbtObrisiartikal.Enabled = false;
            }
            else
            {
                MessageBox.Show("Some of your fields are empty!");
                return;
            }
        }

        private void AAbtIzmeniArtikal_Click(object sender, EventArgs e)
        {

            if (AAlistbox.SelectedItem != null)
            {
                string nazivArt = tbNazivArtikla.Text.Trim();
                string cenaArt_tekst = tbCenaArtikla.Text.Trim();
                double cenaArt;
                string jedinica_mere = tbJMArtikla.Text;
                string naziv_kategorije = cbKategorija.Text.Trim();
                int idkat = 0;
                bool provera = false;
                foreach (Kategorija kategorija in kategorijaManager.kategorije)
                {
                    if (kategorija.Naziv.Trim() == naziv_kategorije)
                    {
                        idkat = kategorija.Id;
                        provera = true;
                    }
                    
                }

                if (provera == false)
                {
                    MessageBox.Show("There is no category entered, please enter one from the list.");
                    return;
                }

                cenaArt = Math.Round(double.Parse(cenaArt_tekst), 2);
                if (!string.IsNullOrWhiteSpace(nazivArt) && !string.IsNullOrWhiteSpace(cenaArt_tekst) && !string.IsNullOrWhiteSpace(jedinica_mere) && !string.IsNullOrWhiteSpace(naziv_kategorije))
                {
                    int indeks = AAlistbox.SelectedIndex;
                    string staraStavka = AAlistbox.SelectedItem.ToString();
                    string novaStavka = $"{nazivArt} {cenaArt_tekst}/{jedinica_mere}";

                    AAlistbox.Items[AAlistbox.SelectedIndex] = novaStavka;

                    Artikal izabraniArtikal = artikalManager.artikali[indeks];
                    izabraniArtikal.Naziv = nazivArt;
                    izabraniArtikal.Cena = cenaArt;
                    izabraniArtikal.JedinicaMere = jedinica_mere;
                    izabraniArtikal.IdKategorije = idkat;
                    tbNazivArtikla.Text = string.Empty;
                    tbCenaArtikla.Text = string.Empty;
                    tbJMArtikla.Text = string.Empty;
                    cbKategorija.Text = string.Empty;
                    AAbtIzmeniArtikal.Enabled = false;
                    AAbtObrisiartikal.Enabled = false;

                }
                else
                {
                    MessageBox.Show("Some of your fields are empty!");
                    return;
                }
            }
        }

        private void AAbtObrisiartikal_Click(object sender, EventArgs e)
        {
            int indeks = AAlistbox.SelectedIndex;

            if (indeks != -1)
            {
                Artikal izabraniArtikal = artikalManager.artikali.ElementAtOrDefault(indeks);
                if (izabraniArtikal != null)
                {
                    artikalManager.obrisiArtikal(izabraniArtikal);
                    AAlistbox.Items.RemoveAt(indeks);
                    tbNazivArtikla.Text = string.Empty;
                    tbCenaArtikla.Text = string.Empty;
                    tbJMArtikla.Text = string.Empty;
                    cbKategorija.Text = string.Empty;
                    AAbtIzmeniArtikal.Enabled = false;
                    AAbtObrisiartikal.Enabled = false;
                }
            }
        }

        private void AAlistbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (AAlistbox.SelectedItem != null)
            {
                AAbtIzmeniArtikal.Enabled = true;
                AAbtObrisiartikal.Enabled = true;
                string odabraniArtikall = AAlistbox.SelectedItem.ToString();
                int indeksRazmaka = odabraniArtikall.LastIndexOf(' ');
                string nazivArtikla = odabraniArtikall.Substring(0, indeksRazmaka);

                // Pronađi odgovarajući objekat Artikal na osnovu naziva
                Artikal odabraniArtikal = new Artikal();
                foreach (Artikal artikal in artikalManager.artikali)
                {
                    if (artikal.Naziv.Trim() == nazivArtikla)
                    {
                        odabraniArtikal = artikal;
                    }
                }

                if (odabraniArtikal != null)
                {
                    // Prikazi odabrane vrijednosti u TextBox-ovima
                    tbNazivArtikla.Text = odabraniArtikal.Naziv;
                    tbCenaArtikla.Text = odabraniArtikal.Cena.ToString();
                    tbJMArtikla.Text = odabraniArtikal.JedinicaMere;
                    foreach(Kategorija kategorija in kategorijaManager.kategorije)
                    {
                        if(kategorija.Id == odabraniArtikal.IdKategorije)
                        {
                            cbKategorija.Text = kategorija.Naziv;
                        }
                    }
                }
            }
        }

        private void PrikaziStatistiku_ValueChanged(object sender, EventArgs e)
        {

            DateTime selectedDate = PrikaziStatistiku.Value.Date;

            for (int i = tabPregledStat.Controls.Count - 1; i >= 0; i--)
            {
                Control control = tabPregledStat.Controls[i];

                if (!(control is DateTimePicker))
                {
                    tabPregledStat.Controls.RemoveAt(i);
                    control.Dispose();
                    
                }
            }




            int spacing = 5;
            int posY = 80;
            int progressBarHeight = 30;

            var racuniZaDatum = racunManager.stavkeRacuna.Where(r => DateTime.Parse(r.datum).Date == selectedDate);
            var grupisaniPodaci = racuniZaDatum
                .GroupBy(r => r.Naziv)
                .Select(g => new
                {
                    Naziv = g.Key,
                    Kolicina = g.Sum(r => r.Kolicina)
                });


            var ukupnaKolicina = racunManager.stavkeRacuna
                .GroupBy(r => r.Naziv)
                .Select(g => new
                {
                    Naziv = g.Key,
                    Kolicina = g.Sum(r => r.Kolicina)
                })
                .ToDictionary(g => g.Naziv, g => g.Kolicina);


            foreach (var podatak in grupisaniPodaci)
            {

                double ukupnaKolicinaArtikla = ukupnaKolicina.ContainsKey(podatak.Naziv) ? ukupnaKolicina[podatak.Naziv] : 0;

                 // Kreiranje labela za prikaz naziva artikla i količine
                Label labelNaziv = new Label();
                 labelNaziv.Text = podatak.Naziv;
                 labelNaziv.AutoSize = true;
                 labelNaziv.Left = spacing;

                 Label labelKolicina = new Label();
                 labelKolicina.Text = podatak.Kolicina.ToString();
                 labelKolicina.AutoSize = true;
                 labelKolicina.Left = labelNaziv.Left + labelNaziv.Width + spacing;

                 int progressBarWidth = 400;

                    // Kreiranje progresne trake za svaku stavku racuna
                 ProgressBar progressBar = new ProgressBar();
                 progressBar.Minimum = 0;
                 progressBar.Maximum = 100;
                 progressBar.Value = Convert.ToInt32((podatak.Kolicina * 100) / ukupnaKolicinaArtikla) ; // Izračunavanje procentualne vrednosti
                 progressBar.Width = progressBarWidth;
                 progressBar.Height = progressBarHeight;
                 progressBar.Top = posY;
                 progressBar.Left = labelNaziv.Left + labelNaziv.Width + spacing * 2;

                    // Podešavanje pozicije labela za prikaz naziva artikla i količine
                 labelNaziv.Top = posY + (progressBarHeight - labelNaziv.Height) / 2;
                 labelKolicina.Top = posY + (progressBarHeight - labelKolicina.Height) / 2;

                    // Podešavanje pozicije labela i progress bara
                 labelNaziv.Left = spacing;
                 labelKolicina.Left = tabPregledStat.Width - labelKolicina.Width - spacing;
                 progressBar.Left = labelKolicina.Left - spacing - progressBar.Width;

                    // Dodavanje progresne trake i labela na tab
                 tabPregledStat.Controls.Add(progressBar);
                 tabPregledStat.Controls.Add(labelNaziv);
                 tabPregledStat.Controls.Add(labelKolicina);

                    // Ažuriranje pozicije Y za sledeću stavku
                 posY += progressBarHeight + spacing;

            }
            

        }

        public void SetSerbianLang()
        {
            this.Text = "Administracija/Statistika";
            tabAzuriranjeKat.Text = "Menadzer kategorija";
            tabAzuriranjeArt.Text = "Menadzer artikla";
            tabPregledStat.Text = "Statistika";
            nazivKategorije.Text = "Naziv kategorije:";
            DodajKat.Text = "Dodaj kategoriju";
            IzmeniKat.Text = "Izmeni ime kategorije";
            ObrisiKat.Text = "Izbrisi kategoriju";
            AAbtDodajArtikal.Text = "Dodaj artikal";
            AAbtIzmeniArtikal.Text = "Izmeni artikal";
            AAbtObrisiartikal.Text = "Izbrisi artikal";
            AAlabelKategorije.Text = "Kategorija:";
            AALabelNaziva.Text = "Naziv Artikla:";
            AACenaArtikla.Text = "Cena Artikla:";
            AAJedinicaMere.Text = "Jedinica mere artikla";
        }

        public void SetEnglishLang()
        {
            this.Text = "Administration/Statistics";
            tabAzuriranjeKat.Text = "Categorie Managment";
            tabAzuriranjeArt.Text = "Article Managment";
            tabPregledStat.Text = "Statistics";
            nazivKategorije.Text = "Name of the Category:";
            DodajKat.Text = "Add category";
            IzmeniKat.Text = "Edit category name";
            ObrisiKat.Text = "Delete category";
            AAbtDodajArtikal.Text = "Add article";
            AAbtIzmeniArtikal.Text = "Edit article";
            AAbtObrisiartikal.Text = "Delete article";
            AAlabelKategorije.Text = "Category:";
            AALabelNaziva.Text = "Article Name:";
            AACenaArtikla.Text = "Price of the article:";
            AAJedinicaMere.Text = "Unit of measure of article:";
        }




    }
}
