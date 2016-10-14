// Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved.


using Sage.CA.SBS.ERP.Sage300.Common.Resources;
namespace Sage.CA.SBS.ERP.Sage300.Common.Models.Enums.InvoiceEntry
{
     /// <summary>
     /// Enum for RateOperation
     /// </summary>
     public enum RateOperation
     {
         /// <summary>
         /// Gets or sets Multiply 
         /// </summary>	
         [EnumValue("Multiply", typeof(EnumerationsResx))]
          Multiply = 1,
         /// <summary>
         /// Gets or sets Divide 
         /// </summary>	
         [EnumValue("Divide", typeof(EnumerationsResx))]
          Divide = 2,
     }
}
