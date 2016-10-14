/* Copyright (c) 1994-2015 Sage Software, Inc.  All rights reserved. */

using System.IO;

namespace Sage.CA.SBS.ERP.Sage300.MetadataDescriptions.Helpers
{
    /// <summary>
    /// Class Logger
    /// </summary>
    class Logger
    {

        #region Static Vars

        /// <summary>
        /// Log file name
        /// </summary>
        private static readonly string Filename = Properties.Resources.LogFile;

        #endregion

        #region Private Vars

        /// <summary>
        /// Log file full path
        /// </summary>
        private readonly string _logfile;
        
        #endregion

        #region Properties
        /// <summary>
        /// Property Failure Count
        /// </summary>
        public int FailCount
        {
            get;
            private set;
        }

        #endregion


        #region Constructor

        /// <summary>
        /// Logger Constructor
        /// </summary>
        /// <param name="logFolder">Log Folder</param>
        public Logger(string logFolder)
        {
            _logfile = logFolder + "\\" + Filename;
            FailCount = 0;

            if (File.Exists(_logfile))
            {
                File.Delete(_logfile);
            }
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Write one line of log info
        /// </summary>
        /// <param name="line">One line of log info</param>
        public void WriteLine(string line)
        {
            FailCount++;
            using (var log = File.AppendText(_logfile))
            {
                log.WriteLine(line);
            }
        }

        #endregion
    }
}
