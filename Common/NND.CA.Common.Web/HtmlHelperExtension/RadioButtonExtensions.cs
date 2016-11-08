/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

#region

using System;
using System.Linq.Expressions;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using Sage.CA.SBS.ERP.Sage300.Common.Models.Customization;

#endregion

namespace Sage.CA.SBS.ERP.Sage300.Common.Web.HtmlHelperExtension
{
    /// <summary>
    /// Class RadioButtonExtensions.
    /// </summary>
    public static class RadioButtonExtensions
    {
        /// <summary>
        /// To Create Radio button
        /// </summary>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="name">The name.</param>
        /// <param name="value">The value.</param>
        /// <param name="htmlAttributes">The HTML attributes.</param>
        /// <returns>MvcHtmlString.</returns>
        public static MvcHtmlString SageRadioButton(this HtmlHelper htmlHelper, string name, object value,
            object htmlAttributes = null)
        {
            return
                MvcHtmlString.Create(string.Format("{0}{1}{2}", "<span class='icon radioBox'>",
                    htmlHelper.RadioButton(name, value, false, htmlAttributes).ToHtmlString(), "</span>"));
        }

        /// <summary>
        /// To Create Radio button (Overloaded method)
        /// </summary>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="name">The name.</param>
        /// <param name="value">The value.</param>
        /// <param name="isChecked">if set to <c>true</c> [is checked].</param>
        /// <param name="htmlAttributes">The HTML attributes.</param>
        /// <returns>MvcHtmlString.</returns>
        public static MvcHtmlString SageRadioButton(this HtmlHelper htmlHelper, string name, object value,
            bool isChecked = false, object htmlAttributes = null)
        {
            return
                MvcHtmlString.Create(string.Format("{0}{1}{2}", "<span class='icon radioBox'>",
                    htmlHelper.RadioButton(name, value, isChecked, htmlAttributes).ToHtmlString(), "</span>"));
        }

        /// <summary>
        /// To create radiobutton
        /// </summary>
        /// <typeparam name="TModel">The type of the t model.</typeparam>
        /// <typeparam name="TProperty">The type of the t property.</typeparam>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="expression">The expression.</param>
        /// <param name="value">The value.</param>
        /// <param name="htmlAttributes">The HTML attributes.</param>
        /// <returns>MvcHtmlString.</returns>
        public static MvcHtmlString SageRadioButtonFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, TProperty>> expression, object value, object htmlAttributes = null)
        {
            return
                MvcHtmlString.Create(string.Format("{0}{1}{2}", "<span class='icon radioBox'>",
                    htmlHelper.RadioButtonFor(expression, value, htmlAttributes).ToHtmlString(), "</span>"));
        }

        /// <summary>
        /// To create radiobutton with knockout binding
        /// </summary>
        /// <typeparam name="TModel">The type of the t model.</typeparam>
        /// <typeparam name="TProperty">The type of the t property.</typeparam>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="expression">The expression.</param>
        /// <param name="value">The value.</param>
        /// <param name="koAttributes">The ko attributes.</param>
        /// <param name="htmlAttributes">The HTML attributes.</param>
        /// <returns>MvcHtmlString.</returns>
        public static MvcHtmlString KoSageRadioButtonFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, TProperty>> expression, object value, object koAttributes,
            object htmlAttributes = null)
        {
            return RadioButtonHelperFor(htmlHelper, expression, value, koAttributes, htmlAttributes);
        }


        /// <summary>
        /// To create radiobutton with knockout binding
        /// </summary>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="name">The name.</param>
        /// <param name="value">The name.</param>
        /// <param name="koAttributes">The ko attributes.</param>
        /// <param name="htmlAttributes">The HTML attributes.</param>
        /// <returns>MvcHtmlString.</returns>
        public static MvcHtmlString KoSageRadioButton(this HtmlHelper htmlHelper, string name,int value, object koAttributes,
            object htmlAttributes = null)
        {
            return RadioButtonHelper(htmlHelper, name, value, string.Empty, koAttributes, htmlAttributes);
        }
        /// <summary>
        /// Helper to create radiobutton with knockout binding
        /// </summary>
        /// <typeparam name="TModel">The type of the t model.</typeparam>
        /// <typeparam name="TProperty">The type of the t property.</typeparam>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="expression">The expression.</param>
        /// <param name="value">The value.</param>
        /// <param name="koAttributes">The ko attributes.</param>
        /// <param name="htmlAttributes">The HTML attributes.</param>
        /// <returns>MvcHtmlString.</returns>
        private static MvcHtmlString RadioButtonHelperFor<TModel, TProperty>(HtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, TProperty>> expression, object value, object koAttributes = null,
            object htmlAttributes = null)
        {
            var metadata = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData);
            var htmlDictionary = HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes);
            var koDictionary = HtmlHelper.AnonymousObjectToHtmlAttributes(koAttributes);
            var sanitizedName = TagBuilder.CreateSanitizedId(ExpressionHelper.GetExpressionText(expression));
            var controlProperties = "data-sage300uicontrol=\"type:" + ControlType.Radio.ToString() + ",name:" + sanitizedName + "\"";

            var control = CommonExtensions.CustomizedDictionary(ControlType.Radio, htmlHelper, sanitizedName, htmlDictionary, koDictionary, metadata);
            if (koDictionary.Count > 0)
            {
                var databind = CommonExtensions.GetKoBindings(koDictionary);
                htmlDictionary.Add("data-bind", databind);
            }
            return
                MvcHtmlString.Create(GetSpan(control, controlProperties,
                    htmlHelper.RadioButtonFor(expression, value, htmlDictionary).ToHtmlString()));
        }

        /// <summary>
        /// To create radiobutton
        /// </summary>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="name">The name.</param>
        /// <param name="value">The value.</param>
        /// <param name="format">The format.</param>
        /// <param name="koAttributes">The ko attributes.</param>
        /// <param name="htmlAttributes">The HTML attributes.</param>
        /// <returns>MvcHtmlString.</returns>
        private static MvcHtmlString RadioButtonHelper(HtmlHelper htmlHelper, string name, object value, string format,
            object koAttributes, object htmlAttributes)
        {
            var koDictionary = HtmlHelper.AnonymousObjectToHtmlAttributes(koAttributes);
            var htmlDictionary = HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes);
            var sanitizedName = TagBuilder.CreateSanitizedId(name);
            var controlProperties = "data-sage300uicontrol=\"type:" + ControlType.Radio.ToString() + ",name:" + sanitizedName + "\"";

            var control = CommonExtensions.CustomizedDictionary(ControlType.Radio, htmlHelper, sanitizedName, htmlDictionary, koDictionary);
            if (koDictionary.Count > 0)
            {
                var databind = CommonExtensions.GetKoBindings(koDictionary);
                htmlDictionary.Add("data-bind", databind);
            }
            return MvcHtmlString.Create(GetSpan(control, controlProperties, htmlHelper.RadioButton(name, value, htmlDictionary).ToHtmlString()));
        }
        /// <summary>
        /// Get span for radio
        /// </summary>
        /// <param name="control"></param>
        /// <param name="controlProperties">sage 300 ui properties</param>
        /// <param name="html"></param>
        /// <returns></returns>
        private static string GetSpan(Control control, string controlProperties, string html)
        {
            return string.Format(@"<span class=""icon radioBox"" {0} {1} > {2} </span>", controlProperties, (control != null && control.Hide) ? "style=\"display:none\"" : "", html);
        }
    }
}