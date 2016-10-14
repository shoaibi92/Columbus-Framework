/* Copyright (c) 1994-2015 Sage Software, Inc.  All rights reserved. */

using Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Repository;
using Sage.CA.SBS.ERP.Sage300.Common.Models.Revaluation;

namespace Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Revaluation.BusinessRepository
{
    /// <summary>
    /// Base Revaluation Processing Repository interface
    /// </summary>
    /// <typeparam name="T">Revaluation processing model type</typeparam>
    public interface IBaseRevaluationProcessEntity<T> : IProcessingRepository<T>
        where T : RevaluationProcess, new()
    {
    }
}
