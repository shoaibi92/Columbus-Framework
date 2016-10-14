using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace Sage.CNA.Web.CloudStatus.Helper
{
    public class ConfigurationHelper
    {
        public static string SubscriptionId
        {
            get
            {
                return ConfigurationManager.AppSettings["SubscriptionId"];
            }
        }

        public static string CertificateData
        {
            get
            {
                return ConfigurationManager.AppSettings["CertificateData"];
            }
        }
    }
}