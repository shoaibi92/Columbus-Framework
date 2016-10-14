using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace Sage.CNA.AzureInfo.Helper
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

        public static List<string> CloudServiceList
        {
            get
            {
                return ConfigurationManager.AppSettings["CloudServiceList"].Split(',').ToList();
            }
        }

        public static string TimeZone
        {
            get
            {
                return ConfigurationManager.AppSettings["TimeZone"];
            }
        }
    }
}