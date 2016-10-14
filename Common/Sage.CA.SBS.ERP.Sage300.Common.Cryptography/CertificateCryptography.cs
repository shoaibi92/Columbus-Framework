
using System;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Sage.CA.SBS.ERP.Sage300.Common.Cryptography
{
    /// <summary>
    /// This class is used for encrption/decryption using certificate
    /// </summary>
    public class CertificateCryptography : ICryptography
    {
        const string EncryptedStringDelimiter = "|";
        const int MaxEncryptionStringLength = 86;
        private readonly string _thumbPrint;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="thumbprintvalue">Thumb print to encrypt and decrypt.</param>
        public CertificateCryptography(string thumbprintvalue)
        {
            _thumbPrint = thumbprintvalue;
        }

        /// <summary>
        /// Encrypts the given string using x509 certificate.
        /// </summary>
        /// <param name="stringToEncrypt">String to encrypt</param>
        /// <returns>Encrypted string</returns>
        public string Encrypt(string stringToEncrypt)
        {
            if (string.IsNullOrEmpty(stringToEncrypt))
            {
                throw new ArgumentNullException("stringToEncrypt");
            }

            if (string.IsNullOrEmpty(_thumbPrint))
            {
                return stringToEncrypt;
            }

            var certificate = GetCertificate();

            if (certificate == null)
            {
                throw new CryptographicException(CryptographyResource.CertificateNullException);
            }

            using (var provider = new RSACryptoServiceProvider())
            {
                provider.FromXmlString(GetPublicKey(certificate));
                return SplitAndEncrypt(provider, stringToEncrypt);
            }
        }

        /// <summary>
        /// Decrypts the given string using x509 certificate.
        /// </summary>
        /// <param name="stringToDecrypt">Encrypted string</param>
        /// <returns>Decrypted string</returns>
        public string Decrypt(string stringToDecrypt)
        {
            if (string.IsNullOrEmpty(stringToDecrypt))
            {
                throw new ArgumentNullException("stringToDecrypt");
            }

            if (string.IsNullOrEmpty(_thumbPrint))
            {
                return stringToDecrypt;
            }

            var certificate = GetCertificate();

            if (certificate == null)
            {
                throw new CryptographicException(CryptographyResource.CertificateNullException);
            }

            using (var provider = (RSACryptoServiceProvider)certificate.PrivateKey)
            {
                return SplitAndDecrypt(provider, stringToDecrypt);
            }
        }

        /// <summary>
        /// Decrypts the given string using x509 certificate.
        /// </summary>
        /// <param name="stringToDecrypt">Encrypted string</param>
        /// <returns>Decrypted string</returns>
        public SecureString SecureDecrypt(string stringToDecrypt)
        {
            if (string.IsNullOrEmpty(stringToDecrypt))
            {
                throw new ArgumentNullException("stringToDecrypt");
            }

            if (string.IsNullOrEmpty(_thumbPrint))
            {
                return ConvertToSecureString(stringToDecrypt);
            }

            var certificate = GetCertificate();

            if (certificate == null)
            {
                throw new CryptographicException(CryptographyResource.CertificateNullException);
            }

            using (var provider = (RSACryptoServiceProvider)certificate.PrivateKey)
            {
                return SplitAndSecureDecrypt(provider, stringToDecrypt);
            }
        }

        /// <summary>
        /// Encrypts the given byte array using x509 certificate.
        /// </summary>
        /// <param name="bytesToEncrypt">String to encrypt</param>
        /// <returns>Encrypted string</returns>
        public byte[] EncryptBytes(byte[] bytesToEncrypt)
        {
            var base64String = GetBase64StringFromBytes(bytesToEncrypt);
            var encryptedString = Encrypt(base64String);
            return GetBytesFromString(encryptedString);
        }

        /// <summary>
        /// Decrypts the given byte array using x509 certificate.
        /// </summary>
        /// <param name="bytesToDecrypt">Encrypted string</param>
        /// <returns>Decrypted strin</returns>
        public byte[] DecryptBytes(byte[] bytesToDecrypt)
        {
            var baseString = GetStringFromBytes(bytesToDecrypt);
            var decryptedString = Decrypt(baseString);
            return GetBytesFromBase64String(decryptedString);
        }

        #region Private Methods

        /// <summary>
        /// Gets the certificate from certificate store
        /// </summary>
        /// <returns>Certificate object</returns>
        private X509Certificate2 GetCertificate()
        {
            return LoadCertificate(StoreName.My, StoreLocation.LocalMachine, _thumbPrint);

        }

        /// <summary>
        /// Gets the the public key of the given certificate-
        /// </summary>
        /// <param name="cert"></param>
        /// <returns>Public key of the certificate</returns>
        private string GetPublicKey(X509Certificate2 cert)
        {
            return cert.PublicKey.Key.ToXmlString(false);
        }

        /// <summary>
        /// Loads the certificate from give store
        /// </summary>
        /// <param name="storeName">Name of the certificate store</param>
        /// <param name="storeLocation">Location of the certificate in the store</param>
        /// <param name="thumbprint">Thumbprint of the certificate</param>
        /// <returns>Certificate</returns>
        private X509Certificate2 LoadCertificate(StoreName storeName, StoreLocation storeLocation, string thumbprint)
        {
            var store = new X509Store(storeName, storeLocation);
            store.Open(OpenFlags.ReadOnly);
            X509Certificate2Collection certCollection = store.Certificates.Find(X509FindType.FindByThumbprint, thumbprint, false);
            X509Certificate2Enumerator enumerator = certCollection.GetEnumerator();
            X509Certificate2 loadedCert = null;
            while (enumerator.MoveNext())
            {
                loadedCert = enumerator.Current;
            }
            return loadedCert;
        }

        /// <summary>
        /// Splits the string into 86 chars length string and encrypts each one of them seperately
        /// </summary>
        /// <param name="provider">Encryption provider</param>
        /// <param name="stringToEncrypt">String to be encrypted</param>
        /// <returns>Encrypted string</returns>
        private string SplitAndEncrypt(RSACryptoServiceProvider provider, string stringToEncrypt)
        {
            var cipher = new StringBuilder();
            int cur = 0;
            while (cur < stringToEncrypt.Length)
            {
                string encryptionPart = stringToEncrypt.Substring(cur);
                if (encryptionPart.Length > MaxEncryptionStringLength) encryptionPart = encryptionPart.Substring(0, MaxEncryptionStringLength);

                byte[] buffer = GetBytesFromString(encryptionPart);
                byte[] result = provider.Encrypt(buffer, true);
                cipher.Append(GetBase64StringFromBytes(result));
                cur += MaxEncryptionStringLength;
                if (cur < stringToEncrypt.Length) cipher.Append(EncryptedStringDelimiter);
            }
            return cipher.ToString();
        }

        /// <summary>
        /// Splits the encrypted string into individual Base64 char string and decrypts each one of them seperately
        /// </summary>
        /// <param name="provider">Encryption provider</param>
        /// <param name="cipher">String to be cipher</param>
        /// <returns>Encrypted string</returns>
        private string SplitAndDecrypt(RSACryptoServiceProvider provider, string cipher)
        {
            var decryptedString = new StringBuilder();
            if (!string.IsNullOrEmpty(cipher))
            {
                foreach (string decryptionPart in cipher.Split(EncryptedStringDelimiter.ToCharArray()))
                {
                    byte[] buffer = GetBytesFromBase64String(decryptionPart);
                    byte[] result = provider.Decrypt(buffer, true);
                    decryptedString.Append(GetStringFromBytes(result));
                }
            }
            return decryptedString.ToString();
        }

        /// <summary>
        /// Splits the encrypted string into individual Base64 char string and decrypts each one of them seperately
        /// </summary>
        /// <param name="provider">Encryption provider</param>
        /// <param name="cipher">String to be cipher</param>
        /// <returns>Encrypted string</returns>
        private SecureString SplitAndSecureDecrypt(RSACryptoServiceProvider provider, string cipher)
        {
            var decryptedString = new StringBuilder();
            if (!string.IsNullOrEmpty(cipher))
            {
                foreach (string decryptionPart in cipher.Split(EncryptedStringDelimiter.ToCharArray()))
                {
                    byte[] buffer = GetBytesFromBase64String(decryptionPart);
                    byte[] result = provider.Decrypt(buffer, true);
                    decryptedString.Append(GetStringFromBytes(result));
                }
            }
            var secureDecryptedString =  ConvertToSecureString(decryptedString.ToString());
            decryptedString.Clear();
            return secureDecryptedString;
        }

        /// <summary>
        /// Converts the byte array to its equivalent Base64 string representation
        /// </summary>
        /// <param name="inputBytes">bytes to convert</param>
        /// <returns>Base64 string equivalent of input bytes</returns>
        private String GetBase64StringFromBytes(Byte[] inputBytes)
        {
            return Convert.ToBase64String(inputBytes);
        }

        /// <summary>
        /// Converts Base64 string to its equivalent byte array representation
        /// </summary>
        /// <param name="inputString">Base64 string</param>
        /// <returns>Byte array equivalent of base64 string</returns>
        /// <exception cref="ArgumentException"></exception>
        private Byte[] GetBytesFromBase64String(String inputString)
        {
            return Convert.FromBase64String(inputString);
        }

        /// <summary>
        /// Converts byte array to its equivalent string representation
        /// </summary>
        /// <param name="inputBytes">Input byte array</param>
        /// <returns>String equivalent of byte array</returns>
        private String GetStringFromBytes(Byte[] inputBytes)
        {
            return Encoding.ASCII.GetString(inputBytes);
        }

        /// <summary>
        /// Converts string to its equivalent byte array representation
        /// </summary>
        /// <param name="inputString"></param>
        /// <returns></returns>
        private Byte[] GetBytesFromString(String inputString)
        {
            return Encoding.ASCII.GetBytes(inputString);
        }

        #endregion

        #region static method

        /// <summary>
        /// Encrypt string
        /// </summary>
        /// <param name="valueToEncrypt">Value to encrypt</param>
        /// <param name="thumbprint">thumbprint</param>
        /// <returns>decrypted value</returns>
        public static string Encrypt(string valueToEncrypt, string thumbprint)
        {
            if (string.IsNullOrEmpty(valueToEncrypt) || string.IsNullOrEmpty(thumbprint))
                return valueToEncrypt;

            var cryptography = new CertificateCryptography(thumbprint);
            return cryptography.Encrypt(valueToEncrypt);
        }

        /// <summary>
        /// Decrypt string
        /// </summary>
        /// <param name="valueToDecrypt">Value to decrypt</param>
        /// <param name="thumbprint">thumbprint</param>
        /// <returns>decrypted value</returns>
        public static string Decrypt(string valueToDecrypt, string thumbprint)
        {
            var cryptography = new CertificateCryptography(thumbprint);
            return cryptography.Decrypt(valueToDecrypt);
        }

        /// <summary>
        /// Decrypt as SecureString
        /// </summary>
        /// <param name="valueToDecrypt">Value to decrypt</param>
        /// <param name="thumbprint">thumbprint</param>
        /// <returns>decrypted value</returns>
        public static SecureString SecureDecrypt(string valueToDecrypt, string thumbprint)
        {
            var cryptography = new CertificateCryptography(thumbprint);
            return cryptography.SecureDecrypt(valueToDecrypt);
        }

        /// <summary>
        /// Converts string to its equivalent encrypted string
        /// </summary>
        /// <param name="valueToSecure"></param>
        /// <returns>Encrypted SecureString Value</returns>
        public static SecureString ConvertToSecureString(string valueToSecure)
        {
            var secureStringValue = new SecureString();
            if (!string.IsNullOrEmpty(valueToSecure))
            {
                foreach (var c in valueToSecure.ToCharArray()) secureStringValue.AppendChar(c);
            }
            return secureStringValue;
        }

        /// <summary>
        /// Converts encrypted string to its equivalent string
        /// </summary>
        /// <param name="secstrPassword"></param>
        /// <returns>Decrypted Value</returns>
        public static string SecureStringToString(SecureString secstrPassword)
        {
            IntPtr unmanagedString = IntPtr.Zero;
            try
            {
                unmanagedString = Marshal.SecureStringToGlobalAllocUnicode(secstrPassword);
                return Marshal.PtrToStringUni(unmanagedString);
            }
            finally
            {
                Marshal.ZeroFreeGlobalAllocUnicode(unmanagedString);
            }
        }

        #endregion
    }
}
