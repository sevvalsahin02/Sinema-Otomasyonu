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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        //sinemaTableAdapters.Seans_BilgileriTableAdapter filmseansi = new sinemaTableAdapters.Seans_BilgileriTableAdapter();
        sinemaTableAdapters.Seans_BilgileriTableAdapter filmseansi = new sinemaTableAdapters.Seans_BilgileriTableAdapter();
        SqlConnection baglanti = new SqlConnection(Class1.sqlconnection);


        private void Form4_Load(object sender, EventArgs e)
        {
            FilmveSalonGoster(comboBox4,"select *from film_bilgileri","filmadi");
            FilmveSalonGoster(comboBox1, "select *from salon_bilgileri", "salonadi");
        }

       

        private void FilmveSalonGoster(ComboBox combo,string sql,string sql2)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand(sql, baglanti);
            SqlDataReader read = komut.ExecuteReader();
            while(read.Read()==true)
            {
                combo.Items.Add(read[sql2].ToString());
            }
            baglanti.Close();
        }

        string seans = "";
        private void radioButtonSeçiliyse()
        {
                 if(radioButton1.Checked==true) seans = radioButton1.Text;
                 else if (radioButton2.Checked == true) seans = radioButton2.Text;
                 else if (radioButton3.Checked== true) seans = radioButton3.Text;
                 else if (radioButton4.Checked== true) seans = radioButton4.Text;
                 else if (radioButton5.Checked== true) seans = radioButton5.Text;
                 else if (radioButton6.Checked== true) seans = radioButton6.Text;
                 else if (radioButton7.Checked== true) seans = radioButton7.Text;
                 else if (radioButton8.Checked== true) seans = radioButton8.Text;
                 else if (radioButton9.Checked== true) seans = radioButton9.Text;
                 else if (radioButton10.Checked== true) seans = radioButton10.Text;
                 else if (radioButton11.Checked== true) seans = radioButton11.Text;
                 else if (radioButton12.Checked== true) seans = radioButton12.Text;
         }
       
        private static bool FiyatOku(string metin, out int fiyat)
        {
            return int.TryParse(metin.Trim(), out fiyat) && fiyat > 0;
        }

        private void FiyatParametreleriniEkle(SqlCommand komut, int tam, int ogrenci)
        {
            komut.Parameters.Add("@FilmAdi", SqlDbType.VarChar, 50).Value = comboBox4.Text;
            komut.Parameters.Add("@SalonAdi", SqlDbType.VarChar, 50).Value = comboBox1.Text;
            komut.Parameters.Add("@Tarih", SqlDbType.VarChar, 50).Value = dateTimePicker1.Text;
            komut.Parameters.Add("@Seans", SqlDbType.VarChar, 50).Value = seans;
            komut.Parameters.Add("@TamUcret", SqlDbType.Int).Value = tam;
            komut.Parameters.Add("@OgrenciUcret", SqlDbType.Int).Value = ogrenci;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            seans = "";
            radioButtonSeçiliyse();

            if (comboBox4.Text == "" || comboBox1.Text == "")
            {
                MessageBox.Show("Film ve salon seçimi yapmadınız!", "Uyarı!");
                return;
            }
            if (seans == "")
            {
                MessageBox.Show("Seans Seçimi Yapmadınız!", "Uyarı!");
                return;
            }

            // Bilet fiyatı seans eklenirken belirlenir; bilet satarken değiştirilemez.
            int tamUcret, ogrenciUcret;
            bool tamTamam = FiyatOku(textBoxTam.Text, out tamUcret);
            bool ogrenciTamam = FiyatOku(textBoxOgrenci.Text, out ogrenciUcret);
            if (!tamTamam || !ogrenciTamam)
            {
                MessageBox.Show("Tam ve öğrenci fiyatını TL olarak, sıfırdan büyük tam sayı şeklinde girin (örn. 150).", "Uyarı!");
                return;
            }

            try
            {
                using (SqlConnection c = new SqlConnection(Class1.sqlconnection))
                {
                    c.Open();

                    // Fiyatı olmayan eski bir kayıt varsa yenisini eklemek yerine onun fiyatını tamamla.
                    int guncellenen;
                    using (SqlCommand guncelle = new SqlCommand(
                        "UPDATE Seans_Bilgileri SET TamUcret=@TamUcret, OgrenciUcret=@OgrenciUcret " +
                        "WHERE FilmAdi=@FilmAdi AND SalonAdi=@SalonAdi AND Tarih=@Tarih AND Seans=@Seans AND TamUcret IS NULL", c))
                    {
                        FiyatParametreleriniEkle(guncelle, tamUcret, ogrenciUcret);
                        guncellenen = guncelle.ExecuteNonQuery();
                    }

                    if (guncellenen == 0)
                    {
                        using (SqlCommand ekle = new SqlCommand(
                            "INSERT INTO Seans_Bilgileri (FilmAdi, SalonAdi, Tarih, Seans, TamUcret, OgrenciUcret) " +
                            "VALUES (@FilmAdi, @SalonAdi, @Tarih, @Seans, @TamUcret, @OgrenciUcret)", c))
                        {
                            FiyatParametreleriniEkle(ekle, tamUcret, ogrenciUcret);
                            ekle.ExecuteNonQuery();
                        }
                    }
                }

                MessageBox.Show("Seans Ekleme İşlemi Yapıldı.", "Kayıt");
            }
            catch (Exception hata)
            {
                MessageBox.Show("Hata oluştu!!! " + hata.Message, "Uyarı!");
                return;
            }

            comboBox1.Text = "";
            comboBox4.Text = "";
            dateTimePicker1.Text = DateTime.Now.ToShortDateString();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

            foreach (Control item3 in groupBox2.Controls)
            {
                item3.Enabled = true;
            } 
            DateTime bugün = DateTime.Parse(DateTime.Now.ToShortDateString());
            DateTime yeni = DateTime.Parse(dateTimePicker1.Text);
            if (yeni==bugün)
            {
                foreach (Control item in groupBox2.Controls)
                {
                    if (DateTime.Parse(DateTime.Now.ToShortTimeString()) > DateTime.Parse(item.Text))
                    {
                        item.Enabled = false;
                    }
                }

                Tarihi_Karşılaştır();
            }
            else if (yeni>bugün)
            {
                Tarihi_Karşılaştır();
            }
            else if (yeni<bugün)
            {
                MessageBox.Show("Geriye dönük işlem yapılamaz!!!", "Uyarı!");
                dateTimePicker1.Text = DateTime.Now.ToShortDateString();

            }
        }

        private void Tarihi_Karşılaştır()
        {
            baglanti.Open();
            // Yalnızca fiyatı girilmiş (yani dolu) seanslar kapatılır.
            SqlCommand komut = new SqlCommand("select * from seans_bilgileri where salonadi=@salon and tarih=@tarih and TamUcret is not null", baglanti);
            komut.Parameters.AddWithValue("@salon", comboBox1.Text);
            komut.Parameters.AddWithValue("@tarih", dateTimePicker1.Text);
            SqlDataReader read = komut.ExecuteReader();
            while (read.Read() == true)
            {
                foreach (Control item2 in groupBox2.Controls)
                {
                    if (read["seans"].ToString() == item2.Text)
                    {
                        item2.Enabled = false;
                    }
                }
            }
            baglanti.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            dateTimePicker1.Text = DateTime.Now.ToShortDateString();
        }

       

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 anasayfa = new Form1();
            anasayfa.Show();
            this.Hide();
        }
    }
}
