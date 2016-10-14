using Microsoft.Win32;

namespace Sage.CA.SBS.ERP.Sage300.Core.Configuration
{
    /// <summary>
    /// Configuration helper
    /// </summary>
    public static class RegistryHelper
    {
        /// <summary>
        /// The path to the Registry Key where the name of the shared folder is stored
        /// </summary>
        private const string CONFIGURATION_KEY = "SOFTWARE\\ACCPAC International, Inc.\\ACCPAC\\Configuration";

        /// <summary>
        /// The name of the Registry Value containing the name of the shared folder
        /// </summary>
        private const string SHARED_FOLDER_VALUE = "SharedData";

        public static string SharedDataDirectory
        {
            get
            {
                if (!string.IsNullOrEmpty(ConfigurationHelper.SharedDataDirectory))
                    return ConfigurationHelper.SharedDataDirectory;

                // Get the registry key
                var baseKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32);
                var configurationKey = baseKey.OpenSubKey(CONFIGURATION_KEY);

                // Find path tp shared folder
                return configurationKey == null ? string.Empty : configurationKey.GetValue(SHARED_FOLDER_VALUE).ToString();
            }
        }
    }
}
