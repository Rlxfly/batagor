namespace FinalPrjk
{
    partial class CatatBelanjaControl
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
            this.lblJudul = new System.Windows.Forms.Label();
            this.lblMode = new System.Windows.Forms.Label();
            this.lblToko = new System.Windows.Forms.Label();
            this.cmbToko = new System.Windows.Forms.ComboBox();
            this.lblTanggal = new System.Windows.Forms.Label();
            this.dtpTanggal = new System.Windows.Forms.DateTimePicker();
            this.lblBarang = new System.Windows.Forms.Label();
            this.cmbBarang = new System.Windows.Forms.ComboBox();
            this.lblJumlah = new System.Windows.Forms.Label();
            this.nudJumlah = new System.Windows.Forms.NumericUpDown();
            this.lblHarga = new System.Windows.Forms.Label();
            this.txtHarga = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.gridItems = new System.Windows.Forms.DataGridView();
            this.panelBar = new System.Windows.Forms.Panel();
            this.btnHapusItem = new System.Windows.Forms.Button();
            this.lblTotal = new System.Windows.Forms.Label();
            this.btnSimpan = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nudJumlah)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridItems)).BeginInit();
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
            this.lblJudul.Text = "Catat Belanjaan";
            this.lblJudul.TabIndex = 0;
            // 
            // lblMode
            // 
            this.lblMode.AutoSize = true;
            this.lblMode.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(63)))), ((int)(((byte)(0)))));
            this.lblMode.Location = new System.Drawing.Point(240, 32);
            this.lblMode.Name = "lblMode";
            this.lblMode.Text = "Nota baru";
            this.lblMode.TabIndex = 1;
            // 
            // lblToko
            // 
            this.lblToko.AutoSize = true;
            this.lblToko.Location = new System.Drawing.Point(24, 70);
            this.lblToko.Name = "lblToko";
            this.lblToko.Text = "Toko";
            this.lblToko.TabIndex = 2;
            // 
            // cmbToko
            // 
            this.cmbToko.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbToko.FormattingEnabled = true;
            this.cmbToko.Location = new System.Drawing.Point(24, 90);
            this.cmbToko.Name = "cmbToko";
            this.cmbToko.Size = new System.Drawing.Size(300, 23);
            this.cmbToko.TabIndex = 3;
            // 
            // lblTanggal
            // 
            this.lblTanggal.AutoSize = true;
            this.lblTanggal.Location = new System.Drawing.Point(340, 70);
            this.lblTanggal.Name = "lblTanggal";
            this.lblTanggal.Text = "Tanggal";
            this.lblTanggal.TabIndex = 4;
            // 
            // dtpTanggal
            // 
            this.dtpTanggal.CustomFormat = "dd MMMM yyyy";
            this.dtpTanggal.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTanggal.Location = new System.Drawing.Point(340, 90);
            this.dtpTanggal.Name = "dtpTanggal";
            this.dtpTanggal.Size = new System.Drawing.Size(220, 23);
            this.dtpTanggal.TabIndex = 5;
            // 
            // lblBarang
            // 
            this.lblBarang.AutoSize = true;
            this.lblBarang.Location = new System.Drawing.Point(24, 128);
            this.lblBarang.Name = "lblBarang";
            this.lblBarang.Text = "Barang";
            this.lblBarang.TabIndex = 6;
            // 
            // cmbBarang
            // 
            this.cmbBarang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBarang.FormattingEnabled = true;
            this.cmbBarang.Location = new System.Drawing.Point(24, 148);
            this.cmbBarang.Name = "cmbBarang";
            this.cmbBarang.Size = new System.Drawing.Size(300, 23);
            this.cmbBarang.TabIndex = 7;
            // 
            // lblJumlah
            // 
            this.lblJumlah.AutoSize = true;
            this.lblJumlah.Location = new System.Drawing.Point(340, 128);
            this.lblJumlah.Name = "lblJumlah";
            this.lblJumlah.Text = "Jumlah";
            this.lblJumlah.TabIndex = 8;
            // 
            // nudJumlah
            // 
            this.nudJumlah.Location = new System.Drawing.Point(340, 148);
            this.nudJumlah.Maximum = new decimal(new int[] {999, 0, 0, 0});
            this.nudJumlah.Minimum = new decimal(new int[] {1, 0, 0, 0});
            this.nudJumlah.Name = "nudJumlah";
            this.nudJumlah.Size = new System.Drawing.Size(70, 23);
            this.nudJumlah.Value = new decimal(new int[] {1, 0, 0, 0});
            this.nudJumlah.TabIndex = 9;
            // 
            // lblHarga
            // 
            this.lblHarga.AutoSize = true;
            this.lblHarga.Location = new System.Drawing.Point(420, 128);
            this.lblHarga.Name = "lblHarga";
            this.lblHarga.Text = "Harga satuan";
            this.lblHarga.TabIndex = 10;
            // 
            // txtHarga
            // 
            this.txtHarga.Location = new System.Drawing.Point(420, 148);
            this.txtHarga.Name = "txtHarga";
            this.txtHarga.Size = new System.Drawing.Size(150, 23);
            this.txtHarga.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtHarga_KeyPress);
            this.txtHarga.TabIndex = 11;
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(255)))), ((int)(((byte)(214)))));
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Location = new System.Drawing.Point(580, 144);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(80, 30);
            this.btnAdd.Text = "Add+";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.BtnAdd_Click);
            this.btnAdd.TabIndex = 12;
            // 
            // gridItems
            // 
            this.gridItems.AllowUserToAddRows = false;
            this.gridItems.AllowUserToDeleteRows = false;
            this.gridItems.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(250)))), ((int)(((byte)(240)))));
            this.gridItems.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.gridItems.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridItems.BackgroundColor = System.Drawing.Color.White;
            this.gridItems.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(212)))), ((int)(((byte)(191)))));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(63)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(212)))), ((int)(((byte)(191)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(63)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridItems.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.gridItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(217)))), ((int)(((byte)(170)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridItems.DefaultCellStyle = dataGridViewCellStyle3;
            this.gridItems.EnableHeadersVisualStyles = false;
            this.gridItems.MultiSelect = false;
            this.gridItems.ReadOnly = true;
            this.gridItems.RowHeadersVisible = false;
            this.gridItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridItems.Location = new System.Drawing.Point(24, 196);
            this.gridItems.Name = "gridItems";
            this.gridItems.Size = new System.Drawing.Size(682, 274);
            this.gridItems.TabIndex = 13;
            // 
            // panelBar
            // 
            this.panelBar.Controls.Add(this.btnSimpan);
            this.panelBar.Controls.Add(this.lblTotal);
            this.panelBar.Controls.Add(this.btnHapusItem);
            this.panelBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(212)))), ((int)(((byte)(191)))));
            this.panelBar.Location = new System.Drawing.Point(24, 486);
            this.panelBar.Name = "panelBar";
            this.panelBar.Size = new System.Drawing.Size(682, 44);
            this.panelBar.TabIndex = 14;
            // 
            // btnHapusItem
            // 
            this.btnHapusItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(212)))));
            this.btnHapusItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHapusItem.Location = new System.Drawing.Point(11, 6);
            this.btnHapusItem.Name = "btnHapusItem";
            this.btnHapusItem.Size = new System.Drawing.Size(106, 32);
            this.btnHapusItem.Text = "Hapus item";
            this.btnHapusItem.UseVisualStyleBackColor = false;
            this.btnHapusItem.Click += new System.EventHandler(this.BtnHapusItem_Click);
            this.btnHapusItem.TabIndex = 0;
            // 
            // lblTotal
            // 
            this.lblTotal.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(63)))), ((int)(((byte)(0)))));
            this.lblTotal.Location = new System.Drawing.Point(190, 6);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(300, 32);
            this.lblTotal.Text = "Total: Rp 0";
            this.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTotal.TabIndex = 1;
            // 
            // btnSimpan
            // 
            this.btnSimpan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(255)))), ((int)(((byte)(214)))));
            this.btnSimpan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSimpan.Location = new System.Drawing.Point(576, 6);
            this.btnSimpan.Name = "btnSimpan";
            this.btnSimpan.Size = new System.Drawing.Size(95, 32);
            this.btnSimpan.Text = "Simpan";
            this.btnSimpan.UseVisualStyleBackColor = false;
            this.btnSimpan.Click += new System.EventHandler(this.BtnSimpan_Click);
            this.btnSimpan.TabIndex = 2;
            // 
            // CatatBelanjaControl
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.OldLace;
            this.Controls.Add(this.panelBar);
            this.Controls.Add(this.gridItems);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.txtHarga);
            this.Controls.Add(this.lblHarga);
            this.Controls.Add(this.nudJumlah);
            this.Controls.Add(this.lblJumlah);
            this.Controls.Add(this.cmbBarang);
            this.Controls.Add(this.lblBarang);
            this.Controls.Add(this.dtpTanggal);
            this.Controls.Add(this.lblTanggal);
            this.Controls.Add(this.cmbToko);
            this.Controls.Add(this.lblToko);
            this.Controls.Add(this.lblMode);
            this.Controls.Add(this.lblJudul);
            this.Name = "CatatBelanjaControl";
            this.Size = new System.Drawing.Size(730, 560);
            ((System.ComponentModel.ISupportInitialize)(this.nudJumlah)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridItems)).EndInit();
            this.panelBar.ResumeLayout(false);
            this.panelBar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblJudul;
        private System.Windows.Forms.Label lblMode;
        private System.Windows.Forms.Label lblToko;
        private System.Windows.Forms.ComboBox cmbToko;
        private System.Windows.Forms.Label lblTanggal;
        private System.Windows.Forms.DateTimePicker dtpTanggal;
        private System.Windows.Forms.Label lblBarang;
        private System.Windows.Forms.ComboBox cmbBarang;
        private System.Windows.Forms.Label lblJumlah;
        private System.Windows.Forms.NumericUpDown nudJumlah;
        private System.Windows.Forms.Label lblHarga;
        private System.Windows.Forms.TextBox txtHarga;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.DataGridView gridItems;
        private System.Windows.Forms.Panel panelBar;
        private System.Windows.Forms.Button btnHapusItem;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Button btnSimpan;
    }
}
