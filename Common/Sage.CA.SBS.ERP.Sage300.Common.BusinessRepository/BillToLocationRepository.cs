// Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved.

#region Namespace

using ACCPAC.Advantage;
using Sage.CA.SBS.ERP.Sage300.Common.BusinessRepository.Base;
using Sage.CA.SBS.ERP.Sage300.Common.BusinessRepository.Mapper;
using Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Entity;
using Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Repository;
using Sage.CA.SBS.ERP.Sage300.Common.Models;
using System;
using System.Linq.Expressions;

#endregion

namespace Sage.CA.SBS.ERP.Sage300.Common.BusinessRepository
{
    public class BillToLocationRepository<T> : FlatRepository<T>, ICommonBillToLocationEntity<T> where T : BillToLocation, new()
    {
        #region Private Properties
        
        #endregion
        /// <summary>
        /// ActiveFilter Condition
        /// </summary>
        static private Expression<Func<T, Boolean>> ActiveFilter
        {
            get
            {
                return null;
            }
        }

         #region Constructors

        /// <summary>
        /// BillToLocation repository constructor
        /// </summary>
        /// <param name="context">Context</param>
        /// <param name="dbLinkType">DBLinkType</param>
      public BillToLocationRepository(Context context, DBLinkType dbLinkType)
            : base(context, dbLinkType)
        {
            
        }

      /// <summary>
      /// Constructor for BillToLocation Repository to open view
      /// </summary>
      /// <param name="context">Context</param>
        public BillToLocationRepository(Context context)
          : base(context, new BillToLocationMapper<T>(context), ActiveFilter)
        {
            
        }

        /// <summary>
        /// Constructor for BillToLocation Repository to open view
        /// </summary>
        /// <param name="context">context</param>
        /// <param name="session">Session</param>
        public BillToLocationRepository(Context context, IBusinessEntitySession session)
            : base(context, new BillToLocationMapper<T>(context), ActiveFilter, session)
        {
        } 

        #endregion

        /// <summary>
        /// Compose the entity for Cost
        /// </summary>
        /// <returns></returns>
        protected override IBusinessEntity CreateBusinessEntities()
        {
            return null;
        }
        /// <summary>
        /// GetUpdateExpression
        /// </summary>
        /// <param name="model">Model</param>
        /// <returns>Expression</returns>
        protected override Expression<Func<T, Boolean>> GetUpdateExpression(T model)
        {
            return null;
        }

        /// <summary>
        /// Sets Bill To Location Attributes
        /// </summary>
        /// <param name="model">Bill To Location Model</param>
        /// <param name="_headerEntity">Header Business Entity</param>
        /// <returns>Bill To Location Model</returns>
        public BillToLocation SetValue(BillToLocation model, IBusinessEntity _headerEntity)
        {
                _headerEntity.SetValue(BillToLocation.Fields.BillToLocationDescription, model.BillToLocationDescription, true);
                _headerEntity.SetValue(BillToLocation.Fields.BillToAddress1, model.BillToAddress1, true);
                _headerEntity.SetValue(BillToLocation.Fields.BillToAddress2, model.BillToAddress2, true);
                _headerEntity.SetValue(BillToLocation.Fields.BillToAddress3, model.BillToAddress3, true);
                _headerEntity.SetValue(BillToLocation.Fields.BillToAddress4, model.BillToAddress4, true);
                _headerEntity.SetValue(BillToLocation.Fields.BillToCity, model.BillToCity, true);
                _headerEntity.SetValue(BillToLocation.Fields.BillToStateProvince, model.BillToStateProvince, true);
                _headerEntity.SetValue(BillToLocation.Fields.BillToZipPostalCode, model.BillToZipPostalCode, true);
                _headerEntity.SetValue(BillToLocation.Fields.BillToCountry, model.BillToCountry, true);
                _headerEntity.SetValue(BillToLocation.Fields.BillToPhoneNumber, model.BillToPhoneNumber, true);
                _headerEntity.SetValue(BillToLocation.Fields.BillToFaxNumber, model.BillToFaxNumber, true);
                _headerEntity.SetValue(BillToLocation.Fields.BillToEmail, model.BillToEmail, true);
                _headerEntity.SetValue(BillToLocation.Fields.BillToContact, model.BillToContact, true);
                _headerEntity.SetValue(BillToLocation.Fields.BillToContactPhone, model.BillToContactPhone, true);
                _headerEntity.SetValue(BillToLocation.Fields.BillToContactFax, model.BillToContactFax, true);
                _headerEntity.SetValue(BillToLocation.Fields.BillToContactEmail, model.BillToContactEmail, true);
            return null;
        }
    }
}
