using System;
using System.Data;

namespace FinalPrjk
{
    internal partial class KategoriEntryForm : EntryFormBase
    {
        private readonly int _id;

        public KategoriEntryForm(int id)
        {
            InitializeComponent();
            _id = id;
            Text = id == 0 ? "Tambah Kategori" : "Ubah Kategori";

            if (id != 0)
            {
                DataTable dt = Db.Query("SELECT nama_kategori FROM kategori WHERE id_kategori=@id", Db.P("@id", id));
                if (dt.Rows.Count > 0) txtNama.Text = Convert.ToString(dt.Rows[0][0]);
            }
        }

        protected override bool Validasi()
        {
            string nama = txtNama.Text.Trim();
            if (nama.Length == 0)
            {
                Ui.Warn("Nama kategori wajib diisi.");
                txtNama.Focus();
                return false;
            }
            int sama = Convert.ToInt32(Db.Scalar(
                "SELECT COUNT(*) FROM kategori WHERE nama_kategori=@n AND id_kategori<>@id",
                Db.P("@n", nama), Db.P("@id", _id)));
            if (sama > 0)
            {
                Ui.Warn("Kategori dengan nama tersebut sudah ada.");
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
                if (_id == 0)
                    Db.Exec("INSERT INTO kategori (nama_kategori) VALUES (@n)", Db.P("@n", nama));
                else
                    Db.Exec("UPDATE kategori SET nama_kategori=@n WHERE id_kategori=@id", Db.P("@n", nama), Db.P("@id", _id));
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
