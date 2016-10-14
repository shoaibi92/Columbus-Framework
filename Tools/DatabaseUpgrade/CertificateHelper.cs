// Copyright (c) 1994-2015 Sage Software, Inc.  All rights reserved. 

using System;
using System.Security.Cryptography.X509Certificates;

namespace Sage.CA.SBS.ERP.Sage300.DatabaseUpgrade
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

            var success = LoadCertFromStore(findType, findValue, ref certificate, StoreName.My, StoreLocation.LocalMachine);
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
                throw new Exception(string.Format("Unable to load X.509 certificate using criteria {0}='{1}'.", findType, findValue));
            }
            return certificate;
        }

        private static bool LoadCertFromStore(X509FindType findType, string findValue, ref X509Certificate2 certificate, StoreName store, StoreLocation location)
        {
            bool success;
            var certStore = new X509Store(store, location);
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
