using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Drawing.Printing;
using static System.Net.Mime.MediaTypeNames;

namespace Sinema_Otomasyonu
{
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(Class1.sqlconnection);


        sinemaTableAdapters.Satis_BilgileriTableAdapter satis = new sinemaTableAdapters.Satis_BilgileriTableAdapter();
        private void bilet_bilgileri( )
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select *from satis_bilgileri where ad='" + comboBox1.SelectedItem + "'", baglanti);
            SqlDataReader read = komut.ExecuteReader();
            while (read.Read())
            {
                textBox2.Text = read["filmadi"].ToString();
                textBox3.Text = read["salonadi"].ToString();
                textBox4.Text = read["tarih"].ToString();
                textBox5.Text = read["saat"].ToString();
                textBox6.Text = read["ad"].ToString();
                textBox7.Text = read["soyad"].ToString();
                textBox8.Text = read["koltukno"].ToString();
                textBox9.Text = read["ucret"].ToString();
                textBox1.Text = read["barkod"].ToString();
            }
            baglanti.Close();




        }

        private void ad_getir(ComboBox combo, string sql1, string sql2)
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
        private void Form7_Load(object sender, EventArgs e)
        {

            ad_getir(comboBox1, "select *from satis_bilgileri", "ad");

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            bilet_bilgileri();

        }

       

        private void button2_Click(object sender, EventArgs e)
        {
            Zen.Barcode.Code128BarcodeDraw barcode = Zen.Barcode.BarcodeDrawFactory.Code128WithChecksum;
            pictureBox1.Image = barcode.Draw(textBox1.Text, 100);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form1 anasayfa = new Form1();
            anasayfa.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form10 frm10 = new Form10();
            frm10.img = pictureBox1.Image;
            frm10.filmadi = textBox2.Text;
            frm10.salonadi = textBox3.Text;
            frm10.filmtarihi = textBox4.Text;
            frm10.filmseansi = textBox5.Text;
            frm10.ad = textBox6.Text;
            frm10.soyad = textBox7.Text;
            frm10.koltuk = textBox8.Text;
            frm10.ucret = textBox9.Text;

            frm10.Show();
            this.Hide();
        }
    }
}
