using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Printing;

namespace Sinema_Otomasyonu
{
    public partial class Form10 : Form
    {
        public string filmadi, salonadi, filmtarihi, filmseansi, ad, soyad, koltuk, ucret;

        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            Rectangle pagearea = e.PageBounds;
            e.Graphics.DrawImage(memoryimg, (pagearea.Width / 2) - (this.panelPrint.Width/2), this.panelPrint.Location.Y);
        }

        private void pictureBox2_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(pictureBox2, "print");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form7 frm7 = new Form7();
            frm7.Show();
            this.Hide();
            
        }

        public Image img = null;
        public Form10()
        {
            InitializeComponent();
        }

        private void print(Panel pnl)
        {
            PrinterSettings ps = new PrinterSettings();
            panelPrint = pnl;
            getprintarea(pnl);
            printPreviewDialog1.Document = printDocument1;
            printDocument1.PrintPage += new PrintPageEventHandler(printDocument1_PrintPage);
            printPreviewDialog1.ShowDialog();
        }

        private Bitmap memoryimg;
        private void getprintarea(Panel pnl)
        {
            memoryimg = new Bitmap(pnl.Width, pnl.Height);
            pnl.DrawToBitmap(memoryimg, new Rectangle(0, 0, pnl.Width, pnl.Height));
        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            print(this.panelPrint);
        }

        private void Form10_Load(object sender, EventArgs e)
        {
            label15.Text = filmadi;
            pictureBox1.Image = img;
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
