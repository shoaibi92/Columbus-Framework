// Copyright (c) 1994-2015 Sage Software, Inc.  All rights reserved.

using System;
using System.Collections.Generic;
using Sage.CA.SBS.ERP.Sage300.Common.Models;
using Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Entity;
using Sage.CA.SBS.ERP.Sage300.Common.Models.Enums.Revaluation;
using Sage.CA.SBS.ERP.Sage300.Common.Models.Revaluation;
using Sage.CA.SBS.ERP.Sage300.Common.Utilities;

namespace Sage.CA.SBS.ERP.Sage300.Common.BusinessRepository.Revaluation.Mappers
{
    /// <summary>
    /// Mapper for Revaluation entity (composite business view - Revaluation and Revaluation optional fields)
    /// </summary>
    /// <typeparam name="T">Revaluation model type</typeparam>
    public class RevaluationCompositeMapper<T> : ModelHierarchyMapper<T>
        where T: RevaluationEntry, new()
    {
        #region Private Properties

        /// <summary>
        /// Gets or sets Context.
        /// </summary>
        private Context Context { get; set; }

        /// <summary>
        /// Header mapper
        /// </summary>
        private readonly RevaluationEntryMapper<T> _headerMapper;

        /// <summary>
        /// Detail mapper
        /// </summary>
        private readonly RevaluationOptionalFieldMapper<RevaluationOptionalFieldValue> _detailMapper;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="RevaluationCompositeMapper{T}"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public RevaluationCompositeMapper(Context context)
        {
            Context = context;

            _headerMapper = new RevaluationEntryMapper<T>(Context, UpdateTarget.All);
            _detailMapper = new RevaluationOptionalFieldMapper<RevaluationOptionalFieldValue>(Context);
        }

        #endregion

        #region IModelMapper methods

        /// <summary>
        /// Maps model to the Business View
        /// </summary>
        /// <param name="model"></param>
        /// <param name="entity"></param>
        public override void Map(T model, List<IBusinessEntity> entity)
        {
            _headerMapper.Map(model, entity[0]);
        }

        /// <summary>
        /// Maps the Business View to model
        /// </summary>
        /// <param name="entities">Entites</param>
        /// <param name="detailPageNumber">Current page number for detail records</param>
        /// <param name="detailPageSize">Current page size for detail records</param>
        /// <param name="filterCount">Number of filtered details</param>
        /// <returns>Revaluaiton</returns>
        public override T Map(List<IBusinessEntity> entities, int? detailPageNumber = null, int? detailPageSize = null, int? filterCount = null)
        {
            var model = _headerMapper.Map(entities[0]);
            model.OptionalFields = new EnumerableResponse<RevaluationOptionalFieldValue>();
            int totalRecords;
            var optionalFieldValues = new List<RevaluationOptionalFieldValue>();
            var startIndex = CommonUtil.ComputeStartIndex(detailPageNumber, detailPageSize);
            var endIndex = CommonUtil.ComputeEndIndex(detailPageNumber, detailPageSize, filterCount);
            var counter = 1;

            if (detailPageNumber.HasValue && detailPageSize.HasValue)
            {
                do
                {
                    if (counter >= startIndex)
                    {
                        var optionalFieldLineItem = _detailMapper.Map(entities[1]);
                        if (!String.IsNullOrEmpty(optionalFieldLineItem.OptionalField))
                            optionalFieldValues.Add(optionalFieldLineItem);
                    }
                    counter++;
                } while (counter <= endIndex && entities[1].Next());
                totalRecords = filterCount.HasValue ? filterCount.Value : GetTotalRecords((entities[1]));
            }
            else
            {
                //Map the current entity alone if page number is not recurringEntryDetails
                optionalFieldValues.Add(_detailMapper.Map(entities[1]));
                totalRecords = GetTotalRecords((entities[1]));
            }
            model.OptionalFields.Items = optionalFieldValues;
            model.OptionalFields.TotalResultsCount = totalRecords;
            return model;
        }

        /// <summary>
        /// Returns the total number of records.
        /// </summary>
        /// <param name="entity">Business entity for which the record count is to be retrieved</param>
        /// <returns>Total record count</returns>
        private int GetTotalRecords(IBusinessEntity entity)
        {
            var total = 0;
            entity.Top();
            do
            {
                total++;
            } while (entity.Next());
            if (!entity.Exists && total == 1)
            {
                return 0;
            }
            return total;
        }

        #endregion
    }
}
