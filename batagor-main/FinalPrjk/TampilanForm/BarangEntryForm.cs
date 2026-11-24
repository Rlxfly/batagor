using System;
using System.Data;
using System.Windows.Forms;

namespace FinalPrjk
{
    internal partial class BarangEntryForm : EntryFormBase
    {
        private readonly int _id;

        public BarangEntryForm(int id)
        {
            InitializeComponent();
            _id = id;
            Text = id == 0 ? "Tambah Barang" : "Ubah Barang";

            cmbKategori.DataSource = Db.Query("SELECT id_kategori, nama_kategori FROM kategori ORDER BY nama_kategori");
            cmbKategori.DisplayMember = "nama_kategori";
            cmbKategori.ValueMember = "id_kategori";

            if (id != 0)
            {
                DataTable dt = Db.Query("SELECT nama_barang, satuan, id_kategori FROM barang WHERE id_barang=@id", Db.P("@id", id));
                if (dt.Rows.Count > 0)
                {
                    txtNama.Text = Convert.ToString(dt.Rows[0]["nama_barang"]);
                    cmbSatuan.Text = Convert.ToString(dt.Rows[0]["satuan"]);
                    cmbKategori.SelectedValue = Convert.ToInt64(dt.Rows[0]["id_kategori"]);
                }
            }
        }

        protected override bool Validasi()
        {
            string nama = txtNama.Text.Trim();
            if (nama.Length == 0)
            {
                Ui.Warn("Nama barang wajib diisi.");
                txtNama.Focus();
                return false;
            }
            if (cmbSatuan.Text.Trim().Length == 0)
            {
                Ui.Warn("Satuan wajib diisi (contoh: kg, liter, pcs).");
                cmbSatuan.Focus();
                return false;
            }
            if (cmbKategori.SelectedValue == null)
            {
                Ui.Warn("Pilih kategori. Jika belum ada, minta pengelola data menambahkan kategori terlebih dahulu.");
                cmbKategori.Focus();
                return false;
            }
            int sama = Convert.ToInt32(Db.Scalar(
                "SELECT COUNT(*) FROM barang WHERE nama_barang=@n AND satuan=@s AND id_barang<>@id",
                Db.P("@n", nama), Db.P("@s", cmbSatuan.Text.Trim()), Db.P("@id", _id)));
            if (sama > 0)
            {
                Ui.Warn("Barang dengan nama dan satuan yang sama sudah ada.");
                txtNama.Focus();
                return false;
            }
            return true;
        }

        protected override bool Simpan()
        {
            try
            {
                string nama = txtNama.Text.Trim();
                string satuan = cmbSatuan.Text.Trim();
                int idKategori = Convert.ToInt32(cmbKategori.SelectedValue);
                if (_id == 0)
                    Db.Exec("INSERT INTO barang (nama_barang, satuan, id_kategori) VALUES (@n, @s, @k)",
                            Db.P("@n", nama), Db.P("@s", satuan), Db.P("@k", idKategori));
                else
                    Db.Exec("UPDATE barang SET nama_barang=@n, satuan=@s, id_kategori=@k WHERE id_barang=@id",
                            Db.P("@n", nama), Db.P("@s", satuan), Db.P("@k", idKategori), Db.P("@id", _id));
                return true;
            }
            catch (Exception ex)
            {
                Ui.Warn("Data gagal disimpan: " + ex.Message);
                return false;
            }
        }
    }
}
