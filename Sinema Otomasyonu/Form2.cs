using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sinema_Otomasyonu
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        // sinemaTableAdapters.Film_BilgileriTableAdapter film = new sinemaTableAdapters.Film_BilgileriTableAdapter();
        sinemaTableAdapters.Film_BilgileriTableAdapter film = new sinemaTableAdapters.Film_BilgileriTableAdapter();

        private void button1_Click(object sender, EventArgs e)
        {
            // Afişi proje/uygulama klasörüne kopyala; veritabanına yalnız dosya adı yazılır (taşınabilirlik için).
            string resim = null;
            try
            {
                resim = VeriTabani.AfisiKaydet(pictureBox1.ImageLocation);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Afiş kopyalanamadı: " + ex.Message, "Uyarı!");
                return;
            }

            try
            {
                // film.FilmEkleme(textBox1.Text, textBox2.Text, comboBox1.Text, textBox4.Text, dateTimePicker1.Text, pictureBox1.ImageLocation, textBox5.Text, textBox3.Text);
                film.FilmEkleme(textBox1.Text, textBox2.Text, comboBox1.Text, textBox4.Text, dateTimePicker1.Text, textBox5.Text, resim, textBox3.Text);
                MessageBox.Show("Film bilgileri eklendi", "Kayıt");
            }
            catch (Exception)
            {

                MessageBox.Show("Bu film daha önce eklendi!!!", "Uyarı!");
            }

            foreach (Control item in Controls)
            if (item is TextBox) item.Text = "";
            comboBox1.Text = "";


        }


        private void Form2_Load(object sender, EventArgs e)
        {

        }


        private void button3_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            pictureBox1.ImageLocation = openFileDialog1.FileName;
        }
        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }


        

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 anasayfa = new Form1();
            anasayfa.Show();
            this.Hide();
        }
    }
}
