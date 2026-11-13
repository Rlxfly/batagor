using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalPrjk
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txtHarga_KeyPress(object sender, KeyPressEventArgs e)
        {
            // izinkan angka, Backspace, dan tombol kontrol lain
            if (char.IsControl(e.KeyChar) || char.IsDigit(e.KeyChar)) return;

            // izinkan koma, tapi hanya satu
            if (e.KeyChar == ',' && !txtHarga.Text.Contains(',')) return;

            e.Handled = true; // tolak karakter lain (huruf, titik, spasi, dll.)
        }
    }
}
