using System;
using System.Configuration;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Security;
using System.Xml.Linq;
using Microsoft.Win32;
using Sage.CA.SBS.ERP.Sage300.Common.Cryptography;
using Sage.CA.SBS.ERP.Sage300.Core.Cache;
using Sage.CA.SBS.ERP.Sage300.Core.Configuration;

namespace Sage.CA.SBS.ERP.Sage300.Common.BusinessRepository.Base
{
    
    /// <summary>
    /// Base DbContext
    /// </summary>
    public abstract class BaseDbContext : DbContext
    {
        private static readonly byte[] PASS_KEY =
        {
            0x3A,0x1E,0x3B,0xA4,0xA6,0x7B,0x1F,0xC2,0x92,0x62,
            0x12,0xC2,0x97,0x9D,0x68,0x49,0x4B,0xAD,0x3B,0xE3,
            0xD7,0xE3,0x7A,0xCE,0x46,0x42,0xE5,0x4A,0xDB,0xF8,
            0x80,0xD4,0xFA,0x23,0xC5,0x89,0x5D,0xF7,0x62,0x74,
        };

        /// <summary>
        /// The name if the folder where the config file is
        /// </summary>
        private const string SITE_FOLDER_NAME = "SITE";

        /// <summary>
        /// The Name of Config File
        /// </summary>
        private const string CONFIG_FILE_NAME = "dbconfig.xml";

        /// <summary>
        /// Database Connection Timeout
        /// </summary>
        private const int CONNECTION_TIMEOUT = 30;

        /// <summary>
        /// Constructor
        /// </summary>
        protected BaseDbContext(string connectionStringName)
            : base(Decrypt(connectionStringName))
        {
        }

        /// <summary>
        /// Decrypt connection string
        /// </summary>
        /// <param name="connectionStringName">connection string name</param>
        /// <returns>Decrypted connection string</returns>
        private static string Decrypt(string connectionStringName)
        {
            if (string.IsNullOrEmpty(ConfigurationHelper.DataCryptoThumbprint))
            {
                return connectionStringName;
            }

            var decryptedConnectionString = InMemoryCacheProvider.Instance.Get<SecureString>(connectionStringName);
            if (decryptedConnectionString == null)
            {
                decryptedConnectionString =
                    CertificateCryptography.SecureDecrypt(ConfigurationHelper.GetConnectionString(connectionStringName),
                        ConfigurationHelper.DataCryptoThumbprint);

                InMemoryCacheProvider.Instance.Set(connectionStringName, decryptedConnectionString);
            }

            return CertificateCryptography.SecureStringToString(decryptedConnectionString);
        }

        /// <summary>
        /// Assembles connection string from xml file.
        /// </summary>
        protected static string GetConnectionString(string connectionStringName)
        {

            if (ConfigurationHelper.IsOnPremise)
            {


                //            // Find path tp shared folder
                var sharedDir = RegistryHelper.SharedDataDirectory;
                var path = System.IO.Path.Combine(sharedDir, SITE_FOLDER_NAME, CONFIG_FILE_NAME);

                // Parse XML file.
                var doc = XDocument.Load(path, LoadOptions.PreserveWhitespace);
                var root = doc.Root;
                if (root == null)
                {
                    throw new Exception("Incorrect XML file");
                }

                var server = root.Attributes().FirstOrDefault(el => el.Name.LocalName.ToLower() == "host");
                if (server == null)
                {
                    throw new Exception("Incorrect XML file - Server missing");
                }

                var port = root.Attributes().FirstOrDefault(el => el.Name.LocalName.ToLower() == "port");
                // TEMPORARY FOR INOK
                //if (port == null)
                //{
                //    throw new Exception("Incorrect XML file - Port missing");
                //}

                var initialCatalog = root.Elements().FirstOrDefault(el => el.Name.LocalName.ToLower() == "database");
                if (initialCatalog == null)
                {
                    throw new Exception("Incorrect XML file - Database missing");
                }

                var userId = root.Elements().FirstOrDefault(el => el.Name.LocalName.ToLower() == "userid");
                if (userId == null)
                {
                    throw new Exception("Incorrect XML file - UserID missing");
                }

                var password = root.Elements().FirstOrDefault(el => el.Name.LocalName.ToLower() == "password");
                if (password == null)
                {
                    throw new Exception("Incorrect XML file - Password missing");
                }

                // Assemble connection string.
                var builder = new SqlConnectionStringBuilder()
                {
                    DataSource =
                        (port != null && !string.IsNullOrEmpty(port.Value))
                            ? string.Format("{0},{1}", server.Value, port.Value)
                            : server.Value,
                    InitialCatalog = initialCatalog.Value,
                    UserID = userId.Value,
                    Password = Blowfish.Blowfish_Decrypt(PASS_KEY, password.Value),
                    IntegratedSecurity = false,
                    MultipleActiveResultSets = true,
                    ConnectTimeout = CONNECTION_TIMEOUT
                };

                return builder.ConnectionString;
            }
            else
            {
                return connectionStringName; // return whatever is passed for Azure 
            }
        }

    }
}
