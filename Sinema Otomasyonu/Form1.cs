using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sinema_Otomasyonu
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
       
        SqlConnection baglanti = new SqlConnection(Class1.sqlconnection);

        private void btnsalonekle_Click(object sender, EventArgs e)
        {
            Form3 ekle = new Form3();
            ekle.Show();
            this.Hide();
        }

        private void btnFilmEkle_Click(object sender, EventArgs e)
        {

            Form2 ekle = new Form2();
            ekle.Show();
            this.Hide();
        }

        private void btnSeansEkle_Click(object sender, EventArgs e)
        {
            Form4 ekle = new Form4();
            ekle.Show();
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        int sayac = 0;
        private void FilmveSalonGetir(ComboBox combo,string sql1,string sql2)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand(sql1, baglanti);
            SqlDataReader read = komut.ExecuteReader();
            while (read.Read())
            {
                combo.Items.Add(read[sql2].ToString());

            }
            baglanti.Close();
        }

        private void filmAfişiGoster()
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select *from film_bilgileri where filmadi='" + comboBox1.SelectedItem + "'", baglanti);
            SqlDataReader read = komut.ExecuteReader();
            while (read.Read())
            {
                pictureBox1.ImageLocation = VeriTabani.AfisYolu(read["resim"].ToString());
            }
            baglanti.Close();
        }

        private void YenidenRenklendir()
        {
            foreach (Control item in panel1.Controls) 
            {
                if (item is Button)
                {
                    item.BackColor = Color.White;
                }
            }
        }
      
        private void combo_dolu_koltuklar()
        {
            comboBox5.Items.Clear();
            comboBox5.Text = "";
            foreach (Control item in panel1.Controls)
            {
                if (item is Button)
                {
                    if (item.BackColor==Color.DarkSlateBlue)
                    {
                        comboBox5.Items.Add(item.Text);
                    }
                }
            }
        }
        private void Veritabani_Dolu_Koltuklar()
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select *from satis_bilgileri where filmadi='"+comboBox1.SelectedItem+"'and salonadi='"+comboBox2.SelectedItem+"' and tarih='"+comboBox3.SelectedItem+"' and saat='"+comboBox4.SelectedItem+"'" ,baglanti);
            SqlDataReader read = komut.ExecuteReader();
            while (read.Read())
            {
                foreach (Control item in panel1.Controls)
                {
                    if (item is Button)
                    {
                        if (read["koltukno"].ToString()==item.Text)
                        {
                            item.BackColor = Color.DarkSlateBlue;
                        }

                        
                    }
                }
            }
            baglanti.Close();
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            Boş_Koltuklar();
            FilmveSalonGetir(comboBox1, "select *from film_bilgileri", "filmadi");
            FilmveSalonGetir(comboBox2, "select *from salon_bilgileri", "salonadi");

            // Ücret seans eklenirken belirlenir; bilet satarken elle değiştirilemez.
            comboBox6.Enabled = false;
            comboBoxTur.SelectedIndex = 0;
            
            




        }

        private void Boş_Koltuklar()
        {
            sayac = 1;
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    Button btn = new Button();
                    btn.Size = new Size(30, 30);
                    btn.BackColor = Color.White;
                    btn.Location = new Point(j * 30 + 20, i * 30 + 30);
                    btn.Name = sayac.ToString();
                    btn.Text = sayac.ToString();
                    if (j == 4)
                    {
                        continue;
                    }
                    sayac++;
                    this.panel1.Controls.Add(btn);
                    btn.Click += Btn_Click;
                }
            }
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (b.BackColor==Color.White)
            {
                textBox3.Text = b.Text;
            }
        }

        private void btnSatislar_Click(object sender, EventArgs e)
        {
            Form6 satis = new Form6();
            satis.Show();
            this.Hide();

        }

        private void btnSeanslar_Click(object sender, EventArgs e)
        {
            Form5 seans = new Form5();
            seans.Show();
            this.Hide();

            
            


        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox4.Items.Clear();
            comboBox3.Items.Clear();
            comboBox2.Text = "";
            comboBox4.Text = "";
            comboBox3.Text = "";
            foreach (Control item in groupBox1.Controls) if (item is TextBox) item.Text = "";            
            filmAfişiGoster();
            YenidenRenklendir();
            combo_dolu_koltuklar();
            FiyatiGuncelle();
        }

        sinemaTableAdapters.Satis_BilgileriTableAdapter satis = new sinemaTableAdapters.Satis_BilgileriTableAdapter();
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox3.Text!="")
            {
                if (comboBox6.Text == "")
                {
                    MessageBox.Show("Ücret belirlenemedi. Film, salon, tarih ve seans seçin. Seçtiğiniz seans için fiyat girilmemişse önce Seans Ekle ekranından fiyatı girin.", "Uyarı!");
                    return;
                }

                try
                {
                    satis.barkod_oluştur(textBox3.Text, comboBox2.Text, comboBox1.Text, comboBox3.Text, comboBox4.Text, textBox1.Text, textBox5.Text, comboBox6.Text, DateTime.Now.ToString(),textBox2.Text);
                    foreach (Control item in groupBox1.Controls) if (item is TextBox) item.Text = "";
                   
                    YenidenRenklendir();
                    Veritabani_Dolu_Koltuklar();
                    combo_dolu_koltuklar();
                    
                }
                catch (Exception hata)
                {
                    
                    MessageBox.Show("Hata oluştu!!!"+hata.Message, "Uyarı!");
                } 
            }
            else
            {
                MessageBox.Show("Koltuk seçimi yapmadınız!", "Uyarı!");
            }

            if (textBox2.Text!="")
            {
                try
                {
                    satis.barkod_oluştur(textBox3.Text, comboBox2.Text, comboBox1.Text, comboBox3.Text, comboBox4.Text, textBox1.Text, textBox5.Text, comboBox6.Text, DateTime.Now.ToString(), textBox2.Text);

                    MessageBox.Show("barkod eklendi", "kayıt");
                }
                catch (Exception)
                {

                    MessageBox.Show("Aynı barkod zaten mevcut", "Uyarı!");
                }
                textBox2.Text = "";
            }

            
        }

        
            
        private void film_tarihi_getir()
        {
            comboBox3.Text = "";
            comboBox4.Text = "";
            comboBox3.Items.Clear();
            comboBox4.Items.Clear();
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select *from seans_bilgileri where filmadi='"+comboBox1.SelectedItem+"' and salonadi='"+comboBox2.SelectedItem+"'",baglanti);
            SqlDataReader read = komut.ExecuteReader();
            while (read.Read())
            {
                if (DateTime.Parse(read["tarih"].ToString())>=DateTime.Parse(DateTime.Now.ToShortDateString()))
                {
                    if (!comboBox3.Items.Contains(read["tarih"].ToString()))
                    {
                        comboBox3.Items.Add(read["tarih"].ToString());
                    }
                    
                }
               
            }
            baglanti.Close();
        
        }
        
       
        private void comboBox2_SelectedIndexChanged(object sender,  EventArgs e)
        {

            film_tarihi_getir();
            FiyatiGuncelle();
        }
       
        
           
        private void film_seansi_getir()
        {
            comboBox4.Text = "";
            comboBox4.Items.Clear();
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select *from seans_bilgileri where filmadi='" + comboBox1.SelectedItem + "' and salonadi='" + comboBox2.SelectedItem + "'and tarih='"+comboBox3.SelectedItem+"'", baglanti);
            SqlDataReader read = komut.ExecuteReader();
            while (read.Read())
            {
                if (DateTime.Parse(read["tarih"].ToString()) == DateTime.Parse(DateTime.Now.ToShortDateString())) 
                {
                    if (DateTime.Parse (read["seans"].ToString())>DateTime.Parse(DateTime.Now.ToShortTimeString()))
                    {
                        comboBox4.Items.Add(read["seans"].ToString());
                    }
                    
                        
                    
                }

                else if (DateTime.Parse(read["tarih"].ToString()) > DateTime.Parse(DateTime.Now.ToShortDateString()))
                {
                    comboBox4.Items.Add(read["seans"].ToString());
                }
            }

            baglanti.Close();
        
        }
        private void comboBoxTur_SelectedIndexChanged(object sender, EventArgs e)
        {
            FiyatiGuncelle();
        }

        // Film, salon, tarih, seans ve bilet türüne göre ücreti seansın fiyatından getirir.
        private void FiyatiGuncelle()
        {
            comboBox6.Text = "";
            if (comboBox1.SelectedIndex < 0 || comboBox2.SelectedIndex < 0 ||
                comboBox3.SelectedIndex < 0 || comboBox4.SelectedIndex < 0)
                return;

            string sutun = comboBoxTur.Text == "Öğrenci" ? "OgrenciUcret" : "TamUcret";

            using (SqlConnection c = new SqlConnection(Class1.sqlconnection))
            {
                c.Open();
                using (SqlCommand komut = new SqlCommand(
                    "SELECT TOP 1 " + sutun + " FROM Seans_Bilgileri " +
                    "WHERE FilmAdi=@film AND SalonAdi=@salon AND Tarih=@tarih AND Seans=@seans", c))
                {
                    komut.Parameters.Add("@film", SqlDbType.VarChar, 50).Value = comboBox1.SelectedItem.ToString();
                    komut.Parameters.Add("@salon", SqlDbType.VarChar, 50).Value = comboBox2.SelectedItem.ToString();
                    komut.Parameters.Add("@tarih", SqlDbType.VarChar, 50).Value = comboBox3.SelectedItem.ToString();
                    komut.Parameters.Add("@seans", SqlDbType.VarChar, 50).Value = comboBox4.SelectedItem.ToString();
                    object sonuc = komut.ExecuteScalar();
                    if (sonuc != null && sonuc != DBNull.Value)
                        comboBox6.Text = sonuc.ToString();
                }
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            film_seansi_getir();
            FiyatiGuncelle();
        }
       
        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            YenidenRenklendir();
            Veritabani_Dolu_Koltuklar();
            combo_dolu_koltuklar();
            FiyatiGuncelle();
          
            
           
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (comboBox5.Text!="")
            {
                try
                {
                    satis.Satis_İptal(comboBox1.Text, comboBox2.Text, comboBox3.Text, comboBox4.Text, comboBox5.Text);
                    YenidenRenklendir();
                    Veritabani_Dolu_Koltuklar();
                    combo_dolu_koltuklar();
                }
                catch (Exception hata)
                {

                    MessageBox.Show("Hata Oluştu!!!"+hata.Message, "Uyarı!");

                }

            }
            else
            {
                MessageBox.Show("Koltuk seçimi yapmadınız!!!", "Uyarı!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form7 bilet = new Form7();
            bilet.Show();
            this.Hide();
        }

       

        private void button7_Click(object sender, EventArgs e)
        {
            Form1 anasayfa = new Form1();
            anasayfa.Close();
            this.Hide();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form9 frm9 = new Form9();
            frm9.Show();
            this.Hide();
        }
    }
}
