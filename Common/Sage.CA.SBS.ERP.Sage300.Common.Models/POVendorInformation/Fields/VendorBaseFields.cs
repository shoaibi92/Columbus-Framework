// Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved.

using System.Collections.Generic;
using Sage.CA.SBS.ERP.Sage300.Common.Models.Attributes;
// ReSharper disable once CheckNamespace


namespace Sage.CA.SBS.ERP.Sage300.Common.Models.POVendorInformation
{
    /// <summary>
    /// Partial class for Vendor Information
    /// </summary>
    public partial class VendorBase        
    {
        public class Fields
        {
            /// <summary>
            /// Dynamic Attributes contain a reverse mapping of field and property
            /// </summary>
            [IgnoreExportImport]
            public static Dictionary<string, string> DynamicAttributes
            {
                get
                {
                    return new Dictionary<string, string>
                    {
                        {"VDCODE", "Vendor"},
                        {"VDNAME", "Name"},
                        {"VDADDRESS1", "Address1"},
                        {"VDADDRESS2", "Address2"},
                        {"VDADDRESS3", "Address3"},
                        {"VDADDRESS4", "Address4"},
                        {"VDCITY", "City"},
                        {"VDSTATE", "StateProvince"},
                        {"VDZIP", "ZipPostalCode"},
                        {"VDCOUNTRY", "Country"},
                        {"VDPHONE", "PhoneNumber"},
                        {"VDFAX", "FaxNumber"},
                        {"VDCONTACT", "Contact"},
                        {"VDEMAIL", "Email"},
                        {"VDPHONEC", "ContactPhone"},
                        {"VDFAXC", "ContactFax"},
                        {"VDEMAILC", "ContactEmail"},
                    };
                }
            }

            /// <summary>
            /// Property for Vendor
            /// </summary>
            public const string Vendor = "VDCODE";

            /// <summary>
            /// Property for VendorExists
            /// </summary>
            public const string VendorExists = "VDEXISTS";

            /// <summary>
            /// Property for Name
            /// </summary>
            public const string Name = "VDNAME";

            /// <summary>
            /// Property for Address1
            /// </summary>
            public const string Address1 = "VDADDRESS1";

            /// <summary>
            /// Property for Address2
            /// </summary>
            public const string Address2 = "VDADDRESS2";

            /// <summary>
            /// Property for Address3
            /// </summary>
            public const string Address3 = "VDADDRESS3";

            /// <summary>
            /// Property for Address4
            /// </summary>
            public const string Address4 = "VDADDRESS4";

            /// <summary>
            /// Property for City
            /// </summary>
            public const string City = "VDCITY";

            /// <summary>
            /// Property for StateProvince
            /// </summary>
            public const string StateProvince = "VDSTATE";

            /// <summary>
            /// Property for ZipPostalCode
            /// </summary>
            public const string ZipPostalCode = "VDZIP";

            /// <summary>
            /// Property for Country
            /// </summary>
            public const string Country = "VDCOUNTRY";

            /// <summary>
            /// Property for PhoneNumber
            /// </summary>
            public const string PhoneNumber = "VDPHONE";

            /// <summary>
            /// Property for FaxNumber
            /// </summary>
            public const string FaxNumber = "VDFAX";

            /// <summary>
            /// Property for Contact
            /// </summary>
            public const string Contact = "VDCONTACT";

            /// <summary>
            /// Property for Email
            /// </summary>
            public const string Email = "VDEMAIL";

            /// <summary>
            /// Property for ContactPhone
            /// </summary>
            public const string ContactPhone = "VDPHONEC";

            /// <summary>
            /// Property for ContactFax
            /// </summary>
            public const string ContactFax = "VDFAXC";

            /// <summary>
            /// Property for ContactEmail
            /// </summary>
            public const string ContactEmail = "VDEMAILC";
        }
    }
}
