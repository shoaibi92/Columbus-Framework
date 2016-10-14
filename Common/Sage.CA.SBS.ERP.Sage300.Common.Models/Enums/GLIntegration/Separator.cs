// Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. 

using Sage.CA.SBS.ERP.Sage300.Common.Resources;

namespace Sage.CA.SBS.ERP.Sage300.Common.Models.Enums.GLIntegration
{
	/// <summary>
    /// Enum for Separator 
    /// </summary>
	public enum Separator 
	{
	    /// <summary>
		/// Gets or sets * Asterisk 
		/// </summary>	
        [EnumValue("SymbolAsterisk", typeof(CommonResx), 1)]
        Asterisk = 0,
		/// <summary>
		/// Gets or sets Hyphen 
		/// </summary>	
        [EnumValue("SymbolHyphen", typeof(CommonResx), 2)]
        Hyphen = 1,
		/// <summary>
		/// Gets or sets Forward Slash 
		/// </summary>	
        [EnumValue("SymbolForwardSlash", typeof(CommonResx), 3)]
        OrForwardSlash = 2,
		/// <summary>
		/// Gets or sets \ Back Slash 
		/// </summary>	
        [EnumValue("SymbolBackslash", typeof(CommonResx), 4)]
        BackSlash = 3,
		/// <summary>
		/// Gets or sets Period 
		/// </summary>	
        [EnumValue("SymbolPeriod", typeof(CommonResx), 5)]
        Period = 4,
		/// <summary>
		/// Gets or sets { Left Parenthesis 
		/// </summary>	
        [EnumValue("SymbolLeftBracket", typeof(CommonResx), 6)]
        LeftParenthesis = 5,
		/// <summary>
		/// Gets or sets } Right Parenthesis 
		/// </summary>	
        [EnumValue("SymbolRightBracket", typeof(CommonResx), 7)]
        RightParenthesis = 6,
		/// <summary>
		/// Gets or sets # Number Sign 
		/// </summary>	
        [EnumValue("SymbolNumberSign", typeof(CommonResx), 8)]
        NumberSign = 7,
		/// <summary>
		/// Gets or sets Space 
		/// </summary>	
        [EnumValue("SymbolSpace", typeof(CommonResx), 9)]
        Space = 8,
	}
}
