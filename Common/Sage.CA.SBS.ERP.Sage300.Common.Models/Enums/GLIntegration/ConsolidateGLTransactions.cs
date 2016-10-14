/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

#region

using Sage.CA.SBS.ERP.Sage300.Common.Resources;

#endregion

namespace Sage.CA.SBS.ERP.Sage300.Common.Models.Enums.GLIntegration
{
    /// <summary>
    /// Enum for Consolidate G/L Transactions 
    /// </summary>
    public enum ConsolidateGLTransactions
    {
        /// <summary>
        /// Gets or sets Do Not Consolidate 
        /// </summary>	
        [EnumValue("DoNotConsolidate", typeof(GLIntegrationResx), 1)]
        DoNotConsolidate = 0,
        /// <summary>
        /// Gets or sets Consolidate by Post Seq, Account and Fiscal Period 
        /// </summary>	
        [EnumValue("ConsolidateByPostAccFisc", typeof(GLIntegrationResx), 2)]
        ConsolidatebyPostSeqAccountandFiscalPeriod = 1,
        /// <summary>
        /// Gets or sets Consolidate by Post Seq, Account, Fiscal Period and Source 
        /// </summary>	
        [EnumValue("ConsolidateByPostAccFiscSource", typeof(GLIntegrationResx), 3)]
        ConsolidatebyPostSeqAccountFiscalPeriodandSource = 2,
    }
}
