using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Digital_Services_BD.Utilities
{
    /// <summary>
    /// Provides AES encryption/decryption for Entity Framework Core properties
    /// </summary>
    public class EncryptionHelper
    {
        private readonly byte[] _key;
        private readonly byte[] _iv;

        public EncryptionHelper(byte[] key, byte[] iv)
        {
            _key = key ?? throw new ArgumentNullException(nameof(key));
            _iv = iv ?? throw new ArgumentNullException(nameof(iv));

            if (key.Length != 32)
                throw new ArgumentException("Key must be 32 bytes for AES-256", nameof(key));
            if (iv.Length != 16)
                throw new ArgumentException("IV must be 16 bytes", nameof(iv));
        }

        /// <summary>
        /// Encrypts a plaintext string to a Base64-encoded encrypted string
        /// </summary>
        public string Encrypt(string plainText)
        {
            if (string.IsNullOrEmpty(plainText))
                return plainText;

            try
            {
                using (var aes = Aes.Create())
                {
                    aes.Key = _key;
                    aes.IV = _iv;
                    aes.Mode = CipherMode.CBC;
                    aes.Padding = PaddingMode.PKCS7;

                    using (var encryptor = aes.CreateEncryptor())
                    using (var msEncrypt = new MemoryStream())
                    {
                        using (var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                        using (var swEncrypt = new StreamWriter(csEncrypt, Encoding.UTF8))
                        {
                            swEncrypt.Write(plainText);
                        }
                        return Convert.ToBase64String(msEncrypt.ToArray());
                    }
                }
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Encryption failed", ex);
            }
        }

        /// <summary>
        /// Decrypts a Base64-encoded encrypted string to plaintext
        /// </summary>
        public string Decrypt(string cipherText)
        {
            if (string.IsNullOrEmpty(cipherText))
                return cipherText;

            try
            {
                byte[] buffer = Convert.FromBase64String(cipherText);

                using (var aes = Aes.Create())
                {
                    aes.Key = _key;
                    aes.IV = _iv;
                    aes.Mode = CipherMode.CBC;
                    aes.Padding = PaddingMode.PKCS7;

                    using (var decryptor = aes.CreateDecryptor())
                    using (var msDecrypt = new MemoryStream(buffer))
                    using (var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    using (var srDecrypt = new StreamReader(csDecrypt, Encoding.UTF8))
                    {
                        return srDecrypt.ReadToEnd();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Decryption failed", ex);
            }
        }
    }
}
