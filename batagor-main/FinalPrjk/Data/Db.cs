using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace FinalPrjk
{
    /// <summary>Akses database SQL Server (LocalDB). Database dan tabel dibuat otomatis bila belum ada.</summary>
    internal static class Db
    {
        // Diisi oleh Initialize() setelah ditemukan server SQL yang benar-benar bisa dihubungi.
        private static string _resolvedConnectionString;

        public static string ConnectionString
        {
            get
            {
                return _resolvedConnectionString
                       ?? ConfigurationManager.ConnectionStrings["BelanjaDb"].ConnectionString;
            }
        }

        public static SqlConnection Open()
        {
            var c = new SqlConnection(ConnectionString);
            c.Open();
            return c;
        }

        public static SqlParameter P(string name, object value)
        {
            return new SqlParameter(name, value ?? DBNull.Value);
        }

        public static SqlParameter PDate(string name, DateTime value)
        {
            return new SqlParameter(name, SqlDbType.Date) { Value = value.Date };
        }

        public static SqlParameter PMoney(string name, decimal value)
        {
            return new SqlParameter(name, SqlDbType.Decimal) { Precision = 12, Scale = 2, Value = value };
        }

        public static SqlCommand Command(SqlConnection c, SqlTransaction t, string sql, params SqlParameter[] ps)
        {
            var cmd = new SqlCommand(sql, c, t);
            if (ps != null && ps.Length > 0) cmd.Parameters.AddRange(ps);
            return cmd;
        }

        public static DataTable Query(string sql, params SqlParameter[] ps)
        {
            using (var c = Open())
            using (var cmd = Command(c, null, sql, ps))
            using (var da = new SqlDataAdapter(cmd))
            {
                var dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public static int Exec(string sql, params SqlParameter[] ps)
        {
            using (var c = Open())
            using (var cmd = Command(c, null, sql, ps))
            {
                return cmd.ExecuteNonQuery();
            }
        }

        public static object Scalar(string sql, params SqlParameter[] ps)
        {
            using (var c = Open())
            using (var cmd = Command(c, null, sql, ps))
            {
                return cmd.ExecuteScalar();
            }
        }

        // ------------------------------------------------------------------
        // Inisialisasi: buat database, tabel, dan data awal (hanya jika belum ada)
        // ------------------------------------------------------------------
        public static void Initialize()
        {
            var configured = new SqlConnectionStringBuilder(
                ConfigurationManager.ConnectionStrings["BelanjaDb"].ConnectionString);
            string dbName = configured.InitialCatalog;

            var errors = new List<string>();
            SqlConnectionStringBuilder working = null;

            foreach (var candidate in Candidates(configured))
            {
                try
                {
                    var master = new SqlConnectionStringBuilder(candidate.ConnectionString);
                    master.InitialCatalog = "master";

                    using (var c = new SqlConnection(master.ConnectionString))
                    {
                        c.Open();
                        string sql = "IF DB_ID(N'" + dbName.Replace("'", "''") + "') IS NULL CREATE DATABASE ["
                                     + dbName.Replace("]", "]]") + "]";
                        using (var cmd = new SqlCommand(sql, c))
                        {
                            cmd.ExecuteNonQuery();
                        }
                    }

                    working = candidate;
                    break;
                }
                catch (Exception ex)
                {
                    errors.Add("- " + candidate.DataSource + "  (" + Describe(ex) + ")");
                }
            }

            if (working == null)
            {
                throw new InvalidOperationException(
                    "Tidak ada SQL Server yang dapat dihubungi. Yang sudah dicoba:\n" + string.Join("\n", errors));
            }

            _resolvedConnectionString = working.ConnectionString;

            Exec(SchemaSql);
            SeedIfEmpty();
        }

        // Server dari App.config dicoba lebih dulu, lalu alternatif umum jika gagal.
        private static IEnumerable<SqlConnectionStringBuilder> Candidates(SqlConnectionStringBuilder configured)
        {
            yield return configured;

            string[] fallbacks =
            {
                @"(localdb)\MSSQLLocalDB",
                @"(localdb)\ProjectsV13",
                @"(localdb)\v11.0",
                @".\SQLEXPRESS",
                @"localhost\SQLEXPRESS",
                @"(local)",
                @"."
            };

            foreach (string ds in fallbacks)
            {
                if (string.Equals(ds, configured.DataSource, StringComparison.OrdinalIgnoreCase)) continue;

                var b = new SqlConnectionStringBuilder(configured.ConnectionString);
                b.DataSource = ds;
                b.ConnectTimeout = 5;   // server yang tidak ada gagal cepat, tidak menggantung
                yield return b;
            }
        }

        private static string Describe(Exception ex)
        {
            string msg = ex.Message ?? "";
            int nl = msg.IndexOfAny(new[] { '\r', '\n' });
            if (nl > 0) msg = msg.Substring(0, nl);
            if (msg.Length > 90) msg = msg.Substring(0, 90) + "...";

            var se = ex as SqlException;
            return se != null ? "error " + se.Number + ": " + msg : msg;
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
                Exec("INSERT INTO barang (nama_barang, satuan, id_kategori) " +
                     "SELECT v.n, v.s, k.id_kategori FROM (VALUES " +
                     "('Beras','kg','Sembako'),('Minyak Goreng','liter','Sembako'),('Gula Pasir','kg','Sembako')," +
                     "('Telur Ayam','kg','Sembako'),('Bayam','ikat','Sayur dan Buah'),('Pisang','sisir','Sayur dan Buah')," +
                     "('Ayam Potong','kg','Daging dan Ikan'),('Bawang Merah','kg','Bumbu Dapur')," +
                     "('Sabun Cuci Piring','pcs','Kebersihan')" +
                     ") AS v(n, s, k) INNER JOIN kategori k ON k.nama_kategori = v.k");
            }
        }

        private static void AddUser(string nama, string username, string password, string peran)
        {
            Exec("INSERT INTO pengguna (nama_lengkap, username, [password], peran) VALUES (@n, @u, @p, @r)",
                 P("@n", nama), P("@u", username), P("@p", Security.Hash(password)), P("@r", peran));
        }

        private const string SchemaSql = @"
IF OBJECT_ID(N'dbo.pengguna', N'U') IS NULL
CREATE TABLE dbo.pengguna (
    id_pengguna  INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_pengguna PRIMARY KEY,
    nama_lengkap VARCHAR(100) NOT NULL,
    username     VARCHAR(50)  NOT NULL CONSTRAINT UQ_pengguna_username UNIQUE,
    [password]   VARCHAR(255) NOT NULL,
    peran        VARCHAR(20)  NOT NULL CONSTRAINT CK_pengguna_peran CHECK (peran IN ('Anggota','Pengelola','Kepala'))
);
IF OBJECT_ID(N'dbo.kategori', N'U') IS NULL
CREATE TABLE dbo.kategori (
    id_kategori   INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_kategori PRIMARY KEY,
    nama_kategori VARCHAR(50) NOT NULL
);
IF OBJECT_ID(N'dbo.toko', N'U') IS NULL
CREATE TABLE dbo.toko (
    id_toko   INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_toko PRIMARY KEY,
    nama_toko VARCHAR(100) NOT NULL,
    lokasi    VARCHAR(150) NULL
);
IF OBJECT_ID(N'dbo.barang', N'U') IS NULL
CREATE TABLE dbo.barang (
    id_barang   INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_barang PRIMARY KEY,
    nama_barang VARCHAR(100) NOT NULL,
    satuan      VARCHAR(20)  NOT NULL,
    id_kategori INT NOT NULL CONSTRAINT FK_barang_kategori REFERENCES dbo.kategori(id_kategori)
);
IF OBJECT_ID(N'dbo.belanja', N'U') IS NULL
CREATE TABLE dbo.belanja (
    id_belanja    INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_belanja PRIMARY KEY,
    tanggal       DATE NOT NULL,
    id_toko       INT NOT NULL CONSTRAINT FK_belanja_toko REFERENCES dbo.toko(id_toko),
    id_pengguna   INT NOT NULL CONSTRAINT FK_belanja_pengguna REFERENCES dbo.pengguna(id_pengguna),
    total_belanja DECIMAL(12,2) NOT NULL CONSTRAINT DF_belanja_total DEFAULT 0
);
IF OBJECT_ID(N'dbo.detail_belanja', N'U') IS NULL
CREATE TABLE dbo.detail_belanja (
    id_detail    INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_detail_belanja PRIMARY KEY,
    id_belanja   INT NOT NULL CONSTRAINT FK_detail_belanja REFERENCES dbo.belanja(id_belanja),
    id_barang    INT NOT NULL CONSTRAINT FK_detail_barang REFERENCES dbo.barang(id_barang),
    jumlah       INT NOT NULL CONSTRAINT CK_detail_jumlah CHECK (jumlah > 0),
    harga_satuan DECIMAL(12,2) NOT NULL CONSTRAINT CK_detail_harga CHECK (harga_satuan >= 0),
    subtotal     DECIMAL(12,2) NOT NULL
);
";
    }
}
