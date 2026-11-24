using System;
using System.Security.Cryptography;

namespace FinalPrjk
{
    /// <summary>Hash password PBKDF2 (salt acak). Format tersimpan: base64(salt):base64(hash).</summary>
    internal static class Security
    {
        private const int Iterations = 10000;

        public static string Hash(string password)
        {
            byte[] salt = new byte[16];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }
            return Convert.ToBase64String(salt) + ":" + Convert.ToBase64String(Derive(password, salt));
        }

        public static bool Verify(string password, string stored)
        {
            if (string.IsNullOrEmpty(stored)) return false;
            string[] parts = stored.Split(':');
            if (parts.Length != 2) return false;

            byte[] salt = Convert.FromBase64String(parts[0]);
            byte[] expected = Convert.FromBase64String(parts[1]);
            byte[] actual = Derive(password, salt);

            if (actual.Length != expected.Length) return false;
            int diff = 0;
            for (int i = 0; i < actual.Length; i++) diff |= actual[i] ^ expected[i];
            return diff == 0;
        }

        private static byte[] Derive(string password, byte[] salt)
        {
            using (var kdf = new Rfc2898DeriveBytes(password, salt, Iterations))
            {
                return kdf.GetBytes(32);
            }
        }
    }
}
