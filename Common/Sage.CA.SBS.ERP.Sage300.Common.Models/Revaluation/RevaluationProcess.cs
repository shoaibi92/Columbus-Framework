// Copyright (c) 1994-2015 Sage Software, Inc.  All rights reserved.

namespace Sage.CA.SBS.ERP.Sage300.Common.Models.Revaluation
{
	/// <summary>
	/// Model class for Process Revaluation 
	/// </summary>
	public partial class RevaluationProcess : ModelBase
	{
        /// <summary>
        /// Specifies whether to perform provisonal revaluation or not
        /// </summary>
		public bool ProvisionalRevaluation { get; set; }
	}
}
