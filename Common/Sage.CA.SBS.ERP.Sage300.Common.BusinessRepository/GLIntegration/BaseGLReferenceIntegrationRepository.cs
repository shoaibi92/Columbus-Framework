/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */


#region

using System;
using System.Linq;
using ACCPAC.Advantage;
using System.Linq.Expressions;
using System.Collections.Generic;
using Sage.CA.SBS.ERP.Sage300.Common.Models;
using Sage.CA.SBS.ERP.Sage300.Common.Models.Enums;
using Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Entity;
using Sage.CA.SBS.ERP.Sage300.Common.Models.GLIntegration;
using Sage.CA.SBS.ERP.Sage300.Common.BusinessRepository.Base;
using Sage.CA.SBS.ERP.Sage300.Common.BusinessRepository.Mapper;
using Sage.CA.SBS.ERP.Sage300.Common.Models.Enums.GLIntegration;
using Sage.CA.SBS.ERP.Sage300.Common.Interfaces.GLIntegration.BusinessRepository;

#endregion

namespace Sage.CA.SBS.ERP.Sage300.Common.BusinessRepository.GLIntegration
{
    /// <summary>
    /// Class for Base G/L Reference Integration Repository
    /// </summary>
    /// <typeparam name="T">Base G/L Reference Integration</typeparam>
    public abstract class BaseGLReferenceIntegrationRepository<T> : FlatRepository<T>, IBaseGLReferenceIntegrationEntity<T> where T : BaseGLReferenceIntegration, new()
    {

        #region Private variables

        /// <summary>
        /// Base G/L Reference Integration Repository BusinessEntity
        /// </summary>
        private IBusinessEntity _businessEntity;

        /// <summary>
        /// Mapper
        /// </summary>
        private readonly BaseGLReferenceIntegrationMapper<T> _mapper;

        #endregion

        #region Constructor

        /// <summary>
        /// constructor with context,dbLinkType
        /// </summary>
        /// <param name="context">Context</param>
        /// <param name="dbLinkType">DB Link Type</param>
        protected BaseGLReferenceIntegrationRepository(Context context, DBLinkType dbLinkType)
            : base(context, dbLinkType)
        {
        }

        
        /// <summary>
        /// Initializes a new instance of the <see cref="BaseGLReferenceIntegrationRepository{T}"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="dbLinkType">Type of the database link.</param>
        /// <param name="businessEntitySessionParams">The business entity session parameters.</param>
        protected BaseGLReferenceIntegrationRepository(Context context, DBLinkType dbLinkType, BusinessEntitySessionParams businessEntitySessionParams)
            : base(context, dbLinkType, businessEntitySessionParams)
        {
        }

        /// <summary>
        /// constructor with context,mapper,activeFilter
        /// </summary>
        /// <param name="context">Context</param>
        /// <param name="mapper">Base GL Reference Integration Mapper<T/></param>
        /// <param name="activeFilter">Expression<TDelegate/></param>
        /// <param name="businessEntitySessionParams"></param>
        protected BaseGLReferenceIntegrationRepository(Context context, BaseGLReferenceIntegrationMapper<T> mapper, Expression<Func<T, bool>> activeFilter, BusinessEntitySessionParams businessEntitySessionParams)
            : this(context, mapper, activeFilter, ObjectPoolType.Default, businessEntitySessionParams)
        {
          
        }

        /// <summary>
        /// constructor with context,mapper,activeFilter
        /// </summary>
        /// <param name="context">Context</param>
        /// <param name="mapper">Base GL Reference Integration Mapper<T/></param>
        /// <param name="activeFilter">Expression<TDelegate/></param>
        protected BaseGLReferenceIntegrationRepository(Context context, BaseGLReferenceIntegrationMapper<T> mapper, Expression<Func<T, bool>> activeFilter)
            : this(context, mapper, activeFilter, ObjectPoolType.Default, null)
        {

        }

        /// <summary>
        /// constructor with context,mapper,activeFilter,session
        /// </summary>
        /// <param name="context">Context</param>
        /// <param name="mapper">Base GL Reference Integration Mapper<T/></param>
        /// <param name="activeFilter">Expression<TDelegate/></param>
        /// <param name="session">Business Entity Session</param>
        protected BaseGLReferenceIntegrationRepository(Context context, BaseGLReferenceIntegrationMapper<T> mapper, Expression<Func<T, bool>> activeFilter, IBusinessEntitySession session)
            : base(context, mapper, activeFilter, session)
        {
            _mapper = mapper;
        }

        /// <summary>
        /// constructor with context,mapper,activeFilter,session and session pool type
        /// </summary>
        /// <param name="context">Context</param>
        /// <param name="mapper">Base GL Reference Integration Mapper<T/></param>
        /// <param name="activeFilter">Expression<TDelegate/></param>
        /// <param name="sessionPoolType">Session Pool Type</param>
        protected BaseGLReferenceIntegrationRepository(Context context, BaseGLReferenceIntegrationMapper<T> mapper, Expression<Func<T, bool>> activeFilter, ObjectPoolType sessionPoolType)
            : this(context, mapper, activeFilter, sessionPoolType, null)
        {
             
        }

        /// <summary>
        /// constructor with context,mapper,activeFilter,session and session pool type
        /// </summary>
        /// <param name="context">Context</param>
        /// <param name="mapper">Base GL Reference Integration Mapper<T/></param>
        /// <param name="activeFilter">Expression<TDelegate/></param>
        /// <param name="sessionPoolType">Session Pool Type</param>
        /// <param name="businessEntitySessionParams"></param>
        protected BaseGLReferenceIntegrationRepository(Context context, BaseGLReferenceIntegrationMapper<T> mapper, Expression<Func<T, bool>> activeFilter, ObjectPoolType sessionPoolType, BusinessEntitySessionParams businessEntitySessionParams)
            : base(context, mapper, activeFilter, sessionPoolType, businessEntitySessionParams)
        {
            _mapper = mapper;
        }

        #endregion

        #region Public methods

        /// <summary>
        /// Get Reference Details
        /// </summary>
        /// <returns>Enumerable Response (i.e List of Reference Detail)<ReferenceDetail/></returns>
        /// <remarks>
        /// Gets Reference Integration details and transform to ReferenceDetails
        /// </remarks>
        public virtual EnumerableResponse<ReferenceDetail> GetReferences()
        {
            var referenceList = new List<ReferenceDetail>();
            var sourceTransactionTypeList = new List<Dictionary<string, object>>();
            var transactionDetails = GetTransactions();

            if (transactionDetails == null || !transactionDetails.Items.Any())
            {
                return new EnumerableResponse<ReferenceDetail> { Items = new List<ReferenceDetail>(), TotalResultsCount = 0 };
            }

            _businessEntity = CreateBusinessEntities();

            //get persention list, for SourceTransactionType.
            var sourceTransationList =
                    _businessEntity.Fields.FieldByID(BaseGLReferenceIntegration.BaseIndex.SourceTransactionType)
                        .PresentationList;

            for (var increment = 0; increment < sourceTransationList.Count; increment++)
            {
                sourceTransactionTypeList.Add(new Dictionary<string, object>
                    {
                        {"Text", sourceTransationList.PredefinedString(increment)},
                        {"Value",sourceTransationList.PredefinedValue(increment)}
                    });
            }


            //Reading SoureTransactionType from filtered transactionDetail
            foreach (var sourceTransaction in sourceTransactionTypeList)
            {
                //Reading the GL TranssactionFields base on SourceTransactionType
                var transactionItems = transactionDetails.Items.Where(itm => itm.SourceTransactionTypeValue.Equals((short)sourceTransaction["Value"])).ToList();

                var transactionItem = transactionItems.FirstOrDefault();// Get GLTransactionFields and assign to default T
                if (transactionItem != null)
                {
                    // create ReferenceDetail object
                    var referenceDetail = new ReferenceDetail
                    {
                        SourceTransactionType = (short)sourceTransaction["Value"],
                        SourceTransactionTypeList = sourceTransactionTypeList,

                        //init and update default values if GLTransactionField null/empty
                        GLEntryDescription =
                            transactionItems.Where(
                                item => item.GLTransactionField == GLTransactionField.GLEntryDescription)
                                .DefaultIfEmpty(
                                    new BaseGLReferenceIntegration(transactionItem.GLTransactionFields,
                                        GLTransactionField.GLEntryDescription)).Single(),

                        GLDetailReference =
                            transactionItems.Where(
                                item => item.GLTransactionField == GLTransactionField.GLDetailReference).DefaultIfEmpty(
                                    new BaseGLReferenceIntegration(transactionItem.GLTransactionFields,
                                        GLTransactionField.GLDetailReference)).Single(),

                        GLDetailDescription =
                            transactionItems.Where(
                                item => item.GLTransactionField == GLTransactionField.GLDetailDescription)
                                .DefaultIfEmpty(
                                    new BaseGLReferenceIntegration(transactionItem.GLTransactionFields,
                                        GLTransactionField.GLDetailDescription)).Single(),

                        GLDetailComment =
                            transactionItems.Where(item => item.GLTransactionField == GLTransactionField.GLDetailComment)
                                .DefaultIfEmpty(
                                    new BaseGLReferenceIntegration(transactionItem.GLTransactionFields,
                                        GLTransactionField.GLDetailComment)).Single()

                    };

                    referenceList.Add(referenceDetail);
                }
            }

            return new EnumerableResponse<ReferenceDetail>
            {
                Items = referenceList,
                TotalResultsCount = referenceList.Count
            };

        }

        /// <summary>
        /// Save and Post Reference Details
        /// </summary>
        /// <param name="referenceDetails">List of reference detail to be saved</param>
        /// <returns>List of ReferenceDetail/></returns>
        /// <remarks>
        /// Transform to G/L Reference Integration from ReferenceDetail and save.
        /// </remarks>
        public virtual EnumerableResponse<ReferenceDetail> SaveReferences(IEnumerable<ReferenceDetail> referenceDetails)
        {

            if (referenceDetails == null) throw new ArgumentNullException("referenceDetails");

            var referenceList = new List<BaseGLReferenceIntegration>();
            var convertedList = referenceDetails as IList<ReferenceDetail> ?? referenceDetails.ToList();
            bool isReadSuccess;

            _businessEntity = CreateBusinessEntities();

            CheckRights(_businessEntity, SecurityType.Modify);

            foreach (var referenceDetail in convertedList)
            {
                referenceList.Add(referenceDetail.GLEntryDescription);
                referenceList.Add(referenceDetail.GLDetailReference);
                referenceList.Add(referenceDetail.GLDetailDescription);
                referenceList.Add(referenceDetail.GLDetailComment);
            }

            try
            {
                foreach (var referenceDetail in referenceList)
                {
                    if (!referenceDetail.GLTransactionFields.Exists(glField => (int)glField["Value"] == (int)referenceDetail.GLTransactionField))
                    {
                        continue;
                    }

                    _businessEntity.SetValue(BaseGLReferenceIntegration.BaseIndex.SourceTransactionType, referenceDetail.SourceTransactionTypeValue);
                    _businessEntity.SetValue(BaseGLReferenceIntegration.BaseIndex.GLTransactionField, referenceDetail.GLTransactionField);

                    isReadSuccess = _businessEntity.Read(false);

                    if (!isReadSuccess || !_businessEntity.Exists)
                    {
                        continue;
                    }

                    CheckETag(_businessEntity, referenceDetail);
                    //map model fields
                    _mapper.SetReferenceIntegration(referenceDetail, _businessEntity);
                    _businessEntity.Update();
                }

                //post unposted data
                _businessEntity.Post();
            }
            finally
            {
                //Navigates to the first record in the view according to the current browse filter and direction. 
                _businessEntity.Top();
            }

            return GetReferences();
        }


        /// <summary>
        /// Update G/L Reference Integration
        /// </summary>
        /// <param name="model">G/L Reference Integration</param>
        /// <returns>G/L Reference Integration</returns>
        public virtual T UpdateReferenceIntegration(T model)
        {
            _businessEntity = CreateBusinessEntities();
            CheckRights(_businessEntity, SecurityType.Modify);

            try
            {
                _mapper.MapKey(model, _businessEntity);

                var isReadSuccess = _businessEntity.Read(false);
                if (isReadSuccess)
                {
                    _mapper.SetReferenceIntegration(model, _businessEntity);
                    if (_businessEntity.Exists)
                    {
                        CheckETag(_businessEntity, model);
                        _businessEntity.Update();
                    }
                }
            }
            finally
            {
                //Navigates to the first record in the view according to the current browse filter and direction. 
                _businessEntity.Top();
            }
            return model;
        }
        #endregion

        #region Private methods

        /// <summary>
        /// Get G/L Reference Integration along with presentation values
        /// </summary>
        /// <returns>List of G/L Reference Integration</returns>
        /// <remarks>
        /// Gets ReferenceIntegration details and performs presentation list based on source transaction type
        /// </remarks>
        private EnumerableResponse<T> GetTransactions()
        {
            _businessEntity = CreateBusinessEntities();

            EnumerableResponse<T> glReferenceIntegrationList = base.Get();

            //return new list,if glReferenceIntegrationList is null/empty.
            if (glReferenceIntegrationList == null || !glReferenceIntegrationList.Items.Any())
            {
                return new EnumerableResponse<T> { Items = new List<T>(), TotalResultsCount = 0 };
            }

            //perform persention list, based on SourceTransactionType Value.
            foreach (T item in glReferenceIntegrationList.Items)
            {
                _businessEntity.SetValue(BaseGLReferenceIntegration.BaseFields.SourceTransactionType, item.SourceTransactionTypeValue);

                if (!_businessEntity.Read(false)) continue;

                var segmentList =
                    _businessEntity.Fields.FieldByID(BaseGLReferenceIntegration.BaseIndex.IncludedSegment1)
                        .PresentationList;

                var transactionFieldsList =
                   _businessEntity.Fields.FieldByID(BaseGLReferenceIntegration.BaseIndex.GLTransactionField)
                       .PresentationList;

                for (var increment = 0; increment < segmentList.Count; increment++)
                {
                    // PredefinedValue is 0(None) then skip
                    if (segmentList.PredefinedValue(increment).Equals((short)IncludedSegment.None)) continue;

                    item.SegmentList.Add(new Dictionary<string, object>
                    {
                        {"SegmentName" , segmentList.PredefinedString(increment)},
                        {"SegmentValue", segmentList.PredefinedValue(increment)}
                    });
                }


                for (var increment = 0; increment < transactionFieldsList.Count; increment++)
                {
                    item.GLTransactionFields.Add(new Dictionary<string, object>
                    {
                        {"Text", transactionFieldsList.PredefinedString(increment)},
                        {"Value", Convert.ToInt32(transactionFieldsList.PredefinedValue(increment))}
                    });

                }

            }

            //Navigates to the first record in the view according to the current browse filter and direction. 
            _businessEntity.Top();

            return glReferenceIntegrationList;
        }

        #endregion

    }

}
