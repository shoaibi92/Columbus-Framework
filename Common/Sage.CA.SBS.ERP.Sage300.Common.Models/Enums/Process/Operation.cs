// Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved.

namespace Sage.CA.SBS.ERP.Sage300.Common.Models.Enums.Process
{
     /// <summary>
     /// Enum for Operation
     /// </summary>
     public enum Operation
     {
          /// <summary>
          /// Gets or sets CreateHeader
          /// </summary>
         CreateHeader = 1,

          /// <summary>
          /// Gets or sets CreateDetail
          /// </summary>
          CreateDetail = 2,

          /// <summary>
          /// Gets or sets Update
          /// </summary>
          /// 
          Update = 3,
          /// <summary>
          /// Gets or sets Read
          /// </summary>
          /// 
          Read = 4,

          /// <summary>
          /// Gets or sets ReadDetail
          /// </summary>
          ReadDetail = 5,

          /// <summary>
          /// Gets or sets FetchDetail
          /// </summary>
          FetchDetail = 6,

          /// <summary>
          /// Gets or sets DeleteDetail
          /// </summary>
          DeleteDetail = 7,

          /// <summary>
          /// Gets or sets DeleteHeader
          /// </summary>
          DeleteHeader = 8,

          /// <summary>
          /// Gets or sets CreateBankEnteredTransaction
          /// </summary>
          CreateBankEnteredTransaction = 9,

          /// <summary>
          /// Gets or sets CreateMiscellaneousEntry
          /// </summary>
          CreateMiscellaneousEntry = 10,

          /// <summary>
          /// Gets or sets CreateaReversalEntry
          /// </summary>
          CreateaReversalEntry = 11,

          /// <summary>
          /// Gets or sets CreateWithdrawal
          /// </summary>
          CreateWithdrawal = 12,

         /// <summary>
         /// Gets or sets HighestTransactionNumber
         /// </summary>
         HighestTransactionNumber=13,

         /// <summary>
         /// Gets or sets LowsetTransactionNumber
         /// </summary>
         LowsetTransactionNumber=14,

         /// <summary>
         /// Gets or sets TransactionCount
         /// </summary>
         TransactionCount=15,

        
     }
}
