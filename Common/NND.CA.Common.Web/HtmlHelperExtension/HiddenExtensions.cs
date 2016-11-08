/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

#region

using System;
using System.Linq.Expressions;
using System.Web.Mvc;
using System.Web.Mvc.Html;

#endregion

namespace Sage.CA.SBS.ERP.Sage300.Common.Web.HtmlHelperExtension
{
    /// <summary>
    /// Class HiddenExtensions.
    /// </summary>
    public static class HiddenExtensions
    {
        /// <summary>
        /// To create simple hidden field
        /// </summary>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="name">The name.</param>
        /// <param name="htmlAttributes">The HTML attributes.</param>
        /// <returns>MvcHtmlString.</returns>
        public static MvcHtmlString SageHidden(this HtmlHelper htmlHelper, string name, object htmlAttributes = null)
        {
            return htmlHelper.Hidden(name, htmlAttributes);
        }

        /// <summary>
        /// To create model binded hidden field
        /// </summary>
        /// <typeparam name="TModel">The type of the t model.</typeparam>
        /// <typeparam name="TProperty">Model property.</typeparam>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="expression">The expression.</param>
        /// <param name="htmlAttributes">The HTML attributes.</param>
        /// <returns>MvcHtmlString.</returns>
        public static MvcHtmlString SageHiddenFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, TProperty>> expression, object htmlAttributes = null)
        {
            return htmlHelper.HiddenFor(expression, htmlAttributes);
        }
    }
}