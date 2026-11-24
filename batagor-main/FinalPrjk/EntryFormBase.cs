using System;
using System.Windows.Forms;

namespace FinalPrjk
{
    /// <summary>
    /// Kerangka form entri (dialog terpisah dari form list): judul, tombol Simpan dan Batal.
    /// Tata letaknya ada di EntryFormBase.Designer.cs. Kelas ini sengaja TIDAK abstract supaya
    /// Visual Studio dapat membuat instance-nya saat membuka Design view form turunan.
    /// </summary>
    internal partial class EntryFormBase : Form
    {
        public EntryFormBase()
        {
            InitializeComponent();
        }

        /// <summary>Judul pada heading mengikuti properti Text form.</summary>
        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);
            if (lblJudul != null) lblJudul.Text = Text;
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            if (Validasi() && Simpan())
            {
                DialogResult = DialogResult.OK;
            }
        }

        /// <summary>Periksa isian. Tampilkan pesan dan kembalikan false bila tidak valid.</summary>
        protected virtual bool Validasi()
        {
            return true;
        }

        /// <summary>Simpan ke database. Kembalikan true bila berhasil.</summary>
        protected virtual bool Simpan()
        {
            return true;
        }
    }
}
