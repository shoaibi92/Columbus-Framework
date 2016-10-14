
namespace Sage.CA.SBS.ERP.Sage300.Common.Models.InvoiceEntry
{
    /// <summary>
    /// BaseInvoice Batch Fields
    /// </summary>
    public partial class BaseInvoiceBatch
    {

        /// <summary>
        /// Contains list of InvoiceBatch Fields Constants
        /// </summary>
        public partial class BaseFields
        {
            /// <summary>
            /// Property for BatchNumber 
            /// </summary>
            public const string BatchNumber = "CNTBTCH";

            /// <summary>
            /// Property for BatchDate 
            /// </summary>
            public const string BatchDate = "DATEBTCH";

            /// <summary>
            /// Property for Description 
            /// </summary>
            public const string Description = "BTCHDESC";

            /// <summary>
            /// Property for NumberofEntries 
            /// </summary>
            public const string NumberOfEntries = "CNTINVCENT";

            /// <summary>
            /// Property for BatchTotal 
            /// </summary>
            public const string BatchTotal = "AMTENTR";

            /// <summary>
            /// Property for BatchType 
            /// </summary>
            public const string BatchType = "BTCHTYPE";

            /// <summary>
            /// Property for BatchStatus 
            /// </summary>
            public const string BatchStatus = "BTCHSTTS";

            /// <summary>
            /// Property for InvoiceType 
            /// </summary>
            public const string InvoiceType = "INVCTYPE";

            /// <summary>
            /// Property for DefaultInvoiceType
            /// </summary>
            public const string DefaultInvoiceType = "INVCTYPE";

            /// <summary>
            /// Property for LastEntryNumber 
            /// </summary>
            public const string LastEntryNumber = "CNTLSTITEM";

            /// <summary>
            /// Property for PostingSequenceNo 
            /// </summary>
            public const string PostingSequenceNo = "POSTSEQNBR";

            /// <summary>
            /// Property for NumberofErrors 
            /// </summary>
            public const string NumberOfErrors = "NBRERRORS";

            /// <summary>
            /// Property for DateLastEdited 
            /// </summary>
            public const string DateLastEdited = "DTELSTEDIT";

            /// <summary>
            /// Property for BatchPrintedFlag 
            /// </summary>
            public const string BatchPrintedFlag = "SWPRINTED";

            /// <summary>
            /// Property for SourceApplication 
            /// </summary>
            public const string SourceApplication = "SRCEAPPL";

            /// <summary>
            /// Property for ProcessCommandCode 
            /// </summary>
            public const string ProcessCommandCode = "PROCESSCMD";
        }

        /// <summary>
        /// Contains list of InvoiceBatch Index Constants
        /// </summary>
        public partial class BaseIndex
        {
            /// <summary>
            /// Property Indexer for BatchNumber 
            /// </summary>
            public const int BatchNumber = 1;

            /// <summary>
            /// Property Indexer for BatchDate 
            /// </summary>
            public const int BatchDate = 2;

            /// <summary>
            /// Property Indexer for Description 
            /// </summary>
            public const int Description = 3;

            /// <summary>
            /// Property Indexer for NumberOfEntries 
            /// </summary>
            public const int NumberOfEntries = 4;

            /// <summary>
            /// Property Indexer for BatchTotal 
            /// </summary>
            public const int BatchTotal = 5;

            /// <summary>
            /// Property Indexer for BatchType 
            /// </summary>
            public const int BatchType = 6;

            /// <summary>
            /// Property Indexer for BatchStatus 
            /// </summary>
            public const int BatchStatus = 7;

            /// <summary>
            /// Property Indexer for InvoiceType 
            /// </summary>
            public const int InvoiceType = 8;

            /// <summary>
            /// Property for DefaultInvoiceType
            /// </summary>
            public const int DefaultInvoiceType = 8;

            /// <summary>
            /// Property Indexer for LastEntryNumber 
            /// </summary>
            public const int LastEntryNumber = 9;

            /// <summary>
            /// Property Indexer for PostingSequenceNo 
            /// </summary>
            public const int PostingSequenceNo = 10;

            /// <summary>
            /// Property Indexer for NumberOfErrors 
            /// </summary>
            public const int NumberOfErrors = 11;

            /// <summary>
            /// Property Indexer for DateLastEdited 
            /// </summary>
            public const int DateLastEdited = 12;

            /// <summary>
            /// Property Indexer for BatchPrintedFlag 
            /// </summary>
            public const int BatchPrintedFlag = 13;

            /// <summary>
            /// Property Indexer for SourceApplication 
            /// </summary>
            public const int SourceApplication = 14;
        }
    }
}
