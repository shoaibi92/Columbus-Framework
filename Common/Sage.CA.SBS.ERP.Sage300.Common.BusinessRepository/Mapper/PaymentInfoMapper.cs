// Copyright (c) 1994-2015 Sage Software, Inc.  All rights reserved.

#region Namespace

using Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Entity;
using Sage.CA.SBS.ERP.Sage300.Common.Models;
using Sage.CA.SBS.ERP.Sage300.Common.Models.Enums;
using System;
using Sage.CA.SBS.ERP.Sage300.Common.Utilities;

#endregion Namespace

namespace Sage.CA.SBS.ERP.Sage300.Common.BusinessRepository.Mappers
{
    /// <summary>
    /// Class for PaymentInfo mapping
    /// </summary>
    public class PaymentInfoMapper<T> : ModelMapper<T> where T : PaymentInfo, new()
    {
        #region Constructor

        /// <summary>
        /// Constructor to set the Context
        /// </summary>
        /// <param name="context">Context</param>
        public PaymentInfoMapper(Context context)
            : base(context)
        {
        }

        #endregion Constructor

        #region IModelMapper methods

        /// <summary>
        /// Get Mapper
        /// </summary>
        /// <param name="entity">Business Entity</param>
        /// <returns>Mapped Model</returns>
        public override T Map(IBusinessEntity entity)
        {
            var model = base.Map(entity);

            model.CustomerNumber = entity.GetValue<string>(PaymentInfo.Index.CustomerNumber);
            model.CardID = entity.GetValue<string>(PaymentInfo.Index.CardID);
            model.CardDescription = entity.GetValue<string>(PaymentInfo.Index.CardDescription);
            model.CardType = EnumUtility.GetEnum<CardType>(entity.GetValue<string>(PaymentInfo.Index.CardType));
            model.ProcessCode = entity.GetValue<string>(PaymentInfo.Index.ProcessCode);
            model.Status = EnumUtility.GetEnum<Status>(entity.GetValue<string>(PaymentInfo.Index.Status));
            model.InactiveDate = DateUtil.GetDate(entity.GetValue<DateTime>(PaymentInfo.Index.InactiveDate), null);
            model.DateLastMaintained = DateUtil.GetDate(entity.GetValue<DateTime>(PaymentInfo.Index.DateLastMaintained), null);
            model.DefaultCard = EnumUtility.GetEnum<DefaultCard>(entity.GetValue<string>(PaymentInfo.Index.DefaultCard));
            model.CardholderName = entity.GetValue<string>(PaymentInfo.Index.CardholderName);
            model.BillingAddressLine1 = entity.GetValue<string>(PaymentInfo.Index.BillingAddressLine1);
            model.BillingAddressLine2 = entity.GetValue<string>(PaymentInfo.Index.BillingAddressLine2);
            model.BillingCity = entity.GetValue<string>(PaymentInfo.Index.BillingCity);
            model.BillingState = entity.GetValue<string>(PaymentInfo.Index.BillingState);
            model.BillingCountry = entity.GetValue<string>(PaymentInfo.Index.BillingCountry);
            model.BillingZipcode = entity.GetValue<string>(PaymentInfo.Index.BillingZipcode);
            model.VaultID = entity.GetValue<string>(PaymentInfo.Index.VaultID);
            model.MaskedCardNumber = entity.GetValue<string>(PaymentInfo.Index.MaskedCardNumber);
            model.Expdate = entity.GetValue<string>(PaymentInfo.Index.Expdate);
            model.Comment = entity.GetValue<string>(PaymentInfo.Index.Comment);
            model.MaskedCreditCardNumber = entity.GetValue<string>(PaymentInfo.Index.MaskedCreditCardNumber);
            model.Vexpdate = entity.GetValue<string>(PaymentInfo.Index.Vexpdate);
            model.TotalAmount = entity.GetValue<decimal>(PaymentInfo.Index.TotalAmount);
            model.TaxAmount = entity.GetValue<decimal>(PaymentInfo.Index.TaxAmount);
            model.SubtotalAmount = entity.GetValue<decimal>(PaymentInfo.Index.SubtotalAmount);
            model.Time = entity.GetValue<string>(PaymentInfo.Index.Time);
            model.AuthorizationCode = entity.GetValue<string>(PaymentInfo.Index.AuthorizationCode);
            model.OneTimeUseSwitch = entity.GetValue<int>(PaymentInfo.Index.OneTimeUseSwitch);
            model.Vproccode = entity.GetValue<int>(PaymentInfo.Index.Vproccode);
            model.ProcessingCommand = EnumUtility.GetEnum<ProcessingCommand>(entity.GetValue<string>(PaymentInfo.Index.ProcessingCommand));
            model.Bankcode = entity.GetValue<string>(PaymentInfo.Index.Bankcode);
            model.CurrencyCode = entity.GetValue<string>(PaymentInfo.Index.CurrencyCode);
            return model;
        }

        /// <summary>
        /// SetValue Mapper
        /// </summary>
        /// <param name="model">Model</param>
        /// <param name="entity">Business Entity</param>
        public override void Map(T model, IBusinessEntity entity)
        {
            if (model == null)
            {
                return;
            }

            entity.SetValue(PaymentInfo.Index.CustomerNumber, model.CustomerNumber);
            entity.SetValue(PaymentInfo.Index.CardID, model.CardID);
            entity.SetValue(PaymentInfo.Index.CardDescription, model.CardDescription);
            entity.SetValue(PaymentInfo.Index.CardType, model.CardType);
            entity.SetValue(PaymentInfo.Index.ProcessCode, model.ProcessCode);
            entity.SetValue(PaymentInfo.Index.DateLastMaintained, model.DateLastMaintained);
            entity.SetValue(PaymentInfo.Index.Status, model.Status);
            entity.SetValue(PaymentInfo.Index.InactiveDate, DateUtil.GetDate(model.InactiveDate, null));
            entity.SetValue(PaymentInfo.Index.DefaultCard, model.DefaultCard, true);
            entity.SetValue(PaymentInfo.Index.CardholderName, model.CardholderName);
            entity.SetValue(PaymentInfo.Index.BillingAddressLine1, model.BillingAddressLine1);
            entity.SetValue(PaymentInfo.Index.BillingAddressLine2, model.BillingAddressLine2);
            entity.SetValue(PaymentInfo.Index.BillingCity, model.BillingCity);
            entity.SetValue(PaymentInfo.Index.BillingState, model.BillingState);
            entity.SetValue(PaymentInfo.Index.BillingCountry, model.BillingCountry);
            entity.SetValue(PaymentInfo.Index.BillingZipcode, model.BillingZipcode);
            entity.SetValue(PaymentInfo.Index.VaultID, model.VaultID);
            entity.SetValue(PaymentInfo.Index.MaskedCardNumber, model.MaskedCardNumber);
            entity.SetValue(PaymentInfo.Index.Expdate, model.Expdate);
            entity.SetValue(PaymentInfo.Index.Comment, model.Comment);
            entity.SetValue(PaymentInfo.Index.MaskedCreditCardNumber, model.MaskedCreditCardNumber);
            entity.SetValue(PaymentInfo.Index.Vexpdate, model.Vexpdate);
            entity.SetValue(PaymentInfo.Index.TotalAmount, model.TotalAmount);
            entity.SetValue(PaymentInfo.Index.TaxAmount, model.TaxAmount);
            entity.SetValue(PaymentInfo.Index.SubtotalAmount, model.SubtotalAmount);
            entity.SetValue(PaymentInfo.Index.Time, model.Time);
            entity.SetValue(PaymentInfo.Index.AuthorizationCode, model.AuthorizationCode);
            entity.SetValue(PaymentInfo.Index.OneTimeUseSwitch, model.OneTimeUseSwitch);
            entity.SetValue(PaymentInfo.Index.Vproccode, model.Vproccode);
            entity.SetValue(PaymentInfo.Index.ProcessingCommand, model.ProcessingCommand);
            entity.SetValue(PaymentInfo.Index.Bankcode, model.Bankcode);
            entity.SetValue(PaymentInfo.Index.CurrencyCode, model.CurrencyCode);
        }

        /// <summary>
        /// Map Key
        /// </summary>
        /// <param name="model">Model</param>
        /// <param name="entity">Business Entity</param>
        /// <exception cref="NotImplementedException"></exception>
        public override void MapKey(T model, IBusinessEntity entity)
        {
            entity.SetValue(PaymentInfo.Index.CustomerNumber, model.CustomerNumber);
            entity.SetValue(PaymentInfo.Index.CardID, model.CardID);
        }

        #endregion IModelMapper methods
    }
}