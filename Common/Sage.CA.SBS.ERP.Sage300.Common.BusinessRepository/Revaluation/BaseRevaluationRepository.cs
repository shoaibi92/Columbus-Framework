// Copyright (c) 1994-2015 Sage Software, Inc.  All rights reserved.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Sage.CA.SBS.ERP.Sage300.Common.BusinessRepository.Base;
using Sage.CA.SBS.ERP.Sage300.Common.BusinessRepository.Revaluation.Mappers;
using Sage.CA.SBS.ERP.Sage300.Common.BusinessRepository.Utilities;
using Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Revaluation.BusinessRepository;
using Sage.CA.SBS.ERP.Sage300.Common.Models;
using Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Entity;
using Sage.CA.SBS.ERP.Sage300.Common.Models.Enums;
using Sage.CA.SBS.ERP.Sage300.Common.Models.Enums.Revaluation;
using Sage.CA.SBS.ERP.Sage300.Common.Models.Revaluation;

namespace Sage.CA.SBS.ERP.Sage300.Common.BusinessRepository.Revaluation
{
    /// <summary>
    /// Base Revaluation Repository implementation
    /// </summary>
    /// <typeparam name="T">Revaluation model type</typeparam>
    /// <typeparam name="TU">Revaluation optional field model type</typeparam>
    public abstract class BaseRevaluationRepository<T, TU> : OrderedHeaderDetailRepository<T, TU>, IBaseRevaluationEntity<T, TU>
        where T : RevaluationEntry, new()
        where TU : RevaluationOptionalFieldValue, new()
    {
        #region Business Entity Variables

        /// <summary>
        /// Header entity
        /// </summary>
        private IBusinessEntity _header;

        /// <summary>
        /// Detail entity
        /// </summary>
        private IBusinessEntity _detail;

        #endregion

        #region Constructors

        /// <summary>
        /// Instantiates a new instance of <see cref="BaseRevaluationRepository{T, TU}"/> class
        /// </summary>
        /// <param name="context">Context</param>
        protected BaseRevaluationRepository(Context context)
            : base(context, new RevaluationCompositeMapper<T>(context))
        {
        }

        /// <summary>
        /// Instantiates a new instance of <see cref="BaseRevaluationRepository{T, TU}"/> class
        /// </summary>
        /// <param name="context">Context</param>
        /// <param name="session">Session</param>
        protected BaseRevaluationRepository(Context context, IBusinessEntitySession session)
            : base(context, new RevaluationCompositeMapper<T>(context), session)
        {
        }

        #endregion

        #region Overridden methods

        protected override OrderedHeaderDetailBusinessEntitySet<T, TU> CreateBusinessEntities()
        {
            _header = OpenHeaderEntity();
            _detail = OpenDetailEntity();

            _header.Compose(new[] { _detail.View });
            _detail.Compose(new[] { _header.View });

            var listOfBusinessEntities = new OrderedHeaderDetailBusinessEntitySet<T, TU>
            {
                HeaderBusinessEntity = _header,
                HeaderMapper = new RevaluationEntryMapper<T>(Context, UpdateTarget.All),
                DetailBusinessEntity = _detail,
                DetailMapper = new RevaluationOptionalFieldMapper<TU>(Context),
            };

            return listOfBusinessEntities;
        }

        protected override void ProcessMap(TU detail, IBusinessEntity detailEntity)
        {
            detailEntity.SetValue(RevaluationEntry.Index.OptionalField, detail.OptionalField, true);
            detailEntity.SetValue(RevaluationOptionalFieldValue.Index.CurrencyCode, detail.CurrencyCode, true);
        }

        protected override IEnumerable<TU> GetDetailModel(T header)
        {
            var details = header.OptionalFields;
            if (details != null && details.Items != null && details.Items.Any())
                return details.Items.Count() != 0
                    ? header.OptionalFields.Items.Cast<TU>().ToList()
                    : null;
            return new List<TU>();
        }

        public override T NewHeader()
        {
            //Override the base implementation so we can use GetAccessRights() method in order to check user rights.
            //The base implementation uses CheckRights(_headerEntity, SecurityType.Inquire) which checks permissions against the screen business view (AP0063 or AR0079).
            //This is not correct - instead we should be checking if user has permissions to use AP0041 or AR0052, which can be done using security groups APPERIOD or ARPERIOD.
            CreateBusinessEntities();
            CheckRights(GetAccessRights(), SecurityType.Modify);

            return base.NewHeader();
        }

        public override EnumerableResponse<T> Get(int currentPageNumber, int pageSize, Expression<Func<T, bool>> filter = null, OrderBy orderBy = null)
        {
            //Override the base implementation so we can use GetAccessRights() method in order to check user rights.
            //The base implementation uses CheckRights(_headerEntity, SecurityType.Inquire) which checks permissions against the screen business view (AP0063 or AR0079).
            //This is not correct - instead we should be checking if user has permissions to use AP0041 or AR0052, which can be done using security groups APPERIOD or ARPERIOD.
            CreateBusinessEntities();
            CheckRights(GetAccessRights(), SecurityType.Modify);

            return base.Get(currentPageNumber, pageSize, filter, orderBy);
        }

        #endregion

        #region Abstract methods

        protected abstract IBusinessEntity OpenHeaderEntity();

        protected abstract IBusinessEntity OpenDetailEntity();

        #endregion

        #region Virtual methods

        /// <summary>
        /// Updates Revaluation entry
        /// </summary>
        /// <param name="model">Model to update</param>
        /// <param name="updateTarget">Specifies what fields need to be updated</param>
        /// <returns>Revaluation model</returns>
        public virtual T Update(T model, UpdateTarget updateTarget)
        {
            CreateBusinessEntities();
            CheckRights(GetAccessRights(), SecurityType.Modify);

            var mapper = new RevaluationEntryMapper<T>(Context, updateTarget);
            if (model.IsNewLine)
            {
                //Map model to the BusinessView
                mapper.Map(model, _header);
                //This will take care of auto-insert optional fields
                _header.Process();
                //only try to insert if all the required data is present
                if (!string.IsNullOrEmpty(model.CurrencyCode) && !string.IsNullOrEmpty(model.RateType))
                {
                    _header.Insert();
                }
                else
                {
                    return model;
                }
            }
            else
            {
                mapper.MapKey(model, _header);
                _header.Read(false);
                if (!string.IsNullOrEmpty(model.ETag))
                {
                    CheckETag(_header, model);
                }

                //Map model to the BusinessView
                mapper.Map(model, _header);
                _header.Update();
            }

            return GetById(model.CurrencyCode);
        }

        /// <summary>
        /// Updates Optional fields related to Revaluation entry
        /// </summary>
        /// <param name="currencyCode">Currency Code</param>
        /// <param name="optionalFields">Optional fields to update</param>
        /// <returns>Revaluation model</returns>
        public virtual T UpdateOptionalFields(string currencyCode, IEnumerable<TU> optionalFields)
        {
            CreateBusinessEntities();
            CheckRights(GetAccessRights(), SecurityType.Modify);

            _header.SetValue(RevaluationEntry.Index.CurrencyCode, currencyCode);
            _header.Read(false);

            optionalFields = optionalFields.OrderByDescending(o => o.IsDeleted);

            Expression<Func<TU, bool>> filter = o => o.CurrencyCode == currencyCode;

            var filterToApply = ExpressionHelper.Translate(filter);
            var count = _detail.FilterCount(filterToApply, 0);

            foreach (var item in optionalFields)
            {
                if (string.IsNullOrEmpty(item.OptionalField) && item.IsNewLine)
                {
                    continue;
                }

                _detail.SetValue(RevaluationOptionalFieldValue.Fields.CurrencyCode, currencyCode);
                _detail.SetValue(RevaluationOptionalFieldValue.Fields.OptionalField, item.OptionalField);
                _detail.Read(false);

                var optionalMapper = new RevaluationOptionalFieldMapper<RevaluationOptionalFieldValue>(Context);

                if (item.IsDeleted)
                {
                    _detail.Delete();
                    count = count - 1;
                }
                else if (!_detail.Exists || item.IsNewLine)
                {
                    optionalMapper.Map(item, _detail);
                    _detail.Insert();
                    count = count + 1;
                }
                else if (_detail.Exists)
                {
                    optionalMapper.Map(item, _detail);
                    _detail.Update();
                }
                _detail.Read(false);
            }

            _header.SetValue(RevaluationEntry.Fields.OptionalFields, count);
            _header.Update();

            return GetById(currencyCode);
        }

        /// <summary>
        /// Returns home currency for the current company
        /// </summary>
        /// <returns></returns>
        public virtual string GetHomeCurrency()
        {
            return Session.HomeCurrency;
        }

        /// <summary>
        /// Returns Composite Currency rate based on currency rate tables for specified source currency code, rate type and date
        /// </summary>
        /// <param name="sourceCurrencyCode">Source Currency Code</param>
        /// <param name="rateType">Rate Type</param>
        /// <param name="date">Rate Date</param>
        /// <returns>CompositeCurrencyRate</returns>
        public virtual CompositeCurrencyRate GetCurrencyRateComposite(string sourceCurrencyCode, string rateType, DateTime date)
        {
            return Session.GetCurrencyRateComposite(Session.HomeCurrency, rateType, sourceCurrencyCode, date);
        }

        #endregion
    }
}
