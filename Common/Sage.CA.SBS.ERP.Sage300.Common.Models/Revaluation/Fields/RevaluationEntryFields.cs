// Copyright (c) 1994-2015 Sage Software, Inc.  All rights reserved.

// ReSharper disable CheckNamespace
namespace Sage.CA.SBS.ERP.Sage300.Common.Models.Revaluation
// ReSharper restore CheckNamespace
{
	/// <summary>
	/// Contains list of Revaluation Constants
	/// </summary>
	public partial class RevaluationEntry
	{
		#region Properties

		/// <summary>
		/// Contains list of Revaluation Field Constants
		/// </summary>
		public class Fields
		{

			/// <summary>
			/// Property for CurrencyCode
			/// </summary>
			public const string CurrencyCode = "CURNCYCODE";

			/// <summary>
			/// Property for ThroughDate
			/// </summary>
			public const string ThroughDate = "CUTDATE";

			/// <summary>
			/// Property for RateDate
			/// </summary>
			public const string RateDate = "CONVDATE";

			/// <summary>
			/// Property for ExchangeRate
			/// </summary>
			public const string ExchangeRate = "CONVRATE";

			/// <summary>
			/// Property for RateType
			/// </summary>
			public const string RateType = "CURTBLTYPE";

			/// <summary>
			/// Property for RateOperator
			/// </summary>
			public const string RateOperator = "RATEOP";

			/// <summary>
			/// Property for RateOverridden
			/// </summary>
			public const string RateOverridden = "SWRATEOVRD";

			/// <summary>
			/// Property for OptionalFields
			/// </summary>
			public const string OptionalFields = "VALUES";

			/// <summary>
			/// Property for EarliestBackdatedActivityDate
			/// </summary>
			public const string EarliestBackdatedActivityDate = "ADJFRMDATE";

			/// <summary>
			/// Property for ProcessCommandCode
			/// </summary>
			public const string ProcessCommandCode = "PROCESSCMD";

			/// <summary>
			/// Property for EarliestBackdatedTransactionD
			/// </summary>
			public const string EarliestBackdatedTransactionD = "DATEFRSTBK";

			/// <summary>
			/// Property for LastRevaluationDate
			/// </summary>
			public const string LastRevaluationDate = "DATELSTREV";

		}

		#endregion

		#region Properties

		/// <summary>
		/// Contains list of Revaluation Index Constants
		/// </summary>
		public class Index
		{

			/// <summary>
			/// Property Indexer for CurrencyCode
			/// </summary>
			public const int CurrencyCode = 1;

			/// <summary>
			/// Property Indexer for ThroughDate
			/// </summary>
			public const int ThroughDate = 2;

			/// <summary>
			/// Property Indexer for RateDate
			/// </summary>
			public const int RateDate = 3;

			/// <summary>
			/// Property Indexer for ExchangeRate
			/// </summary>
			public const int ExchangeRate = 4;

			/// <summary>
			/// Property Indexer for RateType
			/// </summary>
			public const int RateType = 5;

			/// <summary>
			/// Property Indexer for RateOperator
			/// </summary>
			public const int RateOperator = 6;

			/// <summary>
			/// Property Indexer for RateOverridden
			/// </summary>
			public const int RateOverridden = 7;

			/// <summary>
			/// Property Indexer for OptionalFields
			/// </summary>
			public const int OptionalField = 8;

			/// <summary>
			/// Property Indexer for EarliestBackdatedActivityDate
			/// </summary>
			public const int EarliestBackdatedActivityDate = 9;

			/// <summary>
			/// Property Indexer for ProcessCommandCode
			/// </summary>
			public const int ProcessCommandCode = 10;

			/// <summary>
			/// Property Indexer for EarliestBackdatedTransactionD
			/// </summary>
			public const int EarliestBackdatedTransactionDate = 11;

			/// <summary>
			/// Property Indexer for LastRevaluationDate
			/// </summary>
			public const int LastRevaluationDate = 12;

		}

		#endregion
	}
}
