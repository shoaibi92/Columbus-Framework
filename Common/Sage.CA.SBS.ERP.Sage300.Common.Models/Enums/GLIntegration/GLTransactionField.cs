/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

using Sage.CA.SBS.ERP.Sage300.Common.Resources;

namespace Sage.CA.SBS.ERP.Sage300.Common.Models.Enums.GLIntegration
{
	/// <summary>
    /// Enum for G/L Transaction Field 
    /// </summary>
	public enum GLTransactionField 
	{
		/// <summary>
		/// Gets or sets G/L Entry Description 
		/// </summary>	
        [EnumValue("GLEntryDescription", typeof(GLIntegrationResx), 1)]
        GLEntryDescription = 0,

		/// <summary>
		/// Gets or sets G/L Detail Reference 
		/// </summary>	
        [EnumValue("GLDetailReference", typeof(GLIntegrationResx), 2)]
        GLDetailReference = 1,

		/// <summary>
		/// Gets or sets G/L Detail Description 
		/// </summary>	
        [EnumValue("GLDetailDescription", typeof(GLIntegrationResx), 3)]
        GLDetailDescription = 2,

		/// <summary>
		/// Gets or sets G/L Detail Comment 
		/// </summary>	
        [EnumValue("GLDetailComment", typeof(GLIntegrationResx), 4)]
        GLDetailComment = 3,
	}
}
