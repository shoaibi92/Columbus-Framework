// Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved.

namespace Sage.CA.SBS.ERP.Sage300.Common.Models.Enums.InvoiceEntry
{
     /// <summary>
     /// Enum for Command
     /// </summary>
     public enum Command
     {
          /// <summary>
          /// Gets or sets NothingToProcess
          /// </summary>
          //[EnumValue("NothingToProcess", typeof(POCommonResx))]
          NothingToProcess = 0,
          /// <summary>
          /// Gets or sets InsertOptionalFields
          /// </summary>
          //[EnumValue("InsertOptionalFields", typeof(POCommonResx))]
          InsertOptionalFields = 1,
          /// <summary>
          /// Gets or sets DefaultAndTranferOptionalFields
          /// </summary>
         //[EnumValue("DefaultAndTranferOptionalFields", typeof(PurchaseOrderEntryResx))] 
         DefaultAndTranferOptionalFields = 2,
          /// <summary>
          /// Gets or sets DefaultOptFieldsDuringRecordGeneration
          /// </summary>
         //[EnumValue("DefaultOptFieldsDuringRecordGeneration", typeof(PurchaseOrderEntryResx))] 
         DefaultOptFieldsDuringRecordGeneration = 3,
          /// <summary>
          /// Gets or sets RemoveOptionalFields
          /// </summary>
         //[EnumValue("RemoveOptionalFields", typeof(PurchaseOrderEntryResx))] 
         RemoveOptionalFields = 4,
          /// <summary>
          /// Gets or sets TransferOptFieldsFromStandingDocument
          /// </summary>
         //[EnumValue("TransferOptFieldsFromStandingDocument", typeof(PurchaseOrderEntryResx))] 
         TransferOptFieldsFromStandingDocument = 5,
          /// <summary>
          /// Gets or sets InsertItemSerialOptionalFields
          /// </summary>
          //[EnumValue("InsertItemSerialOptionalFields", typeof(POCommonResx))]
          InsertItemSerialOptionalFields = 6,
          /// <summary>
          /// Gets or sets InsertItemLotOptionalFields
          /// </summary>
          //[EnumValue("InsertItemLotOptionalFields", typeof(POCommonResx))]
          InsertItemLotOptionalFields = 7,
          /// <summary>
          /// Gets or sets AutogenerateSerials
          /// </summary>
         //[EnumValue("AutogenerateSerials", typeof(PurchaseOrderEntryResx))] 
         AutogenerateSerials = 21,
          /// <summary>
          /// Gets or sets AutogenerateLots
          /// </summary>
         //[EnumValue("AutogenerateLots", typeof(PurchaseOrderEntryResx))] 
         AutogenerateLots = 22,
          /// <summary>
          /// Gets or sets AutoallocateSerials
          /// </summary>
         //[EnumValue("AutoallocateSerials", typeof(PurchaseOrderEntryResx))] 
         AutoallocateSerials = 23,
          /// <summary>
          /// Gets or sets AutoallocateLots
          /// </summary>
         //[EnumValue("AutoallocateLots", typeof(PurchaseOrderEntryResx))] 
         AutoallocateLots = 24,
          /// <summary>
          /// Gets or sets ClearSerials
          /// </summary>
        //[EnumValue("ClearSerials", typeof(PurchaseOrderEntryResx))] 
         ClearSerials = 25,
          /// <summary>
          /// Gets or sets ClearLots
          /// </summary>
         //[EnumValue("ClearLots", typeof(PurchaseOrderEntryResx))] 
         ClearLots = 26,
          /// <summary>
          /// Gets or sets AutoassignSerials
          /// </summary>
         //[EnumValue("AutoassignSerials", typeof(PurchaseOrderEntryResx))] 
         AutoassignSerials = 27,
          /// <summary>
          /// Gets or sets AutoassignLots
          /// </summary>
         //[EnumValue("AutoassignLots", typeof(PurchaseOrderEntryResx))] 
         AutoassignLots = 28,
          /// <summary>
          /// Gets or sets CreateSerialsLotsList
          /// </summary>
         //[EnumValue("CreateSerialsLotsList", typeof(PurchaseOrderEntryResx))] 
         CreateSerialsLotsList = 29,
          /// <summary>
          /// Gets or sets PostSerialsLotsToICInventory
          /// </summary>
         //[EnumValue("PostSerialsLotsToICInventory", typeof(PurchaseOrderEntryResx))] 
         PostSerialsLotsToICInventory = 31,
     }
}
