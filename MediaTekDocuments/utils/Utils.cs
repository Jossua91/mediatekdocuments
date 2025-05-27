using System;
using System.Security.Cryptography;
using System.Text;

namespace MediaTekDocuments.utils
{
    public class Utils
    {
        /// <summary>
        /// Hash SHA256 d'un mot de passe
        /// </summary>
        public static string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();
                foreach (byte b in bytes)
                {
                    builder.Append(b.ToString("x2"));
                }
                return builder.ToString();
            }
        }

        /// <summary>
        /// Vérifie qu'un mot de passe correspond à un hash stocké
        /// </summary>
        public static bool VerifyPassword(string inputPassword, string storedHash)
        {
            string hashedInput = HashPassword(inputPassword);
            Console.WriteLine(hashedInput, storedHash);
            return hashedInput.Equals(storedHash, StringComparison.OrdinalIgnoreCase);
        }
    }
}