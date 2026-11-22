using System;
using System.Drawing;
using System.Windows.Forms;

namespace FinalPrjk
{
    /// <summary>
    /// Jendela utama: sidebar navigasi (desain awal "Belanjaku") + area konten yang menampung
    /// form list / form entri sesuai menu dan hak akses pengguna.
    /// </summary>
    public partial class Form1 : Form
    {
        private Button _aktif;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            lblUser.Text = "Halo, " + Session.NamaLengkap + "\r\n(" + Session.PeranLabel + ")";

            // Hak akses menu
            btnCatat.Visible = Session.IsAnggota;                       // mencatat nota belanja
            btnRiwayat.Visible = true;                                  // semua peran dapat melihat riwayat
            btnBarang.Visible = Session.IsAnggota || Session.IsPengelola;
            btnToko.Visible = Session.IsAnggota || Session.IsPengelola;
            btnKategori.Visible = Session.IsPengelola;

            int y = 115;
            foreach (Button b in new Button[] { btnCatat, btnRiwayat, btnBarang, btnToko, btnKategori })
            {
                if (!b.Visible) continue;
                b.Top = y;
                y += 38;
            }

            Navigate(Session.IsAnggota ? "catat" : "riwayat");
        }

        private void Menu_Click(object sender, EventArgs e)
        {
            if (sender == btnCatat) Navigate("catat");
            else if (sender == btnRiwayat) Navigate("riwayat");
            else if (sender == btnBarang) Navigate("barang");
            else if (sender == btnToko) Navigate("toko");
            else if (sender == btnKategori) Navigate("kategori");
        }

        private void btnKeluar_Click(object sender, EventArgs e)
        {
            if (!Ui.Confirm("Keluar dari akun " + Session.NamaLengkap + "?")) return;
            Session.LoggedOut = true;
            Close();
        }

        // ------------------------------------------------------------------------------
        private void Navigate(string halaman)
        {
            bool tambahMaster = Session.IsAnggota || Session.IsPengelola;   // Anggota hanya boleh menambah
            bool ubahHapusMaster = Session.IsPengelola;

            if (halaman == "catat")
            {
                var p = new CatatBelanjaControl();
                p.Saved += CatatSaved;
                Tampilkan(p, btnCatat);
            }
            else if (halaman == "riwayat")
            {
                var p = new RiwayatControl();
                p.AddRequested += delegate { Navigate("catat"); };
                p.EditRequested += delegate (int id) { UbahNota(id); };
                Tampilkan(p, btnRiwayat);
            }
            else if (halaman == "barang")
            {
                Tampilkan(new BarangForm(tambahMaster, ubahHapusMaster), btnBarang);
            }
            else if (halaman == "toko")
            {
                Tampilkan(new TokoForm(tambahMaster, ubahHapusMaster), btnToko);
            }
            else if (halaman == "kategori")
            {
                Tampilkan(new KategoriForm(Session.IsPengelola, Session.IsPengelola), btnKategori);
            }
        }

        private void UbahNota(int idBelanja)
        {
            var p = new CatatBelanjaControl();
            p.LoadForEdit(idBelanja);
            p.Saved += CatatSaved;
            Tampilkan(p, btnCatat);
        }

        private void CatatSaved(object sender, EventArgs e)
        {
            var p = (CatatBelanjaControl)sender;
            if (p.EditId > 0) Navigate("riwayat");   // selesai mengubah nota: kembali ke daftar riwayat
            else p.ResetForm();                       // nota baru: siap mencatat nota berikutnya
        }

        private void Tampilkan(Control halaman, Button menuAktif)
        {
            panelContent.SuspendLayout();
            while (panelContent.Controls.Count > 0)
            {
                Control lama = panelContent.Controls[0];
                panelContent.Controls.Remove(lama);
                lama.Dispose();
            }
            var form = halaman as Form;
            if (form != null)
            {
                form.TopLevel = false;                       // form ditanam di area konten
                form.FormBorderStyle = FormBorderStyle.None;
            }
            halaman.Dock = DockStyle.Fill;
            panelContent.Controls.Add(halaman);
            panelContent.ResumeLayout();
            if (form != null) form.Show();

            if (_aktif != null) _aktif.BackColor = Ui.SidebarColor;
            _aktif = menuAktif;
            _aktif.BackColor = Color.FromArgb(255, 236, 205);
        }
    }
}
