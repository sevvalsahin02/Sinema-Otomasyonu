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
using System.Net.Mail;
using System.Net;

namespace Sinema_Otomasyonu
{
    

    public partial class Form11 : Form
    {
       static public string KullanıcıAdı { get; set; }
        static public string sifre { get; set; }
        static public string sifre2 { get; set; }
        static public string e_mail { get; set; }
        static public string telefon { get; set; }


        SqlConnection baglanti = new SqlConnection(Class1.sqlconnection);
        public Form11()
        {
            InitializeComponent();
        }

       
        private void button3_Click(object sender, EventArgs e)
        {
            Form8 giriş = new Form8();
            giriş.Show();
            this.Hide();
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

        private void textBox2_Leave(object sender, EventArgs e)
        {

            char? none = null;
            if (textBox2.Text == "")
            {
                textBox2.Text = "Şifre";
                textBox2.ForeColor = Color.Silver;
                textBox2.PasswordChar = Convert.ToChar(none);

            }
        }

        private void textBox3_Enter(object sender, EventArgs e)
        {
            if (textBox3.Text == "Şifre Yeniden")
            {
                textBox3.Text = "";
                textBox3.ForeColor = Color.White;
                textBox3.PasswordChar = '*';
            }
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            char? none = null;
            if (textBox3.Text == "")
            {
                textBox3.Text = "Şifre Yeniden";
                textBox3.ForeColor = Color.Silver;
                textBox3.PasswordChar = Convert.ToChar(none);

            }
        }

        private void textBox4_Enter(object sender, EventArgs e)
        {
            if (textBox4.Text == "e-Mail")
            {
                textBox4.Text = "";
                textBox4.ForeColor = Color.White;
                
            }
        }

        private void textBox4_Leave(object sender, EventArgs e)
        {
            
            if (textBox4.Text == "")
            {
                textBox4.Text = "e-Mail";
                textBox4.ForeColor = Color.Silver;
                

            }
        }

        private void textBox5_Enter(object sender, EventArgs e)
        {
            if (textBox5.Text == "Telefon Numarası")
            {
                textBox5.Text = "";
                textBox5.ForeColor = Color.White;

            }
        }

        private void textBox5_Leave(object sender, EventArgs e)
        {
            if (textBox5.Text == "")
            {
                textBox5.Text = "Telefon Numarası";
                textBox5.ForeColor = Color.Silver;


            }
        }
        bool move;
        int mouse_x;
        int mouse_y;
        private void Form11_MouseDown(object sender, MouseEventArgs e)
        {
            move = true;
            mouse_x = e.X;
            mouse_y = e.Y;
        }

        private void Form11_MouseUp(object sender, MouseEventArgs e)
        {
            move = false;
        }

        private void Form11_MouseMove(object sender, MouseEventArgs e)
        {
            if (move)
            {
                this.SetDesktopLocation(MousePosition.X - mouse_x, MousePosition.Y - mouse_y);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            KullanıcıAdı = textBox1.Text;
            sifre = textBox2.Text;
            sifre2 = textBox3.Text;
            e_mail = textBox4.Text;
            telefon = textBox5.Text;

            
            Form15 frm15 = new Form15();
            frm15.Show(); 
        
        
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form8 giris = new Form8();
            giris.Show();
            this.Hide();
        }

        private void Form11_Load(object sender, EventArgs e)
        {

        }
    }
}
