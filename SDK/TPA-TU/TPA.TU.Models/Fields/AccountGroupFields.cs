/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

// ReSharper disable CheckNamespace
namespace TPA.TU.Models
// ReSharper restore CheckNamespace
{
    /// <summary>
    /// Contains list of AccountGroup Constants 
    /// </summary>
	public partial class AccountGroup 
	{
	 
        /// <summary>
        /// View Name
        /// </summary>
	    public const string EntityName = "AP0006";

        /// <summary>
        /// Contains list of AccountGroup Fields Constants
        /// </summary>
	    public class Fields
        {

        #region Properties
	            /// <summary>
        /// Property for AccountGroupCode 
        /// </summary>
	    public const string AccountGroupCode  = "ACCTSET";
	            /// <summary>
        /// Property for Description 
        /// </summary>
	    public const string Description  = "TEXTDESC";
	            /// <summary>
        /// Property for Status 
        /// </summary>
	    public const string Status  = "SWACTV";

        /// <summary>
        /// Property for Status 
        /// </summary>
        public const string StatusString = "SWACTV";
	            /// <summary>
        /// Property for InactiveDate 
        /// </summary>
	    public const string InactiveDate  = "DATEINACTV";
	            /// <summary>
        /// Property for DateLastMaintained 
        /// </summary>
	    public const string DateLastMaintained  = "DATELASTMN";
	            /// <summary>
        /// Property for PayablesControlAccount 
        /// </summary>
	    public const string PayablesControlAccount  = "IDACCTAP";
     
	            /// <summary>
        /// Property for DiscountsAccount 
        /// </summary>
	    public const string DiscountsAccount  = "DISCACCT";
	            /// <summary>
        /// Property for PrepaymentAccount 
        /// </summary>
	    public const string PrepaymentAccount  = "PPAYACCT";
	            /// <summary>
        /// Property for CurrencyCodeforAccount 
        /// </summary>
	    public const string CurrencyCodeforAccount  = "CURRCODE";
	            /// <summary>
        /// Property for UnrealizedExchangeGainAccount 
        /// </summary>
	    public const string UnrealizedExchangeGainAccount  = "URLZGNACT";
	            /// <summary>
        /// Property for UnrealizedExchangeLossAccount 
        /// </summary>
	    public const string UnrealizedExchangeLossAccount  = "URLZLSACT";
	            /// <summary>
        /// Property for ExchangeGainAccount 
        /// </summary>
	    public const string ExchangeGainAccount  = "RLZGNACT";
	            /// <summary>
        /// Property for ExchangeLossAccount 
        /// </summary>
	    public const string ExchangeLossAccount  = "RLZLSACT";
       
	            /// <summary>
        /// Property for RetainageAccount 
        /// </summary>
	    public const string RetainageAccount  = "RTGACCT";
	            /// <summary>
        /// Property for ExchangeRoundingAccount 
        /// </summary>
	    public const string ExchangeRoundingAccount  = "RNDACCT";
	     
        #endregion
	    }


		/// <summary>
        /// Contains list of AccountGroup Index Constants
        /// </summary>
	    public class Index
        {

        #region Properties
	             /// <summary>
        /// Property Indexer for AccountGroupCode 
        /// </summary>
	    public const int AccountGroupCode  = 1;
	             /// <summary>
        /// Property Indexer for Description 
        /// </summary>
	    public const int Description  = 2;
	             /// <summary>
        /// Property Indexer for Status 
        /// </summary>
	    public const int Status  = 3;
	             /// <summary>
        /// Property Indexer for InactiveDate 
        /// </summary>
	    public const int InactiveDate  = 4;
	             /// <summary>
        /// Property Indexer for DateLastMaintained 
        /// </summary>
	    public const int DateLastMaintained  = 5;
	             /// <summary>
        /// Property Indexer for PayablesControlAccount 
        /// </summary>
	    public const int PayablesControlAccount  = 6;
	             /// <summary>
        /// Property Indexer for DiscountsAccount 
        /// </summary>
	    public const int DiscountsAccount  = 8;
	             /// <summary>
        /// Property Indexer for PrepaymentAccount 
        /// </summary>
	    public const int PrepaymentAccount  = 9;
	             /// <summary>
        /// Property Indexer for CurrencyCodeforAccount 
        /// </summary>
	    public const int CurrencyCodeforAccount  = 10;
	             /// <summary>
        /// Property Indexer for UnrealizedExchangeGainAccount 
        /// </summary>
	    public const int UnrealizedExchangeGainAccount  = 11;
	             /// <summary>
        /// Property Indexer for UnrealizedExchangeLossAccount 
        /// </summary>
	    public const int UnrealizedExchangeLossAccount  = 12;
	             /// <summary>
        /// Property Indexer for ExchangeGainAccount 
        /// </summary>
	    public const int ExchangeGainAccount  = 13;
	             /// <summary>
        /// Property Indexer for ExchangeLossAccount 
        /// </summary>
	    public const int ExchangeLossAccount  = 14;
	    /// <summary>
        /// Property Indexer for RetainageAccount 
        /// </summary>
	    public const int RetainageAccount  = 16;
	             /// <summary>
        /// Property Indexer for ExchangeRoundingAccount 
        /// </summary>
	    public const int ExchangeRoundingAccount  = 17;
	     
        #endregion
	    }

	
	}
}
	