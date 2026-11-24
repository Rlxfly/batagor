using System;
using System.Data;
using System.Data.SQLite;
using System.Globalization;
using System.Windows.Forms;

namespace FinalPrjk
{
    /// <summary>
    /// Form entri belanja: header nota (tabel belanja) + daftar item (tabel detail_belanja).
    /// Dipakai untuk nota baru maupun mengubah nota yang sudah ada.
    /// Tata letak ada di CatatBelanjaControl.Designer.cs.
    /// </summary>
    internal partial class CatatBelanjaControl : UserControl
    {
        public event EventHandler Saved;
        public int EditId { get; private set; }

        private readonly DataTable _items;

        public CatatBelanjaControl()
        {
            InitializeComponent();

            // Daftar item (detail_belanja) menjadi sumber data grid
            _items = new DataTable();
            _items.Columns.Add("id_barang", typeof(int));
            _items.Columns.Add("Barang", typeof(string));
            _items.Columns.Add("Jumlah", typeof(int));
            _items.Columns.Add("Satuan", typeof(string));
            _items.Columns.Add("Harga Satuan", typeof(decimal));
            _items.Columns.Add("Subtotal", typeof(decimal));

            gridItems.DataSource = _items;
            gridItems.Columns["id_barang"].Visible = false;
            Ui.MoneyColumn(gridItems, "Harga Satuan");
            Ui.MoneyColumn(gridItems, "Subtotal");

            LoadMaster();
            UpdateTotal();
        }

        // ---------------------------------------------------------------------------------
        private void LoadMaster()
        {
            try
            {
                cmbToko.DataSource = Db.Query("SELECT id_toko, nama_toko FROM toko ORDER BY nama_toko");
                cmbToko.DisplayMember = "nama_toko";
                cmbToko.ValueMember = "id_toko";

                cmbBarang.DataSource = Db.Query(
                    "SELECT id_barang, nama_barang, satuan, nama_barang || ' (' || satuan || ')' AS label " +
                    "FROM barang ORDER BY nama_barang");
                cmbBarang.DisplayMember = "label";
                cmbBarang.ValueMember = "id_barang";
            }
            catch (Exception ex)
            {
                Ui.Warn("Data toko/barang gagal dimuat: " + ex.Message);
            }
        }

        /// <summary>Kosongkan form untuk nota baru.</summary>
        public void ResetForm()
        {
            EditId = 0;
            lblMode.Text = "Nota baru";
            _items.Clear();
            dtpTanggal.Value = DateTime.Today;
            nudJumlah.Value = 1;
            txtHarga.Clear();
            if (cmbBarang.Items.Count > 0) cmbBarang.SelectedIndex = 0;
            UpdateTotal();
        }

        /// <summary>Muat nota yang sudah ada untuk diubah.</summary>
        public void LoadForEdit(int idBelanja)
        {
            try
            {
                DataTable h = Db.Query("SELECT tanggal, id_toko FROM belanja WHERE id_belanja=@id", Db.P("@id", idBelanja));
                if (h.Rows.Count == 0) return;

                DataTable d = Db.Query(
                    "SELECT d.id_barang, b.nama_barang, d.jumlah, b.satuan, d.harga_satuan, d.subtotal " +
                    "FROM detail_belanja d INNER JOIN barang b ON b.id_barang = d.id_barang " +
                    "WHERE d.id_belanja=@id ORDER BY d.id_detail", Db.P("@id", idBelanja));

                EditId = idBelanja;
                lblMode.Text = "Mengubah nota #" + idBelanja;
                dtpTanggal.Value = Convert.ToDateTime(h.Rows[0]["tanggal"]);
                cmbToko.SelectedValue = Convert.ToInt64(h.Rows[0]["id_toko"]);

                _items.Clear();
                foreach (DataRow r in d.Rows)
                {
                    _items.Rows.Add(
                        Convert.ToInt32(r["id_barang"]), Convert.ToString(r["nama_barang"]),
                        Convert.ToInt32(r["jumlah"]), Convert.ToString(r["satuan"]),
                        Convert.ToDecimal(r["harga_satuan"]), Convert.ToDecimal(r["subtotal"]));
                }
                UpdateTotal();
            }
            catch (Exception ex)
            {
                Ui.Warn("Nota gagal dimuat: " + ex.Message);
            }
        }

        private void UpdateTotal()
        {
            lblTotal.Text = "Total: " + Fmt.Rupiah(HitungTotal());
        }

        private decimal HitungTotal()
        {
            decimal total = 0;
            foreach (DataRow r in _items.Rows) total += Convert.ToDecimal(r["Subtotal"]);
            return total;
        }

        // ---------------------------------------------------------------------------------
        private void TxtHarga_KeyPress(object sender, KeyPressEventArgs e)
        {
            // izinkan angka, Backspace, dan tombol kontrol lain
            if (char.IsControl(e.KeyChar) || char.IsDigit(e.KeyChar)) return;

            // izinkan koma, tapi hanya satu
            if (e.KeyChar == ',' && !txtHarga.Text.Contains(",")) return;

            e.Handled = true; // tolak karakter lain (huruf, titik, spasi, dll.)
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            if (cmbBarang.SelectedValue == null)
            {
                Ui.Warn("Pilih barang terlebih dahulu. Jika belum ada, tambahkan lewat menu Data Barang.");
                return;
            }

            decimal harga;
            if (!decimal.TryParse(txtHarga.Text.Trim(), NumberStyles.Number, Fmt.Id, out harga) || harga <= 0)
            {
                Ui.Warn("Isi harga satuan dengan angka yang valid (lebih dari 0).");
                txtHarga.Focus();
                return;
            }
            if (harga > 10000000m)
            {
                Ui.Warn("Harga satuan terlalu besar (maksimum Rp 10.000.000).");
                txtHarga.Focus();
                return;
            }

            int jumlah = (int)nudJumlah.Value;
            DataRow barang = ((DataRowView)cmbBarang.SelectedItem).Row;

            _items.Rows.Add(
                Convert.ToInt32(barang["id_barang"]), Convert.ToString(barang["nama_barang"]),
                jumlah, Convert.ToString(barang["satuan"]), harga, harga * jumlah);

            nudJumlah.Value = 1;
            txtHarga.Clear();
            cmbBarang.Focus();
            UpdateTotal();
        }

        private void BtnHapusItem_Click(object sender, EventArgs e)
        {
            if (gridItems.CurrentRow == null)
            {
                Ui.Info("Pilih item pada tabel yang ingin dihapus.");
                return;
            }
            var baris = (DataRowView)gridItems.CurrentRow.DataBoundItem;
            _items.Rows.Remove(baris.Row);
            UpdateTotal();
        }

        private void BtnSimpan_Click(object sender, EventArgs e)
        {
            if (cmbToko.SelectedValue == null)
            {
                Ui.Warn("Pilih toko terlebih dahulu.");
                cmbToko.Focus();
                return;
            }
            if (_items.Rows.Count == 0)
            {
                Ui.Warn("Belum ada item belanja. Tambahkan minimal satu barang dengan tombol Add+.");
                return;
            }

            bool nota = EditId == 0;
            try
            {
                SimpanKeDatabase();
            }
            catch (Exception ex)
            {
                Ui.Warn("Nota gagal disimpan: " + ex.Message);
                return;
            }

            Ui.Info(nota ? "Nota belanja berhasil disimpan." : "Perubahan nota berhasil disimpan.");
            var handler = Saved;
            if (handler != null) handler(this, EventArgs.Empty);   // jangan tulis kode lain setelah baris ini
        }

        private void SimpanKeDatabase()
        {
            decimal total = HitungTotal();
            int idToko = Convert.ToInt32(cmbToko.SelectedValue);

            using (SQLiteConnection conn = Db.Open())
            using (SQLiteTransaction tx = conn.BeginTransaction())
            {
                try
                {
                    int idBelanja;
                    if (EditId == 0)
                    {
                        using (SQLiteCommand cmd = Db.Command(conn, tx,
                            "INSERT INTO belanja (tanggal, id_toko, id_pengguna, total_belanja) " +
                            "VALUES (@t, @toko, @user, @total)",
                            Db.PDate("@t", dtpTanggal.Value), Db.P("@toko", idToko),
                            Db.P("@user", Session.IdPengguna), Db.PMoney("@total", total)))
                        {
                            cmd.ExecuteNonQuery();
                        }
                        idBelanja = (int)conn.LastInsertRowId;
                    }
                    else
                    {
                        idBelanja = EditId;
                        using (SQLiteCommand cmd = Db.Command(conn, tx,
                            "UPDATE belanja SET tanggal=@t, id_toko=@toko, total_belanja=@total WHERE id_belanja=@id",
                            Db.PDate("@t", dtpTanggal.Value), Db.P("@toko", idToko),
                            Db.PMoney("@total", total), Db.P("@id", idBelanja)))
                        {
                            cmd.ExecuteNonQuery();
                        }
                        using (SQLiteCommand cmd = Db.Command(conn, tx,
                            "DELETE FROM detail_belanja WHERE id_belanja=@id", Db.P("@id", idBelanja)))
                        {
                            cmd.ExecuteNonQuery();
                        }
                    }

                    foreach (DataRow r in _items.Rows)
                    {
                        using (SQLiteCommand cmd = Db.Command(conn, tx,
                            "INSERT INTO detail_belanja (id_belanja, id_barang, jumlah, harga_satuan, subtotal) " +
                            "VALUES (@b, @barang, @jml, @harga, @sub)",
                            Db.P("@b", idBelanja), Db.P("@barang", Convert.ToInt32(r["id_barang"])),
                            Db.P("@jml", Convert.ToInt32(r["Jumlah"])),
                            Db.PMoney("@harga", Convert.ToDecimal(r["Harga Satuan"])),
                            Db.PMoney("@sub", Convert.ToDecimal(r["Subtotal"]))))
                        {
                            cmd.ExecuteNonQuery();
                        }
                    }

                    tx.Commit();
                }
                catch
                {
                    tx.Rollback();
                    throw;
                }
            }
        }
    }
}
