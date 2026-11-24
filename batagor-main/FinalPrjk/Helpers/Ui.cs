using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace FinalPrjk
{
    internal static class Fmt
    {
        public static readonly CultureInfo Id = new CultureInfo("id-ID");

        /// <summary>Contoh: 128000 menjadi "Rp 128.000".</summary>
        public static string Rupiah(decimal nilai)
        {
            string format = nilai == Math.Floor(nilai) ? "N0" : "N2";
            return "Rp " + nilai.ToString(format, Id);
        }
    }

    /// <summary>Warna tema (sama dengan desain awal Form1), format kolom, dan kotak pesan.</summary>
    internal static class Ui
    {
        public static readonly Color SidebarColor = Color.FromArgb(255, 217, 170);
        public static readonly Color BrownColor = Color.FromArgb(114, 63, 0);
        public static readonly Color GreenColor = Color.FromArgb(212, 255, 214);
        public static readonly Color RedColor = Color.FromArgb(255, 214, 212);
        public static readonly Color BlueColor = Color.FromArgb(212, 230, 255);
        public static readonly Color BarColor = Color.FromArgb(229, 212, 191);

        /// <summary>Format kolom uang: 128000 tampil "128.000", rata kanan.</summary>
        public static void MoneyColumn(DataGridView g, string name)
        {
            if (!g.Columns.Contains(name)) return;
            DataGridViewColumn c = g.Columns[name];
            c.DefaultCellStyle.Format = "#,##0.##";
            c.DefaultCellStyle.FormatProvider = Fmt.Id;
            c.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            c.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
        }

        public static void Info(string pesan)
        {
            MessageBox.Show(pesan, "Belanjaku", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static void Warn(string pesan)
        {
            MessageBox.Show(pesan, "Belanjaku", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public static bool Confirm(string pesan)
        {
            return MessageBox.Show(pesan, "Konfirmasi", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes;
        }
    }
}
