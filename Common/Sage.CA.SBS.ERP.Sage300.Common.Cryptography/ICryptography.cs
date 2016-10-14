
using System.Security;

namespace Sage.CA.SBS.ERP.Sage300.Common.Cryptography
{
    public interface ICryptography
    {
        /// <summary>
        /// Encrypts the given string using x509 certificate.
        /// </summary>
        /// <param name="valueToEncrypt">String to encrypt</param>
        /// <returns>Encrypted string</returns>
        string Encrypt(string valueToEncrypt);

        /// <summary>
        /// Decrypts the given string using x509 certificate.
        /// </summary>
        /// <param name="valueToDecrypt">Encrypted string</param>
        /// <returns>Decrypted string</returns>
        string Decrypt(string valueToDecrypt);

        /// <summary>
        /// Decrypts the given string using x509 certificate.
        /// </summary>
        /// <param name="valueToDecrypt">Encrypted string</param>
        /// <returns>Decrypted string</returns>
        SecureString SecureDecrypt(string valueToDecrypt);

        /// <summary>
        /// Encrypts the given byte array using x509 certificate.
        /// </summary>
        /// <param name="valueToEncrypt">String to encrypt</param>
        /// <returns>Encrypted string</returns>
        byte[] EncryptBytes(byte[] valueToEncrypt);

        /// <summary>
        /// Decrypts the given byte array using x509 certificate.
        /// </summary>
        /// <param name="valueToDecrypt">Encrypted string</param>
        /// <returns>Decrypted strin</returns>
        byte[] DecryptBytes(byte[] valueToDecrypt);
    }
}
