
using Sage.CA.SBS.ERP.Sage300.Common.Models.Attributes;
using Sage.CA.SBS.ERP.Sage300.Common.Models.Enums.InvoiceEntry;
using Sage.CA.SBS.ERP.Sage300.Common.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Sage.CA.SBS.ERP.Sage300.Common.Models.InvoiceEntry
{
    /// <summary>
    /// BaseInvoiceEntry Class
    /// </summary>
    public partial class BaseInvoiceBatch : ModelBase
    {
        /// <summary>
        /// Constructor 
        /// </summary>
        public BaseInvoiceBatch()
        {
            Invoices = new BaseInvoice
            {
                OptionalFieldList = new EnumerableResponse<BaseInvoiceOptionalField>{Items = new List<BaseInvoiceOptionalField>()},
                InvoiceDetails = new EnumerableResponse<BaseInvoiceDetail> { Items = new List<BaseInvoiceDetail>() }
            };
        }
        /// <summary>
        /// Gets or sets BatchNumber 
        /// </summary>
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [Key]
        [Display(Name = "BatchNumber", ResourceType = typeof(InvoiceResx))]
        [RegularExpression(@"^[0-9]+$", ErrorMessageResourceName = "OnlyNumbersMessage", ErrorMessageResourceType = typeof(AnnotationsResx))]
        public decimal BatchNumber { get; set; }

        /// <summary>
        /// Gets or sets ReadyToPost
        /// </summary>
        /// <value>The readyto post.</value>
        [Display(Name = "ReadyToPost", ResourceType = typeof(InvoiceResx))]
        public Printed ReadyToPost { get; set; }

        /// <summary>
        /// Gets or sets BatchDate 
        /// </summary>
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [ValidateDateFormat(ErrorMessageResourceName = "DateFormat", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [Display(Name = "BatchDate", ResourceType = typeof(InvoiceResx))]
        public DateTime BatchDate { get; set; }

        /// <summary>
        /// Gets or sets Description 
        /// </summary>
        [StringLength(60, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [Display(Name = "BatchDescription", ResourceType = typeof(InvoiceResx))]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets NumberOfEntries 
        /// </summary>
        [Display(Name = "NumOfEntries", ResourceType = typeof(InvoiceResx))]
        public decimal NumberOfEntries { get; set; }

        /// <summary>
        /// Gets or sets BatchTotal 
        /// </summary>
        [Display(Name = "BatchTotal", ResourceType = typeof(InvoiceResx))]
        public decimal BatchTotal { get; set; }

        /// <summary>
        /// Gets or sets Type
        /// </summary>
        /// <value>The type.</value>
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [Display(Name = "Type", ResourceType = typeof(InvoiceResx))]
        public BatchType BatchType { get; set; }

        /// <summary>
        /// To get the string of Type property
        /// </summary>
        /// <value>The type string.</value>
        [Display(Name = "Type", ResourceType = typeof(InvoiceResx))]
        public string TypeString
        {
            get { return EnumUtility.GetStringValue(BatchType); }
        }

        /// <summary>
        /// Gets or sets Type
        /// </summary>
        /// <value>The type</value>
        /// This enum is specific for AR Invoice Batch Type
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [Display(Name = "Type", ResourceType = typeof(InvoiceResx))]
        public ARBatchType ARBatchType { get; set; }

        /// <summary>
        /// To get the string of Type property
        /// </summary>
        /// <value>The type string.</value>
        [Display(Name = "Type", ResourceType = typeof(InvoiceResx))]
        public string ARTypeString
        {
            get { return EnumUtility.GetStringValue(ARBatchType); }
        }

        /// <summary>
        /// Gets or sets BatchStatus 
        /// </summary>
        [Display(Name = "Status", ResourceType = typeof(InvoiceResx))]
        public BatchStatus BatchStatus { get; set; }

        /// <summary>
        /// To get the string of Status property
        /// </summary>
        /// <value>The status string.</value>
        [Display(Name = "Status", ResourceType = typeof(InvoiceResx))]
        public string StatusString
        {
            get { return EnumUtility.GetStringValue(BatchStatus); }
        }

        /// <summary>
        /// Gets or sets InvoiceType 
        /// </summary>
        public InvoiceType InvoiceType { get; set; }

        /// <summary>
        /// Gets or sets ARInvoiceType 
        /// </summary>
        /// ARInvoice Type is specific for AR Invoice Batch Type
        public ARInvoiceType DefaultInvoiceType { get; set; }

        /// <summary>
        /// Gets or sets LastEntryNumber 
        /// </summary>
        [Display(Name = "LastEntryNumber", ResourceType = typeof(InvoiceResx))]
        public decimal LastEntryNumber { get; set; }

        /// <summary>
        /// Gets or sets PostingSequenceNo 
        /// </summary>
        [Display(Name = "PostingSequence", ResourceType = typeof(InvoiceResx))]
        public decimal PostingSequenceNo { get; set; }

        /// <summary>
        /// Gets or sets Printed
        /// </summary>
        /// <value>The printed.</value>
        [Display(Name = "Printed", ResourceType = typeof(CommonResx))]
        public Printed Printed { get; set; }

        /// <summary>
        /// Gets the Printed value as string
        /// </summary>
        [Display(Name = "Printed", ResourceType = typeof(CommonResx))]
        public string PrintedString
        {
            get { return EnumUtility.GetStringValue(BatchPrintedFlag); }
        }

        /// <summary>
        /// Gets or sets NumberOfErrors 
        /// </summary>
        [Display(Name = "NumOfErrors", ResourceType = typeof(InvoiceResx))]
        public decimal NumberOfErrors { get; set; }

        /// <summary>
        /// Gets or sets DateLastEdited 
        /// </summary>
        [ValidateDateFormat(ErrorMessageResourceName = "DateFormat", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [Display(Name = "LastEdited", ResourceType = typeof(InvoiceResx))]
        public DateTime DateLastEdited { get; set; }

        /// <summary>
        /// Gets or sets BatchPrintedFlag 
        /// </summary>
        [Display(Name = "Printed", ResourceType = typeof(CommonResx))]
        public BatchPrintedFlag BatchPrintedFlag { get; set; }

        /// <summary>
        /// Gets the Printed value as string
        /// </summary>
        [Display(Name = "Printed", ResourceType = typeof(CommonResx))]
        public string BatchPrintedFlagString
        {
            get { return EnumUtility.GetStringValue(BatchPrintedFlag); }
        }

        /// <summary>
        /// To get the string of Batch Type String property
        /// </summary>
        public string BatchTypeString
        {
            get { return EnumUtility.GetStringValue(BatchType); }
        }

        /// <summary>
        /// To get the string of Batch Status String property
        /// </summary>
        public string BatchStatusString
        {
            get { return EnumUtility.GetStringValue(BatchStatus); }
        }
        /// <summary>
        /// Gets or sets SourceApplication 
        /// </summary>
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [StringLength(2, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [Display(Name = "SourceApplication", ResourceType = typeof(InvoiceResx))]
        public string SourceApplication { get; set; }

        /// <summary>
        /// Gets or sets ICTRelated 
        /// </summary>
        public BatchPrintedFlag IctRelated { get; set; }

        /// <summary>
        /// Gets or sets ProcessCommandCode 
        /// </summary>
        public ProcessCommandCode ProcessCommandCode { get; set; }



        /// <summary>
        /// Gets or sets LockBatchSwitch
        /// </summary>
        /// <value>The lock batch switch.</value>
        public LockBatchSwitch LockBatchSwitch { get; set; }



        /// <summary>
        /// Conversion of BatchDate into DateTime 
        /// </summary>
        public DateTime BatchDateTime { get; set; }

        /// <summary>
        /// Decimal of BatchNumber
        /// </summary>
        public decimal BatchNumberDecimal { get; set; }

        /// <summary>
        /// Conversion of DateEdited into DateTime
        /// </summary>
        public DateTime LastEditedDateValue { get; set; }

        /// <summary>
        /// Gets the InvoiceType as string
        /// </summary>
        public string InvoiceTypeString
        {
            get { return EnumUtility.GetStringValue(InvoiceType); }
        }

        /// <summary>
        /// Gets the AR InvoiceType as string
        /// </summary>
        public string DefaultInvoiceTypeString
        {
            get { return EnumUtility.GetStringValue(DefaultInvoiceType); }
        }

        /// <summary>
        /// Gets the ProcessCommandCode as string
        /// </summary>
        public string ProcessCommandCodeString
        {
            get { return EnumUtility.GetStringValue(ProcessCommandCode); }
        }

        /// <summary>
        /// Gets the ICTRelated as string
        /// </summary>
        public string IctRelatedString
        {
            get { return EnumUtility.GetStringValue(IctRelated); }
        }

        /// <summary>
        /// Gets or sets Session date
        /// </summary>
        /// <value>The session date.</value>
        public DateTime SessionDate { get; set; }


        /// <summary>
        /// Gets or sets Session Warning Days
        /// </summary>
        /// <value>The session warn days.</value>
        public short SessionWarnDays { get; set; }

        ///// <summary>
        ///// Gets or sets DefaultInvoiceType 
        ///// </summary>
        //public DefaultInvoiceType DefaultInvoiceType { get; set; }

        ///// <summary>
        ///// To get the string of DefaultInvoiceType property
        ///// </summary>
        ///// <value>The status string.</value>
        //public string DefaultInvoiceTypeString
        //{
        //    get { return EnumUtility.GetStringValue(DefaultInvoiceType); }
        //}


        /// <summary>
        /// Gets or sets ProcessCommand 
        /// </summary>
        public ProcessCommandCode ProcessCommand { get; set; }

        /// <summary>
        /// Invoices related to the Invoice Batch
        /// </summary>
        /// <value>The invoices.</value>
        public BaseInvoice Invoices { get; set; }

        
    }
}
