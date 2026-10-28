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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

       

        sinemaTableAdapters.Salon_BilgileriTableAdapter salon = new sinemaTableAdapters.Salon_BilgileriTableAdapter();

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                salon.SalonEkleme(textBox1.Text);
                MessageBox.Show("Salon eklendi", "kayıt");
            }
            catch (Exception)
            {

                MessageBox.Show("Aynı salonu daha önce eklediniz","Uyarı!");
            }
            textBox1.Text = "";
        }

        private void Form3_Load(object sender, EventArgs e)
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
