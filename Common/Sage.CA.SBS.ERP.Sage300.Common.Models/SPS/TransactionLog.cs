// Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved.

#region Namespace

using System;

using System.ComponentModel.DataAnnotations;
using Sage.CA.SBS.ERP.Sage300.Common.Models.Attributes;
using Sage.CA.SBS.ERP.Sage300.Common.Models.Enums;
using Sage.CA.SBS.ERP.Sage300.Common.Models.Enums.SPS;
using Sage.CA.SBS.ERP.Sage300.Common.Resources;

#endregion

namespace Sage.CA.SBS.ERP.Sage300.Common.Models
{
     /// <summary>
     /// Partial class for TransactionLog
     /// </summary>
     public partial class TransactionLog : ModelBase
     {
         /// <summary>
         /// Gets or sets the transaction identifier.
         /// </summary>
         /// <value>
         /// The transaction identifier.
         /// </value>
          [Key]
          [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(AnnotationsResx))]
          [StringLength(36, ErrorMessageResourceName = "MaxLength",ErrorMessageResourceType = typeof(AnnotationsResx))]
          public string TransactionID {get; set;}

          /// <summary>
          /// Gets or sets the bank.
          /// </summary>
          /// <value>
          /// The bank.
          /// </value>
          [StringLength(8, ErrorMessageResourceName = "MaxLength",ErrorMessageResourceType = typeof(AnnotationsResx))]
          public string Bank {get; set;}

          /// <summary>
          /// Gets or sets the currency code.
          /// </summary>
          /// <value>
          /// The currency code.
          /// </value>
          [StringLength(3, ErrorMessageResourceName = "MaxLength",ErrorMessageResourceType = typeof(AnnotationsResx))]
          public string CurrencyCode {get; set;}

          /// <summary>
          /// Gets or sets the action.
          /// </summary>
          /// <value>
          /// The action.
          /// </value>
          public int Action {get; set;}

          /// <summary>
          /// Gets or sets the response indicator.
          /// </summary>
          /// <value>
          /// The response indicator.
          /// </value>
          [StringLength(1, ErrorMessageResourceName = "MaxLength",ErrorMessageResourceType = typeof(AnnotationsResx))]
          public string ResponseIndicator {get; set;}

          /// <summary>
          /// Gets or sets the response code.
          /// </summary>
          /// <value>
          /// The response code.
          /// </value>
          [StringLength(6, ErrorMessageResourceName = "MaxLength",ErrorMessageResourceType = typeof(AnnotationsResx))]
          public string ResponseCode {get; set;}

          /// <summary>
          /// Gets or sets the response message.
          /// </summary>
          /// <value>
          /// The response message.
          /// </value>
          [StringLength(32, ErrorMessageResourceName = "MaxLength",ErrorMessageResourceType = typeof(AnnotationsResx))]
          public string ResponseMessage {get; set;}

          /// <summary>
          /// Gets or sets the unique identifier from message.
          /// </summary>
          /// <value>
          /// The unique identifier from message.
          /// </value>
          [StringLength(36, ErrorMessageResourceName = "MaxLength",ErrorMessageResourceType = typeof(AnnotationsResx))]
          public string GuidFromMessage {get; set;}

          /// <summary>
          /// Gets or sets the expire date.
          /// </summary>
          /// <value>
          /// The expire date.
          /// </value>
          [StringLength(4, ErrorMessageResourceName = "MaxLength",ErrorMessageResourceType = typeof(AnnotationsResx))]
          public string ExpireDate {get; set;}

          /// <summary>
          /// Gets or sets the last4.
          /// </summary>
          /// <value>
          /// The last4.
          /// </value>
          [StringLength(16, ErrorMessageResourceName = "MaxLength",ErrorMessageResourceType = typeof(AnnotationsResx))]
          public string Last4 {get; set;}

          /// <summary>
          /// Gets or sets the payment description.
          /// </summary>
          /// <value>
          /// The payment description.
          /// </value>
          [StringLength(30, ErrorMessageResourceName = "MaxLength",ErrorMessageResourceType = typeof(AnnotationsResx))]
          public string PaymentDescription {get; set;}

          /// <summary>
          /// Gets or sets the payment type identifier.
          /// </summary>
          /// <value>
          /// The payment type identifier.
          /// </value>
          [StringLength(1, ErrorMessageResourceName = "MaxLength",ErrorMessageResourceType = typeof(AnnotationsResx))]
          public string PaymentTypeID {get; set;}

          /// <summary>
          /// Gets or sets the reference1.
          /// </summary>
          /// <value>
          /// The reference1.
          /// </value>
          [StringLength(50, ErrorMessageResourceName = "MaxLength",ErrorMessageResourceType = typeof(AnnotationsResx))]
          public string Reference1 {get; set;}

          /// <summary>
          /// Gets or sets the reference2.
          /// </summary>
          /// <value>
          /// The reference2.
          /// </value>
          [StringLength(50, ErrorMessageResourceName = "MaxLength",ErrorMessageResourceType = typeof(AnnotationsResx))]
          public string Reference2 {get; set;}

          /// <summary>
          /// Gets or sets the amount.
          /// </summary>
          /// <value>
          /// The amount.
          /// </value>
          public decimal Amount {get; set;}

          /// <summary>
          /// Gets or sets the authorization code.
          /// </summary>
          /// <value>
          /// The authorization code.
          /// </value>
          [StringLength(6, ErrorMessageResourceName = "MaxLength",ErrorMessageResourceType = typeof(AnnotationsResx))]
          public string AuthorizationCode {get; set;}

          /// <summary>
          /// Gets or sets the van reference.
          /// </summary>
          /// <value>
          /// The van reference.
          /// </value>
          [StringLength(16, ErrorMessageResourceName = "MaxLength",ErrorMessageResourceType = typeof(AnnotationsResx))]
          public string VanReference {get; set;}

          /// <summary>
          /// Gets or sets the name.
          /// </summary>
          /// <value>
          /// The name.
          /// </value>
          [StringLength(103, ErrorMessageResourceName = "MaxLength",ErrorMessageResourceType = typeof(AnnotationsResx))]
          public string Name {get; set;}

          /// <summary>
          /// Gets or sets the address line1.
          /// </summary>
          /// <value>
          /// The address line1.
          /// </value>
          [StringLength(50, ErrorMessageResourceName = "MaxLength",ErrorMessageResourceType = typeof(AnnotationsResx))]
          public string AddressLine1 {get; set;}

          /// <summary>
          /// Gets or sets the address line2.
          /// </summary>
          /// <value>
          /// The address line2.
          /// </value>
          [StringLength(50, ErrorMessageResourceName = "MaxLength",ErrorMessageResourceType = typeof(AnnotationsResx))]
          public string AddressLine2 {get; set;}

          /// <summary>
          /// Gets or sets the city.
          /// </summary>
          /// <value>
          /// The city.
          /// </value>
          [StringLength(50, ErrorMessageResourceName = "MaxLength",ErrorMessageResourceType = typeof(AnnotationsResx))]
          public string City {get; set;}

          /// <summary>
          /// Gets or sets the state.
          /// </summary>
          /// <value>
          /// The state.
          /// </value>
          [StringLength(50, ErrorMessageResourceName = "MaxLength",ErrorMessageResourceType = typeof(AnnotationsResx))]
          public string State {get; set;}

          /// <summary>
          /// Gets or sets the zip code.
          /// </summary>
          /// <value>
          /// The zip code.
          /// </value>
          [StringLength(50, ErrorMessageResourceName = "MaxLength",ErrorMessageResourceType = typeof(AnnotationsResx))]
          public string ZipCode {get; set;}

          /// <summary>
          /// Gets or sets the country.
          /// </summary>
          /// <value>
          /// The country.
          /// </value>
          [StringLength(50, ErrorMessageResourceName = "MaxLength",ErrorMessageResourceType = typeof(AnnotationsResx))]
          public string Country {get; set;}

          /// <summary>
          /// Gets or sets the email.
          /// </summary>
          /// <value>
          /// The email.
          /// </value>
          [StringLength(255, ErrorMessageResourceName = "MaxLength",ErrorMessageResourceType = typeof(AnnotationsResx))]
          public string Email {get; set;}

          /// <summary>
          /// Gets or sets the telephone.
          /// </summary>
          /// <value>
          /// The telephone.
          /// </value>
          [StringLength(50, ErrorMessageResourceName = "MaxLength",ErrorMessageResourceType = typeof(AnnotationsResx))]
          public string Telephone {get; set;}

          /// <summary>
          /// Gets or sets the fax.
          /// </summary>
          /// <value>
          /// The fax.
          /// </value>
          [StringLength(50, ErrorMessageResourceName = "MaxLength",ErrorMessageResourceType = typeof(AnnotationsResx))]
          public string Fax {get; set;}

          /// <summary>
          /// Gets or sets the avs result.
          /// </summary>
          /// <value>
          /// The avs result.
          /// </value>
          [StringLength(1, ErrorMessageResourceName = "MaxLength",ErrorMessageResourceType = typeof(AnnotationsResx))]
          public string AvsResult {get; set;}

          /// <summary>
          /// Gets or sets the CVV result.
          /// </summary>
          /// <value>
          /// The CVV result.
          /// </value>
          [StringLength(1, ErrorMessageResourceName = "MaxLength",ErrorMessageResourceType = typeof(AnnotationsResx))]
          public string CvvResult {get; set;}

          /// <summary>
          /// Gets or sets the timestamp.
          /// </summary>
          /// <value>
          /// The timestamp.
          /// </value>
          [StringLength(22, ErrorMessageResourceName = "MaxLength",ErrorMessageResourceType = typeof(AnnotationsResx))]
          public string Timestamp {get; set;}

          /// <summary>
          /// Gets or sets the batch reference.
          /// </summary>
          /// <value>
          /// The batch reference.
          /// </value>
          [StringLength(10, ErrorMessageResourceName = "MaxLength",ErrorMessageResourceType = typeof(AnnotationsResx))]
          public string BatchReference {get; set;}

          /// <summary>
          /// Gets or sets the type of the settlement.
          /// </summary>
          /// <value>
          /// The type of the settlement.
          /// </value>
          [StringLength(1, ErrorMessageResourceName = "MaxLength",ErrorMessageResourceType = typeof(AnnotationsResx))]
          public string SettlementType {get; set;}

          /// <summary>
          /// Gets or sets the settlement date.
          /// </summary>
          /// <value>
          /// The settlement date.
          /// </value>
          [StringLength(22, ErrorMessageResourceName = "MaxLength",ErrorMessageResourceType = typeof(AnnotationsResx))]
          public string SettlementDate {get; set;}

          /// <summary>
          /// Gets or sets the type of the transaction.
          /// </summary>
          /// <value>
          /// The type of the transaction.
          /// </value>
          [StringLength(2, ErrorMessageResourceName = "MaxLength",ErrorMessageResourceType = typeof(AnnotationsResx))]
          public string TransactionType {get; set;}

          /// <summary>
          /// Gets or sets the processing date.
          /// </summary>
          /// <value>
          /// The processing date.
          /// </value>
          [ValidateDateFormat(ErrorMessage="DateFormat", ErrorMessageResourceType = typeof(AnnotationsResx))]
          public DateTime ProcessingDate {get; set;}

          /// <summary>
          /// Gets or sets the tax amount.
          /// </summary>
          /// <value>
          /// The tax amount.
          /// </value>
          [StringLength(9, ErrorMessageResourceName = "MaxLength",ErrorMessageResourceType = typeof(AnnotationsResx))]
          public string TaxAmount {get; set;}

          /// <summary>
          /// Gets or sets the customer number.
          /// </summary>
          /// <value>
          /// The customer number.
          /// </value>
          [StringLength(12, ErrorMessageResourceName = "MaxLength",ErrorMessageResourceType = typeof(AnnotationsResx))]
          public string CustomerNumber {get; set;}

          /// <summary>
          /// Gets or sets the processing code.
          /// </summary>
          /// <value>
          /// The processing code.
          /// </value>
          [StringLength(12, ErrorMessageResourceName = "MaxLength",ErrorMessageResourceType = typeof(AnnotationsResx))]
          public string ProcessingCode {get; set;}

          /// <summary>
          /// Gets or sets the card identifier.
          /// </summary>
          /// <value>
          /// The card identifier.
          /// </value>
          [StringLength(12, ErrorMessageResourceName = "MaxLength",ErrorMessageResourceType = typeof(AnnotationsResx))]
          public string CardID {get; set;}

          /// <summary>
          /// Gets or sets the document number.
          /// </summary>
          /// <value>
          /// The document number.
          /// </value>
          [StringLength(22, ErrorMessageResourceName = "MaxLength",ErrorMessageResourceType = typeof(AnnotationsResx))]
          public string DocumentNumber {get; set;}

          /// <summary>
          /// Gets or sets the card description.
          /// </summary>
          /// <value>
          /// The card description.
          /// </value>
          [StringLength(60, ErrorMessageResourceName = "MaxLength",ErrorMessageResourceType = typeof(AnnotationsResx))]
          public string CardDescription {get; set;}

          /// <summary>
          /// Gets or sets the card comment.
          /// </summary>
          /// <value>
          /// The card comment.
          /// </value>
          [StringLength(255, ErrorMessageResourceName = "MaxLength",ErrorMessageResourceType = typeof(AnnotationsResx))]
          public string CardComment {get; set;}

          /// <summary>
          /// Gets or sets the SPS request process completed fl.
          /// </summary>
          /// <value>
          /// The SPS request process completed fl.
          /// </value>
          public SpsRequestProcessCompletedFl SpsRequestProcessCompletedFl { get; set; }

          /// <summary>
          /// Gets or sets the application.
          /// </summary>
          /// <value>
          /// The application.
          /// </value>
          [StringLength(2, ErrorMessageResourceName = "MaxLength",ErrorMessageResourceType = typeof(AnnotationsResx))]
          public string Application {get; set;}
     }
}
