// Copyright (c) 1994-2015 Sage Software, Inc.  All rights reserved. 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.Practices.Unity;
using Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Revaluation.Service;
using Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Service.Base;
using Sage.CA.SBS.ERP.Sage300.Common.Models;
using Sage.CA.SBS.ERP.Sage300.Common.Models.Enums.Revaluation;
using Sage.CA.SBS.ERP.Sage300.Common.Models.Revaluation;
using Sage.CA.SBS.ERP.Sage300.Common.Web;
using Sage.CA.SBS.ERP.Sage300.Shared.Web.Models;
using Context = Sage.CA.SBS.ERP.Sage300.Common.Models.Context;

namespace Sage.CA.SBS.ERP.Sage300.Shared.Web.Controllers
{
    /// <summary>
    /// Internal controller for Revaluation screen
    /// </summary>
    /// <typeparam name="T">Revaluation model type</typeparam>
    /// <typeparam name="TU">Revaluation optional field model type</typeparam>
    /// <typeparam name="TService">Revaluation service type</typeparam>
    public abstract class BaseRevaluationControllerInternal<T, TU, TService> :
        InternalControllerBase<TService>
        where T: RevaluationEntry, new()
        where TU: RevaluationOptionalFieldValue, new()
        where TService : IBaseRevaluationService<T, TU>
    {
        #region Private members

        //Application id to check for optional field license
        private const string AppId = "OB";

        //Cache key used to store Currently selected CurrencyCode
        private readonly string _currencyCodeCacheKey;

        #endregion

        #region Constructor

        /// <summary>
        /// Instantiates a new instance of <see cref="BaseRevaluationControllerInternal{T, TU, TService}"/> class
        /// </summary>
        /// <param name="context">Context</param>
        protected BaseRevaluationControllerInternal(Context context)
            : base(context)
        {
            _currencyCodeCacheKey = CreateSessionKey<string>(GetType().ToString());
        }

        #endregion

        #region Protected methods
        /// <summary>
        /// Currency currency code
        /// </summary>
        public virtual string CurrentCurrencyCode
        {
            get
            {
                return SessionHelper.Get<string>(_currencyCodeCacheKey);
            }
        }

        /// <summary>
        /// Checks if multicurrency is enabled for the current Module
        /// </summary>
        /// <returns>true if multicurrency is enabled, otherwise false</returns>
        public abstract bool IsMulticurrencyEnabled();

        /// <summary>
        /// Checks if optional field license is available
        /// </summary>
        /// <returns>true if optional field license is available, otherwise false</returns>
        public virtual bool IsOptionalFieldsLicenseAvailable()
        {
            var commonService = Context.Container.Resolve<ICommonService>(new ParameterOverride("context", Context));
            var result = commonService.CheckLicense(AppId, string.Empty);
            return result;
        }

        /// <summary>
        /// Gets the screen model
        /// </summary>
        /// <returns></returns>
        public virtual RevaluationViewModel<T> Get()
        {
            var result = Service.Get();
            return new RevaluationViewModel<T>
            {
                DataList = result.Items,
                TotalResultsCount = result.TotalResultsCount,
                HomeCurrency = Service.GetHomeCurrency(),
                IsMultiCurrency = IsMulticurrencyEnabled(),
                IsOptionalFieldsLicenseAvailable = IsOptionalFieldsLicenseAvailable()
            };
        }

        /// <summary>
        /// Gets pageable data for the main grid
        /// </summary>
        /// <param name="pageNumber">curreny page number</param>
        /// <param name="pageSize">page size</param>
        /// <returns>EnumerableResponse</returns>
        public virtual EnumerableResponse<T> Get(int pageNumber, int pageSize)
        {
            Expression<Func<T, bool>> filter = x => x.CurrencyCode != "";

            var result = Service.Get(pageNumber, pageSize, filter); 
            foreach (T item in result.Items)
                item.InternalId = Guid.NewGuid().ToString("N");

            return result;
        }

        /// <summary>
        /// Gets revaluation model by currency code
        /// </summary>
        /// <param name="currencyCode">Currency code</param>
        /// <returns>Revaluation model</returns>
        public virtual T GetById(string currencyCode)
        {
            var result = Service.GetById(currencyCode);
            result.InternalId = Guid.NewGuid().ToString("N");

            return result;
        }

        /// <summary>
        /// Creates a new instance of revaluation model
        /// </summary>
        /// <returns>Revaluation model</returns>
        public virtual T Create()
        {
            var result = Service.NewHeader();
            result.IsNewLine = true;
            result.InternalId = Guid.NewGuid().ToString("N");

            return result;
        }

        /// <summary>
        /// Updates or inserts Revaluation model 
        /// </summary>
        /// <param name="header">Revaluation model</param>
        /// <param name="updateTarget">Specifies what fields need to be updated</param>
        /// <returns>Updated Revaluation model</returns>
        public virtual T Update(T header, UpdateTarget updateTarget)
        {
            return Service.Update(header, updateTarget);
        }

        /// <summary>
        /// Deletes Revaluation models
        /// </summary>
        /// <param name="headers">Revaluation models to delete</param>
        public virtual void Delete(IEnumerable<T> headers)
        {
            foreach (var header in headers)
            {
                var headerToDelete = header;
                Expression<Func<T, bool>> filter = x => x.CurrencyCode == headerToDelete.CurrencyCode;
                Service.Delete(filter);
            }
        }

        /// <summary>
        /// Sets current Revaluation model the user is working with
        /// </summary>
        /// <param name="header">Reavluation model</param>
        /// <returns>Revaluation model</returns>
        public virtual T SetHeader(T header)
        {
            //Cache Currency Code for later use in Optional Filed manipulation logc
            SessionHelper.Set(_currencyCodeCacheKey, header.CurrencyCode);
            return header;
        }

        /// <summary>
        /// Gets Currency rate composite object
        /// </summary>
        /// <param name="sourceCurrencyCode">Source currency code</param>
        /// <param name="rateType">Rate type</param>
        /// <param name="time">Rate date</param>
        /// <returns>CompositeCurrencyRate</returns>
        public virtual CompositeCurrencyRate GetCurrencyRateComposite(string sourceCurrencyCode, string rateType, DateTime time)
        {
            return Service.GetCurrencyRateComposite(sourceCurrencyCode, rateType, time);
        }

        #endregion

        #region Optional Fields

        /// <summary>
        /// Gets pageable optional field data
        /// </summary>
        /// <param name="pageNumber">Curreny page number</param>
        /// <param name="pageSize">Page size</param>
        /// <param name="model">Changed optional fields that need to be updated</param>
        /// <returns>Optional fields</returns>
        public virtual EnumerableResponse<TU> GetOptionalFields(int pageNumber, int pageSize, List<TU> model)
        {
            string currencyCode = CurrentCurrencyCode;
            if (string.IsNullOrEmpty(currencyCode))
                return new EnumerableResponse<TU>();

            if (model != null && model.Any(m => m.IsDeleted || m.HasChanged || m.IsNewLine))
            {
                SaveOptionalFields(model);
            }

            Expression<Func<TU, bool>> filter = x => x.CurrencyCode == currencyCode;

            var result = Service.GetDetail(pageNumber, pageSize, filter);
            foreach (var resultItem in result.Items)
            {
                resultItem.SerialNumber = Guid.NewGuid().ToString("N");
            }

            return result;
        }

        /// <summary>
        /// Saves optional fields data
        /// </summary>
        /// <param name="optionalFields">Optional fields to save</param>
        /// <returns>Updated Revaluation model</returns>
        public virtual T SaveOptionalFields(List<TU> optionalFields)
        {
            var currencyCode = CurrentCurrencyCode;
            if (!string.IsNullOrEmpty(currencyCode))
            {
                return Service.UpdateOptionalFields(currencyCode, optionalFields);
            }

            return null;
        }

        /// <summary>
        /// Checks whether the optional field exists or not
        /// </summary>
        /// <param name="optField">Optional Field ID</param>
        /// <returns>true if optional field exists, otherwise false</returns>
        public virtual bool IsOptionalFieldExists(string optField)
        {
            var currencyCode = CurrentCurrencyCode;
            if (string.IsNullOrEmpty(currencyCode))
            {
                return false;
            }

            Expression<Func<TU, bool>> filter =
                optionalField =>
                    optionalField.CurrencyCode == currencyCode && optionalField.OptionalField == optField;

            var result = Service.GetDetail(0, int.MaxValue, filter);
            return result.Items.Any();
        }

        #endregion 
    }
}