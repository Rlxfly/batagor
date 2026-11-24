using System;
using System.Data;
using System.Windows.Forms;

namespace FinalPrjk
{
    /// <summary>Form login (tabel pengguna). Menentukan peran dan hak akses pengguna.</summary>
    internal partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void BtnMasuk_Click(object sender, EventArgs e)
        {
            string user = txtUser.Text.Trim();
            string pass = txtPass.Text;
            if (user.Length == 0 || pass.Length == 0)
            {
                Ui.Warn("Username dan password wajib diisi.");
                return;
            }

            DataTable dt;
            try
            {
                dt = Db.Query("SELECT id_pengguna, nama_lengkap, [password], peran FROM pengguna WHERE username=@u",
                              Db.P("@u", user));
            }
            catch (Exception ex)
            {
                Ui.Warn("Tidak dapat terhubung ke database: " + ex.Message);
                return;
            }

            if (dt.Rows.Count == 0 || !Security.Verify(pass, Convert.ToString(dt.Rows[0]["password"])))
            {
                Ui.Warn("Username atau password salah.");
                txtPass.Clear();
                txtPass.Focus();
                return;
            }

            Session.IdPengguna = Convert.ToInt32(dt.Rows[0]["id_pengguna"]);
            Session.NamaLengkap = Convert.ToString(dt.Rows[0]["nama_lengkap"]);
            Session.Peran = Convert.ToString(dt.Rows[0]["peran"]);
            Session.LoggedOut = false;
            DialogResult = DialogResult.OK;
        }
    }
}
