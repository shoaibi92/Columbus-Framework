using System;
using System.Configuration;

namespace Sage.CA.SBS.ERP.Sage300.Common.WebApi
{
    /// <summary>
    /// Helper class to access Configuration Settings
    /// </summary>
    public static class WebApiConfigurationHelper
    {
        /// <summary>
        /// Page Size
        /// </summary>
        public static int PageSize
        {
            get
            {
                string value = ConfigurationManager.AppSettings["PageSize"];
                if (string.IsNullOrWhiteSpace(value))
                    return 0;

                return Convert.ToInt32(value);
            }
        }          
    }
}
