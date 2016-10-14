/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

using System;
using TPA.TU.Models;
using TPA.TU.Models.Enums;
using Sage.CA.SBS.ERP.Sage300.Common.BusinessRepository;
using Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Entity;
using Sage.CA.SBS.ERP.Sage300.Common.Models;
using PaymentCode = TPA.TU.Models.AccountGroup;

namespace TPA.TU.BusinessRepository.Mappers
{
    /// <summary>
    /// Class for AccountGroups mapping
    /// </summary>
    public class AccountGroupMapper<T> : ModelMapper<T> where T : AccountGroup, new()
    {
        #region Private Properties

        // ReSharper disable once NotAccessedField.Local
        private readonly Context _context;

        #endregion

        #region Constructor

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public AccountGroupMapper(Context context)
            : base(context)
        {
            _context = context;
        }

        #endregion

        #region Abstract  methods
        /// <summary>
        /// Maps the entities's field values to the model. 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public override T Map(IBusinessEntity entity)
        {
            var model = base.Map(entity);
            model.AccountGroupCode = entity.GetValue<string>(AccountGroup.Index.AccountGroupCode);
            model.Description = entity.GetValue<string>(AccountGroup.Index.Description);
            model.Status = EnumUtility.GetEnum<Status>(entity.GetValue<string>(AccountGroup.Index.Status));
            model.InactiveDate = entity.GetValue<DateTime>(AccountGroup.Index.InactiveDate);
            model.DateLastMaintained = entity.GetValue<DateTime>(AccountGroup.Index.DateLastMaintained);
            model.PayablesControlAccount = entity.GetValue<string>(AccountGroup.Index.PayablesControlAccount);
            model.DiscountsAccount = entity.GetValue<string>(AccountGroup.Index.DiscountsAccount);
            model.PrepaymentAccount = entity.GetValue<string>(AccountGroup.Index.PrepaymentAccount);
            model.CurrencyCodeforAccount = entity.GetValue<string>(AccountGroup.Index.CurrencyCodeforAccount);
            model.UnrealizedExchangeGainAccount = entity.GetValue<string>(AccountGroup.Index.UnrealizedExchangeGainAccount);
            model.UnrealizedExchangeLossAccount = entity.GetValue<string>(AccountGroup.Index.UnrealizedExchangeLossAccount);
            model.ExchangeGainAccount = entity.GetValue<string>(AccountGroup.Index.ExchangeGainAccount);
            model.ExchangeLossAccount = entity.GetValue<string>(AccountGroup.Index.ExchangeLossAccount);
            model.RetainageAccount = entity.GetValue<string>(AccountGroup.Index.RetainageAccount);
            model.ExchangeRoundingAccount = entity.GetValue<string>(AccountGroup.Index.ExchangeRoundingAccount);
            return model;
        }

        /// <summary>
        /// Maps the model data to entity fields
        /// </summary>
        /// <param name="model"></param>
        /// <param name="entity"></param>
        public override void Map(T model, IBusinessEntity entity)
        {
            entity.SetValue(AccountGroup.Index.AccountGroupCode, model.AccountGroupCode);
            entity.SetValue(AccountGroup.Index.Description, model.Description);
            entity.SetValue(AccountGroup.Index.Status, model.Status);
            entity.SetValue(AccountGroup.Index.PayablesControlAccount, model.PayablesControlAccount);
            entity.SetValue(AccountGroup.Index.DiscountsAccount, model.DiscountsAccount);
            entity.SetValue(AccountGroup.Index.PrepaymentAccount, model.PrepaymentAccount);
            entity.SetValue(AccountGroup.Index.CurrencyCodeforAccount, model.CurrencyCodeforAccount);
            entity.SetValue(AccountGroup.Index.UnrealizedExchangeGainAccount, model.UnrealizedExchangeGainAccount);
            entity.SetValue(AccountGroup.Index.UnrealizedExchangeLossAccount, model.UnrealizedExchangeLossAccount);
            entity.SetValue(AccountGroup.Index.ExchangeGainAccount, model.ExchangeGainAccount);
            entity.SetValue(AccountGroup.Index.ExchangeLossAccount, model.ExchangeLossAccount);
            entity.SetValue(AccountGroup.Index.RetainageAccount, model.RetainageAccount);
            entity.SetValue(AccountGroup.Index.ExchangeRoundingAccount, model.ExchangeRoundingAccount);


        }
        #endregion
        /// <summary>
        /// Maps the key.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <param name="entity">The entity.</param>
        public override void MapKey(T model, IBusinessEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
