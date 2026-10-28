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
    public partial class Form12 : Form
    {
        public Form12()
        {
            InitializeComponent();
        }
        //SqlConnection baglanti = new SqlConnection("Data Source=.\\sqlexpress;Initial Catalog= sinema otomasyonu; Integrated Security=True");
        public string filmadi, salonadi, filmtarihi, filmseansi, ad, soyad, koltuk, ucret;
        private void Form12_Load(object sender, EventArgs e)
        {

            label15.Text = filmadi;
            
            label1.Text = salonadi;
            label10.Text = filmtarihi;
            label11.Text = filmseansi;
            label12.Text = ad;
            label13.Text = soyad;
            label14.Text = koltuk;
            label16.Text = ucret;


        }
        
       




    }

    
}
