// Copyright (c) 1994-2015 Sage Software, Inc.  All rights reserved.

#region Namespace

using Sage.CA.SBS.ERP.Sage300.Common.Models.Attributes;
using Sage.CA.SBS.ERP.Sage300.Common.Models.Enums.InvoiceEntry;
using Sage.CA.SBS.ERP.Sage300.Common.Resources;
using System;
using System.ComponentModel.DataAnnotations;

#endregion

namespace Sage.CA.SBS.ERP.Sage300.Common.Models.InvoiceEntry
{
    /// <summary>
    /// Base InvoiceOptionalField Model
    /// </summary>
    public partial class BaseInvoiceOptionalField : ModelBase
    {
        /// <summary>
        /// Gets or sets InvoiceSequenceKey
        /// </summary>
        [Key]
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [Display(Name = "InvoiceSequenceKey", ResourceType = typeof(InvoiceResx))]
        public decimal InvoiceSequenceKey { get; set; }

        /// <summary>
        /// Gets or sets BatchNumber 
        /// </summary>
        [Key]
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [Display(Name = "LineNumber", ResourceType = typeof(InvoiceResx))]
        public int LineNumber { get; set; }

        /// <summary>
        /// Gets or sets BatchNumber 
        /// </summary>
        [Key]
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [Display(Name = "LineNumber", ResourceType = typeof(InvoiceResx))]
        public int DetailLineNumber { get; set; }

        /// <summary>
        /// Gets or sets BatchNumber 
        /// </summary>
        [Key]
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [Display(Name = "LineNumber", ResourceType = typeof(InvoiceResx))]
        public int AdditionalCostLineNumber { get; set; }

        /// <summary>
        /// Gets or sets BatchNumber 
        /// </summary>
        [Key]
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [Display(Name = "BatchNumber", ResourceType = typeof(InvoiceResx))]
        public string BatchNumber { get; set; }

        /// <summary>
        /// Gets or sets EntryNumber 
        /// </summary>
        [Key]
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [Display(Name = "EntryNumber", ResourceType = typeof(InvoiceResx))]
        public string EntryNumber { get; set; }

        /// <summary>
        /// Gets or sets OptionalField 
        /// </summary>
        [Key]
        [StringLength(12, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [Display(Name = "OptionalField", ResourceType = typeof(CommonResx))]
        public string OptionalField { get; set; }

        /// <summary>
        /// Gets or sets Value 
        /// </summary>
        [StringLength(60, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [Display(Name = "Value", ResourceType = typeof(InvoiceResx))]
        public string Value { get; set; }

        /// <summary>
        /// Gets or sets Type 
        /// </summary>
        [Display(Name = "Type", ResourceType = typeof(InvoiceResx))]
        public Enums.InvoiceEntry.Type Type { get; set; }

        /// <summary>
        /// Gets or sets Length 
        /// </summary>
        [Display(Name = "Length", ResourceType = typeof(InvoiceResx))]
        public int Length { get; set; }

        /// <summary>
        /// Gets or sets Decimals 
        /// </summary>
        [Display(Name = "Decimals", ResourceType = typeof(InvoiceResx))]
        public int Decimals { get; set; }

        /// <summary>
        /// Gets or sets AllowBlank 
        /// </summary>
        [Display(Name = "AllowBlank", ResourceType = typeof(InvoiceResx))]
        public BatchPrintedFlag AllowBlank { get; set; }

        /// <summary>
        /// Gets or sets Validate 
        /// </summary>
        [Display(Name = "Validate", ResourceType = typeof(InvoiceResx))]
        public BatchPrintedFlag Validate { get; set; }

        /// <summary>
        /// Gets or sets ValueSet 
        /// </summary>
        [Display(Name = "ValueSet", ResourceType = typeof(InvoiceResx))]
        public ValueSet ValueSet { get; set; }

        /// <summary>
        /// To get the string of ValueSet property
        /// </summary>
        [IgnoreExportImport]
        public string ValueSetString
        {
            get
            {
                return EnumUtility.GetStringValue(ValueSet);
            }
        }
        /// <summary>
        /// Gets or sets TypedValueFieldIndex 
        /// </summary>
        [Display(Name = "TypedValueFieldIndex", ResourceType = typeof(InvoiceResx))]
        public long TypedValueFieldIndex { get; set; }

        /// <summary>
        /// Gets or sets TextValue 
        /// </summary>
        [StringLength(60, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [Display(Name = "TextValue", ResourceType = typeof(InvoiceResx))]
        public string TextValue { get; set; }

        /// <summary>
        /// Gets or sets AmountValue 
        /// </summary>
        [Display(Name = "AmountValue", ResourceType = typeof(InvoiceResx))]
        public decimal AmountValue { get; set; }

        /// <summary>
        /// Gets or sets NumberValue 
        /// </summary>
        [Display(Name = "NumberValue", ResourceType = typeof(InvoiceResx))]
        public decimal NumberValue { get; set; }

        /// <summary>
        /// Gets or sets IntegerValue 
        /// </summary>
        [Display(Name = "IntegerValue", ResourceType = typeof(InvoiceResx))]
        public long IntegerValue { get; set; }

        /// <summary>
        /// Gets or sets YesOrNoValue 
        /// </summary>
        [Display(Name = "YesOrNoValue", ResourceType = typeof(InvoiceResx))]
        public BatchPrintedFlag YesOrNoValue { get; set; }

        /// <summary>
        /// Gets or sets DateValue 
        /// </summary>
        [Display(Name = "DateValue", ResourceType = typeof(InvoiceResx))]
        public DateTime? DateValue { get; set; }

        /// <summary>
        /// Gets or sets TimeValue 
        /// </summary>
        [Display(Name = "TimeValue", ResourceType = typeof(InvoiceResx))]
        public DateTime? TimeValue { get; set; }

        /// <summary>
        /// Gets or sets OptionalFieldDescription 
        /// </summary>
        [StringLength(60, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [Display(Name = "OptionalFieldDescription", ResourceType = typeof(InvoiceResx))]
        public string OptionalFieldDescription { get; set; }

        /// <summary>
        /// Gets or sets ValueDescription 
        /// </summary>
        [IgnoreExportImport]
        [StringLength(60, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [Display(Name = "ValueDescription", ResourceType = typeof(InvoiceResx))]
        public string ValueDescription { get; set; }

        /// <summary>
        /// Gets and sets IsDetailOptionalField
        /// </summary>
        [IgnoreExportImport]
        public bool IsDetailOptionalField { get; set; }

        /// <summary>
        /// Gets and sets LineKey
        /// </summary>
        [IgnoreExportImport]
        public decimal LineKey { get; set; }

        /// <summary>
        /// Gets or sets IsExists
        /// </summary>
        [IgnoreExportImport]
        public bool IsExists { get; set; }

        /// <summary>
        /// Gets or sets IsExists
        /// </summary>
        [Display(Name = "DefaultValueDescription", ResourceType = typeof(InvoiceResx))]
        public string DefaultValueDescription { get; set; }
    }
}
