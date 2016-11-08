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
    /// Class TextboxExtensions.
    /// </summary>
    public static class TextboxExtensions
    {
        /// <summary>
        /// To create textbox
        /// </summary>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="name">The name.</param>
        /// <param name="value">The value.</param>
        /// <param name="format">The format.</param>
        /// <param name="htmlAttributes">The HTML attributes.</param>
        /// <returns>MvcHtmlString.</returns>
        public static MvcHtmlString SageTextBox(this HtmlHelper htmlHelper, string name, object value, string format,
            object htmlAttributes = null)
        {
            return TextBoxHelper(htmlHelper, name, value, format, null, htmlAttributes);
        }

        /// <summary>
        /// To create textbox
        /// </summary>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="name">The name.</param>
        /// <param name="value">The value.</param>
        /// <param name="htmlAttributes">The HTML attributes.</param>
        /// <returns>MvcHtmlString.</returns>
        public static MvcHtmlString SageTextBox(this HtmlHelper htmlHelper, string name, object value,
            object htmlAttributes = null)
        {
            return htmlHelper.SageTextBox(name, value, string.Empty, htmlAttributes);
        }

        /// <summary>
        /// To create textbox
        /// </summary>
        /// <typeparam name="TModel">The type of the t model.</typeparam>
        /// <typeparam name="TProperty">The type of the t property.</typeparam>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="expression">The expression.</param>
        /// <param name="htmlAttributes">The HTML attributes.</param>
        /// <returns>MvcHtmlString.</returns>
        public static MvcHtmlString SageTextBoxFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, TProperty>> expression, object htmlAttributes = null)
        {
            return htmlHelper.SageTextBoxFor(expression, string.Empty, htmlAttributes);
        }

        /// <summary>
        /// To create textbox
        /// </summary>
        /// <typeparam name="TModel">The type of the t model.</typeparam>
        /// <typeparam name="TProperty">The type of the t property.</typeparam>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="expression">The expression.</param>
        /// <param name="format">The format.</param>
        /// <param name="htmlAttributes">The HTML attributes.</param>
        /// <returns>MvcHtmlString.</returns>
        public static MvcHtmlString SageTextBoxFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, TProperty>> expression, string format, object htmlAttributes = null)
        {
            return TextBoxHelperFor(htmlHelper, expression, format, null, htmlAttributes);
        }

        /// <summary>
        /// To create textbox with knockout binding
        /// </summary>
        /// <typeparam name="TModel">The type of the t model.</typeparam>
        /// <typeparam name="TProperty">The type of the t property.</typeparam>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="expression">The expression.</param>
        /// <param name="format">The format.</param>
        /// <param name="koAttributes">The ko attributes.</param>
        /// <param name="htmlAttributes">The HTML attributes.</param>
        /// <returns>MvcHtmlString.</returns>
        public static MvcHtmlString KoSageTextBoxFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, TProperty>> expression, string format, object koAttributes,
            object htmlAttributes = null)
        {
            return TextBoxHelperFor(htmlHelper, expression, format, koAttributes, htmlAttributes);
        }

        /// <summary>
        /// To create textbox with knockout binding
        /// </summary>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="name">The name.</param>
        /// <param name="koAttributes">The ko attributes.</param>
        /// <param name="htmlAttributes">The HTML attributes.</param>
        /// <returns>MvcHtmlString.</returns>
        public static MvcHtmlString KoSageTextBox(this HtmlHelper htmlHelper, string name, object koAttributes,
            object htmlAttributes = null)
        {
            return TextBoxHelper(htmlHelper, name, null, string.Empty, koAttributes, htmlAttributes);
        }

        /// <summary>
        /// To create textbox with knockout binding
        /// </summary>
        /// <typeparam name="TModel">The type of the t model.</typeparam>
        /// <typeparam name="TProperty">The type of the t property.</typeparam>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="expression">The expression.</param>
        /// <param name="koAttributes">The ko attributes.</param>
        /// <param name="htmlAttributes">The HTML attributes.</param>
        /// <returns>MvcHtmlString.</returns>
        public static MvcHtmlString KoSageTextBoxFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, TProperty>> expression, object koAttributes, object htmlAttributes = null)
        {
            return TextBoxHelperFor(htmlHelper, expression, string.Empty, koAttributes, htmlAttributes);
        }

        /// <summary>
        /// Create textbox tag
        /// </summary>
        /// <typeparam name="TModel">The type of the t model.</typeparam>
        /// <typeparam name="TProperty">The type of the t property.</typeparam>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="expression">The expression.</param>
        /// <param name="format">The format.</param>
        /// <param name="koAttributes">The ko attributes.</param>
        /// <param name="htmlAttributes">The HTML attributes.</param>
        /// <returns>MvcHtmlString.</returns>
        private static MvcHtmlString TextBoxHelperFor<TModel, TProperty>(HtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, TProperty>> expression, string format, object koAttributes = null,
            object htmlAttributes = null)
        {
            var metadata = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData);
            var htmlDictionary = HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes);
            var koDictionary = HtmlHelper.AnonymousObjectToHtmlAttributes(koAttributes);
            var sanitizedName = TagBuilder.CreateSanitizedId(ExpressionHelper.GetExpressionText(expression));
            var exprName = ExpressionHelper.GetExpressionText(expression);
            var sageDatePicker = koDictionary.ContainsKey("sageDatePicker");
            var isDatePicker = sageDatePicker || (htmlDictionary.ContainsKey("class") && htmlDictionary["class"].ToString().IndexOf("datepicker") > -1);
            var isNumericBox = (htmlDictionary.ContainsKey("class") && htmlDictionary["class"].ToString().IndexOf("align-right") > -1);
            var controlType = (isDatePicker) ? ControlType.DatePicker : ((isNumericBox) ? ControlType.NumericBox : ControlType.Textbox);
            var name = (isDatePicker || isNumericBox) ? exprName : sanitizedName;

            var control = CommonExtensions.CustomizedDictionary(controlType, htmlHelper, name, htmlDictionary, koDictionary, metadata);
            if (koDictionary.Count > 0)
            {
                var databind = CommonExtensions.GetKoBindings(koDictionary);
                htmlDictionary.Add("data-bind", databind);
            }

            if (isDatePicker || isNumericBox)
            {
                var cssDisplay = (control != null && control.Hide) ? " style = 'display:none'" : "";
                var type = (isDatePicker) ? ControlType.DatePicker.ToString() : ControlType.NumericBox.ToString();
                var tagOpen = "<div data-sage300uicontrol=\"type:" + type + ",name:" + name + "\"" + cssDisplay+ " >";
                var tagEnd = "</div>";
                var element = htmlHelper.TextBoxFor(expression, format, htmlDictionary);
                return MvcHtmlString.Create(tagOpen + element.ToString() + tagEnd);
            }
            else
            {
                htmlDictionary.Add("data-sage300uicontrol", "type:" + ControlType.Textbox.ToString() + ",name:" + name);
                return htmlHelper.TextBoxFor(expression, format, htmlDictionary);
            }

        }

        /// <summary>
        /// To create textbox
        /// </summary>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="name">The name.</param>
        /// <param name="value">The value.</param>
        /// <param name="format">The format.</param>
        /// <param name="koAttributes">The ko attributes.</param>
        /// <param name="htmlAttributes">The HTML attributes.</param>
        /// <returns>MvcHtmlString.</returns>
        private static MvcHtmlString TextBoxHelper(HtmlHelper htmlHelper, string name, object value, string format,
            object koAttributes, object htmlAttributes)
        {
            var koDictionary = HtmlHelper.AnonymousObjectToHtmlAttributes(koAttributes);
            var htmlDictionary = HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes);

            var sanitizedName = TagBuilder.CreateSanitizedId(name);

            CommonExtensions.CustomizedDictionary(ControlType.Textbox, htmlHelper, sanitizedName, htmlDictionary, koDictionary);
            if (koDictionary.Count > 0)
            {
                var databind = CommonExtensions.GetKoBindings(koDictionary);
                htmlDictionary.Add("data-bind", databind);
            }

            htmlDictionary.Add("data-sage300uicontrol", "type:" + ControlType.Textbox.ToString() + ",name:" + sanitizedName);

            return htmlHelper.TextBox(name, value, format, htmlDictionary);
        }
    }
}