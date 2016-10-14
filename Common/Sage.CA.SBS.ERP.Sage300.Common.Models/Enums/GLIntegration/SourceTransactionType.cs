// Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. 

using Sage.CA.SBS.ERP.Sage300.Common.Resources;

namespace Sage.CA.SBS.ERP.Sage300.Common.Models.Enums.GLIntegration
{
	/// <summary>
    /// Enum for Source Transaction Type 
    /// </summary>
	public enum SourceTransactionType 
	{
		/// <summary>
		/// Gets or sets Invoice 
		/// </summary>	
        [EnumValue("Invoice", typeof(GLIntegrationResx), 1)]
        Invoice = 100,
		/// <summary>
		/// Gets or sets Invoice Detail 
		/// </summary>	
        [EnumValue("InvoiceDetail", typeof(EnumerationsResx), 2)]
        InvoiceDetail = 101,
		/// <summary>
		/// Gets or sets Debit Note 
		/// </summary>	
        [EnumValue("DebitNote", typeof(GLIntegrationResx), 3)]
        DebitNote = 200,
		/// <summary>
		/// Gets or sets Debit Note Detail 
		/// </summary>	
        [EnumValue("DebitNoteDetail", typeof(EnumerationsResx), 4)]
        DebitNoteDetail = 201,
		/// <summary>
		/// Gets or sets Credit Note 
		/// </summary>	
        [EnumValue("CreditNote", typeof(GLIntegrationResx), 5)]
        CreditNote = 300,
		/// <summary>
		/// Gets or sets Credit Note Detail 
		/// </summary>	
        [EnumValue("CreditNoteDetail", typeof(EnumerationsResx), 6)]
        CreditNoteDetail = 301,
		/// <summary>
		/// Gets or sets Payment 
		/// </summary>	
        [EnumValue("Payment", typeof(GLIntegrationResx), 7)]
        Payment = 400,
		/// <summary>
		/// Gets or sets Payment Detail 
		/// </summary>	
        [EnumValue("PaymentDetail", typeof(EnumerationsResx), 8)]
        PaymentDetail = 401,
		/// <summary>
		/// Gets or sets Payment Advance Credit Claim 
		/// </summary>	
        [EnumValue("PaymentAdvanceCreditClaim", typeof(EnumerationsResx), 9)]
        PaymentAdvanceCreditClaim = 402,
		/// <summary>
		/// Gets or sets Prepayment 
		/// </summary>	
        [EnumValue("Prepayment", typeof(GLIntegrationResx), 10)]
        Prepayment = 500,
		/// <summary>
		/// Gets or sets Apply Document 
		/// </summary>	
        [EnumValue("ApplyDocument", typeof(EnumerationsResx), 11)]
        ApplyDocument = 600,
		/// <summary>
		/// Gets or sets Apply Document Detail 
		/// </summary>	
        [EnumValue("ApplyDocumentDetail", typeof(EnumerationsResx), 12)]
        ApplyDocumentDetail = 601,
		/// <summary>
		/// Gets or sets Miscellaneous Payment 
		/// </summary>	
        [EnumValue("MiscellaneousPayment", typeof(EnumerationsResx), 13)]
        MiscellaneousPayment = 700,
		/// <summary>
		/// Gets or sets Miscellaneous Payment Detail 
		/// </summary>	
        [EnumValue("MiscellaneousPaymentDetail", typeof(EnumerationsResx), 14)]
        MiscellaneousPaymentDetail = 701,
		/// <summary>
		/// Gets or sets Miscellaneous Adjustment 
		/// </summary>	
        [EnumValue("MiscellaneousAdjustment", typeof(EnumerationsResx), 15)]
        MiscellaneousAdjustment = 800,
		/// <summary>
		/// Gets or sets Miscellaneous Adjustment Detail 
		/// </summary>	
        [EnumValue("MiscellaneousAdjustmentDetail", typeof(EnumerationsResx), 16)]
        MiscellaneousAdjustmentDetail = 801,
		/// <summary>
		/// Gets or sets Adjustment 
		/// </summary>	
        [EnumValue("Adjustment", typeof(GLIntegrationResx), 17)]
        Adjustment = 900,
		/// <summary>
		/// Gets or sets Adjustment Detail 
		/// </summary>	
        [EnumValue("AdjustmentDetail", typeof(EnumerationsResx), 18)]
        AdjustmentDetail = 901,

        /// <summary>
        /// Gets or sets Revaluation Detail 
        /// </summary>	
        [EnumValue("Revaluation", typeof(GLIntegrationResx), 19)]
        Revaluation = 1000,

		/// <summary>
		/// Gets or sets Reverse Check 
		/// </summary>	
        [EnumValue("ReverseCheck", typeof(EnumerationsResx), 20)]
        ReverseCheck = 1100,
	}
}
