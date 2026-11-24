namespace FinalPrjk
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelSidebar = new System.Windows.Forms.Panel();
            this.btnKeluar = new System.Windows.Forms.Button();
            this.btnKategori = new System.Windows.Forms.Button();
            this.btnToko = new System.Windows.Forms.Button();
            this.btnBarang = new System.Windows.Forms.Button();
            this.btnRiwayat = new System.Windows.Forms.Button();
            this.btnCatat = new System.Windows.Forms.Button();
            this.lblUser = new System.Windows.Forms.Label();
            this.lblBrand = new System.Windows.Forms.Label();
            this.panelContent = new System.Windows.Forms.Panel();
            this.panelSidebar.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelSidebar
            // 
            this.panelSidebar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(217)))), ((int)(((byte)(170)))));
            this.panelSidebar.Controls.Add(this.btnKeluar);
            this.panelSidebar.Controls.Add(this.btnKategori);
            this.panelSidebar.Controls.Add(this.btnToko);
            this.panelSidebar.Controls.Add(this.btnBarang);
            this.panelSidebar.Controls.Add(this.btnRiwayat);
            this.panelSidebar.Controls.Add(this.btnCatat);
            this.panelSidebar.Controls.Add(this.lblUser);
            this.panelSidebar.Controls.Add(this.lblBrand);
            this.panelSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelSidebar.Location = new System.Drawing.Point(0, 0);
            this.panelSidebar.Name = "panelSidebar";
            this.panelSidebar.Size = new System.Drawing.Size(170, 560);
            this.panelSidebar.TabIndex = 0;
            // 
            // lblBrand
            // 
            this.lblBrand.AutoSize = true;
            this.lblBrand.Font = new System.Drawing.Font("Arial Rounded MT Bold", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBrand.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblBrand.Location = new System.Drawing.Point(20, 24);
            this.lblBrand.Name = "lblBrand";
            this.lblBrand.Size = new System.Drawing.Size(130, 32);
            this.lblBrand.TabIndex = 0;
            this.lblBrand.Text = "Belanjaku";
            // 
            // lblUser
            // 
            this.lblUser.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(63)))), ((int)(((byte)(0)))));
            this.lblUser.Location = new System.Drawing.Point(14, 62);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(146, 40);
            this.lblUser.TabIndex = 1;
            // 
            // btnCatat
            // 
            this.btnCatat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(217)))), ((int)(((byte)(170)))));
            this.btnCatat.FlatAppearance.BorderSize = 0;
            this.btnCatat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCatat.Location = new System.Drawing.Point(12, 115);
            this.btnCatat.Name = "btnCatat";
            this.btnCatat.Size = new System.Drawing.Size(146, 32);
            this.btnCatat.TabIndex = 2;
            this.btnCatat.Text = "Catat Belanjaan";
            this.btnCatat.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCatat.UseVisualStyleBackColor = false;
            this.btnCatat.Click += new System.EventHandler(this.Menu_Click);
            // 
            // btnRiwayat
            // 
            this.btnRiwayat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(217)))), ((int)(((byte)(170)))));
            this.btnRiwayat.FlatAppearance.BorderSize = 0;
            this.btnRiwayat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRiwayat.Location = new System.Drawing.Point(12, 153);
            this.btnRiwayat.Name = "btnRiwayat";
            this.btnRiwayat.Size = new System.Drawing.Size(146, 32);
            this.btnRiwayat.TabIndex = 3;
            this.btnRiwayat.Text = "Riwayat Belanja";
            this.btnRiwayat.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRiwayat.UseVisualStyleBackColor = false;
            this.btnRiwayat.Click += new System.EventHandler(this.Menu_Click);
            // 
            // btnBarang
            // 
            this.btnBarang.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(217)))), ((int)(((byte)(170)))));
            this.btnBarang.FlatAppearance.BorderSize = 0;
            this.btnBarang.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBarang.Location = new System.Drawing.Point(12, 191);
            this.btnBarang.Name = "btnBarang";
            this.btnBarang.Size = new System.Drawing.Size(146, 32);
            this.btnBarang.TabIndex = 4;
            this.btnBarang.Text = "Data Barang";
            this.btnBarang.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBarang.UseVisualStyleBackColor = false;
            this.btnBarang.Click += new System.EventHandler(this.Menu_Click);
            // 
            // btnToko
            // 
            this.btnToko.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(217)))), ((int)(((byte)(170)))));
            this.btnToko.FlatAppearance.BorderSize = 0;
            this.btnToko.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnToko.Location = new System.Drawing.Point(12, 229);
            this.btnToko.Name = "btnToko";
            this.btnToko.Size = new System.Drawing.Size(146, 32);
            this.btnToko.TabIndex = 5;
            this.btnToko.Text = "Data Toko";
            this.btnToko.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnToko.UseVisualStyleBackColor = false;
            this.btnToko.Click += new System.EventHandler(this.Menu_Click);
            // 
            // btnKategori
            // 
            this.btnKategori.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(217)))), ((int)(((byte)(170)))));
            this.btnKategori.FlatAppearance.BorderSize = 0;
            this.btnKategori.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKategori.Location = new System.Drawing.Point(12, 267);
            this.btnKategori.Name = "btnKategori";
            this.btnKategori.Size = new System.Drawing.Size(146, 32);
            this.btnKategori.TabIndex = 6;
            this.btnKategori.Text = "Data Kategori";
            this.btnKategori.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnKategori.UseVisualStyleBackColor = false;
            this.btnKategori.Click += new System.EventHandler(this.Menu_Click);
            // 
            // btnKeluar
            // 
            this.btnKeluar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(212)))));
            this.btnKeluar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKeluar.Location = new System.Drawing.Point(12, 508);
            this.btnKeluar.Name = "btnKeluar";
            this.btnKeluar.Size = new System.Drawing.Size(146, 32);
            this.btnKeluar.TabIndex = 7;
            this.btnKeluar.Text = "Keluar";
            this.btnKeluar.UseVisualStyleBackColor = false;
            this.btnKeluar.Click += new System.EventHandler(this.btnKeluar_Click);
            // 
            // panelContent
            // 
            this.panelContent.BackColor = System.Drawing.Color.OldLace;
            this.panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContent.Location = new System.Drawing.Point(170, 0);
            this.panelContent.Name = "panelContent";
            this.panelContent.Size = new System.Drawing.Size(730, 560);
            this.panelContent.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.OldLace;
            this.ClientSize = new System.Drawing.Size(900, 560);
            this.Controls.Add(this.panelContent);
            this.Controls.Add(this.panelSidebar);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Belanjaku - Daftar Belanja Bulanan Keluarga";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panelSidebar.ResumeLayout(false);
            this.panelSidebar.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelSidebar;
        private System.Windows.Forms.Label lblBrand;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.Button btnCatat;
        private System.Windows.Forms.Button btnRiwayat;
        private System.Windows.Forms.Button btnBarang;
        private System.Windows.Forms.Button btnToko;
        private System.Windows.Forms.Button btnKategori;
        private System.Windows.Forms.Button btnKeluar;
        private System.Windows.Forms.Panel panelContent;
    }
}
