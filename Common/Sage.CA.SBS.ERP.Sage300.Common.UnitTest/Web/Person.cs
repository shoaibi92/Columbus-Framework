/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

using System;
using Sage.CA.SBS.ERP.Sage300.Common.Models;

namespace Sage.CA.SBS.ERP.Sage300.Common.UnitTest.Web
{
    /// <summary>
    /// Contains list of properties for Person
    /// </summary>
    public class Person : ModelBase
    {
        /// <summary>
        /// get or sets name
        /// </summary>
        /// <value>The name.</value>
        public string Name { get; set; }

        /// <summary>
        /// get or sets Age
        /// </summary>
        /// <value>The age.</value>
        public int Age { get; set; }

        /// <summary>
        /// get or sets Birthdate
        /// </summary>
        /// <value>The birth date.</value>
        public DateTime BirthDate { get; set; }

        /// <summary>
        /// Class Fields.
        /// </summary>
        public class Fields
        {
            /// <summary>
            /// The name
            /// </summary>
            public const string Name = "Name";

            /// <summary>
            /// The age
            /// </summary>
            public const string Age = "Age";

            /// <summary>
            /// The birth date
            /// </summary>
            public const string BirthDate = "BirthDate";
        }
    }
}