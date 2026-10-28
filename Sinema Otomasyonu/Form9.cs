using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge.Video.DirectShow;
using AForge.Video;
using ZXing;
using System.Data.SqlClient;


namespace Sinema_Otomasyonu
{
    public partial class Form9 : Form
    {
        public Form9()
        {
            InitializeComponent();
        }

        FilterInfoCollection filter;
        VideoCaptureDevice captureDevice;

        // Kamera görüntüleri ayrı bir iş parçacığında (thread) gelir. QR çözme işi de orada yapılır;
        // arayüze yalnızca BeginInvoke ile (beklemeden) dokunulur. Eskiden Invoke ile bekleniyor ve
        // aynı anda arayüz kamerayı durdurmak için beklediği için iki taraf birbirini kilitliyordu.
        private readonly BarcodeReader okuyucu = new BarcodeReader();
        private readonly Stopwatch kronometre = Stopwatch.StartNew();
        private long sonCozmeMs;
        private volatile bool okundu;
        private int gosterimBekliyor; // 1: önceki kare henüz ekrana çizilmedi

        private void Form9_Load(object sender, EventArgs e)
        {
            filter = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo filterInfo in filter)
                comboBox1.Items.Add(filterInfo.Name);

            if (comboBox1.Items.Count > 0)
            {
                comboBox1.SelectedIndex = 0;
            }
            else
            {
                button1.Enabled = false;
                MessageBox.Show("Bilgisayarda kamera bulunamadı.", "Uyarı!");
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex < 0)
                return;

            KameraDurdur(); // açık bir kamera varsa önce kapat

            okundu = false;
            sonCozmeMs = 0;
            System.Threading.Interlocked.Exchange(ref gosterimBekliyor, 0);

            captureDevice = new VideoCaptureDevice(filter[comboBox1.SelectedIndex].MonikerString);
            captureDevice.NewFrame += CaptureDevie_NewFrame;
            captureDevice.Start();
        }

        // Kamera iş parçacığında çalışır.
        private void CaptureDevie_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            // Arayüz önceki kareyi henüz çizmediyse bu kareyi atla (kareler birikmesin).
            if (okundu || System.Threading.Interlocked.CompareExchange(ref gosterimBekliyor, 1, 0) != 0)
                return;

            Bitmap kare = (Bitmap)eventArgs.Frame.Clone();
            string metin = null;

            // Her karede değil, saniyede yaklaşık 4 kez çözmeyi dene.
            long simdi = kronometre.ElapsedMilliseconds;
            if (simdi - sonCozmeMs >= 250)
            {
                sonCozmeMs = simdi;
                Result sonuc = okuyucu.Decode(kare);
                if (sonuc != null)
                {
                    metin = sonuc.Text;
                    okundu = true;
                }
            }

            try
            {
                if (IsDisposed || !IsHandleCreated)
                    throw new ObjectDisposedException("Form9");

                // Invoke değil BeginInvoke: kamera iş parçacığı arayüzü beklemez.
                BeginInvoke(new MethodInvoker(delegate () { KareyiGoster(kare, metin); }));
            }
            catch (Exception)
            {
                // Form kapanmış olabilir.
                kare.Dispose();
                System.Threading.Interlocked.Exchange(ref gosterimBekliyor, 0);
            }
        }

        // Arayüz iş parçacığında çalışır.
        private void KareyiGoster(Bitmap kare, string metin)
        {
            Image eski = pictureBox1.Image;
            pictureBox1.Image = kare;
            if (eski != null)
                eski.Dispose();

            System.Threading.Interlocked.Exchange(ref gosterimBekliyor, 0);

            if (metin != null)
            {
                textBox1.Text = metin;
                KameraDurdur();
            }
        }

        // Kamerayı BEKLEMEDEN durdurur. Stop() kullanılmaz: o, kamera iş parçacığının bitmesini
        // arayüzde bekler ve program donabilir.
        private void KameraDurdur()
        {
            if (captureDevice == null)
                return;

            captureDevice.NewFrame -= CaptureDevie_NewFrame;
            if (captureDevice.IsRunning)
                captureDevice.SignalToStop();
            captureDevice = null;
        }

        // Artık kullanılmıyor (QR çözme kamera olayında yapılıyor). Designer dosyası bu metoda bağlı olduğu için duruyor.
        private void timer1_Tick(object sender, EventArgs e)
        {
        }

        private void Form9_FormClosing(object sender, FormClosingEventArgs e)
        {
            KameraDurdur();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            KameraDurdur();
            Form1 anasayfa = new Form1();
            anasayfa.Show();
            this.Hide();
        }
       
        sinemaTableAdapters.Satis_BilgileriTableAdapter satis = new sinemaTableAdapters.Satis_BilgileriTableAdapter();
        private void button3_Click(object sender, EventArgs e)
        {
            Form12 frm12 = new Form12();
            using (SqlConnection baglanti = new SqlConnection(Class1.sqlconnection))
            {
                baglanti.Open();
                using (SqlCommand komut = new SqlCommand("select * from satis_bilgileri where barkod=@barkod", baglanti))
                {
                    komut.Parameters.AddWithValue("@barkod", textBox1.Text);
                    using (SqlDataReader read = komut.ExecuteReader())
                    {
                        while (read.Read())
                        {
                            frm12.filmadi = read["filmadi"].ToString();
                            frm12.salonadi = read["salonadi"].ToString();
                            frm12.filmtarihi = read["tarih"].ToString();
                            frm12.filmseansi = read["saat"].ToString();
                            frm12.ad = read["ad"].ToString();
                            frm12.soyad = read["soyad"].ToString();
                            frm12.koltuk = read["koltukno"].ToString();
                            frm12.ucret = read["ucret"].ToString();
                        }
                    }
                }
            }
            frm12.Show();
            this.Hide();
        }
    }
}
