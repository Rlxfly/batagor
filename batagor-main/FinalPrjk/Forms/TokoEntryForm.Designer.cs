namespace FinalPrjk
{
    partial class TokoEntryForm
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
            this.lblLokasi = new System.Windows.Forms.Label();
            this.txtLokasi = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblNama
            // 
            this.lblNama.AutoSize = true;
            this.lblNama.Location = new System.Drawing.Point(20, 64);
            this.lblNama.Name = "lblNama";
            this.lblNama.Text = "Nama toko";
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
            // lblLokasi
            // 
            this.lblLokasi.AutoSize = true;
            this.lblLokasi.Location = new System.Drawing.Point(20, 124);
            this.lblLokasi.Name = "lblLokasi";
            this.lblLokasi.Text = "Lokasi / alamat";
            this.lblLokasi.TabIndex = 3;
            // 
            // txtLokasi
            // 
            this.txtLokasi.Location = new System.Drawing.Point(20, 144);
            this.txtLokasi.MaxLength = 150;
            this.txtLokasi.Name = "txtLokasi";
            this.txtLokasi.Size = new System.Drawing.Size(360, 23);
            this.txtLokasi.TabIndex = 4;
            // 
            // TokoEntryForm
            // 
            this.ClientSize = new System.Drawing.Size(400, 248);
            this.Controls.Add(this.txtLokasi);
            this.Controls.Add(this.lblLokasi);
            this.Controls.Add(this.txtNama);
            this.Controls.Add(this.lblNama);
            this.Name = "TokoEntryForm";
            this.Text = "Tambah Toko";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblNama;
        private System.Windows.Forms.TextBox txtNama;
        private System.Windows.Forms.Label lblLokasi;
        private System.Windows.Forms.TextBox txtLokasi;
    }
}
