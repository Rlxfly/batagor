using System;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;

namespace FinalPrjk
{
    /// <summary>
    /// Form list barang: tampil data, cari, Tambah / Ubah / Hapus.
    /// Tata letak ada di BarangForm.Designer.cs (bisa dibuka di Design view). Form entri dibuka sebagai dialog BarangEntryForm.
    /// </summary>
    internal partial class BarangForm : Form
    {
        private const string SqlSelect =
            "SELECT b.id_barang AS ID, b.nama_barang AS [Nama Barang], b.satuan AS Satuan, k.nama_kategori AS Kategori " +
            "FROM barang b INNER JOIN kategori k ON k.id_kategori = b.id_kategori ORDER BY b.nama_barang";
        private const string SqlDelete = "DELETE FROM barang WHERE id_barang=@id";

        private readonly bool _canEditDelete;
        private DataTable _table;

        public BarangForm(bool canAdd, bool canEditDelete)
        {
            InitializeComponent();
            _canEditDelete = canEditDelete;

            gridData.AutoGenerateColumns = false;   // kolom sudah didesain di Designer
            btnTambah.Visible = canAdd;
            btnUbah.Visible = canEditDelete;
            btnHapus.Visible = canEditDelete;

            LoadData();
        }

        public void LoadData()
        {
            int selectedId = ListHelper.SelectedId(gridData);
            try
            {
                _table = Db.Query(SqlSelect);
            }
            catch (Exception ex)
            {
                Ui.Warn("Data gagal dimuat: " + ex.Message);
                return;
            }
            gridData.DataSource = _table;
            ApplyFilter();
            ListHelper.SelectRow(gridData, selectedId);
        }

        private void ApplyFilter()
        {
            if (_table == null) return;
            ListHelper.Filter(_table, txtCari.Text);
            lblJumlah.Text = "Jumlah data: " + _table.DefaultView.Count;
        }

        private void txtCari_TextChanged(object sender, EventArgs e)
        {
            ApplyFilter();
        }

        private void btnTambah_Click(object sender, EventArgs e)
        {
            OpenEntry(0);
        }

        private void btnUbah_Click(object sender, EventArgs e)
        {
            EditSelected();
        }

        private void gridData_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (_canEditDelete && e.RowIndex >= 0) EditSelected();
        }

        private void OpenEntry(int id)
        {
            using (var f = new BarangEntryForm(id))
            {
                if (f.ShowDialog(ParentForm) == DialogResult.OK) LoadData();
            }
        }

        private void EditSelected()
        {
            int id = ListHelper.SelectedId(gridData);
            if (id == 0)
            {
                Ui.Info("Pilih satu data pada tabel terlebih dahulu.");
                return;
            }
            OpenEntry(id);
        }

        private void btnHapus_Click(object sender, EventArgs e)
        {
            int id = ListHelper.SelectedId(gridData);
            if (id == 0)
            {
                Ui.Info("Pilih satu data pada tabel terlebih dahulu.");
                return;
            }
            if (!Ui.Confirm("Hapus barang yang dipilih?")) return;

            try
            {
                Db.Exec(SqlDelete, Db.P("@id", id));
                LoadData();
            }
            catch (SQLiteException ex)
            {
                if (ex.ResultCode == SQLiteErrorCode.Constraint || ex.Message.Contains("constraint"))
                    Ui.Warn("Data ini tidak dapat dihapus karena masih dipakai oleh data lain.");
                else
                    Ui.Warn("Data gagal dihapus: " + ex.Message);
            }
        }
    }
}
