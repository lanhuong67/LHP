using System.Security.Cryptography;
using System.Text;

namespace WebBanDienThoai.Helpers
{
    public static class PasswordHasher
    {
        public static string HashPassword(string password)
        {
            if (string.IsNullOrWhiteSpace(password))
                return "";

            using var sha256 = SHA256.Create();
            byte[] bytes = Encoding.UTF8.GetBytes(password);
            byte[] hash = sha256.ComputeHash(bytes);

            return Convert.ToHexString(hash);
        }

        public static bool VerifyPassword(string password, string passwordHash)
        {
            if (string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(passwordHash))
                return false;

            string inputHash = HashPassword(password);

            return inputHash.Equals(passwordHash, StringComparison.OrdinalIgnoreCase);
        }
    }
}