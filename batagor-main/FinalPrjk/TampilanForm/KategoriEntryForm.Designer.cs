namespace FinalPrjk
{
    partial class KategoriEntryForm
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
            this.SuspendLayout();
            // 
            // lblNama
            // 
            this.lblNama.AutoSize = true;
            this.lblNama.Location = new System.Drawing.Point(20, 64);
            this.lblNama.Name = "lblNama";
            this.lblNama.Text = "Nama kategori";
            this.lblNama.TabIndex = 1;
            // 
            // txtNama
            // 
            this.txtNama.Location = new System.Drawing.Point(20, 84);
            this.txtNama.MaxLength = 50;
            this.txtNama.Name = "txtNama";
            this.txtNama.Size = new System.Drawing.Size(360, 23);
            this.txtNama.TabIndex = 2;
            // 
            // KategoriEntryForm
            // 
            this.ClientSize = new System.Drawing.Size(400, 188);
            this.Controls.Add(this.txtNama);
            this.Controls.Add(this.lblNama);
            this.Name = "KategoriEntryForm";
            this.Text = "Tambah Kategori";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblNama;
        private System.Windows.Forms.TextBox txtNama;
    }
}
