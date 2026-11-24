-- Skema database Belanjaku (SQLite) - 6 tabel sesuai Soal 2.1 laporan.
-- Aplikasi menjalankan skrip yang sama otomatis saat pertama dibuka (Data/Db.cs) dan
-- membuat file belanjaku.db di folder aplikasi. Aktifkan PRAGMA foreign_keys = ON saat membuka manual.

CREATE TABLE IF NOT EXISTS pengguna (
    id_pengguna  INTEGER PRIMARY KEY AUTOINCREMENT,
    nama_lengkap VARCHAR(100) NOT NULL,
    username     VARCHAR(50)  NOT NULL UNIQUE,
    password     VARCHAR(255) NOT NULL,   -- hash PBKDF2 (salt:hash), bukan teks biasa
    peran        VARCHAR(20)  NOT NULL CHECK (peran IN ('Anggota','Pengelola','Kepala'))
);
CREATE TABLE IF NOT EXISTS kategori (
    id_kategori   INTEGER PRIMARY KEY AUTOINCREMENT,
    nama_kategori VARCHAR(50) NOT NULL
);
CREATE TABLE IF NOT EXISTS toko (
    id_toko   INTEGER PRIMARY KEY AUTOINCREMENT,
    nama_toko VARCHAR(100) NOT NULL,
    lokasi    VARCHAR(150)
);
CREATE TABLE IF NOT EXISTS barang (
    id_barang   INTEGER PRIMARY KEY AUTOINCREMENT,
    nama_barang VARCHAR(100) NOT NULL,
    satuan      VARCHAR(20)  NOT NULL,
    id_kategori INTEGER NOT NULL REFERENCES kategori(id_kategori)
);
CREATE TABLE IF NOT EXISTS belanja (
    id_belanja    INTEGER PRIMARY KEY AUTOINCREMENT,
    tanggal       DATE NOT NULL,
    id_toko       INTEGER NOT NULL REFERENCES toko(id_toko),
    id_pengguna   INTEGER NOT NULL REFERENCES pengguna(id_pengguna),
    total_belanja DECIMAL(12,2) NOT NULL DEFAULT 0
);
CREATE TABLE IF NOT EXISTS detail_belanja (
    id_detail    INTEGER PRIMARY KEY AUTOINCREMENT,
    id_belanja   INTEGER NOT NULL REFERENCES belanja(id_belanja),
    id_barang    INTEGER NOT NULL REFERENCES barang(id_barang),
    jumlah       INTEGER NOT NULL CHECK (jumlah > 0),
    harga_satuan DECIMAL(12,2) NOT NULL CHECK (harga_satuan >= 0),
    subtotal     DECIMAL(12,2) NOT NULL
);
