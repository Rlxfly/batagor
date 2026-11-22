namespace FinalPrjk
{
    /// <summary>Menyimpan pengguna yang sedang login beserta hak aksesnya.</summary>
    internal static class Session
    {
        public const string Anggota = "Anggota";       // Anggota keluarga
        public const string Pengelola = "Pengelola";   // Pengelola data master
        public const string Kepala = "Kepala";         // Kepala keluarga (hanya baca)

        public static int IdPengguna;
        public static string NamaLengkap = "";
        public static string Peran = "";
        public static bool LoggedOut;

        public static bool IsAnggota { get { return Peran == Anggota; } }
        public static bool IsPengelola { get { return Peran == Pengelola; } }
        public static bool IsKepala { get { return Peran == Kepala; } }

        public static string PeranLabel
        {
            get
            {
                if (IsAnggota) return "Anggota Keluarga";
                if (IsPengelola) return "Pengelola Data Master";
                if (IsKepala) return "Kepala Keluarga";
                return "";
            }
        }

        public static void Clear()
        {
            IdPengguna = 0;
            NamaLengkap = "";
            Peran = "";
        }
    }
}
