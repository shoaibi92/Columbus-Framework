/* Copyright (c) 1994-2015 Sage Software, Inc.  All rights reserved. */

using Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Service;
using Sage.CA.SBS.ERP.Sage300.Common.Models.Revaluation;

namespace Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Revaluation.Service
{
    /// <summary>
    /// Base Revaluation History Service interface
    /// </summary>
    /// <typeparam name="T">Revaluation History model type</typeparam>
    public interface IBaseRevaluationHistoryService<T> : IEntityService<T>, ISecurityService 
        where T : RevaluationHistory, new()
    {
    }
}
