// Copyright (c) 1994-2015 Sage Software, Inc.  All rights reserved.

#region Namespace

using System.Collections.Generic;
using Sage.CA.SBS.ERP.Sage300.Common.Models.Attributes;

#endregion

// ReSharper disable CheckNamespace
namespace Sage.CA.SBS.ERP.Sage300.Common.Models.Revaluation
// ReSharper restore CheckNamespace
{
	/// <summary>
	/// Contains list of RevaluationHistory Constants
	/// </summary>
	public partial class RevaluationHistory
	{
		/// <summary>
		/// Dynamic Attributes contain a reverse mapping of field and property
		/// </summary>
		[IgnoreExportImport]
		public static Dictionary<string, string> DynamicAttributes
		{
			get
			{
				return new Dictionary<string, string>();
			}
		}

		#region Properties

		/// <summary>
		/// Contains list of RevaluationHistory Field Constants
		/// </summary>
		public class Fields
		{
			/// <summary>
			/// Property for CurrencyCode
			/// </summary>
			public const string CurrencyCode = "CURNCYCODE";

			/// <summary>
			/// Property for RevaluationDate
			/// </summary>
			public const string RevaluationDate = "RVLDATE";

			/// <summary>
			/// Property for SequenceNo
			/// </summary>
			public const string SequenceNo = "CNTSEQENCE";

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
			/// Property for RevaluationMethod
			/// </summary>
			public const string RevaluationMethod = "SWRVMETHOD";

			/// <summary>
			/// Property for EarliestBackdatedActivityDate
			/// </summary>
			public const string EarliestBackdatedActivityDate = "ADJFRMDATE";

			/// <summary>
			/// Property for PostingSequenceNo
			/// </summary>
			public const string PostingSequenceNo = "POSTSEQNCE";

			/// <summary>
			/// Property for SystemDate
			/// </summary>
			public const string SystemDate = "DATEPOSTED";

			/// <summary>
			/// Property for ModuleVersionCreatedIn
			/// </summary>
			public const string APVersionCreatedIn = "APVERSION";

		}

		#endregion

		#region Properties

		/// <summary>
		/// Contains list of RevaluationHistory Index Constants
		/// </summary>
		public class Index
		{

			/// <summary>
			/// Property Indexer for CurrencyCode
			/// </summary>
			public const int CurrencyCode = 1;

			/// <summary>
			/// Property Indexer for RevaluationDate
			/// </summary>
			public const int RevaluationDate = 2;

			/// <summary>
			/// Property Indexer for SequenceNo
			/// </summary>
			public const int SequenceNo = 3;

			/// <summary>
			/// Property Indexer for RateDate
			/// </summary>
			public const int RateDate = 4;

			/// <summary>
			/// Property Indexer for ExchangeRate
			/// </summary>
			public const int ExchangeRate = 5;

			/// <summary>
			/// Property Indexer for RateType
			/// </summary>
			public const int RateType = 6;

			/// <summary>
			/// Property Indexer for RateOperator
			/// </summary>
			public const int RateOperator = 7;

			/// <summary>
			/// Property Indexer for RateOverridden
			/// </summary>
			public const int RateOverridden = 8;

			/// <summary>
			/// Property Indexer for RevaluationMethod
			/// </summary>
			public const int RevaluationMethod = 9;

			/// <summary>
			/// Property Indexer for EarliestBackdatedActivityDate
			/// </summary>
			public const int EarliestBackdatedActivityDate = 10;

			/// <summary>
			/// Property Indexer for PostingSequenceNo
			/// </summary>
			public const int PostingSequenceNo = 11;

			/// <summary>
			/// Property Indexer for SystemDate
			/// </summary>
			public const int SystemDate = 12;

			/// <summary>
			/// Property Indexer for ModuleVersionCreatedIn
			/// </summary>
			public const int ModuleVersionCreatedIn = 13;
		}

		#endregion
	}
}
