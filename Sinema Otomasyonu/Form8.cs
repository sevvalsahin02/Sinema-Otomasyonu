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



namespace Sinema_Otomasyonu
{
    public partial class Form8 : Form
    {

        SqlConnection baglanti = new SqlConnection(Class1.sqlconnection);
        public Form8()
        {
            InitializeComponent();


        }



        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        bool move;
        int mouse_x;
        int mouse_y;

        private void Form8_MouseDown(object sender, MouseEventArgs e)
        {
            move = true;
            mouse_x = e.X;
            mouse_y = e.Y;
        }

        private void Form8_MouseUp(object sender, MouseEventArgs e)
        {
            move = false;
        }

        private void Form8_MouseMove(object sender, MouseEventArgs e)
        {
            if (move)
            {
                this.SetDesktopLocation(MousePosition.X - mouse_x, MousePosition.Y - mouse_y);
            }


        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (textBox1.Text == "Kullanıcı Adı")
            {
                textBox1.Text = "";
                textBox1.ForeColor = Color.White;
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.Text = "Kullanıcı Adı";
                textBox1.ForeColor = Color.Silver;
            }
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            if (textBox2.Text == "Şifre")
            {
                textBox2.Text = "";
                textBox2.ForeColor = Color.White;
                textBox2.PasswordChar = '*';
            }
        }
        char? none = null;
        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                textBox2.Text = "Şifre";
                textBox2.ForeColor = Color.Silver;
                textBox2.PasswordChar = Convert.ToChar(none);

            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string kullanıcıadı = textBox1.Text;
            string sifre = textBox2.Text;
            bool isThere = false;

            baglanti.Open();
            SqlCommand komut = new SqlCommand("select *from giris_bilgileri", baglanti);
            SqlDataReader reader = komut.ExecuteReader();

            while (reader.Read())
            {
                if (kullanıcıadı == Cryptology.Decryption(reader["isim"].ToString().TrimEnd(), 2) && sifre == Cryptology.Decryption(reader["sifre"].ToString().TrimEnd(), 2))
                {
                    isThere = true;
                    Form1 anasayfa = new Form1();
                    anasayfa.Show();


                    break;
                }
                else
                {
                    isThere = false;
                    MessageBox.Show("Giriş Yapamadınız!", "Hata!");

                }
            }
            baglanti.Close();
        }


        private void button2_Click(object sender, EventArgs e)
        {
            Form11 kayıt = new Form11();
            kayıt.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form1 anasayfa = new Form1();
            anasayfa.Show();
            this.Hide();

        }


    }
}
