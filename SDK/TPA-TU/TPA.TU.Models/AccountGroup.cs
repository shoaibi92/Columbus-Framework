/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

using System;
using System.ComponentModel.DataAnnotations;
using TPA.TU.Resources.Forms;
using TPA.TU.Resources;
using Sage.CA.SBS.ERP.Sage300.Common.Models;
using Sage.CA.SBS.ERP.Sage300.Common.Models.Attributes;
using Sage.CA.SBS.ERP.Sage300.Common.Resources;
using TPA.TU.Models.Enums;

namespace TPA.TU.Models
{
    public partial class AccountGroup : ModelBase
    {
         /// <summary>
        /// Constructor
        /// </summary>
        public AccountGroup()
        {
            Status = Status.Active;
        }

        /// <summary>
        /// Gets or sets AccountGroupCode 
        /// </summary>
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [StringLength(6, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [Display(Name = "AccountGroupCode", ResourceType = typeof(AccountGroupsResx))]
        [RegularExpression(@"^[a-zA-Z0-9]+$", ErrorMessageResourceName = "AlphaNumeric", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [Key]
        public string AccountGroupCode { get; set; }

        /// <summary>
        /// Gets or sets Description 
        /// </summary>
        [StringLength(60, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [Display(Name = "AccountGroupDesc", ResourceType = typeof(AccountGroupsResx))]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets Status 
        /// </summary>
        [Display(Name = "Status", ResourceType = typeof(AccountGroupsResx))]
        public Status Status { get; set; }

        /// <summary>
        /// To get the string of Status property
        /// </summary>
        public string StatusString
        {
            get
            {
                return EnumUtility.GetStringValue(Status);
            }
        }

        /// <summary>
        /// Gets or sets InactiveDate 
        /// </summary>
        [ValidateDateFormat(ErrorMessageResourceName = "DateFormat", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [Display(Name = "InactiveDate", ResourceType = typeof(AccountGroupsResx))]
        public DateTime InactiveDate { get; set; }

        /// <summary>
        /// Gets or sets DateLastMaintained 
        /// </summary>
        [Display(Name = "LastMaintained", ResourceType = typeof(CommonResx))]
        [ValidateDateFormat(ErrorMessageResourceName = "DateFormat", ErrorMessageResourceType = typeof(AnnotationsResx))]
        public DateTime DateLastMaintained { get; set; }

        /// <summary>
        /// Gets or sets PayablesControlAccount 
        /// </summary>
         [Display(Name = "PayablesControl", ResourceType = typeof(AccountGroupsResx))]
        [StringLength(45, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        public string PayablesControlAccount { get; set; }

        /// <summary>
        /// Gets or sets DiscountsAccount 
        /// </summary>
        [Display(Name = "PurchaseDiscounts", ResourceType = typeof(AccountGroupsResx))]
        [StringLength(45, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        public string DiscountsAccount { get; set; }

        /// <summary>
        /// Gets or sets PrepaymentAccount 
        /// </summary>
          [Display(Name = "Prepayment", ResourceType = typeof(AccountGroupsResx))]
        [StringLength(45, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        public string PrepaymentAccount { get; set; }

        /// <summary>
        /// Gets or sets CurrencyCodeforAccount 
        /// </summary>
       [Display(Name = "Currency", ResourceType = typeof(AccountGroupsResx))]
        [StringLength(3, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        public string CurrencyCodeforAccount { get; set; }

        /// <summary>
        /// Gets or sets UnrealizedExchangeGainAccount 
        /// </summary>
          [Display(Name = "UnrlzExchGain", ResourceType = typeof(AccountGroupsResx))]
        [StringLength(45, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        public string UnrealizedExchangeGainAccount { get; set; }

        /// <summary>
        /// Gets or sets UnrealizedExchangeLossAccount 
        /// </summary>
        [Display(Name = "UnrlzExchLoss", ResourceType = typeof(AccountGroupsResx))] 
        [StringLength(45, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        public string UnrealizedExchangeLossAccount { get; set; }

        /// <summary>
        /// Gets or sets ExchangeGainAccount 
        /// </summary>
        [Display(Name = "RlzExchGain", ResourceType = typeof(AccountGroupsResx))] 
        [StringLength(45, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        public string ExchangeGainAccount { get; set; }

        /// <summary>
        /// Gets or sets ExchangeLossAccount 
        /// </summary>
        [Display(Name = "RlzEXchLoss", ResourceType = typeof(AccountGroupsResx))] 
        [StringLength(45, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        public string ExchangeLossAccount { get; set; }
       

        /// <summary>
        /// Gets or sets RetainageAccount 
        /// </summary>
         [Display(Name = "Retainage", ResourceType = typeof(AccountGroupsResx))] 
        [StringLength(45, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        public string RetainageAccount { get; set; }

        /// <summary>
        /// Gets or sets ExchangeRoundingAccount 
        /// </summary>
        [Display(Name = "ExchRounding", ResourceType = typeof(AccountGroupsResx))] 
        [StringLength(45, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        public string ExchangeRoundingAccount { get; set; }
       
    }
}
