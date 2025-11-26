namespace WeatherApp
{
    partial class WeatherApp
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WeatherApp));
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            btSacuvaj = new Button();
            lbTempMax = new Label();
            label9 = new Label();
            lbTempMin = new Label();
            label7 = new Label();
            lbTemp = new Label();
            label5 = new Label();
            label1 = new Label();
            pictureBox1 = new PictureBox();
            lbDetaljiValue = new Label();
            lbVremeValue = new Label();
            lbPritisak = new Label();
            label2 = new Label();
            lbBV = new Label();
            label4 = new Label();
            lbZSValue = new Label();
            lbZalazakSunca = new Label();
            lbISValue = new Label();
            lbIS = new Label();
            lbDetalji = new Label();
            lbVreme = new Label();
            btPretrazi = new Button();
            tbGrad = new TextBox();
            lbGrad = new Label();
            tabPage2 = new TabPage();
            dataGrid = new DataGridView();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGrid).BeginInit();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Location = new Point(-4, -1);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(862, 486);
            tabControl1.TabIndex = 25;
            // 
            // tabPage1
            // 
            tabPage1.BackgroundImage = (Image)resources.GetObject("tabPage1.BackgroundImage");
            tabPage1.BackgroundImageLayout = ImageLayout.Stretch;
            tabPage1.Controls.Add(btSacuvaj);
            tabPage1.Controls.Add(lbTempMax);
            tabPage1.Controls.Add(label9);
            tabPage1.Controls.Add(lbTempMin);
            tabPage1.Controls.Add(label7);
            tabPage1.Controls.Add(lbTemp);
            tabPage1.Controls.Add(label5);
            tabPage1.Controls.Add(label1);
            tabPage1.Controls.Add(pictureBox1);
            tabPage1.Controls.Add(lbDetaljiValue);
            tabPage1.Controls.Add(lbVremeValue);
            tabPage1.Controls.Add(lbPritisak);
            tabPage1.Controls.Add(label2);
            tabPage1.Controls.Add(lbBV);
            tabPage1.Controls.Add(label4);
            tabPage1.Controls.Add(lbZSValue);
            tabPage1.Controls.Add(lbZalazakSunca);
            tabPage1.Controls.Add(lbISValue);
            tabPage1.Controls.Add(lbIS);
            tabPage1.Controls.Add(lbDetalji);
            tabPage1.Controls.Add(lbVreme);
            tabPage1.Controls.Add(btPretrazi);
            tabPage1.Controls.Add(tbGrad);
            tabPage1.Controls.Add(lbGrad);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(854, 458);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Pretraga";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // btSacuvaj
            // 
            btSacuvaj.BackColor = Color.Transparent;
            btSacuvaj.FlatStyle = FlatStyle.Flat;
            btSacuvaj.Font = new Font("Arial", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            btSacuvaj.ForeColor = Color.White;
            btSacuvaj.Location = new Point(690, 129);
            btSacuvaj.Name = "btSacuvaj";
            btSacuvaj.Size = new Size(115, 40);
            btSacuvaj.TabIndex = 48;
            btSacuvaj.Text = "Sacuvaj";
            btSacuvaj.UseVisualStyleBackColor = false;
            btSacuvaj.Click += btSacuvaj_Click;
            // 
            // lbTempMax
            // 
            lbTempMax.AutoSize = true;
            lbTempMax.BackColor = Color.Transparent;
            lbTempMax.Font = new Font("Arial", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            lbTempMax.ForeColor = Color.White;
            lbTempMax.Location = new Point(732, 373);
            lbTempMax.Name = "lbTempMax";
            lbTempMax.Size = new Size(41, 22);
            lbTempMax.TabIndex = 47;
            lbTempMax.Text = "N/A";
            lbTempMax.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.BackColor = Color.Transparent;
            label9.Font = new Font("Arial", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label9.ForeColor = Color.White;
            label9.Location = new Point(608, 373);
            label9.Name = "label9";
            label9.Size = new Size(107, 22);
            label9.TabIndex = 46;
            label9.Text = "Temp. Max:";
            label9.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lbTempMin
            // 
            lbTempMin.AutoSize = true;
            lbTempMin.BackColor = Color.Transparent;
            lbTempMin.Font = new Font("Arial", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            lbTempMin.ForeColor = Color.White;
            lbTempMin.Location = new Point(732, 338);
            lbTempMin.Name = "lbTempMin";
            lbTempMin.Size = new Size(41, 22);
            lbTempMin.TabIndex = 45;
            lbTempMin.Text = "N/A";
            lbTempMin.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BackColor = Color.Transparent;
            label7.Font = new Font("Arial", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label7.ForeColor = Color.White;
            label7.Location = new Point(608, 338);
            label7.Name = "label7";
            label7.Size = new Size(102, 22);
            label7.TabIndex = 44;
            label7.Text = "Temp. Min:";
            label7.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lbTemp
            // 
            lbTemp.AutoSize = true;
            lbTemp.BackColor = Color.Transparent;
            lbTemp.Font = new Font("Arial", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            lbTemp.ForeColor = Color.White;
            lbTemp.Location = new Point(732, 303);
            lbTemp.Name = "lbTemp";
            lbTemp.Size = new Size(41, 22);
            lbTemp.TabIndex = 43;
            lbTemp.Text = "N/A";
            lbTemp.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Transparent;
            label5.Font = new Font("Arial", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label5.ForeColor = Color.White;
            label5.Location = new Point(608, 303);
            label5.Name = "label5";
            label5.Size = new Size(121, 22);
            label5.TabIndex = 42;
            label5.Text = "Temperatura:";
            label5.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Bauhaus 93", 20.25F, FontStyle.Regular, GraphicsUnit.Point);
            label1.ForeColor = Color.White;
            label1.Location = new Point(465, 51);
            label1.Name = "label1";
            label1.Size = new Size(184, 30);
            label1.TabIndex = 41;
            label1.Text = "WEATHER APP ";
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.BackgroundImage = (Image)resources.GetObject("pictureBox1.BackgroundImage");
            pictureBox1.ErrorImage = null;
            pictureBox1.Location = new Point(29, 29);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(202, 186);
            pictureBox1.TabIndex = 40;
            pictureBox1.TabStop = false;
            // 
            // lbDetaljiValue
            // 
            lbDetaljiValue.AutoSize = true;
            lbDetaljiValue.BackColor = Color.Transparent;
            lbDetaljiValue.Font = new Font("Arial", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            lbDetaljiValue.ForeColor = Color.White;
            lbDetaljiValue.Location = new Point(405, 271);
            lbDetaljiValue.Name = "lbDetaljiValue";
            lbDetaljiValue.Size = new Size(41, 22);
            lbDetaljiValue.TabIndex = 39;
            lbDetaljiValue.Text = "N/A";
            lbDetaljiValue.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lbVremeValue
            // 
            lbVremeValue.AutoSize = true;
            lbVremeValue.BackColor = Color.Transparent;
            lbVremeValue.Font = new Font("Arial", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            lbVremeValue.ForeColor = Color.White;
            lbVremeValue.Location = new Point(408, 239);
            lbVremeValue.Name = "lbVremeValue";
            lbVremeValue.Size = new Size(41, 22);
            lbVremeValue.TabIndex = 38;
            lbVremeValue.Text = "N/A";
            lbVremeValue.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lbPritisak
            // 
            lbPritisak.AutoSize = true;
            lbPritisak.BackColor = Color.Transparent;
            lbPritisak.Font = new Font("Arial", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            lbPritisak.ForeColor = Color.White;
            lbPritisak.Location = new Point(690, 273);
            lbPritisak.Name = "lbPritisak";
            lbPritisak.Size = new Size(41, 22);
            lbPritisak.TabIndex = 37;
            lbPritisak.Text = "N/A";
            lbPritisak.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Arial", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label2.ForeColor = Color.White;
            label2.Location = new Point(608, 273);
            label2.Name = "label2";
            label2.Size = new Size(76, 22);
            label2.TabIndex = 36;
            label2.Text = "Pritisak:";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lbBV
            // 
            lbBV.AutoSize = true;
            lbBV.BackColor = Color.Transparent;
            lbBV.Font = new Font("Arial", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            lbBV.ForeColor = Color.White;
            lbBV.Location = new Point(732, 238);
            lbBV.Name = "lbBV";
            lbBV.Size = new Size(41, 22);
            lbBV.TabIndex = 35;
            lbBV.Text = "N/A";
            lbBV.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Arial", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label4.ForeColor = Color.White;
            label4.Location = new Point(608, 238);
            label4.Name = "label4";
            label4.Size = new Size(113, 22);
            label4.TabIndex = 34;
            label4.Text = "Brzina vetra:";
            label4.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lbZSValue
            // 
            lbZSValue.AutoSize = true;
            lbZSValue.BackColor = Color.Transparent;
            lbZSValue.Font = new Font("Arial", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            lbZSValue.ForeColor = Color.White;
            lbZSValue.Location = new Point(475, 338);
            lbZSValue.Name = "lbZSValue";
            lbZSValue.Size = new Size(41, 22);
            lbZSValue.TabIndex = 33;
            lbZSValue.Text = "N/A";
            lbZSValue.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lbZalazakSunca
            // 
            lbZalazakSunca.AutoSize = true;
            lbZalazakSunca.BackColor = Color.Transparent;
            lbZalazakSunca.Font = new Font("Arial", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            lbZalazakSunca.ForeColor = Color.White;
            lbZalazakSunca.Location = new Point(341, 338);
            lbZalazakSunca.Name = "lbZalazakSunca";
            lbZalazakSunca.Size = new Size(134, 22);
            lbZalazakSunca.TabIndex = 32;
            lbZalazakSunca.Text = "Zalazak sunca:";
            lbZalazakSunca.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lbISValue
            // 
            lbISValue.AutoSize = true;
            lbISValue.BackColor = Color.Transparent;
            lbISValue.Font = new Font("Arial", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            lbISValue.ForeColor = Color.White;
            lbISValue.Location = new Point(465, 303);
            lbISValue.Name = "lbISValue";
            lbISValue.Size = new Size(41, 22);
            lbISValue.TabIndex = 31;
            lbISValue.Text = "N/A";
            lbISValue.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lbIS
            // 
            lbIS.AutoSize = true;
            lbIS.BackColor = Color.Transparent;
            lbIS.Font = new Font("Arial", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            lbIS.ForeColor = Color.White;
            lbIS.Location = new Point(341, 303);
            lbIS.Name = "lbIS";
            lbIS.Size = new Size(127, 22);
            lbIS.TabIndex = 30;
            lbIS.Text = "Izlazak sunca:";
            lbIS.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lbDetalji
            // 
            lbDetalji.AutoSize = true;
            lbDetalji.BackColor = Color.Transparent;
            lbDetalji.Font = new Font("Arial", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            lbDetalji.ForeColor = Color.White;
            lbDetalji.Location = new Point(341, 271);
            lbDetalji.Name = "lbDetalji";
            lbDetalji.Size = new Size(67, 22);
            lbDetalji.TabIndex = 29;
            lbDetalji.Text = "Detalji:";
            lbDetalji.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lbVreme
            // 
            lbVreme.AutoSize = true;
            lbVreme.BackColor = Color.Transparent;
            lbVreme.Font = new Font("Arial", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            lbVreme.ForeColor = Color.White;
            lbVreme.Location = new Point(341, 239);
            lbVreme.Name = "lbVreme";
            lbVreme.Size = new Size(71, 22);
            lbVreme.TabIndex = 28;
            lbVreme.Text = "Vreme:";
            // 
            // btPretrazi
            // 
            btPretrazi.BackColor = Color.Transparent;
            btPretrazi.FlatStyle = FlatStyle.Flat;
            btPretrazi.Font = new Font("Arial", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            btPretrazi.ForeColor = Color.White;
            btPretrazi.Location = new Point(569, 129);
            btPretrazi.Name = "btPretrazi";
            btPretrazi.Size = new Size(115, 40);
            btPretrazi.TabIndex = 27;
            btPretrazi.Text = "Pretrazi";
            btPretrazi.UseVisualStyleBackColor = false;
            btPretrazi.Click += btPretrazi_Click;
            // 
            // tbGrad
            // 
            tbGrad.BackColor = Color.White;
            tbGrad.Font = new Font("Arial", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            tbGrad.Location = new Point(394, 134);
            tbGrad.Name = "tbGrad";
            tbGrad.Size = new Size(163, 29);
            tbGrad.TabIndex = 26;
            // 
            // lbGrad
            // 
            lbGrad.AutoSize = true;
            lbGrad.BackColor = Color.Transparent;
            lbGrad.Font = new Font("Arial", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            lbGrad.ForeColor = Color.White;
            lbGrad.Location = new Point(341, 137);
            lbGrad.Name = "lbGrad";
            lbGrad.Size = new Size(62, 22);
            lbGrad.TabIndex = 25;
            lbGrad.Text = "Grad: ";
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(dataGrid);
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(854, 458);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "IstorijaPretrage";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // dataGrid
            // 
            dataGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGrid.Dock = DockStyle.Fill;
            dataGrid.Location = new Point(3, 3);
            dataGrid.Name = "dataGrid";
            dataGrid.RowTemplate.Height = 25;
            dataGrid.Size = new Size(848, 452);
            dataGrid.TabIndex = 0;
            // 
            // WeatherApp
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(840, 450);
            Controls.Add(tabControl1);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "WeatherApp";
            Text = "WeatherApp";
            Load += Form1_Load;
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGrid).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private Button btSacuvaj;
        private Label lbTempMax;
        private Label label9;
        private Label lbTempMin;
        private Label label7;
        private Label lbTemp;
        private Label label5;
        public Label label1;
        public PictureBox pictureBox1;
        private Label lbDetaljiValue;
        private Label lbVremeValue;
        private Label lbPritisak;
        private Label label2;
        private Label lbBV;
        private Label label4;
        private Label lbZSValue;
        private Label lbZalazakSunca;
        private Label lbISValue;
        private Label lbIS;
        private Label lbDetalji;
        private Label lbVreme;
        private Button btPretrazi;
        private TextBox tbGrad;
        private Label lbGrad;
        private DataGridView dataGrid;
    }
}