/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

using System;

namespace Sage.CA.SBS.ERP.Sage300.Common.Models
{
    /// <summary>
    /// This custom attribute tells us if an enum stores its value as a char or int.
    /// </summary>
    public class StoredAsChar : Attribute
    {
        /// <summary>
        /// This property is true iff the enum stores its value as a char.
        /// By default, assume that all enums are stored as an int instead.
        /// </summary>
        public bool IsChar { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="StoredAsChar"/> class.
        /// </summary>
        public StoredAsChar()
        {
            IsChar = true;
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="StoredAsChar"/> class.
        /// </summary>
        /// <param name="isChar">True iff this value is stored as a char.</param>
        public StoredAsChar(bool isChar)
        {
            IsChar = isChar;
        }
    }

}
