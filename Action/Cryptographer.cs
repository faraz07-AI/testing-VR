using System;
using System.Security.Cryptography;
using System.Text;

public static class Cryptographer
{
    // Encrypts the input string using the provided key
    public static byte[] Encrypt(string plainText, string key)
    {
        if (string.IsNullOrEmpty(plainText)) throw new ArgumentNullException(nameof(plainText));
        if (string.IsNullOrEmpty(key)) throw new ArgumentNullException(nameof(key));

        using (Aes aes = Aes.Create())
        {
            // Generate key and initialization vector (IV)
            aes.Key = GetKeyBytes(key);
            aes.GenerateIV();

            // Create encryptor
            ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

            using (var ms = new MemoryStream())
            {
                // Write the IV to the beginning of the encrypted stream
                ms.Write(aes.IV, 0, aes.IV.Length);

                using (var cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                {
                    byte[] plainBytes = Encoding.UTF8.GetBytes(plainText);
                    cs.Write(plainBytes, 0, plainBytes.Length);
                }

                return ms.ToArray();
            }
        }
    }

    // Decrypts the input bytes using the provided key
    public static string Decrypt(byte[] cipherBytes, string key)
    {
        if (cipherBytes == null || cipherBytes.Length == 0) throw new ArgumentNullException(nameof(cipherBytes));
        if (string.IsNullOrEmpty(key)) throw new ArgumentNullException(nameof(key));

        using (Aes aes = Aes.Create())
        {
            aes.Key = GetKeyBytes(key);

            // Extract IV from the cipher bytes
            byte[] iv = new byte[aes.BlockSize / 8];
            Array.Copy(cipherBytes, 0, iv, 0, iv.Length);
            aes.IV = iv;

            // Create decryptor
            ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

            using (var ms = new MemoryStream())
            {
                using (var cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Write))
                {
                    // Write the remaining encrypted data to the crypto stream
                    cs.Write(cipherBytes, iv.Length, cipherBytes.Length - iv.Length);
                }

                // Convert decrypted bytes back to string
                return Encoding.UTF8.GetString(ms.ToArray());
            }
        }
    }

    // Derives a 256-bit key from the input string
    private static byte[] GetKeyBytes(string key)
    {
        using (var sha256 = SHA256.Create())
        {
            return sha256.ComputeHash(Encoding.UTF8.GetBytes(key));
        }
    }
}
