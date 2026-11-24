using System;
using System.IO;
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

            // SQLite butuh file native SQLite.Interop.dll di subfolder x86 / x64 di samping .exe
            string arsitektur = Environment.Is64BitProcess ? "x64" : "x86";
            string interop = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, arsitektur, "SQLite.Interop.dll");
            if (!File.Exists(interop))
            {
                MessageBox.Show(
                    "File SQLite.Interop.dll tidak ditemukan di:\n" + interop + "\n\n" +
                    "Cara memperbaiki:\n" +
                    "1. Tutup aplikasi, lalu hapus folder bin dan obj di folder FinalPrjk.\n" +
                    "2. Klik kanan Solution > Restore NuGet Packages.\n" +
                    "3. Build > Rebuild Solution, lalu jalankan lagi.",
                    "Belanjaku", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                Db.Initialize();   // membuat database, tabel, dan data awal bila belum ada
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Database SQLite tidak dapat disiapkan.\n\n" +
                    "Cara memperbaiki:\n" +
                    "1. Di Visual Studio: klik kanan Solution > Restore NuGet Packages.\n" +
                    "2. Build > Rebuild Solution, lalu jalankan lagi.\n" +
                    "3. Pastikan folder aplikasi boleh ditulisi (file belanjaku.db dibuat di sana).\n\n" +
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
