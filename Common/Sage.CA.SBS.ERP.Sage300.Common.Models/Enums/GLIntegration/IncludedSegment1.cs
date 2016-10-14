// Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. 

using Sage.CA.SBS.ERP.Sage300.Common.Resources;

namespace Sage.CA.SBS.ERP.Sage300.Common.Models.Enums.GLIntegration
{
	/// <summary>
    /// Enum for IncludedSegment1 
    /// </summary>
	public enum IncludedSegment1 
	{
		/// <summary>
		/// Gets or sets None 
		/// </summary>	
        [EnumValue("None", typeof(CommonResx), 1)]
        None = 0,
		/// <summary>
		/// Gets or sets Adjustment Number 
		/// </summary>	
        [EnumValue("AdjustmentNumber", typeof(EnumerationsResx), 2)]
        AdjustmentNumber = 1,
		/// <summary>
		/// Gets or sets Apply By Document Type 
		/// </summary>	
        [EnumValue("ApplyByDocumentType", typeof(EnumerationsResx), 3)]
        ApplyByDocumentType = 2,
		/// <summary>
		/// Gets or sets Apply To Document Number 
		/// </summary>	
        [EnumValue("ApplyToDocumentNumber", typeof(EnumerationsResx), 4)]
        ApplyToDocumentNumber = 3,
		/// <summary>
		/// Gets or sets Bank Code 
		/// </summary>	
        [EnumValue("BankCode", typeof(EnumerationsResx), 5)]
        BankCode = 4,
		/// <summary>
		/// Gets or sets Batch Number 
		/// </summary>	
        [EnumValue("BatchNumber", typeof(EnumerationsResx), 6)]
        BatchNumber = 5,
		/// <summary>
		/// Gets or sets Batch Type 
		/// </summary>	
        [EnumValue("BatchType", typeof(EnumerationsResx), 7)]
        BatchType = 6,
		/// <summary>
		/// Gets or sets Category 
		/// </summary>	
        [EnumValue("Category", typeof(EnumerationsResx), 8)]
        Category = 7,
		/// <summary>
		/// Gets or sets Check Date 
		/// </summary>	
        [EnumValue("CheckDate", typeof(EnumerationsResx), 9)]
        CheckDate = 8,
		/// <summary>
		/// Gets or sets Check Number 
		/// </summary>	
        [EnumValue("CheckNumber", typeof(EnumerationsResx), 10)]
        CheckNumber = 9,
		/// <summary>
		/// Gets or sets Comment 
		/// </summary>	
        [EnumValue("Comment", typeof(EnumerationsResx), 11)]
        Comment = 10,
		/// <summary>
		/// Gets or sets Contract 
		/// </summary>	
        [EnumValue("Contract", typeof(EnumerationsResx), 12)]
        Contract = 11,
		/// <summary>
		/// Gets or sets Description 
		/// </summary>	
        [EnumValue("ProcessingDescription", typeof(CommonResx), 13)]
        Description = 12,
		/// <summary>
		/// Gets or sets Detail Description 
		/// </summary>	
        [EnumValue("DetailDescription", typeof(EnumerationsResx), 14)]
        DetailDescription = 13,
		/// <summary>
		/// Gets or sets Detail Reference 
		/// </summary>	
        [EnumValue("DetailReference", typeof(EnumerationsResx), 15)]
        DetailReference = 14,
		/// <summary>
		/// Gets or sets Distribution Code 
		/// </summary>	
        [EnumValue("DistributionCode", typeof(EnumerationsResx), 16)]
        DistributionCode = 15,
		/// <summary>
		/// Gets or sets Document Number 
		/// </summary>	
        [EnumValue("DocumentNumber", typeof(EnumerationsResx), 17)]
        DocumentNumber = 16,
		/// <summary>
		/// Gets or sets Document Type 
		/// </summary>	
        [EnumValue("DocumentType", typeof(EnumerationsResx), 18)]
        DocumentType = 17,
		/// <summary>
		/// Gets or sets Entry Number 
		/// </summary>	
        [EnumValue("EntryNumber", typeof(EnumerationsResx), 19)]
        EntryNumber = 18,
		/// <summary>
		/// Gets or sets Invoice Number 
		/// </summary>	
        [EnumValue("InvoiceNumber", typeof(EnumerationsResx), 20)]
        InvoiceNumber = 19,
		/// <summary>
		/// Gets or sets Order Number 
		/// </summary>	
        [EnumValue("OrderNumber", typeof(EnumerationsResx), 21)]
        OrderNumber = 20,
		/// <summary>
		/// Gets or sets Payee 
		/// </summary>	
        [EnumValue("Payee", typeof(EnumerationsResx), 22)]
        Payee = 21,
		/// <summary>
		/// Gets or sets Payment Code 
		/// </summary>	
        [EnumValue("PaymentCode", typeof(EnumerationsResx), 23)]
        PaymentCode = 22,
		/// <summary>
		/// Gets or sets Posting Sequence 
		/// </summary>	
        [EnumValue("PostingSequence", typeof(EnumerationsResx), 24)]
        PostingSequence = 23,
		/// <summary>
		/// Gets or sets Project 
		/// </summary>	
        [EnumValue("Project", typeof(EnumerationsResx), 25)]
        Project = 24,
		/// <summary>
		/// Gets or sets Purchase Order Number 
		/// </summary>	
        [EnumValue("PurchaseOrderNumber", typeof(EnumerationsResx), 26)]
        PurchaseOrderNumber = 25,
		/// <summary>
		/// Gets or sets Reference 
		/// </summary>	
        [EnumValue("Reference", typeof(EnumerationsResx), 27)]
        Reference = 26,
		/// <summary>
		/// Gets or sets Remit To 
		/// </summary>	
        [EnumValue("RemitTo", typeof(EnumerationsResx), 28)]
        RemitTo = 27,
		/// <summary>
		/// Gets or sets Remit To Location 
		/// </summary>	
        [EnumValue("RemitToLocation", typeof(EnumerationsResx), 29)]
        RemitToLocation = 28,
		/// <summary>
		/// Gets or sets Resource 
		/// </summary>	
        [EnumValue("Resource", typeof(EnumerationsResx), 30)]
        Resource = 29,
		/// <summary>
		/// Gets or sets Reversal Date 
		/// </summary>	
        [EnumValue("ReversalDate", typeof(EnumerationsResx), 31)]
        ReversalDate = 30,
		/// <summary>
		/// Gets or sets Reversal Description 
		/// </summary>	
        [EnumValue("ReversalDescription", typeof(EnumerationsResx), 32)]
        ReversalDescription = 31,
		/// <summary>
		/// Gets or sets Tax Group 
		/// </summary>	
        [EnumValue("TaxGroup", typeof(EnumerationsResx), 33)]
        TaxGroup = 32,
		/// <summary>
		/// Gets or sets Transaction Type 
		/// </summary>	
        [EnumValue("TransactionType", typeof(EnumerationsResx), 34)]
        TransactionType = 33,
		/// <summary>
		/// Gets or sets Vendor Name 
		/// </summary>	
        [EnumValue("VendorName", typeof(EnumerationsResx), 35)]
        VendorName = 34,
		/// <summary>
		/// Gets or sets Vendor Number 
		/// </summary>	
        [EnumValue("VendorNumber", typeof(EnumerationsResx), 36)]
        VendorNumber = 35,
		/// <summary>
		/// Gets or sets Vendor Short Name 
		/// </summary>	
        [EnumValue("VendorShortName", typeof(EnumerationsResx), 37)]
        VendorShortName = 36,
	}
}
