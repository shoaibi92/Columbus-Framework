
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
    /// Class TextAreaExtensions.
    /// </summary>
    public static class TextAreaExtensions
    {

        /// <summary>
        /// To create textarea with knockout binding
        /// </summary>
        /// <typeparam name="TModel">The type of the t model.</typeparam>
        /// <typeparam name="TProperty">The type of the t property.</typeparam>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="expression">The expression.</param>
        /// <param name="koAttributes">The ko attributes.</param>
        /// <param name="htmlAttributes">The HTML attributes.</param>
        /// <returns>MvcHtmlString.</returns>
        public static MvcHtmlString KoSageTextAreaFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, TProperty>> expression, object koAttributes, object htmlAttributes = null)
        {
            return TextAreaHelperFor(htmlHelper, expression, string.Empty, koAttributes, htmlAttributes);
        }

        
        /// <summary>
        /// Create textarea tag
        /// </summary>
        /// <typeparam name="TModel">The type of the t model.</typeparam>
        /// <typeparam name="TProperty">The type of the t property.</typeparam>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="expression">The expression.</param>
        /// <param name="format">The format.</param>
        /// <param name="koAttributes">The ko attributes.</param>
        /// <param name="htmlAttributes">The HTML attributes.</param>
        /// <returns>MvcHtmlString.</returns>
        private static MvcHtmlString TextAreaHelperFor<TModel, TProperty>(HtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, TProperty>> expression, string format, object koAttributes = null,
            object htmlAttributes = null)
        {
            var metadata = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData);
            var htmlDictionary = HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes);
            var koDictionary = HtmlHelper.AnonymousObjectToHtmlAttributes(koAttributes);
            var sanitizedName = TagBuilder.CreateSanitizedId(ExpressionHelper.GetExpressionText(expression));

            CommonExtensions.CustomizedDictionary(ControlType.Textarea, htmlHelper, sanitizedName, htmlDictionary, koDictionary, metadata);
           
            if (koDictionary.Count > 0)
            {
                var databind = CommonExtensions.GetKoBindings(koDictionary);
                htmlDictionary.Add("data-bind", databind);
            }
            htmlDictionary.Add("data-sage300uicontrol", "type:" + ControlType.Textarea.ToString() + ",name:" + sanitizedName);
            return htmlHelper.TextAreaFor(expression, htmlDictionary);
        }
        
    }
}
