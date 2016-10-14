using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace EncryptString
{
    public static class CertificateHelper
    {
        public static X509Certificate2 GetCertificateFromFindCriteria(string certificateFindType, string findValue)
        {
            X509FindType findType;
            if (!Enum.TryParse(certificateFindType, true, out findType))
            {
                throw new ArgumentOutOfRangeException("certificateFindType", certificateFindType, "Invalid certificate find type value.");
            }
            return GetCertificateFromFindCriteria(findType, findValue);
        }

        public static X509Certificate2 GetCertificateFromFindCriteria(X509FindType findType, string findValue)
        {
            X509Certificate2 certificate = null;
            bool success;
            
            success = LoadCertFromStore(findType, findValue, ref certificate, StoreName.My, StoreLocation.LocalMachine);
            if (!success)
            {
                success = LoadCertFromStore(findType, findValue, ref certificate, StoreName.Root, StoreLocation.LocalMachine);
            }
            if (!success)
            {
                success = LoadCertFromStore(findType, findValue, ref certificate, StoreName.My, StoreLocation.CurrentUser);
            }
            if (!success)
            {
                throw new Exception(string.Format("Unable to load X.509 certificate using criteria {0}='{1}'.", findType.ToString(), findValue));
            }
            return certificate;
        }

        private static bool LoadCertFromStore(X509FindType findType, string findValue, ref X509Certificate2 certificate, StoreName store, StoreLocation location)
        {
            bool success;
            X509Store certStore = new X509Store(store, location);
            certStore.Open(OpenFlags.OpenExistingOnly | OpenFlags.ReadOnly);

            try
            {
                X509Certificate2Collection certList = certStore.Certificates.Find(findType, findValue, false);
                certificate = certList[0];
                success = true;
            }
            catch
            {
                success = false;
            }
            finally
            {
                certStore.Close();
            }
            return success;
        }
    }
}
