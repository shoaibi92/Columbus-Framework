/* Copyright (c) 1994-2015 Sage Software, Inc.  All rights reserved. */

namespace Sage.CA.SBS.ERP.Sage300.MetadataDescriptions.Interfaces
{
    /// <summary>
    /// Interface IInputReceiver
    /// </summary>
    public interface IInputReceiver
    {
        /// <summary>
        /// Property InputPath
        /// </summary>
        string InputPath {get;set;}

        /// <summary>
        /// Property OutputPath
        /// </summary>
        string OutputPath {get;set;}

        /// <summary>
        /// Get IutputPath from keyboard
        /// </summary>
        void ReceiveInputPath();

        /// <summary>
        /// Get OutputPath from keyboard
        /// </summary>
        void ReceiveOutputPath();

        /// <summary>
        /// Get InputPath/OutputPath from keyboard
        /// </summary>
        void ReadInputOutput();
    }
}
