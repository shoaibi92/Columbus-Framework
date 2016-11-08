/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

#region

using Sage.CA.SBS.ERP.Sage300.Common.Models.Customization;
using System;
using System.Linq.Expressions;
using System.Web.Mvc;
using System.Web.Mvc.Html;

#endregion

namespace Sage.CA.SBS.ERP.Sage300.Common.Web.HtmlHelperExtension
{
    /// <summary>
    /// Class CheckboxExtensions.
    /// </summary>
    public static class CheckboxExtensions
    {
        #region Public Methods

        /// <summary>
        /// To create checkbox
        /// </summary>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="name">The name.</param>
        /// <param name="htmlAttributes">The HTML attributes.</param>
        /// <returns>MvcHtmlString.</returns>
        public static MvcHtmlString SageCheckBox(this HtmlHelper htmlHelper, string name, object htmlAttributes = null)
        {
            return CheckBoxHelper(htmlHelper, name, false, null, htmlAttributes);
        }

        /// <summary>
        /// To create checkbox
        /// </summary>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="name">The name.</param>
        /// <param name="isChecked">if set to <c>true</c> [is checked].</param>
        /// <param name="htmlAttributes">The HTML attributes.</param>
        /// <returns>MvcHtmlString.</returns>
        public static MvcHtmlString SageCheckBox(this HtmlHelper htmlHelper, string name, bool isChecked,
            object htmlAttributes = null)
        {
            return CheckBoxHelper(htmlHelper, name, isChecked, null, htmlAttributes);
        }

        /// <summary>
        /// To create checkbox
        /// </summary>
        /// <typeparam name="TModel">The type of the t model.</typeparam>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="expression">The expression.</param>
        /// <param name="htmlAttributes">The HTML attributes.</param>
        /// <returns>MvcHtmlString.</returns>
        public static MvcHtmlString SageCheckBoxFor<TModel>(this HtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, bool>> expression, object htmlAttributes = null)
        {
            return CheckBoxHelperFor(htmlHelper, expression, null, htmlAttributes);
        }

        /// <summary>
        /// To create checkbox with knockout binding
        /// </summary>
        /// <typeparam name="TModel">The type of the t model.</typeparam>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="expression">The expression.</param>
        /// <param name="koAttributes">The ko attributes.</param>
        /// <param name="htmlAttributes">The HTML attributes.</param>
        /// <returns>MvcHtmlString.</returns>
        public static MvcHtmlString KoSageCheckBoxFor<TModel>(this HtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, bool>> expression, object koAttributes, object htmlAttributes = null)
        {
            return CheckBoxHelperFor(htmlHelper, expression, koAttributes, htmlAttributes);
        }

        /// <summary>
        /// Koes the sage CheckBox.
        /// </summary>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="name">The name.</param>
        /// <param name="isChecked">if set to <c>true</c> [is checked].</param>
        /// <param name="koAttributes">The ko attributes.</param>
        /// <param name="htmlAttributes">The HTML attributes.</param>
        /// <returns>MvcHtmlString.</returns>
        public static MvcHtmlString KoSageCheckBox(this HtmlHelper htmlHelper, string name, bool isChecked,
            object koAttributes, object htmlAttributes)
        {
            return CheckBoxHelper(htmlHelper, name, isChecked, koAttributes, htmlAttributes);
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// CheckBoxes the helper.
        /// </summary>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="name">The name.</param>
        /// <param name="isChecked">if set to <c>true</c> [is checked].</param>
        /// <param name="koAttributes">The ko attributes.</param>
        /// <param name="htmlAttributes">The HTML attributes.</param>
        /// <returns>MvcHtmlString.</returns>
        private static MvcHtmlString CheckBoxHelper(this HtmlHelper htmlHelper, string name, bool isChecked,
            object koAttributes, object htmlAttributes)
        {
            var htmlDictionary = HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes);
            var koDictionary = HtmlHelper.AnonymousObjectToHtmlAttributes(koAttributes);
            
            var sanitizedName = TagBuilder.CreateSanitizedId(name);
            var controlProperties = "data-sage300uicontrol=\"type:" + ControlType.Checkbox.ToString() + ",name:" + sanitizedName + "\"";

            var control = CommonExtensions.CustomizedDictionary(ControlType.Checkbox, htmlHelper, sanitizedName, htmlDictionary,
                koDictionary);
            
            if (koDictionary.Count > 0)
            {
                var databind = CommonExtensions.GetKoBindings(koDictionary);
                htmlDictionary.Add("data-bind", databind);
            }
            var html = htmlHelper.CheckBox(name, isChecked, htmlDictionary);
            return MvcHtmlString.Create(GetSpan(control, controlProperties, html.ToHtmlString()));
        }

        /// <summary>
        /// CheckBoxes the helper for.
        /// </summary>
        /// <typeparam name="TModel">The type of the t model.</typeparam>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="expression">The expression.</param>
        /// <param name="koAttributes">The ko attributes.</param>
        /// <param name="htmlAttributes">The HTML attributes.</param>
        /// <returns>MvcHtmlString.</returns>
        private static MvcHtmlString CheckBoxHelperFor<TModel>(HtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, bool>> expression, object koAttributes = null, object htmlAttributes = null)
        {
            var metadata = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData);
            var htmlDictionary = HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes);
            var koDictionary = HtmlHelper.AnonymousObjectToHtmlAttributes(koAttributes);

            var sanitizedName = TagBuilder.CreateSanitizedId(ExpressionHelper.GetExpressionText(expression));
            
            var controlProperties = "data-sage300uicontrol=\"type:" + ControlType.Checkbox.ToString() + ",name:" + sanitizedName+"\"";
            
            var control = CommonExtensions.CustomizedDictionary(ControlType.Checkbox, htmlHelper,
                sanitizedName, htmlDictionary, koDictionary, metadata);

            if (koDictionary.Count > 0)
            {
                var databind = CommonExtensions.GetKoBindings(koDictionary);
                htmlDictionary.Add("data-bind", databind);
            }

            return
                MvcHtmlString.Create(GetSpan(control, controlProperties, htmlHelper.CheckBoxFor(expression, htmlDictionary).ToHtmlString()));
            
        }

        /// <summary>
        /// Get span for checkbox
        /// </summary>
        /// <param name="control"></param>
        /// <param name="controlProperties">sage 300 ui properties</param>
        /// <param name="html"></param>
        /// <returns></returns>
        private static string GetSpan(Control control, string controlProperties, string html)
        {
            return string.Format(@"<span class=""icon checkBox"" {0} {1} > {2} </span>", controlProperties, (control != null && control.Hide) ? "style=\"display:none\"" : "", html);
        }

        #endregion
    }
}