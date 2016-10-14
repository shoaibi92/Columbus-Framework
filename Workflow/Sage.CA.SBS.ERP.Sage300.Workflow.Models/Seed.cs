/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

using System;
using Sage.CA.SBS.ERP.Sage300.Common.Models;

namespace Sage.CA.SBS.ERP.Sage300.Workflow.Models
{
    /// <summary>
    /// Generic Class Seed - will be used to communicate between web and worker role for tasks (Unit Of Works)
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [Serializable]
    public class Seed<T> where T : ModelBase
    {
        /// <summary>
        /// Generic model
        /// </summary>
        public T Model { get; set; }

        /// <summary>
        /// Context objects (Except container)
        /// </summary>
        public Context Context { get; set; }
    }
}
