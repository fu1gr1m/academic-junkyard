namespace WindowsFormsProjekat
{
    partial class PocetniEkran
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
            this.btAdministracijaStatistika = new System.Windows.Forms.Button();
            this.btProdaja_Naplata = new System.Windows.Forms.Button();
            this.srb = new System.Windows.Forms.Button();
            this.eng = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btAdministracijaStatistika
            // 
            this.btAdministracijaStatistika.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.btAdministracijaStatistika.Location = new System.Drawing.Point(12, 28);
            this.btAdministracijaStatistika.Name = "btAdministracijaStatistika";
            this.btAdministracijaStatistika.Size = new System.Drawing.Size(326, 59);
            this.btAdministracijaStatistika.TabIndex = 0;
            this.btAdministracijaStatistika.Text = "Administracija/Statistika";
            this.btAdministracijaStatistika.UseVisualStyleBackColor = true;
            this.btAdministracijaStatistika.Click += new System.EventHandler(this.btAdministracijaStatistika_Click);
            // 
            // btProdaja_Naplata
            // 
            this.btProdaja_Naplata.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.btProdaja_Naplata.Location = new System.Drawing.Point(12, 93);
            this.btProdaja_Naplata.Name = "btProdaja_Naplata";
            this.btProdaja_Naplata.Size = new System.Drawing.Size(326, 59);
            this.btProdaja_Naplata.TabIndex = 1;
            this.btProdaja_Naplata.Text = "Prodaja/Naplata";
            this.btProdaja_Naplata.UseVisualStyleBackColor = true;
            this.btProdaja_Naplata.Click += new System.EventHandler(this.btProdaja_Naplata_Click);
            // 
            // srb
            // 
            this.srb.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.srb.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.srb.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.srb.Location = new System.Drawing.Point(12, 158);
            this.srb.Name = "srb";
            this.srb.Size = new System.Drawing.Size(160, 44);
            this.srb.TabIndex = 2;
            this.srb.Text = "SRB";
            this.srb.UseVisualStyleBackColor = true;
            this.srb.Click += new System.EventHandler(this.srb_Click);
            // 
            // eng
            // 
            this.eng.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.eng.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.eng.ForeColor = System.Drawing.SystemColors.WindowText;
            this.eng.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.eng.Location = new System.Drawing.Point(178, 158);
            this.eng.Name = "eng";
            this.eng.Size = new System.Drawing.Size(160, 44);
            this.eng.TabIndex = 3;
            this.eng.Text = "ENG";
            this.eng.UseVisualStyleBackColor = true;
            this.eng.Click += new System.EventHandler(this.eng_Click);
            // 
            // PocetniEkran
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(350, 214);
            this.Controls.Add(this.eng);
            this.Controls.Add(this.srb);
            this.Controls.Add(this.btProdaja_Naplata);
            this.Controls.Add(this.btAdministracijaStatistika);
            this.Name = "PocetniEkran";
            this.Text = "Aplikacija za trgovinu";
            this.Load += new System.EventHandler(this.PocetniEkran_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btAdministracijaStatistika;
        private System.Windows.Forms.Button btProdaja_Naplata;
        private System.Windows.Forms.Button srb;
        private System.Windows.Forms.Button eng;
    }
}

