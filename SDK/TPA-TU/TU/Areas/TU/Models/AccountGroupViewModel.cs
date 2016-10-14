using Sage.CA.SBS.ERP.Sage300.Common.Utilities;
using Sage.CA.SBS.ERP.Sage300.Common.Web;
using Sage.CA.SBS.ERP.Sage300.CS.Models.Enums;
using System;
using TPA.TU.Models;
using Status = TPA.TU.Models.Enums.Status;

namespace TPA.Web.Areas.TU.Models
{
    public class AccountGroupViewModel<T> : ViewModelBase<T> where T : AccountGroup, new()
    {
        #region UI property

        /// <summary>
        /// Gets or sets PayablesControl Description 
        /// </summary>
        public string PayablesControlDesc { get; set; }

        /// <summary>
        /// Gets or sets Discounts Description 
        /// </summary>
        public string DiscountsDesc { get; set; }

        /// <summary>
        /// Gets or sets Cost of Prepayment Description 
        /// </summary>
        public string PrepaymentDesc { get; set; }

        /// <summary>
        /// Gets or sets Retainage Description 
        /// </summary>
        public string RetainageDesc { get; set; }

        /// <summary>
        /// Gets or sets UnrealizedExchangeGain Description 
        /// </summary>
        public string UnrealizedExchangeGainDesc { get; set; }

        /// <summary>
        /// Gets or sets UnrealizedExchangeLoss Description 
        /// </summary>
        public string UnrealizedExchangeLossDesc { get; set; }

        /// <summary>
        /// Gets or sets ExchangeGain Description 
        /// </summary>
        public string ExchangeGainDesc { get; set; }

        /// <summary>
        /// Gets or sets ExchangeLoss Description 
        /// </summary>
        public string ExchangeLossDesc { get; set; }

        /// <summary>
        /// Gets or sets ExchangeRounding Description 
        /// </summary>
        public string ExchangeRoundingDesc { get; set; }

        /// <summary>
        /// Gets or sets Currency Description 
        /// </summary>
        public string CurrencyDesc { get; set; }


        /// <summary>
        /// Gets or sets IsMulticurrency
        /// </summary>
        public bool IsMulticurrency { get; set; }

        /// <summary>
        /// Gets or sets IsRetainage
        /// </summary>
        public bool IsRetainage { get; set; }

        /// <summary>
        /// Gets or sets IsValidCurrency
        /// </summary>
        public bool IsValidCurrency { get; set; }

        /// <summary>
        /// Formatted Last Maintained Date 
        /// </summary>
        public string FormattedDateLastMaintained
        {
            get
            {
                return Data != null ? DateUtil.GetShortDate(Data.DateLastMaintained, string.Empty) : string.Empty;
            }
        }

        /// <summary>
        /// Gets formatted DateLastMaintained
        /// </summary>
        public string FormattedInactiveDate
        {
            get
            {
                return DateUtil.GetShortDate((Data != null && Data.Status == Status.Inactive ? Data.InactiveDate : DateTime.Now), string.Empty);
            }
        }

        public GainOrLossAccountingMethod GainOrLossAccountingMethod { get; set; }

        #endregion
    }


}