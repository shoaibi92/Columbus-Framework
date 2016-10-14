// Copyright (c) 1994-2015 Sage Software, Inc.  All rights reserved. 

using System.Drawing;

namespace Sage.CA.SBS.ERP.Sage300.ClassGeneration
{
    /// <summary> Information class to hold info for classes to be generated </summary>
    class Info
    {
        #region Private Vars
        /// <summary> Status Type for status </summary>
        private StatusType _statusType = StatusType.None;
        /// <summary> Icon of the status </summary>
        private Icon _status = Properties.Resources.Blank;
        #endregion

        #region Public Enums
        /// <summary> Status type used to identify icon required for UI </summary>
        public enum StatusType
        {
            None,
            Success,
            Error
        }
        #endregion

        #region Public Constants
        /// <summary> Column in UI for File Name </summary>
        public const int FileNameColumnNo = 0;
        /// <summary> Column name in UI for File Name </summary>
        public const string FileNameColumnName = "FileName";
        /// <summary> Column in UI for Status </summary>
        public const int StatusColumnNo = 1;
        /// <summary> Column name in UI for File Name </summary>
        public const string StatusColumnName = "Status";
        #endregion

        #region Public Properties
        /// <summary> Name for UI display of File Name </summary>
        public string FileName { get; set; }

        /// <summary> Icon for UI display of status </summary>
        public Icon Status
        {
            get { return _status; }
        }
        #endregion

        #region Public Methods
        /// <summary> Sets status to appropriate status column based upon status type </summary>
        /// <param name="statusType">Status Type</param>
        /// <returns>Column index being set</returns>
        public int SetStatus(StatusType statusType)
        {
            _status = GetIcon(statusType); ;
            _statusType = statusType;

            return StatusColumnNo;
        }

        /// <summary> Gets status type </summary>
        /// <returns>Status Type</returns>
        public StatusType GetStatusType()
        {
            return _statusType;
        }

        #endregion

        #region Private Methods
        /// <summary> Get icon based upon status type </summary>
        /// <param name="statusType">Status Type</param>
        /// <returns>Icon</returns>
        private Icon GetIcon(StatusType statusType)
        {
            var retVal = Properties.Resources.Blank;

            switch (statusType)
            {
                case StatusType.None:
                    retVal = Properties.Resources.Blank;
                    break;
                case StatusType.Success:
                    retVal = Properties.Resources.Success;
                    break;
                case StatusType.Error:
                    retVal = Properties.Resources.Error;
                    break;
            }

            return retVal;
        }
        #endregion
    }
}
