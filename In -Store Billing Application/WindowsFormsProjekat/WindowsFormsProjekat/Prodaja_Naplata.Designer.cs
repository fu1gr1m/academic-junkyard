namespace WindowsFormsProjekat
{
    partial class Prodaja_Naplata
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
            this.trKategorija = new System.Windows.Forms.FlowLayoutPanel();
            this.tbCitac = new System.Windows.Forms.TextBox();
            this.trArtikli = new System.Windows.Forms.FlowLayoutPanel();
            this.tbTransakcija = new System.Windows.Forms.Button();
            this.tbCeo = new System.Windows.Forms.TabControl();
            this.tbUnosObrada = new System.Windows.Forms.TabPage();
            this.btObrisi = new System.Windows.Forms.Button();
            this.btDaljaObrada = new System.Windows.Forms.Button();
            this.lbukupnaCena = new System.Windows.Forms.Label();
            this.lbUnosObrada = new System.Windows.Forms.ListBox();
            this.tabFiskalniRacun = new System.Windows.Forms.TabPage();
            this.tbFiskalniRacun = new System.Windows.Forms.TextBox();
            this.btSacuvajRacun = new System.Windows.Forms.Button();
            this.btMnozenje = new System.Windows.Forms.Button();
            this.tbRacun = new System.Windows.Forms.TextBox();
            this.btBrojJedan = new System.Windows.Forms.Button();
            this.btBrojCetiri = new System.Windows.Forms.Button();
            this.btBrojSedam = new System.Windows.Forms.Button();
            this.btBrojDva = new System.Windows.Forms.Button();
            this.btBrojPet = new System.Windows.Forms.Button();
            this.btBrojOsam = new System.Windows.Forms.Button();
            this.btBrojTri = new System.Windows.Forms.Button();
            this.btBrojSest = new System.Windows.Forms.Button();
            this.btBrojDevet = new System.Windows.Forms.Button();
            this.btUnos = new System.Windows.Forms.Button();
            this.btPonistavanje = new System.Windows.Forms.Button();
            this.btBrojNula = new System.Windows.Forms.Button();
            this.btZarez = new System.Windows.Forms.Button();
            this.fileSystemWatcher1 = new System.IO.FileSystemWatcher();
            this.fileSystemWatcher2 = new System.IO.FileSystemWatcher();
            this.tbCeo.SuspendLayout();
            this.tbUnosObrada.SuspendLayout();
            this.tabFiskalniRacun.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher2)).BeginInit();
            this.SuspendLayout();
            // 
            // trKategorija
            // 
            this.trKategorija.AutoScroll = true;
            this.trKategorija.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.trKategorija.Location = new System.Drawing.Point(1, 1);
            this.trKategorija.Name = "trKategorija";
            this.trKategorija.Size = new System.Drawing.Size(496, 97);
            this.trKategorija.TabIndex = 0;
            this.trKategorija.WrapContents = false;
            // 
            // tbCitac
            // 
            this.tbCitac.Location = new System.Drawing.Point(12, 104);
            this.tbCitac.Name = "tbCitac";
            this.tbCitac.Size = new System.Drawing.Size(473, 20);
            this.tbCitac.TabIndex = 1;
            this.tbCitac.TextChanged += new System.EventHandler(this.tbCitac_TextChanged);
            // 
            // trArtikli
            // 
            this.trArtikli.AutoScroll = true;
            this.trArtikli.Location = new System.Drawing.Point(1, 130);
            this.trArtikli.Name = "trArtikli";
            this.trArtikli.Size = new System.Drawing.Size(496, 388);
            this.trArtikli.TabIndex = 2;
            // 
            // tbTransakcija
            // 
            this.tbTransakcija.BackColor = System.Drawing.Color.Transparent;
            this.tbTransakcija.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.tbTransakcija.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.tbTransakcija.Location = new System.Drawing.Point(503, 1);
            this.tbTransakcija.Name = "tbTransakcija";
            this.tbTransakcija.Size = new System.Drawing.Size(168, 48);
            this.tbTransakcija.TabIndex = 3;
            this.tbTransakcija.Text = "Nova Transakcija";
            this.tbTransakcija.UseVisualStyleBackColor = false;
            this.tbTransakcija.Click += new System.EventHandler(this.tbTransakcija_Click);
            // 
            // tbCeo
            // 
            this.tbCeo.Controls.Add(this.tbUnosObrada);
            this.tbCeo.Controls.Add(this.tabFiskalniRacun);
            this.tbCeo.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.tbCeo.Location = new System.Drawing.Point(503, 55);
            this.tbCeo.Name = "tbCeo";
            this.tbCeo.SelectedIndex = 0;
            this.tbCeo.Size = new System.Drawing.Size(295, 186);
            this.tbCeo.TabIndex = 4;
            this.tbCeo.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this.tbCeo_Selecting);
            // 
            // tbUnosObrada
            // 
            this.tbUnosObrada.Controls.Add(this.btObrisi);
            this.tbUnosObrada.Controls.Add(this.btDaljaObrada);
            this.tbUnosObrada.Controls.Add(this.lbukupnaCena);
            this.tbUnosObrada.Controls.Add(this.lbUnosObrada);
            this.tbUnosObrada.Location = new System.Drawing.Point(4, 28);
            this.tbUnosObrada.Name = "tbUnosObrada";
            this.tbUnosObrada.Padding = new System.Windows.Forms.Padding(3);
            this.tbUnosObrada.Size = new System.Drawing.Size(287, 154);
            this.tbUnosObrada.TabIndex = 0;
            this.tbUnosObrada.Text = "Unos/Obrada";
            this.tbUnosObrada.UseVisualStyleBackColor = true;
            // 
            // btObrisi
            // 
            this.btObrisi.BackColor = System.Drawing.Color.Transparent;
            this.btObrisi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btObrisi.Location = new System.Drawing.Point(211, 6);
            this.btObrisi.Name = "btObrisi";
            this.btObrisi.Size = new System.Drawing.Size(70, 66);
            this.btObrisi.TabIndex = 3;
            this.btObrisi.Text = "Obriši";
            this.btObrisi.UseVisualStyleBackColor = false;
            this.btObrisi.Click += new System.EventHandler(this.btObrisi_Click);
            // 
            // btDaljaObrada
            // 
            this.btDaljaObrada.BackColor = System.Drawing.Color.Transparent;
            this.btDaljaObrada.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btDaljaObrada.Location = new System.Drawing.Point(159, 108);
            this.btDaljaObrada.Name = "btDaljaObrada";
            this.btDaljaObrada.Size = new System.Drawing.Size(121, 40);
            this.btDaljaObrada.TabIndex = 2;
            this.btDaljaObrada.Text = "Dalje =>";
            this.btDaljaObrada.UseVisualStyleBackColor = false;
            this.btDaljaObrada.Click += new System.EventHandler(this.btDaljaObrada_Click);
            // 
            // lbukupnaCena
            // 
            this.lbukupnaCena.AutoSize = true;
            this.lbukupnaCena.Location = new System.Drawing.Point(6, 122);
            this.lbukupnaCena.Name = "lbukupnaCena";
            this.lbukupnaCena.Size = new System.Drawing.Size(49, 19);
            this.lbukupnaCena.TabIndex = 1;
            this.lbukupnaCena.Text = "0,00 $";
            this.lbukupnaCena.Click += new System.EventHandler(this.lbukupnaCena_Click);
            // 
            // lbUnosObrada
            // 
            this.lbUnosObrada.FormattingEnabled = true;
            this.lbUnosObrada.ItemHeight = 19;
            this.lbUnosObrada.Location = new System.Drawing.Point(6, 6);
            this.lbUnosObrada.Name = "lbUnosObrada";
            this.lbUnosObrada.Size = new System.Drawing.Size(199, 99);
            this.lbUnosObrada.TabIndex = 0;
            this.lbUnosObrada.SelectedIndexChanged += new System.EventHandler(this.lbUnosObrada_SelectedIndexChanged);
            // 
            // tabFiskalniRacun
            // 
            this.tabFiskalniRacun.Controls.Add(this.tbFiskalniRacun);
            this.tabFiskalniRacun.Controls.Add(this.btSacuvajRacun);
            this.tabFiskalniRacun.Location = new System.Drawing.Point(4, 28);
            this.tabFiskalniRacun.Name = "tabFiskalniRacun";
            this.tabFiskalniRacun.Padding = new System.Windows.Forms.Padding(3);
            this.tabFiskalniRacun.Size = new System.Drawing.Size(287, 154);
            this.tabFiskalniRacun.TabIndex = 1;
            this.tabFiskalniRacun.Text = "Fiskalni račun";
            this.tabFiskalniRacun.UseVisualStyleBackColor = true;
            // 
            // tbFiskalniRacun
            // 
            this.tbFiskalniRacun.Font = new System.Drawing.Font("Times New Roman", 8F);
            this.tbFiskalniRacun.Location = new System.Drawing.Point(6, 6);
            this.tbFiskalniRacun.Multiline = true;
            this.tbFiskalniRacun.Name = "tbFiskalniRacun";
            this.tbFiskalniRacun.ReadOnly = true;
            this.tbFiskalniRacun.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbFiskalniRacun.Size = new System.Drawing.Size(173, 142);
            this.tbFiskalniRacun.TabIndex = 2;
            // 
            // btSacuvajRacun
            // 
            this.btSacuvajRacun.Location = new System.Drawing.Point(185, 32);
            this.btSacuvajRacun.Name = "btSacuvajRacun";
            this.btSacuvajRacun.Size = new System.Drawing.Size(95, 84);
            this.btSacuvajRacun.TabIndex = 1;
            this.btSacuvajRacun.Text = "Sačuvaj račun";
            this.btSacuvajRacun.UseVisualStyleBackColor = true;
            this.btSacuvajRacun.Click += new System.EventHandler(this.btSacuvajRacun_Click);
            // 
            // btMnozenje
            // 
            this.btMnozenje.BackColor = System.Drawing.Color.Transparent;
            this.btMnozenje.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btMnozenje.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.btMnozenje.Location = new System.Drawing.Point(503, 269);
            this.btMnozenje.Name = "btMnozenje";
            this.btMnozenje.Size = new System.Drawing.Size(45, 45);
            this.btMnozenje.TabIndex = 5;
            this.btMnozenje.Text = "X";
            this.btMnozenje.UseVisualStyleBackColor = false;
            this.btMnozenje.Click += new System.EventHandler(this.btMnozenje_Click);
            // 
            // tbRacun
            // 
            this.tbRacun.Location = new System.Drawing.Point(503, 243);
            this.tbRacun.Name = "tbRacun";
            this.tbRacun.ReadOnly = true;
            this.tbRacun.Size = new System.Drawing.Size(291, 20);
            this.tbRacun.TabIndex = 6;
            this.tbRacun.TextChanged += new System.EventHandler(this.tbRacun_TextChanged);
            // 
            // btBrojJedan
            // 
            this.btBrojJedan.BackColor = System.Drawing.Color.Transparent;
            this.btBrojJedan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btBrojJedan.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.btBrojJedan.Location = new System.Drawing.Point(503, 320);
            this.btBrojJedan.Name = "btBrojJedan";
            this.btBrojJedan.Size = new System.Drawing.Size(45, 45);
            this.btBrojJedan.TabIndex = 7;
            this.btBrojJedan.Text = "1";
            this.btBrojJedan.UseVisualStyleBackColor = false;
            this.btBrojJedan.Click += new System.EventHandler(this.Dugme_Broj_Click);
            // 
            // btBrojCetiri
            // 
            this.btBrojCetiri.BackColor = System.Drawing.Color.Transparent;
            this.btBrojCetiri.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btBrojCetiri.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.btBrojCetiri.Location = new System.Drawing.Point(503, 371);
            this.btBrojCetiri.Name = "btBrojCetiri";
            this.btBrojCetiri.Size = new System.Drawing.Size(45, 45);
            this.btBrojCetiri.TabIndex = 8;
            this.btBrojCetiri.Text = "4";
            this.btBrojCetiri.UseVisualStyleBackColor = false;
            this.btBrojCetiri.Click += new System.EventHandler(this.Dugme_Broj_Click);
            // 
            // btBrojSedam
            // 
            this.btBrojSedam.BackColor = System.Drawing.Color.Transparent;
            this.btBrojSedam.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btBrojSedam.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.btBrojSedam.Location = new System.Drawing.Point(503, 422);
            this.btBrojSedam.Name = "btBrojSedam";
            this.btBrojSedam.Size = new System.Drawing.Size(45, 45);
            this.btBrojSedam.TabIndex = 9;
            this.btBrojSedam.Text = "7";
            this.btBrojSedam.UseVisualStyleBackColor = false;
            this.btBrojSedam.Click += new System.EventHandler(this.Dugme_Broj_Click);
            // 
            // btBrojDva
            // 
            this.btBrojDva.BackColor = System.Drawing.Color.Transparent;
            this.btBrojDva.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btBrojDva.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.btBrojDva.Location = new System.Drawing.Point(554, 320);
            this.btBrojDva.Name = "btBrojDva";
            this.btBrojDva.Size = new System.Drawing.Size(45, 45);
            this.btBrojDva.TabIndex = 10;
            this.btBrojDva.Text = "2";
            this.btBrojDva.UseVisualStyleBackColor = false;
            this.btBrojDva.Click += new System.EventHandler(this.Dugme_Broj_Click);
            // 
            // btBrojPet
            // 
            this.btBrojPet.BackColor = System.Drawing.Color.Transparent;
            this.btBrojPet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btBrojPet.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.btBrojPet.Location = new System.Drawing.Point(554, 371);
            this.btBrojPet.Name = "btBrojPet";
            this.btBrojPet.Size = new System.Drawing.Size(45, 45);
            this.btBrojPet.TabIndex = 11;
            this.btBrojPet.Text = "5";
            this.btBrojPet.UseVisualStyleBackColor = false;
            this.btBrojPet.Click += new System.EventHandler(this.Dugme_Broj_Click);
            // 
            // btBrojOsam
            // 
            this.btBrojOsam.BackColor = System.Drawing.Color.Transparent;
            this.btBrojOsam.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btBrojOsam.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.btBrojOsam.Location = new System.Drawing.Point(554, 422);
            this.btBrojOsam.Name = "btBrojOsam";
            this.btBrojOsam.Size = new System.Drawing.Size(45, 45);
            this.btBrojOsam.TabIndex = 12;
            this.btBrojOsam.Text = "8";
            this.btBrojOsam.UseVisualStyleBackColor = false;
            this.btBrojOsam.Click += new System.EventHandler(this.Dugme_Broj_Click);
            // 
            // btBrojTri
            // 
            this.btBrojTri.BackColor = System.Drawing.Color.Transparent;
            this.btBrojTri.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btBrojTri.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.btBrojTri.Location = new System.Drawing.Point(605, 320);
            this.btBrojTri.Name = "btBrojTri";
            this.btBrojTri.Size = new System.Drawing.Size(45, 45);
            this.btBrojTri.TabIndex = 13;
            this.btBrojTri.Text = "3";
            this.btBrojTri.UseVisualStyleBackColor = false;
            this.btBrojTri.Click += new System.EventHandler(this.Dugme_Broj_Click);
            // 
            // btBrojSest
            // 
            this.btBrojSest.BackColor = System.Drawing.Color.Transparent;
            this.btBrojSest.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btBrojSest.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.btBrojSest.Location = new System.Drawing.Point(605, 371);
            this.btBrojSest.Name = "btBrojSest";
            this.btBrojSest.Size = new System.Drawing.Size(45, 45);
            this.btBrojSest.TabIndex = 14;
            this.btBrojSest.Text = "6";
            this.btBrojSest.UseVisualStyleBackColor = false;
            this.btBrojSest.Click += new System.EventHandler(this.Dugme_Broj_Click);
            // 
            // btBrojDevet
            // 
            this.btBrojDevet.BackColor = System.Drawing.Color.Transparent;
            this.btBrojDevet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btBrojDevet.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.btBrojDevet.Location = new System.Drawing.Point(605, 422);
            this.btBrojDevet.Name = "btBrojDevet";
            this.btBrojDevet.Size = new System.Drawing.Size(45, 45);
            this.btBrojDevet.TabIndex = 15;
            this.btBrojDevet.Text = "9";
            this.btBrojDevet.UseVisualStyleBackColor = false;
            this.btBrojDevet.Click += new System.EventHandler(this.Dugme_Broj_Click);
            // 
            // btUnos
            // 
            this.btUnos.BackColor = System.Drawing.Color.Transparent;
            this.btUnos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btUnos.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.btUnos.Location = new System.Drawing.Point(656, 320);
            this.btUnos.Name = "btUnos";
            this.btUnos.Size = new System.Drawing.Size(138, 45);
            this.btUnos.TabIndex = 16;
            this.btUnos.Text = "Unesi";
            this.btUnos.UseVisualStyleBackColor = false;
            this.btUnos.Click += new System.EventHandler(this.btUnos_Click);
            // 
            // btPonistavanje
            // 
            this.btPonistavanje.BackColor = System.Drawing.Color.Transparent;
            this.btPonistavanje.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btPonistavanje.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.btPonistavanje.Location = new System.Drawing.Point(656, 371);
            this.btPonistavanje.Name = "btPonistavanje";
            this.btPonistavanje.Size = new System.Drawing.Size(138, 45);
            this.btPonistavanje.TabIndex = 17;
            this.btPonistavanje.Text = "Poništi";
            this.btPonistavanje.UseVisualStyleBackColor = false;
            this.btPonistavanje.Click += new System.EventHandler(this.btPonistavanje_Click);
            // 
            // btBrojNula
            // 
            this.btBrojNula.BackColor = System.Drawing.Color.Transparent;
            this.btBrojNula.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btBrojNula.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.btBrojNula.Location = new System.Drawing.Point(503, 473);
            this.btBrojNula.Name = "btBrojNula";
            this.btBrojNula.Size = new System.Drawing.Size(96, 45);
            this.btBrojNula.TabIndex = 18;
            this.btBrojNula.Text = "0";
            this.btBrojNula.UseVisualStyleBackColor = false;
            this.btBrojNula.Click += new System.EventHandler(this.Dugme_Broj_Click);
            // 
            // btZarez
            // 
            this.btZarez.BackColor = System.Drawing.Color.Transparent;
            this.btZarez.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btZarez.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.btZarez.Location = new System.Drawing.Point(605, 473);
            this.btZarez.Name = "btZarez";
            this.btZarez.Size = new System.Drawing.Size(45, 45);
            this.btZarez.TabIndex = 19;
            this.btZarez.Text = ",";
            this.btZarez.UseVisualStyleBackColor = false;
            this.btZarez.Click += new System.EventHandler(this.Dugme_Broj_Click);
            // 
            // fileSystemWatcher1
            // 
            this.fileSystemWatcher1.EnableRaisingEvents = true;
            this.fileSystemWatcher1.SynchronizingObject = this;
            // 
            // fileSystemWatcher2
            // 
            this.fileSystemWatcher2.EnableRaisingEvents = true;
            this.fileSystemWatcher2.SynchronizingObject = this;
            // 
            // Prodaja_Naplata
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(799, 523);
            this.Controls.Add(this.btZarez);
            this.Controls.Add(this.btBrojNula);
            this.Controls.Add(this.btPonistavanje);
            this.Controls.Add(this.btUnos);
            this.Controls.Add(this.btBrojDevet);
            this.Controls.Add(this.btBrojSest);
            this.Controls.Add(this.btBrojTri);
            this.Controls.Add(this.btBrojOsam);
            this.Controls.Add(this.btBrojPet);
            this.Controls.Add(this.btBrojDva);
            this.Controls.Add(this.btBrojSedam);
            this.Controls.Add(this.btBrojCetiri);
            this.Controls.Add(this.btBrojJedan);
            this.Controls.Add(this.tbRacun);
            this.Controls.Add(this.btMnozenje);
            this.Controls.Add(this.tbCeo);
            this.Controls.Add(this.tbTransakcija);
            this.Controls.Add(this.trArtikli);
            this.Controls.Add(this.tbCitac);
            this.Controls.Add(this.trKategorija);
            this.Name = "Prodaja_Naplata";
            this.Text = "Prodaja_Naplata";
            this.Load += new System.EventHandler(this.Prodaja_Naplata_Load);
            this.tbCeo.ResumeLayout(false);
            this.tbUnosObrada.ResumeLayout(false);
            this.tbUnosObrada.PerformLayout();
            this.tabFiskalniRacun.ResumeLayout(false);
            this.tabFiskalniRacun.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.FlowLayoutPanel trArtikli;
        private System.Windows.Forms.TabControl tbCeo;
        private System.Windows.Forms.ListBox lbUnosObrada;
        private System.Windows.Forms.Button btMnozenje;
        private System.Windows.Forms.TextBox tbRacun;
        private System.Windows.Forms.Button btBrojJedan;
        private System.Windows.Forms.Button btBrojCetiri;
        private System.Windows.Forms.Button btBrojSedam;
        private System.Windows.Forms.Button btBrojDva;
        private System.Windows.Forms.Button btBrojPet;
        private System.Windows.Forms.Button btBrojOsam;
        private System.Windows.Forms.Button btBrojTri;
        private System.Windows.Forms.Button btBrojSest;
        private System.Windows.Forms.Button btBrojDevet;
        private System.Windows.Forms.Button btBrojNula;
        private System.Windows.Forms.Button btZarez;
        private System.IO.FileSystemWatcher fileSystemWatcher1;
        public System.Windows.Forms.FlowLayoutPanel trKategorija;
        private System.IO.FileSystemWatcher fileSystemWatcher2;
        public System.Windows.Forms.TextBox tbFiskalniRacun;
        public System.Windows.Forms.Button tbTransakcija;
        public System.Windows.Forms.TabPage tbUnosObrada;
        public System.Windows.Forms.TabPage tabFiskalniRacun;
        public System.Windows.Forms.Button btSacuvajRacun;
        public System.Windows.Forms.Button btDaljaObrada;
        public System.Windows.Forms.Label lbukupnaCena;
        public System.Windows.Forms.Button btObrisi;
        public System.Windows.Forms.Button btUnos;
        public System.Windows.Forms.Button btPonistavanje;
        public System.Windows.Forms.TextBox tbCitac;
    }
}