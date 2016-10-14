using Microsoft.Practices.Unity;
using Sage.CA.SBS.ERP.Sage300.Common.Models;
using Sage.CA.SBS.ERP.Sage300.Common.Models.Enums;
using Sage.CA.SBS.ERP.Sage300.Common.Models.ExportImport;
using Sage.CA.SBS.ERP.Sage300.Common.Resources;
using Sage.CA.SBS.ERP.Sage300.Common.Web.Controllers.ExportImport;
using Sage.CA.SBS.ERP.Sage300.CS.Interfaces.Services;
using Sage.CA.SBS.ERP.Sage300.CS.Models;
using Sage.CA.SBS.ERP.Sage300.CS.Models.Enums;
using Sage.CA.SBS.ERP.Sage300.GL.Interfaces.Services;
using Sage.CA.SBS.ERP.Sage300.GL.Models;
/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using TPA.TU.Models.Enums;
using TPA.TU.Resources.Forms;
using TPA.Web.Areas.TU.Models;
using AccountGroup = TPA.TU.Models.AccountGroup;
using GL = Sage.CA.SBS.ERP.Sage300.GL;
using Multicurrency = TPA.TU.Models.Enums.Multicurrency;

namespace TPA.Web.Areas.TU.Controllers
{
    internal class Options
    {
        public Multicurrency Multicurrency { get; set; }
    }

    internal class OptionsPaymentAndAging
    {
        public AllowedType UseRetainage { get; set; }
    }

    /// <summary>
    /// Controller Internal Class for Account Set
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class AccountGroupControllerInternal<T> : BaseExportImportControllerInternal<T, TPA.TU.Interfaces.Services.IAccountGroupService<T>>
        where T : TPA.TU.Models.AccountGroup, new()
    {
        #region Constructor

        /// <summary>
        /// Constructor to initialize the service from the input context
        /// </summary>
        /// <param name="context">context</param>
        public AccountGroupControllerInternal(Context context)
            : base(context)
        {
        }

        #endregion

        #region internal methods

        /// <summary>
        /// Create account set
        /// </summary>
        /// <returns>Json object for account set</returns>
        internal AccountGroupViewModel<T> Create()
        {
            var model = new AccountGroupViewModel<T>();
            LoadCompanyDetails(model);
            return model;
        }

        /// <summary>
        /// Gets account set by ID
        /// </summary>
        /// <param name="id">id</param>
        /// <returns>AccountGroupViewModel</returns>
        internal AccountGroupViewModel<T> Get(string id)
        {
            T data = Service.GetById(id);
            var model = new AccountGroupViewModel<T>();
            {
                if (data != null)
                {
                    model.Data = data;
                }
            }
            return GetAccAndCurrDescription(model);
        }

        /// <summary>
        /// Add account set
        /// </summary>
        /// <param name="model">AccountGroupModel</param>
        /// <returns>Json object for account set </returns>
        internal AccountGroupViewModel<T> Add(T model)
        {
            var data = Service.Add(model);
            var modelData = new AccountGroupViewModel<T>();
            {
                if (data != null)
                {
                    modelData.Data = data;
                }
            }
            modelData = GetAccAndCurrDescription(modelData);
            if (data != null)
            {
                modelData.UserMessage = new UserMessage(data,
                    string.Format(CommonResx.AddSuccessMessage, AccountGroupsResx.AccountGroupCode, data.AccountGroupCode));
            }
            modelData.GainOrLossAccountingMethod = GetGainOrLossAccount();
            return modelData;
        }

        /// <summary>
        /// Updates a account set
        /// </summary>
        /// <param name="model">Account set Model</param>
        /// <returns>Json object for account set </returns>
        internal AccountGroupViewModel<T> Save(T model)
        {
            var data = Service.Save(model);
            var modelData = new AccountGroupViewModel<T>();
            {
                if (data != null)
                {
                    modelData.Data = data;
                }
            }
            modelData = GetAccAndCurrDescription(modelData);
            if (data != null)
            {
                modelData.UserMessage = new UserMessage(data, CommonResx.SaveSuccessMessage);
            }
            modelData.GainOrLossAccountingMethod = GetGainOrLossAccount();
            return modelData;
        }

        /// <summary>
        /// Update the status of the account set
        /// </summary>
        /// <param name="model">model</param>
        /// <returns>AccountGroupViewModel</returns>
        internal AccountGroupViewModel<T> UpdateStatus(T model)
        {
            var data = Service.UpdateStatus(model);
            var modelData = new AccountGroupViewModel<T>();
            {
                if (data != null)
                {
                    modelData.Data = data;
                }
            }
            modelData = GetAccAndCurrDescription(modelData);
            modelData.GainOrLossAccountingMethod = GetGainOrLossAccount();
            if (data != null)
            {
                modelData.UserMessage = new UserMessage(data, CommonResx.SaveSuccessMessage);
            }
            return modelData;
        }

        /// <summary>
        /// Delete account set
        /// </summary>
        /// <param name="id">id</param>
        /// <returns>AccountGroupViewModel</returns>
        internal AccountGroupViewModel<T> Delete(string id)
        {
            Expression<Func<T, bool>> filter = param => param.AccountGroupCode == id;
            var data = Service.Delete(filter);
            var modelData = new AccountGroupViewModel<T>();
            {
                if (data != null)
                {
                    modelData.Data = data;
                }
            }
            modelData = GetAccAndCurrDescription(modelData);
            if (data != null)
            {
                modelData.UserMessage = new UserMessage(modelData.Data, string.Format(CommonResx.DeleteSuccessMessage, AccountGroupsResx.AccountGroupCode, data.AccountGroupCode));
            }
            return modelData;



        }

        /// <summary>
        /// Get the Description of Account
        /// </summary>
        /// <param name="model">Account set Model</param>
        /// <param name="accountType">accountType</param>
        /// <returns>Account Description</returns>
        internal AccountGroupViewModel<T> GetAccountDescription(T model, AccountType accountType)
        {
            var response = new AccountGroupViewModel<T> { Data = model, UserMessage = new UserMessage { IsSuccess = true } };
            var data = GetAccountType(model, accountType);
            var account = GetAccount(data ?? "");
            var companyProfile = GetCompanyProfile();
            response = SetDescription(response, account, accountType);
            if (string.IsNullOrEmpty(data))
            {
                response.UserMessage.IsSuccess = false;
                response.UserMessage.Errors = GetMessage(account, data, accountType);
                return response;
            }

            if (account.Status == GL.Models.Enums.Status.Active)
            {
                return response;
            }

            if ((!account.NewAccount && companyProfile.CompanyProfileOptions.InactiveGorLAccount == LockedFiscalPeriod.Error && model.Status != TPA.TU.Models.Enums.Status.Inactive) ||
                (account.NewAccount && companyProfile.CompanyProfileOptions.NonexistentGorLAccount == LockedFiscalPeriod.Error))
            {
                response.UserMessage.IsSuccess = false;
                response.UserMessage.Errors = GetMessage(account, data, accountType);
            }

            else if ((!account.NewAccount && companyProfile.CompanyProfileOptions.InactiveGorLAccount == LockedFiscalPeriod.Warning && model.Status != TPA.TU.Models.Enums.Status.Inactive) ||
                (account.NewAccount && companyProfile.CompanyProfileOptions.NonexistentGorLAccount == LockedFiscalPeriod.Warning))
            {
                response.UserMessage.IsSuccess = false;
                response.UserMessage.Warnings = GetMessage(account, data, accountType);
            }
            return response;
        }

        /// <summary>
        /// Get Account Type
        /// </summary>
        /// <param name="model">Modified Account set view model</param>
        /// <param name="accountType"></param>
        /// <returns>Updated Account set view model</returns>
        internal string GetAccountType(T model, AccountType accountType)
        {
            switch (accountType)
            {
                case AccountType.PayablesControl: return model.PayablesControlAccount;
                case AccountType.Discounts: return model.DiscountsAccount;
                case AccountType.Prepayment: return model.PrepaymentAccount;
                case AccountType.Retainage: return model.RetainageAccount;
                case AccountType.UnrealizedExchangeGain: return model.UnrealizedExchangeGainAccount;
                case AccountType.UnrealizedExchangeLoss: return model.UnrealizedExchangeLossAccount;
                case AccountType.ExchangeGain: return model.ExchangeGainAccount;
                case AccountType.ExchangeLoss: return model.ExchangeLossAccount;
                case AccountType.ExchangeRounding: return model.ExchangeRoundingAccount;
            }


            return null;
        }

        /// <summary>
        /// Set Account Description
        /// </summary>
        /// <param name="model">Modified Account Set view model</param>
        /// <param name="account">Account model</param>
        /// <param name="accountType">Account Type</param>
        /// <returns></returns>
        internal AccountGroupViewModel<T> SetDescription(AccountGroupViewModel<T> model, Account account, AccountType accountType)
        {
            if (!string.IsNullOrEmpty(account.AccountNumber))
            {
                switch (accountType)
                {
                    case AccountType.PayablesControl:
                        model.Data.PayablesControlAccount = account.AccountNumber;
                        model.PayablesControlDesc = account.Description;
                        return model;
                    case AccountType.Discounts:
                        model.Data.DiscountsAccount = account.AccountNumber;
                        model.DiscountsDesc = account.Description;
                        return model;
                    case AccountType.Prepayment:
                        model.Data.PrepaymentAccount = account.AccountNumber;
                        model.PrepaymentDesc = account.Description;
                        return model;
                    case AccountType.Retainage:
                        model.Data.RetainageAccount = account.AccountNumber;
                        model.RetainageDesc = account.Description;
                        return model;
                    case AccountType.UnrealizedExchangeGain:
                        model.Data.UnrealizedExchangeGainAccount = account.AccountNumber;
                        model.UnrealizedExchangeGainDesc = account.Description;
                        return model;
                    case AccountType.UnrealizedExchangeLoss:
                        model.Data.UnrealizedExchangeLossAccount = account.AccountNumber;
                        model.UnrealizedExchangeLossDesc = account.Description;
                        return model;
                    case AccountType.ExchangeGain:
                        model.Data.ExchangeGainAccount = account.AccountNumber;
                        model.ExchangeGainDesc = account.Description;
                        return model;

                    case AccountType.ExchangeLoss:
                        model.Data.ExchangeLossAccount = account.AccountNumber;
                        model.ExchangeLossDesc = account.Description;
                        return model;
                    case AccountType.ExchangeRounding:
                        model.Data.ExchangeRoundingAccount = account.AccountNumber;
                        model.ExchangeRoundingDesc = account.Description;
                        return model;
                }
            }
            return model;
        }

        /// <summary>
        /// initial load of CompanyDetails, need for integration 
        ///     * The default currency in AP Account set screen is the functional currency which is fetch from company profile.
        ///     * GetGainOrLossAccount from company profile which disable the unrealised exchange gain/loss on selection of Recognized Gain/Loss
        ///     * IsRetainge sets the vaule from AP Options, precessing tab, useretainge propery.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        internal AccountGroupViewModel<T> LoadCompanyDetails(AccountGroupViewModel<T> model)
        {
            var companyProfile = GetCompanyProfile();
            model.GainOrLossAccountingMethod = GetGainOrLossAccount();
            model.Data.CurrencyCodeforAccount = companyProfile.CompanyProfileOptions.FunctionalCurrency;
            model.CurrencyDesc = companyProfile.CompanyProfileOptions.CurrencyDescription;
            model.IsMulticurrency = GetOptions().Multicurrency == Multicurrency.Yes;
            model.IsRetainage = GetOptionsPayAndAging().UseRetainage == (AllowedType)Multicurrency.Yes;
            return model;
        }
        /// <summary>
        /// Get currency description
        /// </summary>
        /// <param name="model">Account Set Model</param>
        /// <returns>AccountGroupViewModel</returns>
        public AccountGroupViewModel<T> GetCurrencyDescription(T model)
        {

            var currencyService = Context.Container.Resolve<ICurrencyCodeService<CurrencyCode>>(new ParameterOverride("context", Context));
            var response = new AccountGroupViewModel<T> { Data = model, UserMessage = new UserMessage { IsSuccess = true } };
            var data = currencyService.GetById(model.CurrencyCodeforAccount);
            var errorList = new List<EntityError>();
            if (!string.IsNullOrEmpty(model.CurrencyCodeforAccount))
            {
                if (data != null)
                {
                    response.UserMessage.IsSuccess = true;
                    response.IsValidCurrency = true;
                    response.CurrencyDesc = data.Description;
                    return response;
                }
                var entityError1 = new EntityError
                {
                    Message = string.Format(CommonResx.RecordNotFoundMessage, AccountGroupsResx.Currency, model.CurrencyCodeforAccount.ToUpper()),
                    Priority = Priority.Error
                };
                errorList.Add(entityError1);
                response.UserMessage.IsSuccess = false;
                response.IsValidCurrency = false;
                response.UserMessage.Errors = errorList;
                return response;
            }
            var entityError2 = new EntityError
            {
                Message = string.Format(CommonResx.CannotBeBlankMessage, AccountGroupsResx.Currency),
                Priority = Priority.Error
            };
            errorList.Add(entityError2);
            response.UserMessage.IsSuccess = false;
            response.IsValidCurrency = false;
            response.UserMessage.Errors = errorList;
            return response;

        }

        #region Private Methods


        /// <summary>
        /// Get description for G/L account set
        /// </summary>
        /// <param name="model">Modified AccountGroup view model</param>
        /// <returns>Updated AccountGroup view model</returns>
        private AccountGroupViewModel<T> GetDescription(AccountGroupViewModel<T> model)
        {
            var accountService = Context.Container.Resolve<IAccountService<Account>>(new ParameterOverride("context", Context));
            Expression<Func<Account, bool>> payablesControl = acct => acct.AccountNumber == model.Data.PayablesControlAccount;
            model.PayablesControlDesc = accountService.GetAccountDescription(payablesControl);

            Expression<Func<Account, bool>> discounts = acct => acct.AccountNumber == model.Data.DiscountsAccount;
            model.DiscountsDesc = accountService.GetAccountDescription(discounts);

            Expression<Func<Account, bool>> prepayment = acct => acct.AccountNumber == model.Data.PrepaymentAccount;
            model.PrepaymentDesc = accountService.GetAccountDescription(prepayment);

            Expression<Func<Account, bool>> retainage = acct => acct.AccountNumber == model.Data.RetainageAccount;
            model.RetainageDesc = accountService.GetAccountDescription(retainage);

            Expression<Func<Account, bool>> unrealizedExchangeGain = acct => acct.AccountNumber == model.Data.UnrealizedExchangeGainAccount;
            model.UnrealizedExchangeGainDesc = accountService.GetAccountDescription(unrealizedExchangeGain);

            Expression<Func<Account, bool>> unrealizedExchangeLoss = acct => acct.AccountNumber == model.Data.UnrealizedExchangeLossAccount;
            model.UnrealizedExchangeLossDesc = accountService.GetAccountDescription(unrealizedExchangeLoss);

            Expression<Func<Account, bool>> exchangeGain = acct => acct.AccountNumber == model.Data.ExchangeGainAccount;
            model.ExchangeGainDesc = accountService.GetAccountDescription(exchangeGain);

            Expression<Func<Account, bool>> exchangeLoss = acct => acct.AccountNumber == model.Data.ExchangeLossAccount;
            model.ExchangeLossDesc = accountService.GetAccountDescription(exchangeLoss);

            Expression<Func<Account, bool>> exchangeRounding = acct => acct.AccountNumber == model.Data.ExchangeRoundingAccount;
            model.ExchangeRoundingDesc = accountService.GetAccountDescription(exchangeRounding);

            return model;
        }
        /// <summary>
        /// GetMessage
        /// </summary>
        /// <param name="account">account</param>
        /// <param name="data">data</param>
        /// <param name="accountType">accountType</param>
        /// <returns></returns>
        private static IEnumerable<EntityError> GetMessage(Account account, string data, AccountType accountType)
        {
            var errorList = new List<EntityError>();
            var entityError = new EntityError
            {
                Priority = Priority.Error,
                Message = (data != null ?
                        (account.NewAccount ? string.Format(CommonResx.RecordNotFoundMessage, AccountGroupsResx.GenLedgerAcct, data.ToUpper())
                        : string.Format(CommonResx.InactiveRecordMessage, AccountGroupsResx.GenLedgerAcct, data.ToUpper()))
                        : string.Format(CommonResx.CannotBeBlankMessage, string.Format(GetAccountTypeMessage(accountType) + " " + AccountGroupsResx.GenLedgerAcct)))
            };

            errorList.Add(entityError);
            return errorList;
        }

        /// <summary>
        /// Get AccountType for message
        /// </summary>
        /// <param name="accountType">accountType</param>
        /// <returns>AccountGroupsResx string values</returns>
        private static string GetAccountTypeMessage(AccountType accountType)
        {
            switch (accountType)
            {
                case AccountType.PayablesControl:
                    return AccountGroupsResx.PayablesControl;
                case AccountType.Discounts:
                    return AccountGroupsResx.PurchaseDiscounts;
                case AccountType.Prepayment:
                    return AccountGroupsResx.Prepayment;
                case AccountType.Retainage:
                    return AccountGroupsResx.Retainage;
                case AccountType.UnrealizedExchangeGain:
                    return AccountGroupsResx.Retainage;
                case AccountType.UnrealizedExchangeLoss:
                    return AccountGroupsResx.UnrlzExchGain;
                case AccountType.ExchangeGain:
                    return AccountGroupsResx.UnrlzExchLoss;
                case AccountType.ExchangeLoss:
                    return AccountGroupsResx.RlzExchGain;
                case AccountType.ExchangeRounding:
                    return AccountGroupsResx.ExchRounding;

            }
            return string.Empty;
        }

        /// <summary>
        /// Get Company profile
        /// </summary>
        /// <returns>CompanyProfile</returns>
        private CompanyProfile GetCompanyProfile()
        {
            var companyProfileService = Context.Container.Resolve<ICompanyProfileService<CompanyProfile>>(new ParameterOverride("context", Context));
            var companyProfile = companyProfileService.Get();
            return (companyProfile.Items != null && companyProfile.Items.Any() ? companyProfile.Items.First() : new CompanyProfile());
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
        /// Get Account
        /// </summary>
        /// <param name="accountNumber">accountNumber</param>
        /// <returns>Account</returns>
        private Account GetAccount(string accountNumber)
        {
            var accountService = Context.Container.Resolve<IAccountService<Account>>(new ParameterOverride("context", Context));
            Expression<Func<Account, bool>> filter = m => m.UnformattedAccount == accountNumber.ToUpper() || m.AccountNumber == accountNumber.ToUpper();
            var accounts = accountService.Get(filter);
            return (accounts.Items != null && accounts.Items.Any() ? accounts.Items.First() : new Account { NewAccount = true });
        }

        ///  <summary>
        /// Get account and currency Description
        ///  </summary>
        /// <param name="modelData">modelData</param>
        /// <returns>Json object for account set </returns>
        private AccountGroupViewModel<T> GetAccAndCurrDescription(AccountGroupViewModel<T> modelData)
        {
            modelData = GetCurrencyDescription(modelData.Data);
            modelData = GetDescription(modelData);
            modelData.GainOrLossAccountingMethod = GetGainOrLossAccount();
            return modelData;
        }
        /// <summary>
        /// Get company profile gain or loss
        /// </summary>
        /// <returns></returns>
        private GainOrLossAccountingMethod GetGainOrLossAccount()
        {
            var companyProfile = GetCompanyProfile();
            return companyProfile.CompanyProfileOptions.GainOrLossAccountingMethod;
        }
        #endregion
        #endregion

        #region Export Items
        /// <summary>
        /// ExportItems
        /// </summary>
        /// <param name="request">Export request</param>
        /// <returns>Export Request</returns>
        public override ExportRequest ExportItems(ExportRequest request)
        {
            var data = GetDataMigrationItem<T>(request.Name, false);
            data.Description = AccountGroupsResx.AccountGroup;
            if (GetOptions().Multicurrency == Multicurrency.No && GetOptionsPayAndAging().UseRetainage == AllowedType.No)
            {
                var columns = data.Items.Where(i => i.columnId != AccountGroup.Index.UnrealizedExchangeGainAccount && i.columnId != AccountGroup.Index.UnrealizedExchangeLossAccount
                    && i.columnId != AccountGroup.Index.ExchangeGainAccount && i.columnId != AccountGroup.Index.ExchangeLossAccount && i.columnId != AccountGroup.Index.ExchangeRoundingAccount
                    && i.columnId != AccountGroup.Index.RetainageAccount).ToList();
                data.Items = columns;
            }
            else if (GetOptionsPayAndAging().UseRetainage == AllowedType.No)
            {
                var columns = data.Items.Where(i => i.columnId != AccountGroup.Index.RetainageAccount).ToList();
                data.Items = columns;
            }
            else if (GetOptions().Multicurrency == Multicurrency.No)
            {
                var columns = data.Items.Where(i => i.columnId != AccountGroup.Index.UnrealizedExchangeGainAccount && i.columnId != AccountGroup.Index.UnrealizedExchangeLossAccount
                    && i.columnId != AccountGroup.Index.ExchangeGainAccount && i.columnId != AccountGroup.Index.ExchangeLossAccount && i.columnId != AccountGroup.Index.ExchangeRoundingAccount).ToList();
                data.Items = columns;
            }
            request.DataMigrationList.Add(data);
            return request;
        }
        #endregion

    }
}