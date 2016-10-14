// Copyright (c) 1994-2015 Sage Software, Inc.  All rights reserved.

// ReSharper disable CheckNamespace
namespace Sage.CA.SBS.ERP.Sage300.Common.Models.Revaluation
// ReSharper restore CheckNamespace
{
	/// <summary>
	/// Contains list of Revaluation Constants
	/// </summary>
	public partial class RevaluationProcess
	{
		#region Properties

		/// <summary>
		/// Contains list of Revaluation Field Constants
		/// </summary>
		public class Fields
		{

			/// <summary>
			/// Property for ProvisionalRevaluation
			/// </summary>
			public const string ProvisionalRevaluation = "SWPROV";

		}

		#endregion

		#region Properties

		/// <summary>
		/// Contains list of Revaluation Index Constants
		/// </summary>
		public class Index
		{

			/// <summary>
			/// Property Indexer for ProvisionalRevaluation
			/// </summary>
			public const int ProvisionalRevaluation = 1;

		}

		#endregion
	}
}
