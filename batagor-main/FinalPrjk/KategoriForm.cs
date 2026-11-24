using System;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;

namespace FinalPrjk
{
    /// <summary>
    /// Form list kategori: tampil data, cari, Tambah / Ubah / Hapus.
    /// Tata letak ada di KategoriForm.Designer.cs (bisa dibuka di Design view). Form entri dibuka sebagai dialog KategoriEntryForm.
    /// </summary>
    internal partial class KategoriForm : Form
    {
        private const string SqlSelect =
            "SELECT id_kategori AS ID, nama_kategori AS [Nama Kategori] FROM kategori ORDER BY nama_kategori";
        private const string SqlDelete = "DELETE FROM kategori WHERE id_kategori=@id";

        private readonly bool _canEditDelete;
        private DataTable _table;

        public KategoriForm(bool canAdd, bool canEditDelete)
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
            using (var f = new KategoriEntryForm(id))
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
            if (!Ui.Confirm("Hapus kategori yang dipilih?")) return;

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
