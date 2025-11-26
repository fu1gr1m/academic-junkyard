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
    public partial class Prodaja_Naplata : Form
    {
        public delegate void DelegatMetode(string kategorija, DateTime vreme_unosa);
        public event DelegatMetode dogadjajzaupis;
        
        

        private Kategorija kategorijaManager;
        private Artikal artikalManager;
        private Racun racunManager;

        bool proba = false;
        public Prodaja_Naplata()
        {
            InitializeComponent();
            kategorijaManager = new Kategorija();
            artikalManager = new Artikal();
            racunManager = new Racun();
            dogadjajzaupis += artikalManager.snimiPokusajUnosa;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        private void Prodaja_Naplata_Load(object sender, EventArgs e)
        {
            kategorijaManager.kategorije = kategorijaManager.UcitajKategorijeIzFajla();
            artikalManager.artikali = artikalManager.UcitajArtikleIzFajla();
            racunManager.stavkeRacuna = racunManager.UcitajRacun();
            tbCitac.ReadOnly = true;
            btPonistavanje.Enabled = false;
            btUnos.Enabled = false;
            btBrojJedan.Enabled = false;
            btBrojDva.Enabled = false;
            btBrojTri.Enabled = false;
            btBrojCetiri.Enabled = false;
            btBrojPet.Enabled = false;
            btBrojSest.Enabled = false;
            btBrojSedam.Enabled = false;
            btBrojOsam.Enabled = false;
            btBrojDevet.Enabled = false;
            btBrojNula.Enabled = false;
            btMnozenje.Enabled = false;
            MaximizeBox = false;
            tbCitac.Enabled = false;

            foreach (Kategorija kategorija in kategorijaManager.kategorije)
            {
                Button dugme = new Button();
                dugme.Text = kategorija.Naziv;
                dugme.AutoSize = false;
                dugme.Anchor = AnchorStyles.Top | AnchorStyles.Left;
                dugme.BackColor = Color.RosyBrown;
                dugme.Font = new Font("Times New Roman", 12, FontStyle.Regular);
                int dugme_visina = trKategorija.Height;
                int dugme_sirina = trKategorija.Width / kategorijaManager.kategorije.Count;
                dugme.Height = 74;
                dugme.Width = dugme_sirina + 30;
                dugme.FlatStyle = FlatStyle.Flat;
                dugme.Click += Dugme_Click;
                dugme.Tag = kategorija;
                trKategorija.Controls.Add(dugme);




            }
        }

        private void lbukupnaCena_Click(object sender, EventArgs e)
        {

        }

        private void Dugme_Click(object sender, EventArgs e)
        {
            tbCitac.ReadOnly = false;
            foreach (Button dugme in trKategorija.Controls.OfType<Button>())
            {
                if (dugme == (Button)sender)
                {
                    dugme.BackColor = Color.Red;
                    foreach (Kategorija kategorija in kategorijaManager.kategorije)
                    {
                        if (dugme.Text.Trim() == kategorija.Naziv.Trim())
                        {
                            Ucitavanje_Dugmica_Artikala(kategorija);
                        }
                    }
                }
                else
                {
                    dugme.BackColor = Color.RosyBrown;

                }
            }


        }

        private void Dugme_Artikal_Click(object sender, EventArgs e)
        {
            foreach (Button dugme in trArtikli.Controls.OfType<Button>())
            {
                if (dugme == (Button)sender)
                {
                    dugme.BackColor = Color.DarkRed;

                    tbRacun.Text = string.Empty;
                    tbRacun.Text = dugme.Text;
                }
                else
                {
                    dugme.BackColor = Color.DarkOrange;
                }
            }
        }

        private void Ucitavanje_Dugmica_Artikala(Kategorija kategorija)
        {
            trArtikli.Controls.Clear();
            foreach (Artikal artikli in artikalManager.artikali)
            {
                if (artikli.IdKategorije == kategorija.Id)
                {
                    Button dugme_artikal = new Button();
                    dugme_artikal.Text = artikli.Naziv;
                    dugme_artikal.AutoSize = false;
                    dugme_artikal.Anchor = AnchorStyles.Top | AnchorStyles.Left;
                    dugme_artikal.BackColor = Color.DarkOrange;
                    dugme_artikal.Font = new Font("Times New Roman", 12, FontStyle.Regular);
                    foreach (Artikal artikal in artikalManager.artikali)

                    dugme_artikal.Height = 113;
                    dugme_artikal.Width = 113;
                    dugme_artikal.FlatStyle = FlatStyle.Flat;
                    dugme_artikal.Click += Dugme_Artikal_Click;
                    dugme_artikal.Tag = artikli;
                    trArtikli.Controls.Add(dugme_artikal);
                }
            }
        }

        private void Dugme_Broj_Click(object sender, EventArgs e)
        {
            Button dugme_broj = (Button)sender;
            string broj = dugme_broj.Text;
            

            tbRacun.Text += broj;
        }

        private void btPonistavanje_Click(object sender, EventArgs e)
        {
            tbRacun.Text = string.Empty;
        }

        private void btMnozenje_Click(object sender, EventArgs e)
        {
            btBrojJedan.Enabled = true;
            btBrojDva.Enabled = true;
            btBrojTri.Enabled = true;
            btBrojCetiri.Enabled = true;
            btBrojPet.Enabled = true;
            btBrojSest.Enabled = true;
            btBrojSedam.Enabled = true;
            btBrojOsam.Enabled = true;
            btBrojDevet.Enabled = true;
            btBrojNula.Enabled = true;

            string substring = "kom";
            foreach (var artikalcic in artikalManager.artikali)
            {
                if (artikalcic.Naziv.Trim() == tbRacun.Text.Trim() && artikalcic.JedinicaMere.Trim() == substring.Trim())
                {
                    btZarez.Enabled = false;
                    btBrojNula.Enabled = false;
                    break;
                }
                else
                {
                    btZarez.Enabled = true;
                    btBrojNula.Enabled = true;
                }
            }

            tbRacun.Text += " x ";
            
        }

        

        private void btUnos_Click(object sender, EventArgs e)
        {
            string unos = tbRacun.Text;
            double ukupna_cena = 0;
            string[] delimetri = { " x " };
            string[] delovi = unos.Split(delimetri, StringSplitOptions.RemoveEmptyEntries);

            DateTime vreme_unosa = DateTime.Now;

            string naziv = delovi[0];
            foreach(Artikal art in artikalManager.artikali)
            {
                if(art.Naziv.Trim() == naziv.Trim() && art.IdKategorije == 3 && vreme_unosa.Hour > 22)
                {
                    dogadjajzaupis?.Invoke(art.Naziv, vreme_unosa);
                    MessageBox.Show("It is impossible to bring in alcoholic beverages after 10 pm.");
                    return;
                }
            }




            if (delovi.Length == 2)
            {
                string nazivArtikla = delovi[0];
                string broj = delovi[1].Replace(',', '.');
                string lbunos_obrazac = "";
                double cena = 0;

                foreach(Artikal artikal in artikalManager.artikali)
                {
                    if(artikal.Naziv.Trim() == nazivArtikla.Trim())
                    {
                        lbunos_obrazac = $"{artikal.Naziv} ({broj}/{artikal.JedinicaMere})";
                        cena = artikal.Cena;
                    }
                }

                

                
                lbUnosObrada.Items.Add(lbunos_obrazac);

                foreach (var stavka in lbUnosObrada.Items)
                {
                    string nazivStavke = stavka.ToString();
                    string cenaString = nazivStavke.Substring(nazivStavke.LastIndexOf("(") + 1);
                    cenaString = cenaString.Substring(0, cenaString.LastIndexOf("/")).Trim();
                    string nazivArtiklaa = nazivStavke.Substring(0, nazivStavke.LastIndexOf(" ")).Trim();
                    double cena_artikla = 0;
                    double broji = double.Parse(cenaString);
                    foreach (Artikal artikal in artikalManager.artikali)
                    {
                        if (artikal.Naziv.Trim() == nazivArtiklaa)
                        {
                            cena_artikla = artikal.Cena;
                            break;
                        }
                    }

                    ukupna_cena += cena_artikla * broji;

                }

                lbukupnaCena.Text = ukupna_cena.ToString("N2") + " $";



            }
            else if(delovi.Length == 1){
                string nazivArtikla = delovi[0];
                string broj = "1";
                string lbunos_obrazac = "";
                double cena = 0;

                foreach (Artikal artikal in artikalManager.artikali)
                {
                    if (artikal.Naziv.Trim() == nazivArtikla.Trim())
                    {
                        lbunos_obrazac = $"{artikal.Naziv} ({broj}/{artikal.JedinicaMere})";
                        cena = artikal.Cena;
                    }
                }

               
                lbUnosObrada.Items.Add(lbunos_obrazac);

                foreach (var stavka in lbUnosObrada.Items)
                {
                    string nazivStavke = stavka.ToString();
                    string cenaString = nazivStavke.Substring(nazivStavke.LastIndexOf("(") + 1);
                    cenaString = cenaString.Substring(0, cenaString.LastIndexOf("/")).Trim();
                    string nazivArtiklaa = nazivStavke.Substring(0, nazivStavke.LastIndexOf(" ")).Trim();
                    double cena_artikla = 0;
                    double broji = double.Parse(cenaString);
                    foreach (Artikal artikal in artikalManager.artikali)
                    {
                        if (artikal.Naziv.Trim() == nazivArtiklaa)
                        {
                            cena_artikla = artikal.Cena;
                            break;
                        }
                    }

                    ukupna_cena += cena_artikla * broji;

                }

                lbukupnaCena.Text = ukupna_cena.ToString("N2") + " $";

            }
            else
            {
                MessageBox.Show("The entry is not valid!");
            }


            tbRacun.Text = string.Empty;
        }

        private void tbRacun_TextChanged(object sender, EventArgs e)
        {



            if(tbRacun.Text == string.Empty)
            {
                btPonistavanje.Enabled = false;
                btUnos.Enabled = false;
                btBrojJedan.Enabled = false;
                btBrojDva.Enabled = false;
                btBrojTri.Enabled = false;
                btBrojCetiri.Enabled = false;
                btBrojPet.Enabled = false;
                btBrojSest.Enabled = false;
                btBrojSedam.Enabled = false;
                btBrojOsam.Enabled = false;
                btBrojDevet.Enabled = false;
                btBrojNula.Enabled = false;
                btMnozenje.Enabled = false;
                btZarez.Enabled = false;
            }
            else
            {
                btMnozenje.Enabled = true;
                btUnos.Enabled = true;
                btPonistavanje.Enabled = true;
            }
        }

        private void btObrisi_Click(object sender, EventArgs e)
        {
            double ukupna_cena = 0;
            if (lbUnosObrada.SelectedItem != null)
            {
                string selectedItem = lbUnosObrada.SelectedItem.ToString();
                lbUnosObrada.Items.Remove(selectedItem);

                double cena_artikla = IzracunajCenuArtikla(selectedItem);

                string labela = lbukupnaCena.Text;
                string[] delovi = labela.Split(' ');

                ukupna_cena = double.Parse(delovi[0]);
                ukupna_cena -= cena_artikla;

                lbukupnaCena.Text = ukupna_cena.ToString("N2") + " $";
                ukupna_cena = 0;
            }

            

        }

        private double IzracunajCenuArtikla(string stavka)
        {

            string nazivStavke = stavka;
            string cenaString = nazivStavke.Substring(nazivStavke.LastIndexOf("(") + 1);
            cenaString = cenaString.Substring(0, cenaString.LastIndexOf("/")).Trim();
            string nazivArtiklaa = nazivStavke.Substring(0, nazivStavke.LastIndexOf(" ")).Trim();
            double cena_artikla = 0;
            double broji = double.Parse(cenaString);
            foreach (Artikal artikal in artikalManager.artikali)
            {
                if (artikal.Naziv.Trim() == nazivArtiklaa)
                {
                    cena_artikla = artikal.Cena;
                    break;
                }
            }

            return cena_artikla * broji;

        }

        private void btDaljaObrada_Click(object sender, EventArgs e)
        {
            
            if (lbUnosObrada.Items.Count == 0)
            {
                MessageBox.Show("ListBox is empty. Add items before pressing the button.");
                return;
            }


            StringBuilder sb = new StringBuilder();
            foreach (var stavka in lbUnosObrada.Items)
            {
                string naziv_stavke = stavka.ToString();
                double cena_artikla = IzracunajCenuArtikla(naziv_stavke);
                string nazivArtiklaa = naziv_stavke.Substring(0, naziv_stavke.LastIndexOf(" ")).Trim();
                string ceo = nazivArtiklaa + " " + cena_artikla;
                sb.AppendLine(ceo);
            }
            sb.AppendLine("------------------------------------");
            sb.AppendLine(lbukupnaCena.Text);
               
            tbFiskalniRacun.Text = sb.ToString();
            proba = true;
            tbCeo.SelectedTab = tabFiskalniRacun;

        }

        private void btSacuvajRacun_Click(object sender, EventArgs e)
        {
            
            foreach (var stavka in lbUnosObrada.Items)
            {
                string naziv_stavke = stavka.ToString();
                string nazivArtikla = naziv_stavke.Substring(0, naziv_stavke.LastIndexOf(" ")).Trim();
                string cenaString = naziv_stavke.Substring(naziv_stavke.LastIndexOf("(") + 1);
                cenaString = cenaString.Substring(0, cenaString.LastIndexOf("/")).Trim();

                Racun stavkaRacuna = new Racun
                {
                    Naziv = nazivArtikla,
                    Kolicina = Double.Parse(cenaString),
                    datum = DateTime.Now.ToString("yyyy-MM-dd")
                    
                };

                racunManager.stavkeRacuna.Add(stavkaRacuna);


            }


            racunManager.SacuvajRacun();
            MessageBox.Show("The bill have been saved to file successfully!");

            tbFiskalniRacun.Text = string.Empty;
            tbUnosObrada.Show();
            tbCeo.SelectTab(0);
            lbUnosObrada.Items.Clear();
            lbukupnaCena.Text = "0,00 $";
            tbRacun.Text = string.Empty;
            

        }

        private void tbTransakcija_Click(object sender, EventArgs e)
        {
            lbUnosObrada.Items.Clear();
            lbukupnaCena.Text = "0.00 $";
            tbRacun.Text = string.Empty;
            trArtikli.Controls.Clear();
            tbFiskalniRacun.Text = string.Empty;
            tbUnosObrada.Show();
        }

        private void lbUnosObrada_SelectedIndexChanged(object sender, EventArgs e)
        {
            btDaljaObrada.Enabled = true;
        }



        public void SetSerbianLang()
        {
            this.Text = "Prodaja/Naplata";
            tbTransakcija.Text = "Nova Transakcija";
            tbUnosObrada.Text = "Unos/Obrada";
            tbFiskalniRacun.Text = "Fiskalni račun";
            btObrisi.Text = "Obriši";
            btDaljaObrada.Text = "Dalje =>";
            btUnos.Text = "Unesi";
            btPonistavanje.Text = "Poništi";
            btSacuvajRacun.Text = "Sačuvaj račun";
        }

        public void SetEnglishLang()
        {
            this.Text = "Selling/Billing";
            tbTransakcija.Text = "New Transaction";
            tbUnosObrada.Text = "Input/Processing";
            tabFiskalniRacun.Text = "Fiscal Bill";
            btObrisi.Text = "Delete";
            btDaljaObrada.Text = "Continue =>";
            btUnos.Text = "Input";
            btPonistavanje.Text = "Cancel input";
            btSacuvajRacun.Text = "Save the reciept";
        }

        private void tbCeo_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (e.TabPage == tbCeo.TabPages[1])
            {
                e.Cancel = true;
            }
            if(proba == true)
            {
                e.Cancel = false;
                proba = false;
            }
        }

        private void tbCitac_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
