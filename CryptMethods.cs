using System.IO;
using System.Security.Cryptography;

namespace AesMethodsNET
{
    /// <summary>
    /// Provides methods for encrypting and decrypting byte arrays using AES-256.
    /// </summary>
    public class CryptMethods
    {
        /// <summary>
        /// Encrypts a byte array using AES-256 with a specified key and initialization vector (IV).
        /// </summary>
        /// <param name="bytes">The byte array to encrypt.</param>
        /// <param name="key">The 256-bit (32-byte) key to use for encryption.</param>
        /// <param name="iv">The 128-bit (16-byte) IV to use for encryption.</param>
        /// <returns>The encrypted byte array.</returns>
        public static byte[] EncryptBytes(byte[] bytes, byte[] key, byte[] iv)
        {
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = key;
                aesAlg.IV = iv;
                aesAlg.Mode = CipherMode.CBC;
                ICryptoTransform encryptor = aesAlg.CreateEncryptor();
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                    {
                        cs.Write(bytes, 0, bytes.Length);
                    }
                    return ms.ToArray();
                }
            }
        }


        /// <summary>
        /// Encrypts a byte array using AES-256 with a randomly generated key and IV.
        /// </summary>
        /// <param name="bytes">The byte array to encrypt.</param>
        /// <returns>An <see cref="EncryptionParams"/> object containing the encrypted byte array, key, and IV.</returns>
        public static EncryptionParams EncryptBytes(byte[] bytes)
        {
            byte[] key = new byte[32];
            using (RandomNumberGenerator rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(key);
            }
            byte[] iv = new byte[16];
            using (RandomNumberGenerator rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(iv);
            }
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = key;
                aesAlg.IV = iv;
                aesAlg.Mode = CipherMode.CBC;
                ICryptoTransform encryptor = aesAlg.CreateEncryptor();
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                    {
                        cs.Write(bytes, 0, bytes.Length);
                    }
                    return new EncryptionParams() { EncryptedBytes = ms.ToArray(), Key = key, IV = iv };
                }
            }
        }


        /// <summary>
        /// Generates a random 256-bit (32-byte) key and 128-bit (16-byte) IV for use in encryption.
        /// </summary>
        /// <returns>An <see cref="EncryptionParams"/> object containing the randomly generated key and IV.</returns>
        public static EncryptionParams GetRandomParams()
        {
            byte[] key = new byte[32];
            using (RandomNumberGenerator rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(key);
            }
            byte[] iv = new byte[16];
            using (RandomNumberGenerator rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(iv);
            }
            return new EncryptionParams() { Key = key, IV = iv };
        }


        /// <summary>
        /// Decrypts a byte array using AES-256 with a specified key and initialization vector (IV).
        /// </summary>
        /// <param name="bytes">The byte array to encrypt.</param>
        /// <param name="key">The 256-bit (32-byte) key to use for encryption.</param>
        /// <param name="iv">The 128-bit (16-byte) IV to use for encryption.</param>
        /// <returns>The decrypted byte array.</returns>
        public static byte[] DecryptBytes(byte[] bytes, byte[] key, byte[] iv)
        {
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = key;
                aesAlg.IV = iv;
                aesAlg.Mode = CipherMode.CBC;
                ICryptoTransform encryptor = aesAlg.CreateDecryptor();
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                    {
                        cs.Write(bytes, 0, bytes.Length);
                    }
                    return ms.ToArray();
                }
            }
        }
    }
}
