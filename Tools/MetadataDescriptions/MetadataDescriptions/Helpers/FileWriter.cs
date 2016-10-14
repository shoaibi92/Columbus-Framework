/* Copyright (c) 1994-2015 Sage Software, Inc.  All rights reserved. */

using System;
using System.IO;
using System.Windows.Forms;

namespace Sage.CA.SBS.ERP.Sage300.MetadataDescriptions.Helpers
{
    /// <summary>
    /// Class FileWriter
    /// </summary>
    class FileWriter
    {
        #region Private Vars
        /// <summary>
        /// The output file
        /// </summary>
        private readonly string _outputFile;

        #endregion

        #region Constructor
        /// <summary>
        /// FileWriter Constructor
        /// </summary>
        /// <param name="outputFile">Output File Full Path</param>
        public FileWriter(string outputFile)
        {
            _outputFile = outputFile;

            if (File.Exists(outputFile))
            {
                File.Delete(outputFile);
            }
        }

        #endregion

        #region Public Methods
        /// <summary>
        /// Write content to the ouputFile
        /// </summary>
        /// <param name="contentToWrite">Content To write</param>
        public void Write(string contentToWrite)
        {
        save:
            try
            {
                File.AppendAllText(_outputFile, contentToWrite);
            }
            catch (Exception e)
            {
                var result = DialogResult.Abort;
                try
                {
                    result = MessageBox.Show(Properties.Resources.ErrorWritingFile 
                        + e.Message + e.StackTrace,
                      Properties.Resources.DialogCaption, MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Stop);
                    if (result == DialogResult.Retry)
                    {
                        goto save;
                    }
                }
                finally
                {
                    if (result == DialogResult.Abort)
                    {
                        Application.Exit();
                    }
                }
            }
        }

        #endregion
    }
}
