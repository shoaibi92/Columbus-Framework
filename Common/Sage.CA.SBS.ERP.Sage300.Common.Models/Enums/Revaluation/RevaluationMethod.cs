// Copyright (c) 1994-2015 Sage Software, Inc.  All rights reserved.

using Sage.CA.SBS.ERP.Sage300.Common.Resources;

namespace Sage.CA.SBS.ERP.Sage300.Common.Models.Enums.Revaluation
{
	/// <summary>
	/// Enum for RevaluationMethod
	/// </summary>
	public enum RevaluationMethod
	{
		/// <summary>
		/// Gets or sets RealizedAndUnrealizedGainLossRevaluation
		/// </summary>
        [EnumValue("RevaluationMethod_RealizedAndUnrealizedGainLossRevaluation", typeof(EnumerationsResx))]
        RealizedAndUnrealizedGainLossRevaluation = 1,

		/// <summary>
		/// Gets or sets RecognizedGainLossRevaluation
		/// </summary>
        [EnumValue("RevaluationMethod_RecognizedGainLossRevaluation", typeof(EnumerationsResx))]
        RecognizedGainLossRevaluation = 2
	}
}
