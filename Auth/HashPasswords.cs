using System.Security.Cryptography;
using System.Text;

namespace BikeServiceAPI.Auth;

public static class HashPasswords
{
    public static string HashPassword(string password)
    {
        string salt = "BikeService";
        byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
        byte[] saltBytes = Encoding.UTF8.GetBytes(salt);

        byte[] combinedBytes = new byte[passwordBytes.Length + saltBytes.Length];
        Array.Copy(passwordBytes, 0, combinedBytes, 0, passwordBytes.Length);
        Array.Copy(saltBytes, 0, combinedBytes, passwordBytes.Length, saltBytes.Length);

        using (SHA256 sha256 = SHA256.Create())
        {
            byte[] hashBytes = sha256.ComputeHash(combinedBytes);
            return Convert.ToBase64String(hashBytes);
        }
    }
}