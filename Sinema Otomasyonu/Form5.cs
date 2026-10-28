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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(Class1.sqlconnection);
        DataTable tablo = new DataTable();
        private void seansListesi(string sql)
        {
            baglanti.Open();
            SqlDataAdapter adtr = new SqlDataAdapter(sql, baglanti);
            adtr.Fill(tablo);
            dataGridView1.DataSource = tablo;
            baglanti.Close();

        }

        private void Form5_Load(object sender, EventArgs e)
        {
            tablo.Clear();
            seansListesi("select *from seans_bilgileri where tarih like '" + dateTimePicker1 + "' ");
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            tablo.Clear();
            seansListesi("select *from seans_bilgileri where tarih like '" + dateTimePicker1 + "' ");

        }

        private void button3_Click(object sender, EventArgs e)
        {
            tablo.Clear();
            seansListesi("select *from seans_bilgileri");

        }

        

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
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