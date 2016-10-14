// Copyright (c) 1994-2015 Sage Software, Inc.  All rights reserved.

using Sage.CA.SBS.ERP.Sage300.Common.Resources;

namespace Sage.CA.SBS.ERP.Sage300.Common.Models.Enums.Revaluation
{
	/// <summary>
	/// Enum for RateOperator
	/// </summary>
	public enum RateOperator
	{
		/// <summary>
		/// Gets or sets Multiply
		/// </summary>
        [EnumValue("RateOperator_Multiply", typeof(EnumerationsResx))]
		Multiply = 1,

		/// <summary>
		/// Gets or sets Divide
		/// </summary>
        [EnumValue("RateOperator_Divide", typeof(EnumerationsResx))]
        Divide = 2
	}
}
