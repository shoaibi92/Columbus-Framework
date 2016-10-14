using System;
using System.Linq.Expressions;
using Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Entity;
using Sage.CA.SBS.ERP.Sage300.Common.Models;
using Sage.CA.SBS.ERP.Sage300.Common.Models.InvoiceEntry;

namespace Sage.CA.SBS.ERP.Sage300.Common.BusinessRepository.Utilities
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TBatch"></typeparam>
    /// <typeparam name="THeader"></typeparam>
    /// <typeparam name="TDetail"></typeparam>
    /// <typeparam name="TPayment"></typeparam>
    /// <typeparam name="TOptional"></typeparam>
    public class BaseInvoiceEntryBusinessSet<TBatch, THeader, TDetail, TPayment,TOptional> : BatchHeaderDetailBusinessEntitySet<TBatch, THeader, TDetail>
        where TBatch : ModelBase, new()
        where THeader : ModelBase, new()
        where TDetail : ModelBase, new()
        where TPayment : ModelBase, new()
        where TOptional : ModelBase, new()
    {
        /// <summary>
        /// Gets or sets the batch business entity.
        /// </summary>
        /// <value>The batch business entity.</value>
        public IBusinessEntity PaymentBusinessEntity { get; set; }

        /// <summary>
        /// Gets or sets the batch filter.
        /// </summary>
        /// <value>The batch filter.</value>
        public Expression<Func<TPayment, bool>> PaymentFilter { get; set; }

        /// <summary>
        /// Gets or sets the batch mapper.
        /// </summary>
        /// <value>The batch mapper.</value>
        public ModelMapper<TPayment> PaymentMapper { get; set; }

        /// <summary>
        /// Gets or sets the batch business entity.
        /// </summary>
        /// <value>The batch business entity.</value>
        public IBusinessEntity OptionalBusinessEntity { get; set; }

        /// <summary>
        /// Gets or sets the batch filter.
        /// </summary>
        /// <value>The batch filter.</value>
        public Expression<Func<TOptional, bool>> OptionalFilter { get; set; }

        /// <summary>
        /// Gets or sets the batch mapper.
        /// </summary>
        /// <value>The batch mapper.</value>
        public ModelMapper<TOptional> OptionalMapper { get; set; }

        /// <summary>
        /// Gets or sets the detail optional field business entity.
        /// </summary>
        /// <value>The batch business entity.</value>
        public IBusinessEntity DetailOptionalBusinessEntity { get; set; }

        /// <summary>
        /// Gets or sets the detail optional field filter.
        /// </summary>
        /// <value>The batch filter.</value>
        public Expression<Func<TOptional, bool>> DetailOptionalFilter { get; set; }

        /// <summary>
        /// Gets or sets the InvoiceHeaderMapper.
        /// </summary>
        /// <value>The header mapper.</value>
        public ModelMapper<BaseInvoice> InvoiceHeaderMapper { get; set; }

        /// <summary>
        /// Gets or sets the InvoiceDetailMapper.
        /// </summary>
        /// <value>The detail mapper.</value>
        public ModelMapper<BaseInvoiceDetail> InvoiceDetailMapper { get; set; }

        /// <summary>
        /// Gets or sets the InvoiceHeaderOptFldMapper.
        /// </summary>
        /// <value>The invoice optional field mapper.</value>
        public ModelMapper<BaseInvoiceOptionalField> InvoiceOptFldMapper { get; set; }

        /// <summary>
        /// Gets or sets the InvoiceDetailOptFldMapper.
        /// </summary>
        /// <value>The invoice optional field mapper.</value>
        public ModelMapper<BaseInvoiceOptionalField> InvoiceDetailOptFldMapper { get; set; }

     
    }
}
