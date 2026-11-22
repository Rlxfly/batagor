-- Skema database Belanjaku (SQL Server / LocalDB)
-- Sesuai Soal 2.1 laporan: 6 tabel, saling berelasi.
-- Aplikasi menjalankan skrip yang sama secara otomatis saat pertama dibuka (Data/Db.cs).

IF DB_ID(N'DbBelanjaKeluarga') IS NULL CREATE DATABASE [DbBelanjaKeluarga];
GO
USE [DbBelanjaKeluarga];
GO

CREATE TABLE dbo.pengguna (
    id_pengguna  INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_pengguna PRIMARY KEY,
    nama_lengkap VARCHAR(100) NOT NULL,
    username     VARCHAR(50)  NOT NULL CONSTRAINT UQ_pengguna_username UNIQUE,
    [password]   VARCHAR(255) NOT NULL,          -- hash PBKDF2 (salt:hash), bukan teks biasa
    peran        VARCHAR(20)  NOT NULL CONSTRAINT CK_pengguna_peran CHECK (peran IN ('Anggota','Pengelola','Kepala'))
);

CREATE TABLE dbo.kategori (
    id_kategori   INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_kategori PRIMARY KEY,
    nama_kategori VARCHAR(50) NOT NULL
);

CREATE TABLE dbo.toko (
    id_toko   INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_toko PRIMARY KEY,
    nama_toko VARCHAR(100) NOT NULL,
    lokasi    VARCHAR(150) NULL
);

CREATE TABLE dbo.barang (
    id_barang   INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_barang PRIMARY KEY,
    nama_barang VARCHAR(100) NOT NULL,
    satuan      VARCHAR(20)  NOT NULL,
    id_kategori INT NOT NULL CONSTRAINT FK_barang_kategori REFERENCES dbo.kategori(id_kategori)
);

CREATE TABLE dbo.belanja (
    id_belanja    INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_belanja PRIMARY KEY,
    tanggal       DATE NOT NULL,
    id_toko       INT NOT NULL CONSTRAINT FK_belanja_toko REFERENCES dbo.toko(id_toko),
    id_pengguna   INT NOT NULL CONSTRAINT FK_belanja_pengguna REFERENCES dbo.pengguna(id_pengguna),
    total_belanja DECIMAL(12,2) NOT NULL CONSTRAINT DF_belanja_total DEFAULT 0
);

CREATE TABLE dbo.detail_belanja (
    id_detail    INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_detail_belanja PRIMARY KEY,
    id_belanja   INT NOT NULL CONSTRAINT FK_detail_belanja REFERENCES dbo.belanja(id_belanja),
    id_barang    INT NOT NULL CONSTRAINT FK_detail_barang REFERENCES dbo.barang(id_barang),
    jumlah       INT NOT NULL CONSTRAINT CK_detail_jumlah CHECK (jumlah > 0),
    harga_satuan DECIMAL(12,2) NOT NULL CONSTRAINT CK_detail_harga CHECK (harga_satuan >= 0),
    subtotal     DECIMAL(12,2) NOT NULL
);
GO
