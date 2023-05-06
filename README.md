[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT)
![Created with C# .NET Framework 4.8](https://img.shields.io/badge/Created%20with-C%23%20.NET%20Framework%204.8-purple)

# AesMethodsNET

AesMethodsNET is a .NET library that provides methods for encrypting and decrypting byte arrays using AES-256.

## Features

- Encrypt and decrypt byte arrays using AES-256 with a specified key and initialization vector (IV).
- Encrypt and decrypt byte arrays using AES-256 with randomly generated key and IV.
- Generate a random 256-bit (32-byte) key and 128-bit (16-byte) IV for use in encryption.

## Usage

### Encrypt and decrypt with specified key and IV

```cs
// Encrypt
byte[] encryptedBytes = CryptMethods.EncryptBytes(bytesToEncrypt, key, iv);

// Decrypt
byte[] decryptedBytes = CryptMethods.DecryptBytes(encryptedBytes, key, iv);

```
### Encrypt and decrypt with randomly generated key and IV

```cs
// Encrypt
EncryptionParams encryptionParams = CryptMethods.EncryptBytes(bytesToEncrypt);
byte[] encryptedBytes = encryptionParams.EncryptedBytes;
byte[] key = encryptionParams.Key;
byte[] iv = encryptionParams.IV;

// Decrypt
byte[] decryptedBytes = CryptMethods.DecryptBytes(encryptedBytes, key, iv);

```

### Generate random key and IV

```cs
EncryptionParams encryptionParams = CryptMethods.GetRandomParams();
byte[] key = encryptionParams.Key;
byte[] iv = encryptionParams.IV;

```
## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.
