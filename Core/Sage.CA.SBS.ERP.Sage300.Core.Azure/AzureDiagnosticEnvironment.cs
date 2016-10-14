/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

using System.Diagnostics;
using System.Runtime.InteropServices;
using Microsoft.WindowsAzure.ServiceRuntime;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using Sage.CA.SBS.ERP.Sage300.Common.Cryptography;
using Sage.CA.SBS.ERP.Sage300.Core.Configuration;

namespace Sage.CA.SBS.ERP.Sage300.Core.Azure
{
    /// <summary>
    /// Resource Type
    /// </summary>
    public enum ResourceType
    {
        /// <summary>
        /// Disk
        /// </summary>
        RESOURCETYPE_DISK = 1,
    };

    /// <summary>
    /// Azure diagnostic Environment 
    /// </summary>
    public class AzureDiagnosticEnvironment
    {

        /// <summary>
        /// Log message
        /// </summary>
        /// <param name="message">Message</param>
        /// <param name="isError">Is Error</param>
        public static void WriteLine(string message, bool isError = false)
        {
            const string source = "RoleStartup";
            if (!EventLog.SourceExists(source))
            {
                EventLog.CreateEventSource(source, "Application");
            }
            if (!isError)
            {
                EventLog.WriteEntry(source, message);
                return;
            }
            EventLog.WriteEntry(source, message, EventLogEntryType.Error);
        }

        // This is  list of configuration settings (in ServiceConfiguration.cscfg) that if changed
        // should not result in the role being recycled.  This is implemented in the RoleEnvironmentChanging
        // and RoleEnvironmentChanged callbacks below
        /// <summary>
        /// The _exempt configuration items
        /// </summary>
        private static readonly string[] ExemptConfigurationItems = { "SageCloudDiagnosticTraceLevel", "AllowSessionLogging", "BlobTimeOut" };

        /// <summary>
        /// Determines whether [has non exempt configuration changes] [the specified CHGS].
        /// </summary>
        /// <param name="chgs">The CHGS.</param>
        /// <returns><c>true</c> if [has non exempt configuration changes] [the specified CHGS]; otherwise, <c>false</c>.</returns>
        // ReSharper disable once ParameterTypeCanBeEnumerable.Local
        public static bool HasNonExemptConfigurationChanges(ReadOnlyCollection<RoleEnvironmentChange> chgs)
        {
            Func<RoleEnvironmentConfigurationSettingChange, bool> changeIsNonExempt =
                settingChange => !ExemptConfigurationItems.Contains(settingChange.ConfigurationSettingName);

            var instanceChange = chgs.OfType<RoleEnvironmentTopologyChange>();

            var environmentChanges = chgs.OfType<RoleEnvironmentConfigurationSettingChange>();

            return environmentChanges.Any(changeIsNonExempt) || instanceChange.Any();
        }

        #region Azure File Services

        [DllImport("Mpr.dll",
            EntryPoint = "WNetAddConnection2",
            CallingConvention = CallingConvention.Winapi)]
        private static extern int WNetAddConnection2(NetResource lpNetResource,
                                                     string lpPassword,
                                                     string lpUsername,
                                                     UInt32 dwFlags);

        [DllImport("Mpr.dll",
                   EntryPoint = "WNetCancelConnection2",
                   CallingConvention = CallingConvention.Winapi)]
        private static extern int WNetCancelConnection2(string lpName,
                                                        UInt32 dwFlags,
                                                        Boolean fForce);

        [StructLayout(LayoutKind.Sequential)]
        private class NetResource
        {
#pragma warning disable 169
            public int dwScope;
#pragma warning restore 169
#pragma warning disable 414
            public ResourceType dwType;
#pragma warning restore 414
#pragma warning disable 169
            public int dwDisplayType;
#pragma warning restore 169
#pragma warning disable 169
            public int dwUsage;
#pragma warning restore 169
#pragma warning disable 414
            public string lpLocalName;
#pragma warning restore 414
#pragma warning disable 414
            public string lpRemoteName;
#pragma warning restore 414
#pragma warning disable 169
            public string lpComment;
#pragma warning restore 169
#pragma warning disable 169
            public string lpProvider;
#pragma warning restore 169
        };

        /// <summary>
        /// Create Azure file service
        /// </summary>
        public static void MountShare()
        {
            var shareName = ConfigurationHelper.GetConfigValue("FileServerName");
            const string driveLetterAndColon = "Z:";
            var username = ConfigurationHelper.GetConfigValue("FileServerAccountName");
            var password = ConfigurationHelper.GetConfigValue("FileServerAccountKey");
            if (!string.IsNullOrEmpty(ConfigurationHelper.DataCryptoThumbprint))
            {
                //decrypt the password
                password = CertificateCryptography.Decrypt(password, ConfigurationHelper.DataCryptoThumbprint);
            }
            if (!String.IsNullOrEmpty(driveLetterAndColon))
            {
                // Make sure we aren't using this driveLetter for another mapping
                WNetCancelConnection2(driveLetterAndColon, 0, true);
            }
            WriteLine(string.Format("Config Value  FileServerName : {0} , FileServerAccountName (username) : {1}, FileServerAccountKey(password) : {2}", shareName, username, password));

            var windowsIdentity = System.Security.Principal.WindowsIdentity.GetCurrent();
            if (windowsIdentity != null)
            {
                WriteLine(string.Format("Current User: {0}", windowsIdentity.Name));
            }

            var nr = new NetResource
            {
                dwType = ResourceType.RESOURCETYPE_DISK,
                lpRemoteName = shareName,
                lpLocalName = driveLetterAndColon
            };
            var result = WNetAddConnection2(nr, password, username, 0);
            if (result != 0)
            {
                WriteLine("WNetAddConnection2 failed with error " + result, true);
                throw new Exception("WNetAddConnection2 failed with error " + result);
            }
        }

        #endregion
    }
}