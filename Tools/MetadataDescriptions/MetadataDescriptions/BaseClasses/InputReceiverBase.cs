/* Copyright (c) 1994-2015 Sage Software, Inc.  All rights reserved. */

using Sage.CA.SBS.ERP.Sage300.MetadataDescriptions.Interfaces;

namespace Sage.CA.SBS.ERP.Sage300.MetadataDescriptions.BaseClasses
{
    /// <summary>
    /// Abstract Class InputReceiverBase
    /// </summary>
    class InputReceiverBase: IInputReceiver
    {

        #region Public Properties

        /// <summary>
        /// Property InputPath
        /// </summary>
        public string InputPath
        {
            get; set; 
        }

        /// <summary>
        /// Property OutputPath
        /// </summary>
        public string OutputPath
        {
            get; set;
        }

        #endregion


        #region Public Methods

        /// <summary>
        /// Read the input and output path from keyboard
        /// </summary>
        public void ReadInputOutput()
        {
            ReceiveInputPath();
            ReceiveOutputPath();
        }

        /// <summary>
        /// Receive the input path from keyboard
        /// </summary>
        public virtual void ReceiveInputPath()
        {

        }

        /// <summary>
        /// Receive the input path from keyboard
        /// </summary>
        public virtual void ReceiveOutputPath()
        {

        }

        #endregion
    }
}
