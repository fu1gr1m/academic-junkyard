namespace WindowsFormsProjekat
{
    partial class AdministracijaIStatistika
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabAzuriranjeKat = new System.Windows.Forms.TabPage();
            this.ObrisiKat = new System.Windows.Forms.Button();
            this.IzmeniKat = new System.Windows.Forms.Button();
            this.DodajKat = new System.Windows.Forms.Button();
            this.nazivKategorije = new System.Windows.Forms.Label();
            this.tbNaziv = new System.Windows.Forms.TextBox();
            this.AKlistbox = new System.Windows.Forms.ListBox();
            this.tabAzuriranjeArt = new System.Windows.Forms.TabPage();
            this.AAbtObrisiartikal = new System.Windows.Forms.Button();
            this.AAbtIzmeniArtikal = new System.Windows.Forms.Button();
            this.AAbtDodajArtikal = new System.Windows.Forms.Button();
            this.AAJedinicaMere = new System.Windows.Forms.Label();
            this.tbJMArtikla = new System.Windows.Forms.TextBox();
            this.AACenaArtikla = new System.Windows.Forms.Label();
            this.tbCenaArtikla = new System.Windows.Forms.TextBox();
            this.tbNazivArtikla = new System.Windows.Forms.TextBox();
            this.AALabelNaziva = new System.Windows.Forms.Label();
            this.AAlabelKategorije = new System.Windows.Forms.Label();
            this.cbKategorija = new System.Windows.Forms.ComboBox();
            this.AAlistbox = new System.Windows.Forms.ListBox();
            this.tabPregledStat = new System.Windows.Forms.TabPage();
            this.PrikaziStatistiku = new System.Windows.Forms.DateTimePicker();
            this.tabControl1.SuspendLayout();
            this.tabAzuriranjeKat.SuspendLayout();
            this.tabAzuriranjeArt.SuspendLayout();
            this.tabPregledStat.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabAzuriranjeKat);
            this.tabControl1.Controls.Add(this.tabAzuriranjeArt);
            this.tabControl1.Controls.Add(this.tabPregledStat);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(840, 471);
            this.tabControl1.TabIndex = 0;
            // 
            // tabAzuriranjeKat
            // 
            this.tabAzuriranjeKat.Controls.Add(this.ObrisiKat);
            this.tabAzuriranjeKat.Controls.Add(this.IzmeniKat);
            this.tabAzuriranjeKat.Controls.Add(this.DodajKat);
            this.tabAzuriranjeKat.Controls.Add(this.nazivKategorije);
            this.tabAzuriranjeKat.Controls.Add(this.tbNaziv);
            this.tabAzuriranjeKat.Controls.Add(this.AKlistbox);
            this.tabAzuriranjeKat.Location = new System.Drawing.Point(4, 22);
            this.tabAzuriranjeKat.Name = "tabAzuriranjeKat";
            this.tabAzuriranjeKat.Padding = new System.Windows.Forms.Padding(3);
            this.tabAzuriranjeKat.Size = new System.Drawing.Size(832, 445);
            this.tabAzuriranjeKat.TabIndex = 0;
            this.tabAzuriranjeKat.Text = "Ažuriranje kategorija";
            this.tabAzuriranjeKat.UseVisualStyleBackColor = true;
            this.tabAzuriranjeKat.Click += new System.EventHandler(this.tabPage1_Click);
            // 
            // ObrisiKat
            // 
            this.ObrisiKat.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ObrisiKat.Location = new System.Drawing.Point(8, 312);
            this.ObrisiKat.Name = "ObrisiKat";
            this.ObrisiKat.Size = new System.Drawing.Size(542, 40);
            this.ObrisiKat.TabIndex = 5;
            this.ObrisiKat.Text = "Obriši kategoriju";
            this.ObrisiKat.UseVisualStyleBackColor = true;
            this.ObrisiKat.Click += new System.EventHandler(this.ObrisiKat_Click);
            // 
            // IzmeniKat
            // 
            this.IzmeniKat.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IzmeniKat.Location = new System.Drawing.Point(8, 257);
            this.IzmeniKat.Name = "IzmeniKat";
            this.IzmeniKat.Size = new System.Drawing.Size(542, 40);
            this.IzmeniKat.TabIndex = 4;
            this.IzmeniKat.Text = "Izmeni kategoriju";
            this.IzmeniKat.UseVisualStyleBackColor = true;
            this.IzmeniKat.Click += new System.EventHandler(this.IzmeniKat_Click);
            // 
            // DodajKat
            // 
            this.DodajKat.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DodajKat.Location = new System.Drawing.Point(8, 202);
            this.DodajKat.Name = "DodajKat";
            this.DodajKat.Size = new System.Drawing.Size(542, 40);
            this.DodajKat.TabIndex = 3;
            this.DodajKat.Text = "Dodaj kategoriju";
            this.DodajKat.UseVisualStyleBackColor = true;
            this.DodajKat.Click += new System.EventHandler(this.DodajKat_Click);
            // 
            // nazivKategorije
            // 
            this.nazivKategorije.AutoSize = true;
            this.nazivKategorije.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.nazivKategorije.Location = new System.Drawing.Point(6, 132);
            this.nazivKategorije.Name = "nazivKategorije";
            this.nazivKategorije.Size = new System.Drawing.Size(111, 19);
            this.nazivKategorije.TabIndex = 2;
            this.nazivKategorije.Text = "Naziv kategorije:";
            // 
            // tbNaziv
            // 
            this.tbNaziv.Location = new System.Drawing.Point(8, 154);
            this.tbNaziv.Name = "tbNaziv";
            this.tbNaziv.Size = new System.Drawing.Size(542, 20);
            this.tbNaziv.TabIndex = 1;
            this.tbNaziv.TextChanged += new System.EventHandler(this.tbNaziv_TextChanged);
            // 
            // AKlistbox
            // 
            this.AKlistbox.FormattingEnabled = true;
            this.AKlistbox.Location = new System.Drawing.Point(556, 6);
            this.AKlistbox.Name = "AKlistbox";
            this.AKlistbox.Size = new System.Drawing.Size(268, 433);
            this.AKlistbox.TabIndex = 0;
            this.AKlistbox.SelectedIndexChanged += new System.EventHandler(this.AKlistbox_SelectedIndexChanged);
            // 
            // tabAzuriranjeArt
            // 
            this.tabAzuriranjeArt.Controls.Add(this.AAbtObrisiartikal);
            this.tabAzuriranjeArt.Controls.Add(this.AAbtIzmeniArtikal);
            this.tabAzuriranjeArt.Controls.Add(this.AAbtDodajArtikal);
            this.tabAzuriranjeArt.Controls.Add(this.AAJedinicaMere);
            this.tabAzuriranjeArt.Controls.Add(this.tbJMArtikla);
            this.tabAzuriranjeArt.Controls.Add(this.AACenaArtikla);
            this.tabAzuriranjeArt.Controls.Add(this.tbCenaArtikla);
            this.tabAzuriranjeArt.Controls.Add(this.tbNazivArtikla);
            this.tabAzuriranjeArt.Controls.Add(this.AALabelNaziva);
            this.tabAzuriranjeArt.Controls.Add(this.AAlabelKategorije);
            this.tabAzuriranjeArt.Controls.Add(this.cbKategorija);
            this.tabAzuriranjeArt.Controls.Add(this.AAlistbox);
            this.tabAzuriranjeArt.Location = new System.Drawing.Point(4, 22);
            this.tabAzuriranjeArt.Name = "tabAzuriranjeArt";
            this.tabAzuriranjeArt.Padding = new System.Windows.Forms.Padding(3);
            this.tabAzuriranjeArt.Size = new System.Drawing.Size(832, 445);
            this.tabAzuriranjeArt.TabIndex = 1;
            this.tabAzuriranjeArt.Text = "Ažuriranje artikala";
            this.tabAzuriranjeArt.UseVisualStyleBackColor = true;
            // 
            // AAbtObrisiartikal
            // 
            this.AAbtObrisiartikal.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AAbtObrisiartikal.Location = new System.Drawing.Point(8, 399);
            this.AAbtObrisiartikal.Name = "AAbtObrisiartikal";
            this.AAbtObrisiartikal.Size = new System.Drawing.Size(392, 40);
            this.AAbtObrisiartikal.TabIndex = 12;
            this.AAbtObrisiartikal.Text = "Obriši artikal";
            this.AAbtObrisiartikal.UseVisualStyleBackColor = true;
            this.AAbtObrisiartikal.Click += new System.EventHandler(this.AAbtObrisiartikal_Click);
            // 
            // AAbtIzmeniArtikal
            // 
            this.AAbtIzmeniArtikal.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AAbtIzmeniArtikal.Location = new System.Drawing.Point(8, 353);
            this.AAbtIzmeniArtikal.Name = "AAbtIzmeniArtikal";
            this.AAbtIzmeniArtikal.Size = new System.Drawing.Size(392, 40);
            this.AAbtIzmeniArtikal.TabIndex = 11;
            this.AAbtIzmeniArtikal.Text = "Izmeni artikal";
            this.AAbtIzmeniArtikal.UseVisualStyleBackColor = true;
            this.AAbtIzmeniArtikal.Click += new System.EventHandler(this.AAbtIzmeniArtikal_Click);
            // 
            // AAbtDodajArtikal
            // 
            this.AAbtDodajArtikal.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AAbtDodajArtikal.Location = new System.Drawing.Point(8, 307);
            this.AAbtDodajArtikal.Name = "AAbtDodajArtikal";
            this.AAbtDodajArtikal.Size = new System.Drawing.Size(392, 40);
            this.AAbtDodajArtikal.TabIndex = 10;
            this.AAbtDodajArtikal.Text = "Dodaj artikal";
            this.AAbtDodajArtikal.UseVisualStyleBackColor = true;
            this.AAbtDodajArtikal.Click += new System.EventHandler(this.AAbtDodajArtikal_Click);
            // 
            // AAJedinicaMere
            // 
            this.AAJedinicaMere.AutoSize = true;
            this.AAJedinicaMere.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.AAJedinicaMere.Location = new System.Drawing.Point(8, 239);
            this.AAJedinicaMere.Name = "AAJedinicaMere";
            this.AAJedinicaMere.Size = new System.Drawing.Size(135, 19);
            this.AAJedinicaMere.TabIndex = 9;
            this.AAJedinicaMere.Text = "Jedinica mere artikla:";
            // 
            // tbJMArtikla
            // 
            this.tbJMArtikla.Location = new System.Drawing.Point(8, 261);
            this.tbJMArtikla.Name = "tbJMArtikla";
            this.tbJMArtikla.Size = new System.Drawing.Size(392, 20);
            this.tbJMArtikla.TabIndex = 8;
            // 
            // AACenaArtikla
            // 
            this.AACenaArtikla.AutoSize = true;
            this.AACenaArtikla.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.AACenaArtikla.Location = new System.Drawing.Point(8, 170);
            this.AACenaArtikla.Name = "AACenaArtikla";
            this.AACenaArtikla.Size = new System.Drawing.Size(85, 19);
            this.AACenaArtikla.TabIndex = 7;
            this.AACenaArtikla.Text = "Cena artikla:";
            // 
            // tbCenaArtikla
            // 
            this.tbCenaArtikla.Location = new System.Drawing.Point(8, 192);
            this.tbCenaArtikla.Name = "tbCenaArtikla";
            this.tbCenaArtikla.Size = new System.Drawing.Size(392, 20);
            this.tbCenaArtikla.TabIndex = 6;
            // 
            // tbNazivArtikla
            // 
            this.tbNazivArtikla.Location = new System.Drawing.Point(8, 119);
            this.tbNazivArtikla.Name = "tbNazivArtikla";
            this.tbNazivArtikla.Size = new System.Drawing.Size(392, 20);
            this.tbNazivArtikla.TabIndex = 5;
            this.tbNazivArtikla.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // AALabelNaziva
            // 
            this.AALabelNaziva.AutoSize = true;
            this.AALabelNaziva.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.AALabelNaziva.Location = new System.Drawing.Point(6, 97);
            this.AALabelNaziva.Name = "AALabelNaziva";
            this.AALabelNaziva.Size = new System.Drawing.Size(91, 19);
            this.AALabelNaziva.TabIndex = 4;
            this.AALabelNaziva.Text = "Naziv Artikla:";
            // 
            // AAlabelKategorije
            // 
            this.AAlabelKategorije.AutoSize = true;
            this.AAlabelKategorije.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.AAlabelKategorije.Location = new System.Drawing.Point(8, 23);
            this.AAlabelKategorije.Name = "AAlabelKategorije";
            this.AAlabelKategorije.Size = new System.Drawing.Size(76, 19);
            this.AAlabelKategorije.TabIndex = 3;
            this.AAlabelKategorije.Text = "Kategorija:";
            // 
            // cbKategorija
            // 
            this.cbKategorija.FormattingEnabled = true;
            this.cbKategorija.Location = new System.Drawing.Point(8, 45);
            this.cbKategorija.Name = "cbKategorija";
            this.cbKategorija.Size = new System.Drawing.Size(392, 21);
            this.cbKategorija.TabIndex = 1;
            this.cbKategorija.SelectedIndexChanged += new System.EventHandler(this.cbKategorija_SelectedIndexChanged);
            // 
            // AAlistbox
            // 
            this.AAlistbox.FormattingEnabled = true;
            this.AAlistbox.Location = new System.Drawing.Point(406, 6);
            this.AAlistbox.Name = "AAlistbox";
            this.AAlistbox.Size = new System.Drawing.Size(420, 433);
            this.AAlistbox.TabIndex = 0;
            this.AAlistbox.SelectedIndexChanged += new System.EventHandler(this.AAlistbox_SelectedIndexChanged);
            // 
            // tabPregledStat
            // 
            this.tabPregledStat.Controls.Add(this.PrikaziStatistiku);
            this.tabPregledStat.Location = new System.Drawing.Point(4, 22);
            this.tabPregledStat.Name = "tabPregledStat";
            this.tabPregledStat.Padding = new System.Windows.Forms.Padding(3);
            this.tabPregledStat.Size = new System.Drawing.Size(832, 445);
            this.tabPregledStat.TabIndex = 2;
            this.tabPregledStat.Text = "Pregled Statistike";
            this.tabPregledStat.UseVisualStyleBackColor = true;
            // 
            // PrikaziStatistiku
            // 
            this.PrikaziStatistiku.Location = new System.Drawing.Point(329, 29);
            this.PrikaziStatistiku.Name = "PrikaziStatistiku";
            this.PrikaziStatistiku.Size = new System.Drawing.Size(182, 20);
            this.PrikaziStatistiku.TabIndex = 0;
            this.PrikaziStatistiku.ValueChanged += new System.EventHandler(this.PrikaziStatistiku_ValueChanged);
            // 
            // AdministracijaIStatistika
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(840, 471);
            this.Controls.Add(this.tabControl1);
            this.Name = "AdministracijaIStatistika";
            this.Text = "AdministracijaIStatistika";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AdministracijaIStatistika_FormClosing);
            this.Load += new System.EventHandler(this.AdministracijaIStatistika_Load_1);
            this.tabControl1.ResumeLayout(false);
            this.tabAzuriranjeKat.ResumeLayout(false);
            this.tabAzuriranjeKat.PerformLayout();
            this.tabAzuriranjeArt.ResumeLayout(false);
            this.tabAzuriranjeArt.PerformLayout();
            this.tabPregledStat.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.ListBox AKlistbox;
        private System.Windows.Forms.ListBox AAlistbox;
        private System.Windows.Forms.TextBox tbJMArtikla;
        private System.Windows.Forms.TextBox tbCenaArtikla;
        private System.Windows.Forms.TextBox tbNazivArtikla;
        public System.Windows.Forms.TabPage tabAzuriranjeKat;
        public System.Windows.Forms.TabPage tabAzuriranjeArt;
        public System.Windows.Forms.TextBox tbNaziv;
        public System.Windows.Forms.ComboBox cbKategorija;
        public System.Windows.Forms.DateTimePicker PrikaziStatistiku;
        public System.Windows.Forms.TabPage tabPregledStat;
        public System.Windows.Forms.Label nazivKategorije;
        public System.Windows.Forms.Button ObrisiKat;
        public System.Windows.Forms.Button IzmeniKat;
        public System.Windows.Forms.Button DodajKat;
        public System.Windows.Forms.Label AAlabelKategorije;
        public System.Windows.Forms.Label AAJedinicaMere;
        public System.Windows.Forms.Label AACenaArtikla;
        public System.Windows.Forms.Label AALabelNaziva;
        public System.Windows.Forms.Button AAbtObrisiartikal;
        public System.Windows.Forms.Button AAbtIzmeniArtikal;
        public System.Windows.Forms.Button AAbtDodajArtikal;
    }
}