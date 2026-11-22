using System;
using System.Data;

namespace FinalPrjk
{
    internal partial class TokoEntryForm : EntryFormBase
    {
        private readonly int _id;

        public TokoEntryForm(int id)
        {
            InitializeComponent();
            _id = id;
            Text = id == 0 ? "Tambah Toko" : "Ubah Toko";

            if (id != 0)
            {
                DataTable dt = Db.Query("SELECT nama_toko, lokasi FROM toko WHERE id_toko=@id", Db.P("@id", id));
                if (dt.Rows.Count > 0)
                {
                    txtNama.Text = Convert.ToString(dt.Rows[0]["nama_toko"]);
                    txtLokasi.Text = Convert.ToString(dt.Rows[0]["lokasi"]);
                }
            }
        }

        protected override bool Validasi()
        {
            string nama = txtNama.Text.Trim();
            if (nama.Length == 0)
            {
                Ui.Warn("Nama toko wajib diisi.");
                txtNama.Focus();
                return false;
            }
            int sama = Convert.ToInt32(Db.Scalar(
                "SELECT COUNT(*) FROM toko WHERE nama_toko=@n AND ISNULL(lokasi,'')=@l AND id_toko<>@id",
                Db.P("@n", nama), Db.P("@l", txtLokasi.Text.Trim()), Db.P("@id", _id)));
            if (sama > 0)
            {
                Ui.Warn("Toko dengan nama dan lokasi yang sama sudah ada.");
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
                string lokasi = txtLokasi.Text.Trim();
                object lokasiDb = lokasi.Length == 0 ? null : lokasi;
                if (_id == 0)
                    Db.Exec("INSERT INTO toko (nama_toko, lokasi) VALUES (@n, @l)", Db.P("@n", nama), Db.P("@l", lokasiDb));
                else
                    Db.Exec("UPDATE toko SET nama_toko=@n, lokasi=@l WHERE id_toko=@id",
                            Db.P("@n", nama), Db.P("@l", lokasiDb), Db.P("@id", _id));
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
