// Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved.

#region Namespace

using System.ComponentModel.DataAnnotations;
using Sage.CA.SBS.ERP.Sage300.Common.Models;
using Sage.CA.SBS.ERP.Sage300.Common.Resources;

#endregion

namespace Sage.CA.SBS.ERP.Sage300.Common.Models
{
     /// <summary>
     /// Partial class for Cost
     /// </summary>
    public partial class BillToLocation : ModelBase
     {
         /// <summary>
         /// Gets or sets BillToLocation
         /// </summary>
         [StringLength(6, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
         //[Display(Name = "BillToLocation", ResourceType = typeof(POCommonResx))]
         public string BillToLoc { get; set; }


         /// <summary>
         /// Gets or sets BillToLocationDescription
         /// </summary>
         [StringLength(60, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
         //[Display(Name = "BillToLocationDescription", ResourceType = typeof(ReturnEntryResx))]
         public string BillToLocationDescription { get; set; }

         /// <summary>
         /// Gets or sets BillToAddress1
         /// </summary>
         [StringLength(60, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
         //[Display(Name = "BillToAddress1", ResourceType = typeof(ReturnEntryResx))]
         public string BillToAddress1 { get; set; }

         /// <summary>
         /// Gets or sets BillToAddress2
         /// </summary>
         [StringLength(60, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
         //[Display(Name = "BillToAddress2", ResourceType = typeof(ReturnEntryResx))]
         public string BillToAddress2 { get; set; }

         /// <summary>
         /// Gets or sets BillToAddress3
         /// </summary>
         [StringLength(60, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
         //[Display(Name = "BillToAddress3", ResourceType = typeof(ReturnEntryResx))]
         public string BillToAddress3 { get; set; }

         /// <summary>
         /// Gets or sets BillToAddress4
         /// </summary>
         [StringLength(60, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
         //[Display(Name = "BillToAddress4", ResourceType = typeof(ReturnEntryResx))]
         public string BillToAddress4 { get; set; }

         /// <summary>
         /// Gets or sets BillToCity
         /// </summary>
         [StringLength(30, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
         //[Display(Name = "BillToCity", ResourceType = typeof(ReturnEntryResx))]
         public string BillToCity { get; set; }

         /// <summary>
         /// Gets or sets BillToStateProvince
         /// </summary>
         [StringLength(30, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
         //[Display(Name = "BillToStateProvince", ResourceType = typeof(ReturnEntryResx))]
         public string BillToStateProvince { get; set; }

         /// <summary>
         /// Gets or sets BillToZipPostalCode
         /// </summary>
         [StringLength(20, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
         //[Display(Name = "BillToZipPostalCode", ResourceType = typeof(ReturnEntryResx))]
         public string BillToZipPostalCode { get; set; }

         /// <summary>
         /// Gets or sets BillToCountry
         /// </summary>
         [StringLength(30, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
         //[Display(Name = "BillToCountry", ResourceType = typeof(ReturnEntryResx))]
         public string BillToCountry { get; set; }

         /// <summary>
         /// Gets or sets BillToPhoneNumber
         /// </summary>
         [StringLength(30, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
         //[Display(Name = "BillToPhoneNumber", ResourceType = typeof(ReturnEntryResx))]
         public string BillToPhoneNumber { get; set; }

         /// <summary>
         /// Gets or sets BillToFaxNumber
         /// </summary>
         [StringLength(30, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
         //[Display(Name = "BillToFaxNumber", ResourceType = typeof(ReturnEntryResx))]
         public string BillToFaxNumber { get; set; }

         /// <summary>
         /// Gets or sets BillToContact
         /// </summary>
         [StringLength(60, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
         //[Display(Name = "BillToContact", ResourceType = typeof(ReturnEntryResx))]
         public string BillToContact { get; set; }

         /// <summary>
         /// Gets or sets BillToEmail
         /// </summary>
         [StringLength(50, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
         //[Display(Name = "BillToEmail", ResourceType = typeof(ReturnEntryResx))]
         public string BillToEmail { get; set; }

         /// <summary>
         /// Gets or sets BillToContactPhone
         /// </summary>
         [StringLength(30, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
         //[Display(Name = "BillToContactPhone", ResourceType = typeof(ReturnEntryResx))]
         public string BillToContactPhone { get; set; }

         /// <summary>
         /// Gets or sets BillToContactFax
         /// </summary>
         [StringLength(30, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
         //[Display(Name = "BillToContactFax", ResourceType = typeof(ReturnEntryResx))]
         public string BillToContactFax { get; set; }

         /// <summary>
         /// Gets or sets BillToContactEmail
         /// </summary>
         [StringLength(50, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
         //[Display(Name = "BillToContactEmail", ResourceType = typeof(ReturnEntryResx))]
         public string BillToContactEmail { get; set; }

         public class Fields
         {
             /// <summary>
             /// Property for BillToLocation
             /// </summary>
             public const string BillToLocation = "BTCODE";

             /// <summary>
             /// Property for BillToLocationDescription
             /// </summary>
             public const string BillToLocationDescription = "BTDESC";

             /// <summary>
             /// Property for BillToAddress1
             /// </summary>
             public const string BillToAddress1 = "BTADDRESS1";

             /// <summary>
             /// Property for BillToAddress2
             /// </summary>
             public const string BillToAddress2 = "BTADDRESS2";

             /// <summary>
             /// Property for BillToAddress3
             /// </summary>
             public const string BillToAddress3 = "BTADDRESS3";

             /// <summary>
             /// Property for BillToAddress4
             /// </summary>
             public const string BillToAddress4 = "BTADDRESS4";

             /// <summary>
             /// Property for BillToCity
             /// </summary>
             public const string BillToCity = "BTCITY";

             /// <summary>
             /// Property for BillToStateProvince
             /// </summary>
             public const string BillToStateProvince = "BTSTATE";

             /// <summary>
             /// Property for BillToZipPostalCode
             /// </summary>
             public const string BillToZipPostalCode = "BTZIP";

             /// <summary>
             /// Property for BillToCountry
             /// </summary>
             public const string BillToCountry = "BTCOUNTRY";

             /// <summary>
             /// Property for BillToPhoneNumber
             /// </summary>
             public const string BillToPhoneNumber = "BTPHONE";

             /// <summary>
             /// Property for BillToFaxNumber
             /// </summary>
             public const string BillToFaxNumber = "BTFAX";

             /// <summary>
             /// Property for BillToContact
             /// </summary>
             public const string BillToContact = "BTCONTACT";

             /// <summary>
             /// Property for BillToEmail
             /// </summary>
             public const string BillToEmail = "BTEMAIL";

             /// <summary>
             /// Property for BillToContactPhone
             /// </summary>
             public const string BillToContactPhone = "BTPHONEC";

             /// <summary>
             /// Property for BillToContactFax
             /// </summary>
             public const string BillToContactFax = "BTFAXC";

             /// <summary>
             /// Property for BillToContactEmail
             /// </summary>
             public const string BillToContactEmail = "BTEMAILC";
         }
     }


}
