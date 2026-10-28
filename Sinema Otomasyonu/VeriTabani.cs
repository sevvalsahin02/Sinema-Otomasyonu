using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace Sinema_Otomasyonu
{
    /// <summary>
    /// Veritabanını uygulamayla birlikte taşınabilir hale getirir.
    ///
    /// Veri, SQL Server LocalDB ile "Veri\SinemaOtomasyonu.mdf" dosyasında tutulur.
    /// Uygulama açılırken dosya yoksa kendisi oluşturur ve tabloları kurar.
    /// Projeyi başka bir bilgisayara taşırken "Veri" klasörünü de kopyalamak yeterlidir.
    /// Film afişleri de aynı klasörde ("Veri\Afisler") saklanır.
    /// </summary>
    internal static class VeriTabani
    {
        private const string DosyaAdi = "SinemaOtomasyonu.mdf";
        private const string GunlukDosyaAdi = "SinemaOtomasyonu_log.ldf";

        // App.config içindeki bağlantı cümlesiyle aynı olmalı (TableAdapter'lar onu kullanıyor).
        public const string BaglantiCumlesi =
            @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\SinemaOtomasyonu.mdf;Integrated Security=True;Connect Timeout=60";

        private const string MasterBaglantiCumlesi =
            @"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=master;Integrated Security=True;Connect Timeout=60";

        /// <summary>Veritabanı dosyasının ve afişlerin durduğu klasör.</summary>
        public static string VeriKlasoru
        {
            get
            {
                string taban = AppDomain.CurrentDomain.BaseDirectory
                    .TrimEnd(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar);

                // Visual Studio'dan çalışırken exe "...\bin\Debug" içindedir. Veriyi bin/obj temizlenince
                // silinmesin diye proje klasörüne (csproj'un yanına) koyuyoruz.
                string proje = ProjeKlasoruBul(taban);
                return Path.Combine(proje ?? taban, "Veri");
            }
        }

        public static string AfisKlasoru
        {
            get { return Path.Combine(VeriKlasoru, "Afisler"); }
        }

        private static string ProjeKlasoruBul(string taban)
        {
            DirectoryInfo klasor = new DirectoryInfo(taban);
            for (int i = 0; i < 3 && klasor.Parent != null; i++)
            {
                klasor = klasor.Parent;
                if (klasor.GetFiles("*.csproj").Length > 0)
                    return klasor.FullName;
            }
            return null;
        }

        /// <summary>
        /// Uygulama başlarken bir kez çağrılır: klasörleri, veritabanı dosyasını ve tabloları hazırlar.
        /// </summary>
        public static void Hazirla()
        {
            string klasor = VeriKlasoru;
            Directory.CreateDirectory(klasor);
            Directory.CreateDirectory(AfisKlasoru);

            // Bağlantı cümlesindeki |DataDirectory| bu klasöre çözülür.
            AppDomain.CurrentDomain.SetData("DataDirectory", klasor);

            string mdf = Path.Combine(klasor, DosyaAdi);
            string ldf = Path.Combine(klasor, GunlukDosyaAdi);

            bool yeniOlusturuldu = false;
            if (!File.Exists(mdf))
            {
                DosyayiOlustur(mdf, ldf);
                yeniOlusturuldu = true;
            }

            using (SqlConnection baglanti = new SqlConnection(BaglantiCumlesi))
            {
                baglanti.Open();

                foreach (string sql in Sema)
                    Calistir(baglanti, sql);

                if (yeniOlusturuldu)
                    VarsayilanKullaniciEkle(baglanti);
            }
        }

        // Boş bir .mdf/.ldf çiftini oluşturup ayırır (detach). Uygulamanın asıl bağlantısı
        // dosyayı AttachDbFilename ile kendisi bağlar.
        private static void DosyayiOlustur(string mdf, string ldf)
        {
            if (File.Exists(ldf))
                File.Delete(ldf); // yalnız kalmış eski log dosyası CREATE DATABASE'i bozar

            string gecici = "SinemaOtomasyonu_" + Guid.NewGuid().ToString("N");

            using (SqlConnection master = new SqlConnection(MasterBaglantiCumlesi))
            {
                master.Open();

                Calistir(master,
                    "CREATE DATABASE [" + gecici + "] " +
                    "ON PRIMARY (NAME = N'SinemaOtomasyonu', FILENAME = N'" + SqlMetin(mdf) + "') " +
                    "LOG ON (NAME = N'SinemaOtomasyonu_log', FILENAME = N'" + SqlMetin(ldf) + "') " +
                    "COLLATE Turkish_CI_AS");

                Calistir(master,
                    "EXEC master.dbo.sp_detach_db @dbname = N'" + gecici + "', @skipchecks = N'true'");
            }
        }

        private static void VarsayilanKullaniciEkle(SqlConnection baglanti)
        {
            // Eski kayıtlı kullanıcılar veritabanıyla birlikte kaybolduğu için giriş yapılabilsin diye
            // bir başlangıç hesabı: kullanıcı adı "admin", şifre "1234". İlk girişten sonra değiştir.
            // Kullanıcı bilgileri uygulamadaki gibi Cryptology ile saklanır.
            using (SqlCommand komut = new SqlCommand(
                "INSERT INTO giris_bilgileri (isim, sifre, sifre2, e_mail, telefon, aktif) " +
                "VALUES (@isim, @sifre, @sifre2, @mail, @tel, 0)", baglanti))
            {
                komut.Parameters.AddWithValue("@isim", Cryptology.Encryption("admin", 2));
                komut.Parameters.AddWithValue("@sifre", Cryptology.Encryption("1234", 2));
                komut.Parameters.AddWithValue("@sifre2", Cryptology.Encryption("1234", 2));
                komut.Parameters.AddWithValue("@mail", Cryptology.Encryption("admin@sinema.local", 2));
                komut.Parameters.AddWithValue("@tel", Cryptology.Encryption("0000000000", 2));
                komut.ExecuteNonQuery();
            }
        }

        // ---- Film afişleri -------------------------------------------------------------------

        /// <summary>
        /// Seçilen afiş dosyasını Veri\Afisler klasörüne kopyalar ve veritabanına yazılacak
        /// dosya adını döndürür. Böylece kayıt, bilgisayardaki tam yola bağımlı olmaz.
        /// Dosya seçilmediyse null döner.
        /// </summary>
        public static string AfisiKaydet(string kaynakYol)
        {
            if (string.IsNullOrWhiteSpace(kaynakYol) || !File.Exists(kaynakYol))
                return null;

            string kaynak = Path.GetFullPath(kaynakYol);
            string ad = Path.GetFileName(kaynak);
            string hedef = Path.Combine(AfisKlasoru, ad);

            bool ayniDosya = string.Equals(kaynak, Path.GetFullPath(hedef), StringComparison.OrdinalIgnoreCase);
            if (!ayniDosya)
            {
                if (File.Exists(hedef))
                {
                    // Aynı adlı başka bir afiş varsa üzerine yazma.
                    ad = Guid.NewGuid().ToString("N").Substring(0, 8) + "_" + ad;
                    hedef = Path.Combine(AfisKlasoru, ad);
                }
                File.Copy(kaynak, hedef);
            }
            return ad;
        }

        /// <summary>
        /// Veritabanındaki "resim" değerini gerçek dosya yoluna çevirir. Yalnız dosya adı saklanmışsa
        /// Veri\Afisler içinde aranır; eski kayıtlardaki tam yollar olduğu gibi kullanılır.
        /// </summary>
        public static string AfisYolu(string kayitliDeger)
        {
            if (string.IsNullOrWhiteSpace(kayitliDeger))
                return "";

            kayitliDeger = kayitliDeger.Trim();
            try
            {
                return Path.IsPathRooted(kayitliDeger)
                    ? kayitliDeger
                    : Path.Combine(AfisKlasoru, kayitliDeger);
            }
            catch (ArgumentException)
            {
                return "";
            }
        }

        // ---- Yardımcılar ---------------------------------------------------------------------

        private static void Calistir(SqlConnection baglanti, string sql)
        {
            using (SqlCommand komut = new SqlCommand(sql, baglanti))
            {
                komut.CommandTimeout = 120;
                komut.ExecuteNonQuery();
            }
        }

        private static string SqlMetin(string metin)
        {
            return metin.Replace("'", "''");
        }

        // Tablolar (eski SQL Server veritabanından: kod ve sinema.xsd incelenerek çıkarıldı).
        // Her komut tabloyu yalnız yoksa oluşturur, o yüzden her açılışta çalıştırmak güvenlidir.
        private static readonly string[] Sema =
        {
            @"IF OBJECT_ID(N'dbo.Salon_Bilgileri', N'U') IS NULL
              CREATE TABLE dbo.Salon_Bilgileri (
                  Salonld   int IDENTITY(1,1) NOT NULL,
                  SalonAdi  varchar(50) NOT NULL PRIMARY KEY
              )",

            @"IF OBJECT_ID(N'dbo.Film_Bilgileri', N'U') IS NULL
              CREATE TABLE dbo.Film_Bilgileri (
                  Filmld      int IDENTITY(1,1) NOT NULL,
                  FilmAdi     varchar(50) NOT NULL PRIMARY KEY,
                  Yonetmen    varchar(50) NULL,
                  FilmTuru    varchar(50) NULL,
                  FilmSuresi  varchar(50) NULL,
                  Tarih       varchar(50) NULL,
                  YapimYili   varchar(50) NULL,
                  Resim       varchar(100) NULL,
                  Oyuncular   varchar(50) NULL
              )",

            @"IF OBJECT_ID(N'dbo.Seans_Bilgileri', N'U') IS NULL
              CREATE TABLE dbo.Seans_Bilgileri (
                  Seansld   int IDENTITY(1,1) NOT NULL PRIMARY KEY,
                  FilmAdi   varchar(50) NULL,
                  SalonAdi  varchar(50) NULL,
                  Tarih     varchar(50) NULL,
                  Seans     varchar(50) NULL,
                  TamUcret      int NULL,
                  OgrenciUcret  int NULL
              )",

            @"IF OBJECT_ID(N'dbo.Satis_Bilgileri', N'U') IS NULL
              CREATE TABLE dbo.Satis_Bilgileri (
                  Satisld   int IDENTITY(1,1) NOT NULL PRIMARY KEY,
                  KoltukNo  varchar(50) NULL,
                  SalonAdi  varchar(50) NULL,
                  FilmAdi   varchar(50) NULL,
                  Tarih     varchar(50) NULL,
                  Saat      varchar(50) NULL,
                  Ad        varchar(50) NULL,
                  Soyad     varchar(50) NULL,
                  Ucret     varchar(50) NULL,
                  Tarih2    varchar(50) NULL,
                  barkod    varchar(100) NULL
              )",

            @"IF OBJECT_ID(N'dbo.giris_bilgileri', N'U') IS NULL
              CREATE TABLE dbo.giris_bilgileri (
                  isim     nchar(50) NULL,
                  sifre    nchar(20) NULL,
                  sifre2   nchar(20) NULL,
                  e_mail   nchar(30) NULL,
                  telefon  nchar(20) NULL,
                  aktif    bit NOT NULL DEFAULT 0
              )",

            @"IF OBJECT_ID(N'dbo.[kullanıcı_bilgileri]', N'U') IS NULL
              CREATE TABLE dbo.[kullanıcı_bilgileri] (
                  ad      nchar(50) NULL,
                  soyad   nchar(50) NULL,
                  eposta  nchar(50) NULL,
                  resim   nchar(100) NULL
              )",

            // Seans başına bilet fiyatı (Tam / Öğrenci). Bu sütunlar olmayan eski veritabanlarına eklenir.
            @"IF COL_LENGTH(N'dbo.Seans_Bilgileri', N'TamUcret') IS NULL
              ALTER TABLE dbo.Seans_Bilgileri ADD TamUcret int NULL",

            @"IF COL_LENGTH(N'dbo.Seans_Bilgileri', N'OgrenciUcret') IS NULL
              ALTER TABLE dbo.Seans_Bilgileri ADD OgrenciUcret int NULL"
        };
    }
}
