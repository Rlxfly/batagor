# UTS - UAS PL: Belanjaku (Daftar Belanja Bulanan Keluarga)

Aplikasi Windows Forms (C#, .NET Framework 4.7.2) untuk mencatat belanja bulanan keluarga.
Kelompok 5 - IF03 - Pemrograman Lanjut (ST122), Universitas AMIKOM Yogyakarta.

## Cara menjalankan
1. Buka `FinalPrjk.slnx` di Visual Studio 2022 (workload ".NET desktop development").
2. Klik kanan Solution > **Restore NuGet Packages** (mengunduh System.Data.SQLite), lalu **Build > Rebuild Solution**.
3. Tekan **F5**. Saat pertama dijalankan, aplikasi membuat sendiri file database `belanjaku.db`
   (di `FinalPrjk\bin\Debug`) beserta 6 tabel dan data awal. Tidak perlu memasang SQL Server.
4. Untuk mengembalikan data ke kondisi awal, tutup aplikasi lalu hapus file `belanjaku.db`.

## Akun contoh
| Peran | Username | Password | Hak akses |
| --- | --- | --- | --- |
| Anggota Keluarga | `anggota` | `anggota123` | catat/ubah/hapus nota, tambah barang & toko, lihat riwayat |
| Pengelola Data Master | `pengelola` | `pengelola123` | CRUD barang, toko, kategori; lihat riwayat |
| Kepala Keluarga | `kepala` | `kepala123` | hanya melihat riwayat dan total per bulan |

## Struktur
- `Data/` : akses database (`Db.cs`), hash password PBKDF2 (`Security.cs`), sesi login (`Session.cs`)
- `Forms/` : login dan form entri terpisah (Kategori, Toko, Barang) 
- `Controls/` : form list master (`MasterListControl`), riwayat belanja, catat belanjaan
- `Form1` : jendela utama dengan sidebar navigasi
- `Database/skema.sql` : skrip skema SQLite (sama dengan yang dijalankan otomatis oleh aplikasi)

Kolom `pengguna.peran` (VARCHAR(20)) menyimpan kode singkat: `Anggota`, `Pengelola`, `Kepala`.
