// Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved.

using Sage.CA.SBS.ERP.Sage300.Common.Models;
using Sage.CA.SBS.ERP.Sage300.Common.Resources;
using System.Web;

namespace Sage.CA.SBS.ERP.Sage300.Common.Web.Utilities
{
    /// <summary>
    /// Utility class for building drill down URL
    /// </summary>
    public class DrillDownUrlBuilder
    {
        #region Private variables
        private readonly string _rotoId;
        private readonly DrillDownParametersParser _parser;
        #endregion

        /// <summary>
        /// Creates a new instance of DrillDownUrlBuilder class
        /// </summary>
        /// <param name="rotoId"></param>
        /// <param name="parser"></param>
        public DrillDownUrlBuilder(string rotoId, DrillDownParametersParser parser)
        {
            _rotoId = rotoId;
            _parser = parser;
        }

        /// <summary>
        /// Gets the drill down URL
        /// </summary>
        /// <returns>drill down URL</returns>
        public string GetUrl()
        {
            var urlFormat = DrillDownResx.ResourceManager.GetString(_rotoId);
            if (urlFormat == null)
            {
                return null;
            }

            string url = null;
            switch (_rotoId)
            {
                case ScreenRotoIds.APInvoiceEntry:
                case ScreenRotoIds.APPaymentEntry:
                case ScreenRotoIds.APAdjustmentEntry:
				case ScreenRotoIds.ARAdjustmentEntry:
                case ScreenRotoIds.ARReceiptEntry:
				case ScreenRotoIds.ARRefundEntry:
                case ScreenRotoIds.ARInvoiceEntry:
                    url = string.Format(urlFormat, _parser.GetBatchNumber(), _parser.GetBatchEntryNumber(), _parser.GetMode());
                    break;
                case ScreenRotoIds.CSBankEntry:
                    url = string.Format(urlFormat, _parser.GetSequenceNumber());
                    break;
                case ScreenRotoIds.POCreditDebitNoteEntry:
                case ScreenRotoIds.POReturnEntry:
                case ScreenRotoIds.POReceiptEntry:
                    url = string.Format(urlFormat, _parser.GetKey(), _parser.GetInquiryMode());
                    break;
                case ScreenRotoIds.POInvoiceEntry:
                    url = string.Format(urlFormat, _parser.GetKey(), _parser.GetInquiryMode());
                    break;
                case ScreenRotoIds.OEInvoiceEntry:
                case ScreenRotoIds.OEShipmentEntry:
                    url = string.Format(urlFormat, _parser.GetKey(), !_parser.GetInquiryMode());
                    break;
                case ScreenRotoIds.OECreditDebitNoteEntry:
                    url = string.Format(urlFormat, _parser.GetKey(), _parser.GetInquiryMode());
                    break;
                case ScreenRotoIds.CSBankTransfer:
                    url = string.Format(urlFormat, _parser.GetPostingSequence(), _parser.GetSequenceKey(), _parser.GetTypeParameter());
                    break;
                case ScreenRotoIds.ICInternalUsage:
                case ScreenRotoIds.ICReceipts:
                case ScreenRotoIds.ICTransfers:
                case ScreenRotoIds.ICShipments:
                case ScreenRotoIds.ICAdjustments:
                    url = string.Format(urlFormat, _parser.GetKey(), _parser.GetInquiryMode());
                    break;
                case ScreenRotoIds.CSReconsileStatement:
                    url = string.Format(urlFormat, _parser.GetPostingSequence(), _parser.GetBankSequence(), _parser.GetTypeParameter());
                    break;
            }

            return url != null ? VirtualPathUtility.ToAbsolute(string.Format("~/{0}/{1}", Utilities.GetUrlPrefix(), url)) : null;
        }
    }
}
