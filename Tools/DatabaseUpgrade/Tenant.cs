// Copyright (c) 1994-2015 Sage Software, Inc.  All rights reserved. 

#region Namespaces
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
#endregion

namespace Sage.CA.SBS.ERP.Sage300.DatabaseUpgrade
{
    /// <summary> Tenant to be upgraded/rolled back (future) </summary>
    public class Tenant
    {
        #region Private Vars
        private UpgradeStatusType _upgradeStatusType = UpgradeStatusType.None;
        private Icon _upgradeStatus = Properties.Resources.Blank;
        #endregion

        #region Public Enums
        /// <summary> Upgrade status for UI </summary>
        public enum UpgradeStatusType
        {
            None = 0,
            Success = 1,
            Error = 2,
            Warning = 3
        }
        #endregion

        #region Public Properties
        /// <summary> Row Index (Zero Based) </summary>
        [NotMapped]
        public int RowIndex { get; set; }
        /// <summary> True if tenant is selected otherwise False </summary>
        [NotMapped]
        public bool IsSelected { get; set; }
        /// <summary> Primary Key to tenant </summary>
        public int ID { get; set; }
        /// <summary> Tenant ID (GUID) </summary>
        public Guid? TenantId { get; set; }
        /// <summary> Site ID (GUID) </summary>
        public Guid SiteId { get; set; }
        /// <summary> Internal Name </summary>
        public string InternalName { get; set; }
        /// <summary> Version </summary>
        public string Version { get; set; }
        /// <summary> Status </summary>
        public int Status { get; set; }
        /// <summary> Timestamp </summary>
        public byte[] UpdatedTimestamp { get; set; }
        /// <summary> Last Updated </summary>
        public DateTime LastUpdated { get; set; }
        /// <summary> Company </summary>
        public string Company { get; set; }
        /// <summary> Tenant SQL Server Name </summary>
        public string ServerName { get; set; }
        /// <summary> Tenant SQL Server Database Name </summary>
        public string DatabaseName { get; set; }
        /// <summary> Tenant Database Login </summary>
        public string DatabaseLogin { get; set; }
        /// <summary> Tenant Database Password </summary>
        public string DatabasePassword { get; set; }
        /// <summary> Upgrade Status for UI </summary>
        [NotMapped]
        public Icon UpgradeStatus { get { return _upgradeStatus; } }
        /// <summary> Message property for Error </summary>
        [NotMapped]
        public string Message { get; set; }
        /// <summary> Thread number assigned to tenant for processing </summary>
        [NotMapped]
        public int Thread { get; set; }
        /// <summary> Flag to cancel upgrade from user. Will not upgrade tenant if caught before script is executed </summary>
        [NotMapped]
        public bool Cancel { get; set; }
        /// <summary> Attempts at upgrade </summary>
        [NotMapped]
        public int Attempts { get; set; }
        #endregion

        #region Public Methods
        /// <summary> Sets upgrade status based upon upgrade status type </summary>
        /// <param name="upgradeStatusType">Upgrade Status Type</param>
        public void SetUpgradeStatus(UpgradeStatusType upgradeStatusType)
        {
            _upgradeStatus = GetIcon(upgradeStatusType);
            _upgradeStatusType = upgradeStatusType;
        }

        /// <summary> Gets upgrade status type </summary>
        /// <returns>Upgrade Status Type</returns>
        public UpgradeStatusType GetUpgradeStatusType()
        {
            return _upgradeStatusType;
        }

        #endregion

        #region Private Methods
        /// <summary> Get icon based upon upgrade status type </summary>
        /// <param name="upgradeStatusType">Upgrade Status Type</param>
        /// <returns>Icon</returns>
        private static Icon GetIcon(UpgradeStatusType upgradeStatusType)
        {
            var retVal = Properties.Resources.Blank;

            switch (upgradeStatusType)
            {
                case UpgradeStatusType.None:
                    retVal = Properties.Resources.Blank;
                    break;
                case UpgradeStatusType.Success:
                    retVal = Properties.Resources.Success;
                    break;
                case UpgradeStatusType.Error:
                    retVal = Properties.Resources.Error;
                    break;
                case UpgradeStatusType.Warning:
                    retVal = Properties.Resources.ProgressWarn;
                    break;
            }

            return retVal;
        }
        #endregion
    }
}
