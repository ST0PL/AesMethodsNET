using System;
using System.Collections.Generic;
using System.Text;

namespace AesMethodsNET
{
    /// <summary>
    /// Represents the result of an encryption operation, including the encryption key, initialization vector (IV), and encrypted bytes.
    /// </summary>
    public class EncryptionParams
    {
        /// <summary>
        /// Gets or sets the encryption key used for the encryption operation.
        /// </summary>
        public byte[] Key { get; set; }

        /// <summary>
        /// Gets or sets the initialization vector (IV) used for the encryption operation.
        /// </summary>
        public byte[] IV { get; set; }

        /// <summary>
        /// Gets or sets the encrypted bytes resulting from the encryption operation.
        /// </summary>
        public byte[] EncryptedBytes { get; set; }
    }
}
