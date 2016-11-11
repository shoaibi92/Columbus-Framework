/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

#region

using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Sage.CA.SBS.ERP.Sage300.Common.Models;
using Sage.CA.SBS.ERP.Sage300.Common.Resources;
using Sage.CA.SBS.ERP.Sage300.Common.Models.GLIntegration;
using Sage.CA.SBS.ERP.Sage300.Common.Models.Enums.GLIntegration;

#endregion

namespace Sage.CA.SBS.ERP.Sage300.Common.Web.Models.GLIntegration
{
    /// <summary>
    /// View Model Class for Base G/L Integration
    /// </summary>
    /// <typeparam name="TRef">Base GL Reference Integration</typeparam>
    public abstract class BaseGLIntegrationViewModel<TRef> : ViewModelBase<TRef>
        where TRef : ModelBase, new()
    {
        /// <summary>
        /// Get Defer G/L Transactions
        /// </summary>
        public IEnumerable<CustomSelectList> GetDeferGLTransactions
        {
            get { return EnumUtility.GetItemsList<DeferGLTransactions>(); }
        }

        /// <summary>
        /// Get Create G/L Transactions By
        /// </summary>
        public IEnumerable<CustomSelectList> GetCreateGLTransactionsBy
        {
            get { return EnumUtility.GetOrderedItemsList<CreateGLTransactionsBy>(); }
        }

        /// <summary>
        /// Get Consolidate G/L Transactions
        /// </summary>
        public IEnumerable<CustomSelectList> GetConsolidateGLTransactions
        {
            get { return EnumUtility.GetItemsList<ConsolidateGLTransactions>(); }
        }

        /// <summary>
        /// Get the List of G/L Transaction Fields
        /// </summary>
        public IEnumerable GetGLTransactionField
        {
            get { return EnumUtility.GetItems<GLTransactionField>(); }
        }

        /// <summary>
        /// Get the List of Separator Options
        /// </summary>
        public IEnumerable GetSeparator
        {
            get { return EnumUtility.GetItems<Separator>(); }
        }

        /// <summary>
        /// Get list of G/L Source Codes
        /// </summary>
        public EnumerableResponse<GLSourceCode> GLSourceCodes { get; set; }

        /// <summary>
        /// Get list of G/L Posting Sequences
        /// </summary>
        public EnumerableResponse<GLPostingSequence> GLPostingSequences { get; set; }

        /// <summary>
        /// Get list of G/L Reference Integration Details
        /// </summary>
        public EnumerableResponse<ReferenceDetail> ReferenceDetails { get; set; }

        /// <summary>
        /// Get or Set IntegrationOption
        /// </summary>
        public ModelBase IntegrationOption { get; set; }

        /// <summary>
        /// Get or Set user security modify access 
        /// </summary>
        public bool CanModify { get; set; }
    }

    /// <summary>
    /// Class GL SourceCode for binding the data with GL SourceCode.
    /// </summary>
    /// <remarks>Used to bind the grid</remarks>
    public class GLSourceCode : ModelBase
    {
        /// <summary>
        /// Get and Set the Serial number value
        /// </summary>
        public int SerialNo { get; set; }

        /// <summary>
        /// Get and Set the Transaction Type value
        /// </summary>
        public string TransactionType { get; set; }

        /// <summary>
        /// Get and Set the Source Ledger value
        /// </summary>
        public string SourceLedger { get; set; }

        /// <summary>
        /// Get and Set the Source Type value 
        /// </summary>
        [StringLength(2, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        public string SourceType { get; set; }
    }

    /// <summary>
    /// Class GL Transaction Posting Sequence for binding the data with GL Posting Sequence
    /// </summary>
    /// <remarks>Used to bind the grid</remarks>
    public class GLPostingSequence : ModelBase
    {
        /// <summary>
        /// Get and Set the Serial number value
        /// </summary>
        public int SerialNo { get; set; }

        /// <summary>
        /// Get and Set the Sequence Description value
        /// </summary>
        public string Sequence { get; set; }

        /// <summary>
        /// Get and Set the Sequence No value
        /// </summary>
        public decimal SequenceNo { get; set; }
    }
}
