namespace Sinema_Otomasyonu
{
    partial class Form1
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnsalonekle = new System.Windows.Forms.Button();
            this.ımageList1 = new System.Windows.Forms.ImageList(this.components);
            this.btnFilmEkle = new System.Windows.Forms.Button();
            this.btnSeansEkle = new System.Windows.Forms.Button();
            this.btnSeanslar = new System.Windows.Forms.Button();
            this.btnSatislar = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.comboBox6 = new System.Windows.Forms.ComboBox();
            this.comboBoxTur = new System.Windows.Forms.ComboBox();
            this.labelTur = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.button6 = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.comboBox5 = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.comboBox4 = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.button7 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Location = new System.Drawing.Point(771, 15);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(483, 367);
            this.panel1.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(17, 38);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(256, 262);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // btnsalonekle
            // 
            this.btnsalonekle.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnsalonekle.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnsalonekle.ImageIndex = 0;
            this.btnsalonekle.ImageList = this.ımageList1;
            this.btnsalonekle.Location = new System.Drawing.Point(31, 27);
            this.btnsalonekle.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnsalonekle.Name = "btnsalonekle";
            this.btnsalonekle.Size = new System.Drawing.Size(99, 75);
            this.btnsalonekle.TabIndex = 3;
            this.btnsalonekle.Text = "Salon Ekle";
            this.btnsalonekle.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnsalonekle.UseVisualStyleBackColor = false;
            this.btnsalonekle.Click += new System.EventHandler(this.btnsalonekle_Click);
            // 
            // ımageList1
            // 
            this.ımageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ımageList1.ImageStream")));
            this.ımageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.ımageList1.Images.SetKeyName(0, "3028292.png");
            this.ımageList1.Images.SetKeyName(1, "film.png");
            this.ımageList1.Images.SetKeyName(2, "seanss.png");
            this.ımageList1.Images.SetKeyName(3, "liste.png");
            this.ımageList1.Images.SetKeyName(4, "sale.png");
            this.ımageList1.Images.SetKeyName(5, "kapat.png");
            this.ımageList1.Images.SetKeyName(6, "barkod-nedir.png");
            // 
            // btnFilmEkle
            // 
            this.btnFilmEkle.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnFilmEkle.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnFilmEkle.ImageIndex = 1;
            this.btnFilmEkle.ImageList = this.ımageList1;
            this.btnFilmEkle.Location = new System.Drawing.Point(163, 27);
            this.btnFilmEkle.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnFilmEkle.Name = "btnFilmEkle";
            this.btnFilmEkle.Size = new System.Drawing.Size(85, 75);
            this.btnFilmEkle.TabIndex = 4;
            this.btnFilmEkle.Text = "Film Ekle";
            this.btnFilmEkle.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnFilmEkle.UseVisualStyleBackColor = false;
            this.btnFilmEkle.Click += new System.EventHandler(this.btnFilmEkle_Click);
            // 
            // btnSeansEkle
            // 
            this.btnSeansEkle.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnSeansEkle.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnSeansEkle.ImageIndex = 2;
            this.btnSeansEkle.ImageList = this.ımageList1;
            this.btnSeansEkle.Location = new System.Drawing.Point(276, 27);
            this.btnSeansEkle.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSeansEkle.Name = "btnSeansEkle";
            this.btnSeansEkle.Size = new System.Drawing.Size(95, 75);
            this.btnSeansEkle.TabIndex = 5;
            this.btnSeansEkle.Text = "Seans Ekle";
            this.btnSeansEkle.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSeansEkle.UseVisualStyleBackColor = false;
            this.btnSeansEkle.Click += new System.EventHandler(this.btnSeansEkle_Click);
            // 
            // btnSeanslar
            // 
            this.btnSeanslar.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnSeanslar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnSeanslar.ImageIndex = 3;
            this.btnSeanslar.ImageList = this.ımageList1;
            this.btnSeanslar.Location = new System.Drawing.Point(400, 27);
            this.btnSeanslar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSeanslar.Name = "btnSeanslar";
            this.btnSeanslar.Size = new System.Drawing.Size(85, 75);
            this.btnSeanslar.TabIndex = 6;
            this.btnSeanslar.Text = "Seanslar";
            this.btnSeanslar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSeanslar.UseVisualStyleBackColor = false;
            this.btnSeanslar.Click += new System.EventHandler(this.btnSeanslar_Click);
            // 
            // btnSatislar
            // 
            this.btnSatislar.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnSatislar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnSatislar.ImageIndex = 4;
            this.btnSatislar.ImageList = this.ımageList1;
            this.btnSatislar.Location = new System.Drawing.Point(524, 27);
            this.btnSatislar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSatislar.Name = "btnSatislar";
            this.btnSatislar.Size = new System.Drawing.Size(85, 75);
            this.btnSatislar.TabIndex = 7;
            this.btnSatislar.Text = "Satışlar";
            this.btnSatislar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSatislar.UseVisualStyleBackColor = false;
            this.btnSatislar.Click += new System.EventHandler(this.btnSatislar_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(135, 38);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(148, 26);
            this.comboBox1.Sorted = true;
            this.comboBox1.TabIndex = 8;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.textBox2);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.comboBox6);
            this.groupBox1.Controls.Add(this.comboBoxTur);
            this.groupBox1.Controls.Add(this.labelTur);
            this.groupBox1.Controls.Add(this.label17);
            this.groupBox1.Controls.Add(this.textBox5);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.comboBox3);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.textBox3);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.comboBox4);
            this.groupBox1.Controls.Add(this.comboBox2);
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.groupBox1.Location = new System.Drawing.Point(44, 143);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(292, 655);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Satış Bilgileri";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label7.Location = new System.Drawing.Point(29, 367);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(83, 54);
            this.label7.TabIndex = 17;
            this.label7.Text = "barkod \r\nnumarası \r\noluşturun:";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(135, 382);
            this.textBox2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(148, 24);
            this.textBox2.TabIndex = 30;
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(17, 426);
            this.button2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(129, 31);
            this.button2.TabIndex = 29;
            this.button2.Text = "Bileti Göster";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // comboBox6
            // 
            this.comboBox6.FormattingEnabled = true;
            this.comboBox6.Location = new System.Drawing.Point(135, 337);
            this.comboBox6.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.comboBox6.Name = "comboBox6";
            this.comboBox6.Size = new System.Drawing.Size(148, 26);
            this.comboBox6.TabIndex = 28;
            // 
            // comboBoxTur
            // 
            this.comboBoxTur.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTur.FormattingEnabled = true;
            this.comboBoxTur.Items.AddRange(new object[] {
            "Tam",
            "Öğrenci"});
            this.comboBoxTur.Location = new System.Drawing.Point(135, 300);
            this.comboBoxTur.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.comboBoxTur.Name = "comboBoxTur";
            this.comboBoxTur.Size = new System.Drawing.Size(148, 26);
            this.comboBoxTur.TabIndex = 31;
            this.comboBoxTur.SelectedIndexChanged += new System.EventHandler(this.comboBoxTur_SelectedIndexChanged);
            // 
            // labelTur
            // 
            this.labelTur.AutoSize = true;
            this.labelTur.BackColor = System.Drawing.Color.WhiteSmoke;
            this.labelTur.ForeColor = System.Drawing.SystemColors.ControlText;
            this.labelTur.Location = new System.Drawing.Point(8, 306);
            this.labelTur.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelTur.Name = "labelTur";
            this.labelTur.Size = new System.Drawing.Size(104, 18);
            this.labelTur.TabIndex = 32;
            this.labelTur.Text = "BİLET TÜRÜ";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label17.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label17.Location = new System.Drawing.Point(57, 229);
            this.label17.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(64, 18);
            this.label17.TabIndex = 27;
            this.label17.Text = "SOYAD";
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(135, 225);
            this.textBox5.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(148, 24);
            this.textBox5.TabIndex = 26;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(184, 427);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 28);
            this.button1.TabIndex = 25;
            this.button1.Text = "bilet al";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // comboBox3
            // 
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Location = new System.Drawing.Point(135, 111);
            this.comboBox3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(148, 26);
            this.comboBox3.Sorted = true;
            this.comboBox3.TabIndex = 24;
            this.comboBox3.SelectedIndexChanged += new System.EventHandler(this.comboBox3_SelectedIndexChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.button6);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.comboBox5);
            this.groupBox3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.groupBox3.Location = new System.Drawing.Point(17, 462);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox3.Size = new System.Drawing.Size(247, 176);
            this.groupBox3.TabIndex = 23;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "BİLET İPTAL";
            this.groupBox3.Enter += new System.EventHandler(this.groupBox3_Enter);
            // 
            // button6
            // 
            this.button6.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button6.Location = new System.Drawing.Point(56, 111);
            this.button6.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(119, 34);
            this.button6.TabIndex = 8;
            this.button6.Text = "Bilet İptal";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label10.Location = new System.Drawing.Point(28, 34);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(164, 18);
            this.label10.TabIndex = 10;
            this.label10.Text = "KOLTUK NUMARASI";
            // 
            // comboBox5
            // 
            this.comboBox5.FormattingEnabled = true;
            this.comboBox5.Location = new System.Drawing.Point(40, 62);
            this.comboBox5.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.comboBox5.Name = "comboBox5";
            this.comboBox5.Size = new System.Drawing.Size(161, 26);
            this.comboBox5.Sorted = true;
            this.comboBox5.TabIndex = 9;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label9.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label9.Location = new System.Drawing.Point(53, 343);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 18);
            this.label9.TabIndex = 22;
            this.label9.Text = "ÜCRET";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label8.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label8.Location = new System.Drawing.Point(13, 265);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(104, 18);
            this.label8.TabIndex = 21;
            this.label8.Text = "KOLTUK NO";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label6.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label6.Location = new System.Drawing.Point(93, 194);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(30, 18);
            this.label6.TabIndex = 19;
            this.label6.Text = "AD";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label5.Location = new System.Drawing.Point(4, 154);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(109, 18);
            this.label5.TabIndex = 18;
            this.label5.Text = "FİLM SEANSI";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label4.Location = new System.Drawing.Point(8, 114);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(102, 18);
            this.label4.TabIndex = 17;
            this.label4.Text = "FİLM TARİHİ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(55, 79);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 18);
            this.label3.TabIndex = 16;
            this.label3.Text = "SALON";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(40, 38);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 18);
            this.label2.TabIndex = 15;
            this.label2.Text = "FİLM ADI";
            // 
            // textBox3
            // 
            this.textBox3.Enabled = false;
            this.textBox3.Location = new System.Drawing.Point(135, 265);
            this.textBox3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(148, 24);
            this.textBox3.TabIndex = 13;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(135, 191);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(148, 24);
            this.textBox1.TabIndex = 3;
            // 
            // comboBox4
            // 
            this.comboBox4.FormattingEnabled = true;
            this.comboBox4.Location = new System.Drawing.Point(135, 150);
            this.comboBox4.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.comboBox4.Name = "comboBox4";
            this.comboBox4.Size = new System.Drawing.Size(148, 26);
            this.comboBox4.Sorted = true;
            this.comboBox4.TabIndex = 11;
            this.comboBox4.SelectedIndexChanged += new System.EventHandler(this.comboBox4_SelectedIndexChanged);
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(135, 75);
            this.comboBox2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(148, 26);
            this.comboBox2.Sorted = true;
            this.comboBox2.TabIndex = 9;
            this.comboBox2.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.pictureBox1);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.groupBox2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.groupBox2.Location = new System.Drawing.Point(383, 143);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Size = new System.Drawing.Size(292, 329);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Afiş";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.SlateBlue;
            this.label11.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label11.Location = new System.Drawing.Point(1287, 27);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(17, 352);
            this.label11.TabIndex = 11;
            this.label11.Text = "P\r\n\r\n\r\n\r\n\r\nE\r\n\r\n\r\n\r\n\r\nR\r\n\r\n\r\n\r\n\r\nD\r\n\r\n\r\n\r\n\r\nE\r\n\r\n";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.label12.Location = new System.Drawing.Point(767, 449);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(52, 64);
            this.label12.TabIndex = 12;
            this.label12.Text = "\r\n\r\n              \r\n               ";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.label13.Location = new System.Drawing.Point(767, 540);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(52, 64);
            this.label13.TabIndex = 13;
            this.label13.Text = "\r\n\r\n              \r\n               ";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.MediumPurple;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label14.Location = new System.Drawing.Point(875, 470);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(118, 17);
            this.label14.TabIndex = 14;
            this.label14.Text = "DOLU KOLTUK";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label15.Location = new System.Drawing.Point(875, 567);
            this.label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(107, 17);
            this.label15.TabIndex = 15;
            this.label15.Text = "BOŞ KOLTUK";
            // 
            // button7
            // 
            this.button7.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.button7.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button7.ImageIndex = 5;
            this.button7.ImageList = this.ımageList1;
            this.button7.Location = new System.Drawing.Point(1168, 678);
            this.button7.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(97, 81);
            this.button7.TabIndex = 16;
            this.button7.Text = "ÇIKIŞ";
            this.button7.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button7.UseVisualStyleBackColor = false;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button3
            // 
            this.button3.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button3.ImageIndex = 6;
            this.button3.ImageList = this.ımageList1;
            this.button3.Location = new System.Drawing.Point(1063, 678);
            this.button3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(97, 82);
            this.button3.TabIndex = 17;
            this.button3.Text = "Barkod Tarat";
            this.button3.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Sinema_Otomasyonu.Properties.Resources.film_movie_background_clapperboard_film_840191;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1323, 812);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnSatislar);
            this.Controls.Add(this.btnSeanslar);
            this.Controls.Add(this.btnSeansEkle);
            this.Controls.Add(this.btnFilmEkle);
            this.Controls.Add(this.btnsalonekle);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ana Sayfa";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnsalonekle;
        private System.Windows.Forms.Button btnFilmEkle;
        private System.Windows.Forms.Button btnSeansEkle;
        private System.Windows.Forms.Button btnSeanslar;
        private System.Windows.Forms.Button btnSatislar;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ComboBox comboBox4;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox comboBox5;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.ImageList ımageList1;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.ComboBox comboBox6;
        private System.Windows.Forms.ComboBox comboBoxTur;
        private System.Windows.Forms.Label labelTur;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button button3;
    }
}

