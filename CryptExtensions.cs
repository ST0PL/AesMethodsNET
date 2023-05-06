using System;
using System.IO;
using System.Threading.Tasks;

namespace AesMethodsNET
{
    /// <summary>
    /// Provides extension methods for encrypting byte arrays using AES-256.
    /// </summary>
    public static class CryptExtensions
    {
        /// <summary>
        /// Encrypts a byte array using AES-256 with a randomly generated key and IV.
        /// </summary>
        /// <param name="bytes">The byte array to encrypt.</param>
        /// <returns>An <see cref="EncryptionParams"/> object containing the encrypted byte array, key, and IV.</returns>
        public static EncryptionParams CryptBytes(this byte[] bytes) => CryptMethods.EncryptBytes(bytes);


        /// <summary>
        /// Encrypts a byte array using AES-256 with a specified key and initialization vector (IV).
        /// </summary>
        /// <param name="bytes">The byte array to encrypt.</param>
        /// <param name="key">The 256-bit (32-byte) key to use for encryption.</param>
        /// <param name="iv">The 128-bit (16-byte) IV to use for encryption.</param>
        /// <returns>The encrypted byte array.</returns>
        public static byte[] CryptBytes(this byte[] bytes, byte[] key, byte[] iv) => CryptMethods.EncryptBytes(bytes, key, iv);
    }
}
