using System;
using System.Data;
using System.Data.SQLite;
using System.IO;

namespace FinalPrjk
{
    /// <summary>
    /// Akses database SQLite. Seluruh data tersimpan di satu file "belanjaku.db" di folder aplikasi
    /// (bin\Debug saat dijalankan dari Visual Studio). Tabel dan data awal dibuat otomatis bila belum ada.
    /// Hapus file tersebut untuk mengembalikan database ke kondisi awal.
    /// </summary>
    internal static class Db
    {
        public static string DbPath
        {
            get { return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "belanjaku.db"); }
        }

        public static string ConnectionString
        {
            get { return "Data Source=" + DbPath + ";Version=3;Foreign Keys=True;"; }
        }

        public static SQLiteConnection Open()
        {
            var c = new SQLiteConnection(ConnectionString);
            c.Open();
            return c;
        }

        public static SQLiteParameter P(string name, object value)
        {
            return new SQLiteParameter(name, value ?? DBNull.Value);
        }

        /// <summary>Tanggal disimpan sebagai teks yyyy-MM-dd (urutan teks sama dengan urutan tanggal).</summary>
        public static SQLiteParameter PDate(string name, DateTime value)
        {
            return new SQLiteParameter(name, value.ToString("yyyy-MM-dd"));
        }

        public static SQLiteParameter PMoney(string name, decimal value)
        {
            return new SQLiteParameter(name, (object)value);
        }

        public static SQLiteCommand Command(SQLiteConnection c, SQLiteTransaction t, string sql, params SQLiteParameter[] ps)
        {
            var cmd = new SQLiteCommand(sql, c, t);
            if (ps != null && ps.Length > 0) cmd.Parameters.AddRange(ps);
            return cmd;
        }

        public static DataTable Query(string sql, params SQLiteParameter[] ps)
        {
            using (var c = Open())
            using (var cmd = Command(c, null, sql, ps))
            using (var da = new SQLiteDataAdapter(cmd))
            {
                var dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public static int Exec(string sql, params SQLiteParameter[] ps)
        {
            using (var c = Open())
            using (var cmd = Command(c, null, sql, ps))
            {
                return cmd.ExecuteNonQuery();
            }
        }

        public static object Scalar(string sql, params SQLiteParameter[] ps)
        {
            using (var c = Open())
            using (var cmd = Command(c, null, sql, ps))
            {
                return cmd.ExecuteScalar();
            }
        }

        // ------------------------------------------------------------------
        // Inisialisasi: buat file database, tabel, dan data awal (hanya jika belum ada)
        // ------------------------------------------------------------------
        public static void Initialize()
        {
            Exec(SchemaSql);
            SeedIfEmpty();
        }

        private static void SeedIfEmpty()
        {
            if (Convert.ToInt32(Scalar("SELECT COUNT(*) FROM pengguna")) == 0)
            {
                AddUser("Anggota Keluarga", "anggota", "anggota123", Session.Anggota);
                AddUser("Pengelola Data", "pengelola", "pengelola123", Session.Pengelola);
                AddUser("Kepala Keluarga", "kepala", "kepala123", Session.Kepala);
            }

            if (Convert.ToInt32(Scalar("SELECT COUNT(*) FROM kategori")) == 0)
            {
                Exec("INSERT INTO kategori (nama_kategori) VALUES " +
                     "('Sembako'),('Sayur dan Buah'),('Daging dan Ikan'),('Bumbu Dapur'),('Kebersihan'),('Lain-lain')");
            }

            if (Convert.ToInt32(Scalar("SELECT COUNT(*) FROM toko")) == 0)
            {
                Exec("INSERT INTO toko (nama_toko, lokasi) VALUES " +
                     "('Pasar Beringharjo','Jl. Margo Mulyo, Yogyakarta')," +
                     "('Indomaret','Jl. Kaliurang, Sleman')," +
                     "('Superindo','Jl. Affandi, Sleman')");
            }

            if (Convert.ToInt32(Scalar("SELECT COUNT(*) FROM barang")) == 0)
            {
                string[,] data =
                {
                    { "Beras", "kg", "Sembako" }, { "Minyak Goreng", "liter", "Sembako" },
                    { "Gula Pasir", "kg", "Sembako" }, { "Telur Ayam", "kg", "Sembako" },
                    { "Bayam", "ikat", "Sayur dan Buah" }, { "Pisang", "sisir", "Sayur dan Buah" },
                    { "Ayam Potong", "kg", "Daging dan Ikan" }, { "Bawang Merah", "kg", "Bumbu Dapur" },
                    { "Sabun Cuci Piring", "pcs", "Kebersihan" }
                };
                for (int i = 0; i < data.GetLength(0); i++)
                {
                    Exec("INSERT INTO barang (nama_barang, satuan, id_kategori) " +
                         "VALUES (@n, @s, (SELECT id_kategori FROM kategori WHERE nama_kategori=@k))",
                         P("@n", data[i, 0]), P("@s", data[i, 1]), P("@k", data[i, 2]));
                }
            }
        }

        private static void AddUser(string nama, string username, string password, string peran)
        {
            Exec("INSERT INTO pengguna (nama_lengkap, username, password, peran) VALUES (@n, @u, @p, @r)",
                 P("@n", nama), P("@u", username), P("@p", Security.Hash(password)), P("@r", peran));
        }

        private const string SchemaSql = @"
CREATE TABLE IF NOT EXISTS pengguna (
    id_pengguna  INTEGER PRIMARY KEY AUTOINCREMENT,
    nama_lengkap VARCHAR(100) NOT NULL,
    username     VARCHAR(50)  NOT NULL UNIQUE,
    password     VARCHAR(255) NOT NULL,
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
";
    }
}
