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
    public partial class Form15 : Form
    {
        SqlConnection baglanti = new SqlConnection(Class1.sqlconnection);
        static Random random = new Random();
        int rand_code = random.Next(10000, 99999);

        public Form15()
        {
            InitializeComponent();
        }

        bool move;
        int mouse_x;
        int mouse_y;

        private void Form15_MouseDown(object sender, MouseEventArgs e)
        {
            move = true;
            mouse_x = e.X;
            mouse_y = e.Y;
        }

        private void Form15_MouseUp(object sender, MouseEventArgs e)
        {
            move = false;
        }

        private void Form15_MouseMove(object sender, MouseEventArgs e)
        {
            if (move)
            {
                this.SetDesktopLocation(MousePosition.X - mouse_x, MousePosition.Y - mouse_y);
            }


        }



        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (textBox1.Text == "Kodunu Gir")
            {
                textBox1.Text = "";
                textBox1.ForeColor = Color.White;
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.Text = "Kodunu Gir";
                textBox1.ForeColor = Color.Silver;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == rand_code.ToString())
            {
                baglanti.Open();
                SqlCommand komut = new SqlCommand("insert into giris_bilgileri (isim,sifre,sifre2,e_mail,telefon,aktif)values ('" + Cryptology.Encryption(Form11.KullanıcıAdı, 2) + "','" + Cryptology.Encryption(Form11.sifre, 2) + "','" + Cryptology.Encryption(Form11.sifre2, 2) + "','" + Cryptology.Encryption(Form11.e_mail, 2) + "','" + Cryptology.Encryption(Form11.telefon, 2) + "','false')", baglanti);
                komut.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Kaydolma Başarılı", "Program");
                Form1 anasayfa = new Form1();
                anasayfa.Show();
                this.Hide();
            }
            else
                MessageBox.Show("Bir şeyler yanlış gitti", "Program");
        }
        private void SendMail()
        {
            SmtpClient client = new SmtpClient();
            MailMessage message = new MailMessage();


            client.Credentials = new NetworkCredential("mail", "sifre");
            client.Port = 587;
            client.Host = "smtp-mail.outlook.com"; //smtp.gmail.com
            client.EnableSsl = true;

            message.To.Add(Form11.e_mail);
            message.From = new MailAddress("mail", "Sinema Otomasyonu");
            message.Subject = "Doğrulama Kodu";
            message.Body = "Senin doğrulama kodun="+rand_code;
            client.Send(message);
        }

        private void Form15_Load(object sender, EventArgs e)
        {
            SendMail();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form11 kaydol = new Form11();
            kaydol.Show();
            this.Hide();
        }
    }
}
