using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sinema_Otomasyonu
{
    internal static class Program
    {
        /// <summary>
        /// Uygulamanın ana girdi noktası.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            try
            {
                // Veritabanı dosyasını (yoksa) oluşturur ve tabloları hazırlar.
                VeriTabani.Hazirla();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Veritabanı hazırlanamadı.\n\n" +
                    "Bu bilgisayarda \"SQL Server Express LocalDB\" kurulu olmayabilir. " +
                    "Visual Studio Installer > Değiştir > \"Veri depolama ve işleme\" iş yükünden ya da " +
                    "Microsoft'un sitesinden SQL Server Express LocalDB'yi kurabilirsin.\n\n" +
                    "Ayrıntı: " + ex.Message,
                    "Sinema Otomasyonu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Application.Run(new Form8());
        }
    }
}
