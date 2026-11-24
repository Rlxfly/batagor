using System;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;

namespace FinalPrjk
{
    /// <summary>
    /// Form list riwayat belanja per bulan: daftar nota (belanja) di atas, rincian item (detail_belanja) di bawah.
    /// Kepala keluarga dan pengelola hanya dapat membaca; anggota keluarga dapat menambah, mengubah, menghapus nota.
    /// Tata letak ada di RiwayatControl.Designer.cs.
    /// </summary>
    internal partial class RiwayatControl : UserControl
    {
        public event Action AddRequested;
        public event Action<int> EditRequested;

        private DataTable _nota;

        public RiwayatControl()
        {
            InitializeComponent();

            // Hak akses: hanya Anggota yang boleh menambah / mengubah / menghapus nota
            bool anggota = Session.IsAnggota;
            btnTambah.Visible = anggota;
            btnUbah.Visible = anggota;
            btnHapus.Visible = anggota;
            lblModeBaca.Visible = !anggota;
            lblModeBaca.Location = new System.Drawing.Point(11, 6);

            LoadNota();
        }

        private void dtpBulan_ValueChanged(object sender, EventArgs e)
        {
            LoadNota();
        }

        private void gridNota_SelectionChanged(object sender, EventArgs e)
        {
            LoadDetail();
        }

        private void BtnTambah_Click(object sender, EventArgs e)
        {
            var h = AddRequested;
            if (h != null) h();
        }

        private DateTime AwalBulan()
        {
            return new DateTime(dtpBulan.Value.Year, dtpBulan.Value.Month, 1);
        }

        private int SelectedId()
        {
            if (gridNota.CurrentRow == null || !gridNota.Columns.Contains("ID")) return 0;
            object v = gridNota.CurrentRow.Cells["ID"].Value;
            return (v == null || v == DBNull.Value) ? 0 : Convert.ToInt32(v);
        }

        private void LoadNota()
        {
            DateTime awal = AwalBulan();
            try
            {
                _nota = Db.Query(
                    "SELECT b.id_belanja AS ID, b.tanggal AS Tanggal, t.nama_toko AS Toko, " +
                    "p.nama_lengkap AS [Dicatat Oleh], b.total_belanja AS Total " +
                    "FROM belanja b INNER JOIN toko t ON t.id_toko = b.id_toko " +
                    "INNER JOIN pengguna p ON p.id_pengguna = b.id_pengguna " +
                    "WHERE b.tanggal >= @awal AND b.tanggal < @akhir " +
                    "ORDER BY b.tanggal DESC, b.id_belanja DESC",
                    Db.PDate("@awal", awal), Db.PDate("@akhir", awal.AddMonths(1)));
            }
            catch (Exception ex)
            {
                Ui.Warn("Riwayat gagal dimuat: " + ex.Message);
                return;
            }

            gridNota.DataSource = _nota;
            gridNota.Columns["ID"].Visible = false;
            gridNota.Columns["Tanggal"].DefaultCellStyle.Format = "dd MMM yyyy";
            gridNota.Columns["Tanggal"].DefaultCellStyle.FormatProvider = Fmt.Id;
            Ui.MoneyColumn(gridNota, "Total");

            decimal total = 0;
            object jumlah = _nota.Compute("SUM(Total)", "");
            if (jumlah != null && jumlah != DBNull.Value) total = Convert.ToDecimal(jumlah);
            lblTotalBulan.Text = "Total bulan ini: " + Fmt.Rupiah(total) + "  (" + _nota.Rows.Count + " nota)";

            LoadDetail();
        }

        private void LoadDetail()
        {
            int id = SelectedId();
            if (id == 0)
            {
                gridDetail.DataSource = null;
                return;
            }
            try
            {
                DataTable d = Db.Query(
                    "SELECT br.nama_barang AS Barang, d.jumlah AS Jumlah, br.satuan AS Satuan, " +
                    "d.harga_satuan AS [Harga Satuan], d.subtotal AS Subtotal " +
                    "FROM detail_belanja d INNER JOIN barang br ON br.id_barang = d.id_barang " +
                    "WHERE d.id_belanja=@id ORDER BY d.id_detail", Db.P("@id", id));
                gridDetail.DataSource = d;
                Ui.MoneyColumn(gridDetail, "Harga Satuan");
                Ui.MoneyColumn(gridDetail, "Subtotal");
            }
            catch (Exception ex)
            {
                Ui.Warn("Detail nota gagal dimuat: " + ex.Message);
            }
        }

        private void BtnUbah_Click(object sender, EventArgs e)
        {
            int id = SelectedId();
            if (id == 0)
            {
                Ui.Info("Pilih satu nota pada tabel terlebih dahulu.");
                return;
            }
            var h = EditRequested;
            if (h != null) h(id);
        }

        private void BtnHapus_Click(object sender, EventArgs e)
        {
            int id = SelectedId();
            if (id == 0)
            {
                Ui.Info("Pilih satu nota pada tabel terlebih dahulu.");
                return;
            }
            if (!Ui.Confirm("Hapus nota ini beserta seluruh itemnya?")) return;

            try
            {
                using (SQLiteConnection conn = Db.Open())
                using (SQLiteTransaction tx = conn.BeginTransaction())
                {
                    try
                    {
                        using (SQLiteCommand c1 = Db.Command(conn, tx, "DELETE FROM detail_belanja WHERE id_belanja=@id", Db.P("@id", id)))
                        {
                            c1.ExecuteNonQuery();
                        }
                        using (SQLiteCommand c2 = Db.Command(conn, tx, "DELETE FROM belanja WHERE id_belanja=@id", Db.P("@id", id)))
                        {
                            c2.ExecuteNonQuery();
                        }
                        tx.Commit();
                    }
                    catch
                    {
                        tx.Rollback();
                        throw;
                    }
                }
                LoadNota();
            }
            catch (Exception ex)
            {
                Ui.Warn("Nota gagal dihapus: " + ex.Message);
            }
        }
    }
}
