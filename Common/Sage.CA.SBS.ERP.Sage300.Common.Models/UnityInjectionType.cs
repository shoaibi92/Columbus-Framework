/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

namespace Sage.CA.SBS.ERP.Sage300.Common.Models
{
    /// <summary>
    /// Unity Container Injection Type
    /// </summary>
    public static class UnityInjectionType
    {
        /// <summary>
        /// The default
        /// </summary>
        public const string Default = "Default";

        /// <summary>
        /// The session
        /// </summary>
        public const string Session = "Session";

        /// <summary>
        /// Decides if pooling should be Disable, Per Call or enabled
        /// </summary>
        public const string Pooling = "Pooling";

        /// <summary>
        /// The Database
        /// </summary>
        public const string SystemDatabase = "SystemDatabase";

    }
}