﻿using NND.CA.Common.Model;

using NND.CA.DV.Services;
    namespace NND.CA.Common.Web.ServicesCommon
{
    public abstract class BaseClassService<T>
    {

        #region Constructor

        /// <summary>
        ///     Constructor
        /// </summary>
        /// <param name="baseModelContext"></param>
        protected BaseClassService(BaseModelContext baseModelContext)
        {
            BaseModelContextInBaseClassAtFlasService = baseModelContext;
        }

        #endregion

        ///// <summary>

        #region Private Members 

        /// <summary>
        ///     IsReadOnly property - opens business entity in readonly mode
        /// </summary>
        public bool IsReadOnly { get; set; }

        /// <summary>
        ///     Gets or sets Context
        /// </summary>
        /// <value>The context.</value>
        protected BaseModelContext BaseModelContextInBaseClassAtFlasService { get; private set; }

        #endregion
        
    }
}