/* Copyright (c) 1994-2015 Sage Software, Inc.  All rights reserved. */

using Sage.CA.SBS.ERP.Sage300.MetadataDescriptions.Interfaces;

namespace Sage.CA.SBS.ERP.Sage300.MetadataDescriptions.BaseClasses
{
    /// <summary>
    /// Class DataProcessorBase
    /// </summary>
    class DataProcessorBase: IDataProcessor
    {
        #region Public Vars

        /// <summary>
        /// Prompt message when processing ends
        /// </summary>
        public string PromptEnd;

        #endregion

        #region Public Delegates

        /// <summary> Delegate to update UI with status of file being processed and the text to display </summary>
        /// <param name="success">True/False based upon file processing</param>
        /// <param name="text">Text to display</param>
        public delegate void StatusEventHandler(bool success, string text = null);

        /// <summary> Delegate to update UI with the text being processed </summary>
        /// <param name="text">Text to display</param>
        public delegate void DisplayEventHandler(string text);

        #endregion

        #region Public Events

        /// <summary> Event to update UI with status of file being processed </summary>
        public event StatusEventHandler StatusEvent;

        /// <summary> Event to update UI with the text being processed </summary>
        public event DisplayEventHandler DisplayEvent;

        #endregion

        #region Protected Methods

        /// <summary> Update UI </summary>
        /// <param name="success">True/False based upon file processing</param>
        /// <param name="text">Extra text to display</param>
        protected void LaunchStatusEvent(bool success, string text = null)
        {
            if (StatusEvent != null)
            {
                StatusEvent(success, text);
            }
        }

        /// <summary> Update UI </summary>
        /// <param name="text">Text to display</param>
        protected void LaunchDisplayEvent(string text)
        {
            if (DisplayEvent != null)
            {
                DisplayEvent(text);
            }
        }

        #endregion

        #region Public Methods

        public virtual void Process()
        {
            
        }

        /// <summary>
        /// Property TotalFiles
        /// </summary>
        public int TotalFiles
        {
            get;
            set;
        }

        #endregion
    }
}
