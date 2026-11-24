namespace FinalPrjk
{
    partial class RiwayatControl
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblJudul = new System.Windows.Forms.Label();
            this.lblBulan = new System.Windows.Forms.Label();
            this.dtpBulan = new System.Windows.Forms.DateTimePicker();
            this.lblTotalBulan = new System.Windows.Forms.Label();
            this.gridNota = new System.Windows.Forms.DataGridView();
            this.lblDetail = new System.Windows.Forms.Label();
            this.gridDetail = new System.Windows.Forms.DataGridView();
            this.panelBar = new System.Windows.Forms.Panel();
            this.btnTambah = new System.Windows.Forms.Button();
            this.btnUbah = new System.Windows.Forms.Button();
            this.btnHapus = new System.Windows.Forms.Button();
            this.lblModeBaca = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gridNota)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridDetail)).BeginInit();
            this.panelBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblJudul
            // 
            this.lblJudul.AutoSize = true;
            this.lblJudul.Font = new System.Drawing.Font("Arial Rounded MT Bold", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblJudul.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(63)))), ((int)(((byte)(0)))));
            this.lblJudul.Location = new System.Drawing.Point(24, 22);
            this.lblJudul.Name = "lblJudul";
            this.lblJudul.Text = "Riwayat Belanja";
            this.lblJudul.TabIndex = 0;
            // 
            // lblBulan
            // 
            this.lblBulan.AutoSize = true;
            this.lblBulan.Location = new System.Drawing.Point(24, 66);
            this.lblBulan.Name = "lblBulan";
            this.lblBulan.Text = "Bulan";
            this.lblBulan.TabIndex = 1;
            // 
            // dtpBulan
            // 
            this.dtpBulan.CustomFormat = "MMMM yyyy";
            this.dtpBulan.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpBulan.Location = new System.Drawing.Point(24, 86);
            this.dtpBulan.Name = "dtpBulan";
            this.dtpBulan.ShowUpDown = true;
            this.dtpBulan.Size = new System.Drawing.Size(170, 23);
            this.dtpBulan.ValueChanged += new System.EventHandler(this.dtpBulan_ValueChanged);
            this.dtpBulan.TabIndex = 2;
            // 
            // lblTotalBulan
            // 
            this.lblTotalBulan.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalBulan.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(63)))), ((int)(((byte)(0)))));
            this.lblTotalBulan.Location = new System.Drawing.Point(300, 84);
            this.lblTotalBulan.Name = "lblTotalBulan";
            this.lblTotalBulan.Size = new System.Drawing.Size(406, 28);
            this.lblTotalBulan.Text = "Total bulan ini: Rp 0  (0 nota)";
            this.lblTotalBulan.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblTotalBulan.TabIndex = 3;
            // 
            // gridNota
            // 
            this.gridNota.AllowUserToAddRows = false;
            this.gridNota.AllowUserToDeleteRows = false;
            this.gridNota.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(250)))), ((int)(((byte)(240)))));
            this.gridNota.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.gridNota.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridNota.BackgroundColor = System.Drawing.Color.White;
            this.gridNota.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(212)))), ((int)(((byte)(191)))));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(63)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(212)))), ((int)(((byte)(191)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(63)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridNota.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.gridNota.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(217)))), ((int)(((byte)(170)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridNota.DefaultCellStyle = dataGridViewCellStyle3;
            this.gridNota.EnableHeadersVisualStyles = false;
            this.gridNota.MultiSelect = false;
            this.gridNota.ReadOnly = true;
            this.gridNota.RowHeadersVisible = false;
            this.gridNota.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridNota.Location = new System.Drawing.Point(24, 124);
            this.gridNota.Name = "gridNota";
            this.gridNota.Size = new System.Drawing.Size(682, 170);
            this.gridNota.SelectionChanged += new System.EventHandler(this.gridNota_SelectionChanged);
            this.gridNota.TabIndex = 4;
            // 
            // lblDetail
            // 
            this.lblDetail.AutoSize = true;
            this.lblDetail.Location = new System.Drawing.Point(24, 300);
            this.lblDetail.Name = "lblDetail";
            this.lblDetail.Text = "Detail nota yang dipilih";
            this.lblDetail.TabIndex = 5;
            // 
            // gridDetail
            // 
            this.gridDetail.AllowUserToAddRows = false;
            this.gridDetail.AllowUserToDeleteRows = false;
            this.gridDetail.AllowUserToResizeRows = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(250)))), ((int)(((byte)(240)))));
            this.gridDetail.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.gridDetail.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridDetail.BackgroundColor = System.Drawing.Color.White;
            this.gridDetail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(212)))), ((int)(((byte)(191)))));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(63)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(212)))), ((int)(((byte)(191)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(63)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridDetail.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.gridDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(217)))), ((int)(((byte)(170)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridDetail.DefaultCellStyle = dataGridViewCellStyle6;
            this.gridDetail.EnableHeadersVisualStyles = false;
            this.gridDetail.MultiSelect = false;
            this.gridDetail.ReadOnly = true;
            this.gridDetail.RowHeadersVisible = false;
            this.gridDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridDetail.Location = new System.Drawing.Point(24, 320);
            this.gridDetail.Name = "gridDetail";
            this.gridDetail.Size = new System.Drawing.Size(682, 150);
            this.gridDetail.TabIndex = 6;
            // 
            // panelBar
            // 
            this.panelBar.Controls.Add(this.lblModeBaca);
            this.panelBar.Controls.Add(this.btnHapus);
            this.panelBar.Controls.Add(this.btnUbah);
            this.panelBar.Controls.Add(this.btnTambah);
            this.panelBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(212)))), ((int)(((byte)(191)))));
            this.panelBar.Location = new System.Drawing.Point(24, 486);
            this.panelBar.Name = "panelBar";
            this.panelBar.Size = new System.Drawing.Size(682, 44);
            this.panelBar.TabIndex = 7;
            // 
            // btnTambah
            // 
            this.btnTambah.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(255)))), ((int)(((byte)(214)))));
            this.btnTambah.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTambah.Location = new System.Drawing.Point(11, 6);
            this.btnTambah.Name = "btnTambah";
            this.btnTambah.Size = new System.Drawing.Size(110, 32);
            this.btnTambah.Text = "Tambah Nota";
            this.btnTambah.UseVisualStyleBackColor = false;
            this.btnTambah.Click += new System.EventHandler(this.BtnTambah_Click);
            this.btnTambah.TabIndex = 0;
            // 
            // btnUbah
            // 
            this.btnUbah.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(230)))), ((int)(((byte)(255)))));
            this.btnUbah.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUbah.Location = new System.Drawing.Point(131, 6);
            this.btnUbah.Name = "btnUbah";
            this.btnUbah.Size = new System.Drawing.Size(100, 32);
            this.btnUbah.Text = "Ubah";
            this.btnUbah.UseVisualStyleBackColor = false;
            this.btnUbah.Click += new System.EventHandler(this.BtnUbah_Click);
            this.btnUbah.TabIndex = 1;
            // 
            // btnHapus
            // 
            this.btnHapus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(212)))));
            this.btnHapus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHapus.Location = new System.Drawing.Point(241, 6);
            this.btnHapus.Name = "btnHapus";
            this.btnHapus.Size = new System.Drawing.Size(100, 32);
            this.btnHapus.Text = "Hapus";
            this.btnHapus.UseVisualStyleBackColor = false;
            this.btnHapus.Click += new System.EventHandler(this.BtnHapus_Click);
            this.btnHapus.TabIndex = 2;
            // 
            // lblModeBaca
            // 
            this.lblModeBaca.Location = new System.Drawing.Point(361, 6);
            this.lblModeBaca.Name = "lblModeBaca";
            this.lblModeBaca.Size = new System.Drawing.Size(200, 32);
            this.lblModeBaca.Text = "Mode hanya baca";
            this.lblModeBaca.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblModeBaca.TabIndex = 3;
            // 
            // RiwayatControl
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.OldLace;
            this.Controls.Add(this.panelBar);
            this.Controls.Add(this.gridDetail);
            this.Controls.Add(this.lblDetail);
            this.Controls.Add(this.gridNota);
            this.Controls.Add(this.lblTotalBulan);
            this.Controls.Add(this.dtpBulan);
            this.Controls.Add(this.lblBulan);
            this.Controls.Add(this.lblJudul);
            this.Name = "RiwayatControl";
            this.Size = new System.Drawing.Size(730, 560);
            ((System.ComponentModel.ISupportInitialize)(this.gridNota)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridDetail)).EndInit();
            this.panelBar.ResumeLayout(false);
            this.panelBar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblJudul;
        private System.Windows.Forms.Label lblBulan;
        private System.Windows.Forms.DateTimePicker dtpBulan;
        private System.Windows.Forms.Label lblTotalBulan;
        private System.Windows.Forms.DataGridView gridNota;
        private System.Windows.Forms.Label lblDetail;
        private System.Windows.Forms.DataGridView gridDetail;
        private System.Windows.Forms.Panel panelBar;
        private System.Windows.Forms.Button btnTambah;
        private System.Windows.Forms.Button btnUbah;
        private System.Windows.Forms.Button btnHapus;
        private System.Windows.Forms.Label lblModeBaca;
    }
}
