using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsProjekat
{
    public partial class PocetniEkran : Form
    {
        
        
        string IDJezik = "engleski";
        public PocetniEkran()
        {
            InitializeComponent();
            MaximizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            
        }

        private void btAdministracijaStatistika_Click(object sender, EventArgs e)
        {
            AdministracijaIStatistika admstat = new AdministracijaIStatistika();
            if(IDJezik == "engleski")
            {
                admstat.SetEnglishLang();
            }
            if(IDJezik == "srpski")
            {
                admstat.SetSerbianLang();
            }
            admstat.Show();
        }

        private void btProdaja_Naplata_Click(object sender, EventArgs e)
        {
            Prodaja_Naplata prodnap = new Prodaja_Naplata();
            if (IDJezik == "engleski")
            {
                prodnap.SetEnglishLang();
            }
            if (IDJezik == "srpski")
            {
                prodnap.SetSerbianLang();
            }
            prodnap.Show();
        }

        private void PocetniEkran_Load(object sender, EventArgs e)
        {

            IDJezik = Properties.Settings.Default.jezik;
            if(IDJezik == "engleski")
            {
                this.Text = "Application for marketplace";
                btAdministracijaStatistika.Text = "Administration/Statistics";
                btProdaja_Naplata.Text = "Selling/Billing";
            }
            if(IDJezik == "srpski")
            {
                this.Text = "Aplikacija za trgovinu";
                btAdministracijaStatistika.Text = "Administracija/Statistika";
                btProdaja_Naplata.Text = "Prodaja/Naplata";
            }
        }

        private void srb_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.jezik = "srpski";
            IDJezik = "srpski";
            this.Text = "Aplikacija za trgovinu";
            btAdministracijaStatistika.Text = "Administracija/Statistika";
            btProdaja_Naplata.Text = "Prodaja/Naplata";
            Properties.Settings.Default.Save();
        }

        private void eng_Click(object sender, EventArgs e)
        {

            Properties.Settings.Default.jezik = "engleski";
            IDJezik = "engleski";
            this.Text = "Application for marketplace";
            btAdministracijaStatistika.Text = "Administration/Statistics";
            btProdaja_Naplata.Text = "Selling/Billing";
            Properties.Settings.Default.Save();
        }

    }
}
