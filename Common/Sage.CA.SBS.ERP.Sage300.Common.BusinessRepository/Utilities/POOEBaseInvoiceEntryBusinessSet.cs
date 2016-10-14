using Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Entity;
using Sage.CA.SBS.ERP.Sage300.Common.Models;
using Sage.CA.SBS.ERP.Sage300.Common.Models.InvoiceEntry;
using System;
using System.Linq.Expressions;
using Sage.CA.SBS.ERP.Sage300.Common.Models.POOEInvoiceEntry;

namespace Sage.CA.SBS.ERP.Sage300.Common.BusinessRepository.Utilities
{
    public class POOEBaseInvoiceEntryBusinessSet<THeader, TDetail1, TDetail2, TDetail3, TDetail4, TDetail5, TDetail6, TDetail7, TDetail8, TDetail9, TDetail10
        , TDetail11, TDetail12, TDetail13, TDetail14, TDetail15> : SequencedHeaderDetailFiveBusinessEntitySet<THeader, TDetail1, TDetail2, TDetail3, TDetail4, TDetail5>
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
        /// Gets or sets the comment business entity.
        /// </summary>
        /// <value>The comment business entity.</value>
        public IBusinessEntity CommentBusinessEntity { get; set; }

        /// <summary>
        /// Gets or sets the comment filter.
        /// </summary>
        /// <value>The comment filter.</value>
        public Expression<Func<TDetail2, bool>> CommentFilter { get; set; }

        /// <summary>
        /// Gets or sets the comment mapper.
        /// </summary>
        /// <value>The comment mapper.</value>
        public ModelMapper<TDetail2> CommentMapper { get; set; }

        /// <summary>
        /// Gets or sets the AdditionalCost business entity.
        /// </summary>
        /// <value>The AdditionalCost business entity.</value>
        public IBusinessEntity AdditionalCostBusinessEntity { get; set; }

        /// <summary>
        /// Gets or sets the AdditionalCost filter.
        /// </summary>
        /// <value>The AdditionalCost filter.</value>
        public Expression<Func<TDetail3, bool>> AdditionalCostFilter { get; set; }

        /// <summary>
        /// Gets or sets the AdditionalCost mapper.
        /// </summary>
        /// <value>The AdditionalCost mapper.</value>
        public ModelMapper<TDetail3> AdditionalCostMapper { get; set; }

        /// <summary>
        /// Gets or sets the Payment business entity.
        /// </summary>
        /// <value>The Payment business entity.</value>
        public IBusinessEntity PaymentBusinessEntity { get; set; }

        /// <summary>
        /// Gets or sets the Payment filter.
        /// </summary>
        /// <value>The Payment filter.</value>
        public Expression<Func<TDetail4, bool>> PaymentFilter { get; set; }

        /// <summary>
        /// Gets or sets the Payment mapper.
        /// </summary>
        /// <value>The Payment mapper.</value>
        public ModelMapper<TDetail4> PaymentMapper { get; set; }

        /// <summary>
        /// Gets or sets the Function business entity.
        /// </summary>
        /// <value>The Function business entity.</value>
        public IBusinessEntity FunctionBusinessEntity { get; set; }

        /// <summary>
        /// Gets or sets the Function filter.
        /// </summary>
        /// <value>The Function filter.</value>
        public Expression<Func<TDetail5, bool>> FunctionFilter { get; set; }

        /// <summary>
        /// Gets or sets the Function mapper.
        /// </summary>
        /// <value>The Function mapper.</value>
        public ModelMapper<TDetail5> FunctionMapper { get; set; }

        /// <summary>
        /// Gets or sets the Reciept business entity.
        /// </summary>
        /// <value>The Reciept business entity.</value>
        public IBusinessEntity RecieptsBusinessEntity { get; set; }

        /// <summary>
        /// Gets or sets the Reciept filter.
        /// </summary>
        /// <value>The Reciept filter.</value>
        public Expression<Func<TDetail6, bool>> ReceiptsFilter { get; set; }

        /// <summary>
        /// Gets or sets the Reciept mapper.
        /// </summary>
        /// <value>The Reciept mapper.</value>
        public ModelMapper<TDetail6> RecieptsMapper { get; set; }

        /// <summary>
        /// Gets or sets the CostSuperView business entity.
        /// </summary>
        /// <value>The CostSuperView business entity.</value>
        public IBusinessEntity CostSuperViewBusinessEntity { get; set; }

        /// <summary>
        /// Gets or sets the CostSuperView filter.
        /// </summary>
        /// <value>The CostSuperView filter.</value>
        public Expression<Func<POOEInvBaseAddCostsSuperview, bool>> CostSuperViewFilter { get; set; }

        /// <summary>
        /// Gets or sets the CostSuperView mapper.
        /// </summary>
        /// <value>The CostSuperView mapper.</value>
        public ModelMapper<POOEInvBaseAddCostsSuperview> CostSuperViewMapper { get; set; }

        /// <summary>
        /// Gets or sets the OptionalField business entity.
        /// </summary>
        /// <value>The OptionalField business entity.</value>
        public IBusinessEntity OptionalFieldBusinessEntity { get; set; }

        /// <summary>
        /// Gets or sets the OptionalField filter.
        /// </summary>
        /// <value>The OptionalField filter.</value>
        public Expression<Func<BaseInvoiceOptionalField, bool>> OptionalFieldFilter { get; set; }

        /// <summary>
        /// Gets or sets the OptionalField mapper.
        /// </summary>
        /// <value>The OptionalField mapper.</value>
        public ModelMapper<BaseInvoiceOptionalField> OptionalFieldMapper { get; set; }

        /// <summary>
        /// Gets or sets the DetailOptionalField business entity.
        /// </summary>
        /// <value>The DetailOptionalField business entity.</value>
        public IBusinessEntity DetailOptionalFieldBusinessEntity { get; set; }

        /// <summary>
        /// Gets or sets the DetailOptionalField filter.
        /// </summary>
        /// <value>The DetailOptionalField filter.</value>
        public Expression<Func<BaseInvoiceOptionalField, bool>> DetailOptionalFieldFilter { get; set; }

        /// <summary>
        /// Gets or sets the DetailOptionalField mapper.
        /// </summary>
        /// <value>The DetailOptionalField mapper.</value>
        public ModelMapper<BaseInvoiceOptionalField> DetailOptionalFieldMapper { get; set; }

        /// <summary>
        /// Gets or sets the AdjustmentCost Optional Field business entity.
        /// </summary>
        /// <value>The AdjustmentCost Optional Field business entity.</value>
        public IBusinessEntity AdjCostOptFldBusinessEntity { get; set; }

        /// <summary>
        /// Gets or sets the AdjustmentCost Optional Field filter.
        /// </summary>
        /// <value>The AdjustmentCost Optional Field filter.</value>
        public Expression<Func<TDetail10, bool>> AdjCostOptFldFilter { get; set; }

        /// <summary>
        /// Gets or sets the PostingCost Distribution mapper.
        /// </summary>
        /// <value>The PostingCost Distribution mapper.</value>
        public ModelMapper<TDetail10> AdjCostOptFldMapper { get; set; }

        /// <summary>
        /// Gets or sets the PostingCost Distribution business entity.
        /// </summary>
        /// <value>The PostingCost Distribution business entity.</value>
        public IBusinessEntity PostingCostDistBusinessEntity { get; set; }

        /// <summary>
        /// Gets or sets the AdjustmentCost Optional Field filter.
        /// </summary>
        /// <value>The AdjustmentCost Optional Field filter.</value>
        public Expression<Func<TDetail11, bool>> PostingCostDistFilter { get; set; }

        /// <summary>
        /// Gets or sets the PostingCost Distribution mapper.
        /// </summary>
        /// <value>The PostingCost Distribution mapper.</value>
        public ModelMapper<TDetail11> PostingCostDistMapper { get; set; }

        /// <summary>
        /// Gets or sets the PostingCost Distribution business entity.
        /// </summary>
        /// <value>The PostingCost Distribution business entity.</value>
        public IBusinessEntity CostDistBusinessEntity { get; set; }

        /// <summary>
        /// Gets or sets the PostingCost Distribution Field filter.
        /// </summary>
        /// <value>The PostingCost Distribution Field filter.</value>
        public Expression<Func<TDetail12, bool>> CostDistFilter { get; set; }

        /// <summary>
        /// Gets or sets the PostingCost Distribution mapper.
        /// </summary>
        /// <value>The PostingCost Distribution mapper.</value>
        public ModelMapper<TDetail12> CostDistMapper { get; set; }

        /// <summary>
        /// Gets or sets the Distribution Proration business entity.
        /// </summary>
        /// <value>The Distribution Proration business entity.</value>
        public IBusinessEntity DistProrationBusinessEntity { get; set; }

        /// <summary>
        /// Gets or sets the Distribution Proration filter.
        /// </summary>
        /// <value>The Distribution Proration filter.</value>
        public Expression<Func<TDetail13, bool>> DistProrationFilter { get; set; }

        /// <summary>
        /// Gets or sets the Distribution Proration mapper.
        /// </summary>
        /// <value>The Distribution Proration mapper.</value>
        public ModelMapper<TDetail13> DistProrationMapper { get; set; }

        /// <summary>
        /// Gets or sets the Line Lot business entity.
        /// </summary>
        /// <value>The Line Lot business entity.</value>
        public IBusinessEntity LineLotBusinessEntity { get; set; }

        /// <summary>
        /// Gets or sets the Line Lot filter.
        /// </summary>
        /// <value>The Line Lot filter.</value>
        public Expression<Func<TDetail14, bool>> LineLotFilter { get; set; }

        /// <summary>
        /// Gets or sets the Line Lot mapper.
        /// </summary>
        /// <value>The Line Lot mapper.</value>
        public ModelMapper<TDetail14> LineLotMapper { get; set; }

        /// <summary>
        /// Gets or sets the Line Serial business entity.
        /// </summary>
        /// <value>The Line Serial business entity.</value>
        public IBusinessEntity LineSerialBusinessEntity { get; set; }

        /// <summary>
        /// Gets or sets the Line Serial filter.
        /// </summary>
        /// <value>The Line Serial filter.</value>
        public Expression<Func<TDetail15, bool>> LineSerialFilter { get; set; }

        /// <summary>
        /// Gets or sets the Line Serial mapper.
        /// </summary>
        /// <value>The Line Serial mapper.</value>
        public ModelMapper<TDetail15> LineSerialMapper { get; set; }

        /// <summary>
        /// Gets or sets the Duplicate Invoice Entity.
        /// </summary>
        /// <value>The Duplicate Invoice Entity.</value>
        public IBusinessEntity DuplicateInvoiceEntity { get; set; }

        /// <summary>
        /// Gets or sets the Line Serial mapper.
        /// </summary>
        /// <value>The Line Serial mapper.</value>
        public ModelMapper<POOEBaseInvoiceLine> LineMapper { get; set; }
       
        /// <summary>
        /// Gets or sets the Reciept Mapper
        /// </summary>
        /// <value>The Reciept mapper.</value>
        public ModelMapper<POOEBaseInvoiceReciepts> RecieptMapper { get; set; }
         
        /// <summary>
        /// Gets or sets the Reciept Mapper
        /// </summary>
        /// <value>The Reciept mapper.</value>
        public ModelMapper<POOEBaseInvoiceComments> BaseCommentMapper { get; set; }
       
    }
}
