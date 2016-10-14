// Copyright (c) 1994-2015 Sage Software, Inc.  All rights reserved.

#region Namespace

using Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Entity;
using Sage.CA.SBS.ERP.Sage300.Common.Models;
using Sage.CA.SBS.ERP.Sage300.Common.Models.InvoiceEntry;

#endregion

namespace Sage.CA.SBS.ERP.Sage300.Common.BusinessRepository.Mapper
{
    public abstract class POOEBaseInvoiceEntryMapper<THeader, TDetail1, TDetail2, TDetail3, TDetail4, TDetail5, TDetail6, TDetail7, TDetail8, TDetail9, TDetail10
        , TDetail11, TDetail12, TDetail13, TDetail14, TDetail15> : ModelHierarchyMapper<THeader>
        where THeader : ModelBase, new()
        where TDetail1 : ModelBase, new()
        where TDetail2 : ModelBase, new()
        where TDetail3 : ModelBase, new()
        where TDetail4 : ModelBase, new()
        where TDetail5 : ModelBase, new()
        where TDetail6 : ModelBase, new()
        where TDetail7 : ModelBase, new()
        where TDetail8 : ModelBase, new()
        where TDetail9 : ModelBase, new()
        where TDetail10 : ModelBase, new()
        where TDetail11 : ModelBase, new()
        where TDetail12 : ModelBase, new()
        where TDetail13 : ModelBase, new()
        where TDetail14 : ModelBase, new()
        where TDetail15 : ModelBase, new()
    {
        /// <summary>
        /// Map Optional Field
        /// </summary>
        /// <param name="optionalField">Optional Field</param>
        /// <param name="entity">Entity</param>
        public abstract void MapOptionalField(BaseInvoiceOptionalField optionalField, IBusinessEntity entity);

        /// <summary>
        /// Converts the Header Models Tax Authority Data to List of TaxGroupAuthority
        /// </summary>
        /// <param name="model">BaseInvoiceDetail Model</param>
        /// <param name="headerEntity">Header Entity</param>
        public abstract EnumerableResponse<TaxGroupAuthority> GetDetailTaxAuthority(TDetail1 model, IBusinessEntity headerEntity);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entities"></param>
        /// <param name="detailPageNumber"></param>
        /// <param name="detailPageSize"></param>
        /// <param name="filterCount"></param>
        /// <returns></returns>
        public override THeader Map(System.Collections.Generic.List<IBusinessEntity> entities, int? detailPageNumber = null, int? detailPageSize = null, int? filterCount = null)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <param name="entity"></param>
        public override void Map(THeader model, System.Collections.Generic.List<IBusinessEntity> entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
