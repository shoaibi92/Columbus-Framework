/* Copyright (c) 1994-2015 Sage Software, Inc.  All rights reserved. */

using Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Process;
using Sage.CA.SBS.ERP.Sage300.Common.Models.Revaluation;

namespace Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Revaluation.Service
{
    /// <summary>
    /// Base Revaluation Processing Service interface
    /// </summary>
    /// <typeparam name="T">Revaluation Processing model type</typeparam>
    public interface IBaseRevaluationProcessService<T> : IProcessService<T>
        where T : RevaluationProcess, new()
    {
    }
}
