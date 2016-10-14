
/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Repository;
using Sage.CA.SBS.ERP.Sage300.Common.Models;
using Sage.CA.SBS.ERP.Sage300.Common.Models.Enums;
using Sage.CA.SBS.ERP.Sage300.Common.Web.Controllers.Finder;
using Sage.CA.SBS.ERP.Sage300.Common.Web.Utilities;
using Sage.CA.SBS.ERP.Sage300.Common.Resources;
using TPA.TU.Resources.Forms;
using TPA.TU.Interfaces.Services;
using TPA.TU.Models;
using TPA.TU.Models.Enums;

namespace TPA.Web.Areas.TU.Controllers.Finder
{
    /// <summary>
    /// Class for Find Account Sets Controller Internal methods
    /// </summary>
    /// <typeparam name="T"></typeparam> 
    public class FindAccountGroupControllerInternal<T> : BaseFindControllerInternal<T, IAccountGroupService<T>>, IFinder
        where T : AccountGroup, new()
    {

        /// <summary>
        /// Constructor to initialize  Find account set Controller Internal
        /// </summary>
        /// <param name="context">Request context</param>
        public FindAccountGroupControllerInternal(Context context)
            : base(context)
        {
        }

        /// <summary>
        /// Gets ModelBase
        /// </summary>
        /// <param name="id">Message ID</param>
        /// <returns>First or Default Message ID</returns>
        public virtual ModelBase Get(string id)
        {

            return null;
        }

        /// <summary>
        /// Returns the default columns 
        /// </summary>
        /// <returns>List of Default Columns</returns>
        public override List<string> GetDefaultColumns()
        {
            return new List<string> { "AccountGroupCode", "Description", "StatusString", "CurrencyCodeforAccount" };
        }

        /// <summary>
        /// Get Company options
        /// </summary>
        /// <returns>CompanyOptions</returns>
        private Options GetOptions()
        {
            return new Options
            {

                Multicurrency = Multicurrency.Yes
            };
        }

        /// <summary>
        /// Get options payment and aging
        /// </summary>
        /// <returns>OptionsPayAndAging</returns>
        private OptionsPaymentAndAging GetOptionsPayAndAging()
        {
            return new OptionsPaymentAndAging
            {
                UseRetainage = AllowedType.Yes
            };
        }
        /// <summary>
        /// Fetches Columns
        /// </summary>
        /// <returns>List of Account Set fields</returns>
        public override IEnumerable<ModelBase> GetAllColumns()
        {
            var isMulticurrency = GetOptions().Multicurrency == Multicurrency.Yes;
            var isRetainage = GetOptionsPayAndAging().UseRetainage == AllowedType.Yes;
            var column = new List<GridField>();
            var retainageColumn = new List<GridField>
            {
                new GridField
                {
                    field = "RetainageAccount",
                    title = AccountGroupsResx.RetainageAcct,
                    attributes = FinderConstant.CssClassGridColumn10,
                    headerAttributes = FinderConstant.CssClassGridColumn10,
                    dataType = FinderConstant.DataTypeString,
                    customAttributes = new Dictionary<string, string>
                    {
                        {"class", "txt-upper"},
                        {"maxLength", "45"}
                    }
                },
            };
            var multiCurrencyColumn = new List<GridField>
            {
                new GridField
                {
                    field = "UnrealizedExchangeGainAccount",
                    title = AccountGroupsResx.UnrlzExchGainAcct,
                    attributes = FinderConstant.CssClassGridColumn10,
                    headerAttributes = FinderConstant.CssClassGridColumn10,
                    dataType = FinderConstant.DataTypeString,
                    customAttributes = new Dictionary<string, string>
                    {
                        {"class", "txt-upper"},
                        {"maxLength", "45"}
                    }
                },
                new GridField
                {
                    field = "UnrealizedExchangeLossAccount",
                    title = AccountGroupsResx.UnrlzExchLossAcct,
                    attributes = FinderConstant.CssClassGridColumn10,
                    headerAttributes = FinderConstant.CssClassGridColumn10,
                    dataType = FinderConstant.DataTypeString,
                    customAttributes = new Dictionary<string, string>
                    {
                        {"class", "txt-upper"},
                        {"maxLength", "45"}
                    }
                },
                new GridField
                {
                    field = "ExchangeGainAccount",
                    title = AccountGroupsResx.RlzExchGainAcct,
                    attributes = FinderConstant.CssClassGridColumn10,
                    headerAttributes = FinderConstant.CssClassGridColumn10,
                    dataType =FinderConstant.DataTypeString,
                    customAttributes = new Dictionary<string, string>
                    {
                        {"class", "txt-upper"},
                        {"maxLength", "45"}
                    }
                },
                new GridField
                {
                    field = "ExchangeLossAccount",
                    title = AccountGroupsResx.RlzExchLossAcct,
                    attributes = FinderConstant.CssClassGridColumn10,
                    headerAttributes = FinderConstant.CssClassGridColumn10,
                    dataType =FinderConstant.DataTypeString,
                    customAttributes = new Dictionary<string, string>
                    {
                        {"class", "txt-upper"},
                        {"maxLength", "45"}
                    }
                },
                new GridField
                {
                    field = "ExchangeRoundingAccount",
                    title = AccountGroupsResx.ExchRoundingAcct,
                    attributes = FinderConstant.CssClassGridColumn10,
                    headerAttributes = FinderConstant.CssClassGridColumn10,
                    dataType =FinderConstant.DataTypeString,
                    customAttributes = new Dictionary<string, string>
                    {
                        {"class", "txt-upper"},
                        {"maxLength", "45"}
                    }
                },
            };
            if (isRetainage && isMulticurrency)
            {
                var commonColumn = GetCommonColumns();
                column.AddRange(commonColumn);
                column.AddRange(retainageColumn);
                column.AddRange(multiCurrencyColumn);
            }
            else if (isMulticurrency)
            {
                var commonColumn = GetCommonColumns();
                column.AddRange(commonColumn);
                column.AddRange(multiCurrencyColumn);
            }
            else if (isRetainage)
            {
                var commonColumn = GetCommonColumns();
                column.AddRange(commonColumn);
                column.AddRange(retainageColumn);
            }
            else
            {
                var commonColumn = GetCommonColumns();
                column.AddRange(commonColumn);
            }
            return column.AsEnumerable();
        }

        /// <summary>
        /// Get Common Columns
        /// </summary>
        /// <returns>List of Columns</returns>
        public IEnumerable<GridField> GetCommonColumns()
        {
            var column = new List<GridField>
            {
                new GridField
                {
                    field = "AccountGroupCode",
                    title = AccountGroupsResx.AccountGroupCode,
                    attributes = FinderConstant.CssClassGridColumn10,
                    headerAttributes = FinderConstant.CssClassGridColumn10,
                    dataType = FinderConstant.DataTypeString,
                    customAttributes =
                        new Dictionary<string, string>
                        {
                            {"class", "txt-upper"},
                            {"maxLength", "6"},
                            {"formatTextbox", "alphaNumeric"}
                        }
                },
                new GridField
                {
                    field = "Description",
                    title =AccountGroupsResx.AccountGroupDesc,
                    attributes =FinderConstant.CssClassGridColumn10,
                    headerAttributes = FinderConstant.CssClassGridColumn10,
                    dataType = FinderConstant.DataTypeString,
                     customAttributes = new Dictionary<string, string>
                    {
                        {"maxLength", "60"},
                    }
                },
                new GridField
                {
                    field = "StatusString",
                    title = AccountGroupsResx.Status,
                    attributes = FinderConstant.CssClassGridColumn10,
                    headerAttributes = FinderConstant.CssClassGridColumn10,
                    PresentationList = EnumUtility.GetItemsList<TPA.TU.Models.Enums.Status>(),
                },
                new GridField
                {
                    field = "CurrencyCodeforAccount",
                    title = AccountGroupsResx.CurrencyCodeForAcct,
                    attributes =FinderConstant.CssClassGridColumn10,
                    headerAttributes = FinderConstant.CssClassGridColumn10,
                    dataType = FinderConstant.DataTypeString,
                    customAttributes = new Dictionary<string, string>
                    {
                        {"class", "txt-upper"},
                        {"maxLength", "3"},
                        {"formatTextbox", "alphaNumeric"}
                    }
                },
                new GridField
                {
                    field = "InactiveDate",
                    title = AccountGroupsResx.InactiveDate,
                    attributes = FinderConstant.CssClassGridColumn10,
                    headerAttributes =FinderConstant.CssClassGridColumn10,
                    dataType =FinderConstant.DataTypeDate,
                    template = Utilities.GetGridTemplate("InactiveDate"),
                },
                new GridField
                {
                    field = "DateLastMaintained",
                    title = CommonResx.LastMaintained,
                    attributes = FinderConstant.CssClassGridColumn10,
                    headerAttributes =FinderConstant.CssClassGridColumn10,
                    dataType = FinderConstant.DataTypeDate,
                    template = Utilities.GetGridTemplate("DateLastMaintained"),
                },
                new GridField
                {
                    field = "PayablesControlAccount",
                    title = AccountGroupsResx.PayablesControlAcct,
                    attributes = FinderConstant.CssClassGridColumn10,
                    headerAttributes = FinderConstant.CssClassGridColumn10,
                    dataType = FinderConstant.DataTypeString,
                    customAttributes = new Dictionary<string, string>
                    {
                        {"class", "txt-upper"},
                        {"maxLength", "45"}
                    }
                },
                new GridField
                {
                    field = "PrepaymentAccount",
                    title = AccountGroupsResx.PrepaymentAcct,
                    attributes = FinderConstant.CssClassGridColumn10,
                    headerAttributes = FinderConstant.CssClassGridColumn10,
                    dataType = FinderConstant.DataTypeString,
                    customAttributes = new Dictionary<string, string>
                    {
                        {"class", "txt-upper"},
                        {"maxLength", "45"}
                    }
                },
                new GridField
                {
                    field = "DiscountsAccount",
                    title = AccountGroupsResx.DiscountsAcct,
                    attributes = FinderConstant.CssClassGridColumn10,
                    headerAttributes = FinderConstant.CssClassGridColumn10,
                    dataType =FinderConstant.DataTypeString,
                    customAttributes = new Dictionary<string, string>
                    {
                        {"class", "txt-upper"},
                        {"maxLength", "45"}
                    }
                },
             };
            return column;
        }
    }
}