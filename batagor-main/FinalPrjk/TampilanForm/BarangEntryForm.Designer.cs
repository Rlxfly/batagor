namespace FinalPrjk
{
    partial class BarangEntryForm
    {
        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblNama = new System.Windows.Forms.Label();
            this.txtNama = new System.Windows.Forms.TextBox();
            this.lblSatuan = new System.Windows.Forms.Label();
            this.cmbSatuan = new System.Windows.Forms.ComboBox();
            this.lblKategori = new System.Windows.Forms.Label();
            this.cmbKategori = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // lblNama
            // 
            this.lblNama.AutoSize = true;
            this.lblNama.Location = new System.Drawing.Point(20, 64);
            this.lblNama.Name = "lblNama";
            this.lblNama.Text = "Nama barang";
            this.lblNama.TabIndex = 1;
            // 
            // txtNama
            // 
            this.txtNama.Location = new System.Drawing.Point(20, 84);
            this.txtNama.MaxLength = 100;
            this.txtNama.Name = "txtNama";
            this.txtNama.Size = new System.Drawing.Size(360, 23);
            this.txtNama.TabIndex = 2;
            // 
            // lblSatuan
            // 
            this.lblSatuan.AutoSize = true;
            this.lblSatuan.Location = new System.Drawing.Point(20, 124);
            this.lblSatuan.Name = "lblSatuan";
            this.lblSatuan.Text = "Satuan";
            this.lblSatuan.TabIndex = 3;
            // 
            // cmbSatuan
            // 
            this.cmbSatuan.FormattingEnabled = true;
            this.cmbSatuan.Items.AddRange(new object[] {
                "kg",
                "gram",
                "liter",
                "ml",
                "pcs",
                "pak",
                "bungkus",
                "botol",
                "ikat",
                "sisir",
                "butir"});
            this.cmbSatuan.Location = new System.Drawing.Point(20, 144);
            this.cmbSatuan.MaxLength = 20;
            this.cmbSatuan.Name = "cmbSatuan";
            this.cmbSatuan.Size = new System.Drawing.Size(360, 23);
            this.cmbSatuan.TabIndex = 4;
            // 
            // lblKategori
            // 
            this.lblKategori.AutoSize = true;
            this.lblKategori.Location = new System.Drawing.Point(20, 184);
            this.lblKategori.Name = "lblKategori";
            this.lblKategori.Text = "Kategori";
            this.lblKategori.TabIndex = 5;
            // 
            // cmbKategori
            // 
            this.cmbKategori.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbKategori.FormattingEnabled = true;
            this.cmbKategori.Location = new System.Drawing.Point(20, 204);
            this.cmbKategori.Name = "cmbKategori";
            this.cmbKategori.Size = new System.Drawing.Size(360, 23);
            this.cmbKategori.TabIndex = 6;
            // 
            // BarangEntryForm
            // 
            this.ClientSize = new System.Drawing.Size(400, 308);
            this.Controls.Add(this.cmbKategori);
            this.Controls.Add(this.lblKategori);
            this.Controls.Add(this.cmbSatuan);
            this.Controls.Add(this.lblSatuan);
            this.Controls.Add(this.txtNama);
            this.Controls.Add(this.lblNama);
            this.Name = "BarangEntryForm";
            this.Text = "Tambah Barang";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblNama;
        private System.Windows.Forms.TextBox txtNama;
        private System.Windows.Forms.Label lblSatuan;
        private System.Windows.Forms.ComboBox cmbSatuan;
        private System.Windows.Forms.Label lblKategori;
        private System.Windows.Forms.ComboBox cmbKategori;
    }
}
