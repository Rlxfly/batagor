using System;
using System.Windows.Forms;

namespace FinalPrjk
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            try
            {
                Db.Initialize();   // membuat database, tabel, dan data awal bila belum ada
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Database tidak dapat disiapkan.\n\n" +
                    "Cara memperbaiki:\n" +
                    "1. Pasang SQL Server Express LocalDB (Visual Studio Installer > Individual components >\n" +
                    "   'SQL Server Express LocalDB'), atau pasang SQL Server Express.\n" +
                    "2. Cek dengan perintah: sqllocaldb info\n" +
                    "3. Jika nama server berbeda, ubah connection string \"BelanjaDb\" di App.config.\n\n" +
                    "Rincian:\n" + ex.Message,
                    "Belanjaku", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            while (true)
            {
                using (var login = new LoginForm())
                {
                    if (login.ShowDialog() != DialogResult.OK) break;
                }

                using (var utama = new Form1())
                {
                    Application.Run(utama);
                }

                if (!Session.LoggedOut) break;   // jendela ditutup lewat tombol X: keluar aplikasi
                Session.Clear();                  // tombol Keluar: kembali ke form login
            }
        }
    }
}
