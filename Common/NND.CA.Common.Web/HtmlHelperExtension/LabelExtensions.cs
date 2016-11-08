/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

#region

using System;
using System.Linq.Expressions;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Linq;

#endregion

namespace Sage.CA.SBS.ERP.Sage300.Common.Web.HtmlHelperExtension
{
    /// <summary>
    /// Class LabelExtensions.
    /// </summary>
    public static class LabelExtensions
    {
        /// <summary>
        /// To create label using model property i.e. string expression
        /// </summary>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="expression">The expression.</param>
        /// <param name="labelText">The label text.</param>
        /// <param name="htmlAttributes">The HTML attributes.</param>
        /// <returns>MvcHtmlString.</returns>
        public static MvcHtmlString SageLabel(this HtmlHelper htmlHelper, string expression, string labelText,
            object htmlAttributes = null)
        {
            return LabelHelper(htmlHelper, expression, labelText, htmlAttributes);
        }

        /// <summary>
        /// To create label by specify name and text
        /// </summary>
        /// <param name="htmlHelper"></param>
        /// <param name="name">label name</param>
        /// <param name="labelText">label text</param>
        /// <param name="attributes">The HTML attributes.</param>
        /// <param name="htmlAttributes">MvcHtmlString</param>
        /// <returns></returns>
        public static MvcHtmlString SageLabel(this HtmlHelper htmlHelper, string name, string labelText,
        object attributes, object htmlAttributes)
        {
            return LabelHelper(htmlHelper, name, labelText, htmlAttributes);
        }

        /// <summary>
        /// To create label without using model property i.e. expression
        /// </summary>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="labelText">The label text.</param>
        /// <param name="htmlAttributes">The HTML attributes.</param>
        /// <returns>MvcHtmlString.</returns>
        public static MvcHtmlString SageLabel(this HtmlHelper htmlHelper, string labelText, object htmlAttributes = null)
        {
            return htmlHelper.SageLabel(string.Empty, labelText, htmlAttributes);
        }

        /// <summary>
        /// To create H3 label
        /// </summary>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="name">The name.</param>
        /// <param name="labelText">The label text.</param>
        /// <param name="htmlAttributes">The HTML attributes.</param>
        /// <returns>MvcHtmlString.</returns>
        public static MvcHtmlString SageHeader3Label(this HtmlHelper htmlHelper, string name, string labelText,
            object htmlAttributes = null)
        {
            return SageHeaderLabel(htmlHelper, name, labelText, "h3", htmlAttributes);
        }

        /// <summary>
        /// To create H1 label
        /// </summary>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="name">The name.</param>
        /// <param name="labelText">The label text.</param>
        /// <param name="htmlAttributes">The HTML attributes.</param>
        /// <returns>MvcHtmlString.</returns>
        public static MvcHtmlString SageHeader1Label(this HtmlHelper htmlHelper, string name, string labelText,
            object htmlAttributes = null)
        {
            return SageHeaderLabel(htmlHelper, name, labelText, "h1", htmlAttributes);
        }

        /// <summary>
        /// To create Header label
        /// </summary>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="name">The name.</param>
        /// <param name="labelText">The label text.</param>
        /// <param name="headerSize">The label Header Size.</param>
        /// <param name="htmlAttributes">The HTML attributes.</param>
        /// <returns>MvcHtmlString.</returns>
        private static MvcHtmlString SageHeaderLabel(this HtmlHelper htmlHelper, string name, string labelText, string headerSize,
            object htmlAttributes = null)
        {
            var htmlDictionary = HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes);
            var tag = new TagBuilder(headerSize);
            tag.Attributes.Add("id", name);

            if (!string.IsNullOrEmpty(name))
            {
                var control = CommonExtensions.CustomizedDictionary(ControlType.Label, htmlHelper, name, htmlDictionary);
                htmlDictionary.Add("data-sage300uicontrol", "type:" + ControlType.Label.ToString() + ",name: " + name);

                if (control != null && !string.IsNullOrEmpty(control.Label))
                {
                    labelText = control.Label;
                }
            }

            tag.SetInnerText(labelText);

            tag.MergeAttributes(htmlDictionary);

            return MvcHtmlString.Create(tag.ToString());
        }

        /// <summary>
        /// To create label using model property
        /// </summary>
        /// <typeparam name="TModel">The type of the t model.</typeparam>
        /// <typeparam name="TValue">The type of the t value.</typeparam>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="expression">The expression.</param>
        /// <param name="htmlAttributes">The HTML attributes.</param>
        /// <returns>MvcHtmlString.</returns>
        public static MvcHtmlString SageLabelFor<TModel, TValue>(this HtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, TValue>> expression, object htmlAttributes = null)
        {
            return LabelHelperFor(htmlHelper, expression, string.Empty, null, htmlAttributes);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="htmlHelper"></param>
        /// <param name="expression"></param>
        /// <param name="htmlAttributes"></param>
        /// <returns></returns>
        public static MvcHtmlString SageLabelForWithHamburger<TModel, TValue>(this HtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, TValue>> expression, object htmlAttributes, string burgerUrl, string burgerValue, object burgerKoAttributes = null,
            object burgerHtmlAttributes = null)
        {
            return LabelHelperForWithHamburger(htmlHelper, expression, string.Empty, null, htmlAttributes, burgerUrl, burgerValue, burgerKoAttributes, burgerHtmlAttributes);
        }

        /// <summary>
        /// Sages the grid header for.
        /// </summary>
        /// <typeparam name="TModel">The type of the t model.</typeparam>
        /// <typeparam name="TValue">The type of the t value.</typeparam>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="expression">The expression.</param>
        /// <param name="htmlAttributes">The HTML attributes.</param>
        /// <returns>MvcHtmlString.</returns>
        public static MvcHtmlString SageGridHeaderFor<TModel, TValue>(this HtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, TValue>> expression, object htmlAttributes = null)
        {
            return GridHeaderHelperFor(htmlHelper, expression, string.Empty, null, htmlAttributes);
        }

        /// <summary>
        /// Grids the header helper for.
        /// </summary>
        /// <typeparam name="TModel">The type of the t model.</typeparam>
        /// <typeparam name="TValue">The type of the t value.</typeparam>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="expression">The expression.</param>
        /// <param name="labelText">The label text.</param>
        /// <param name="koAttributes">The ko attributes.</param>
        /// <param name="htmlAttributes">The HTML attributes.</param>
        /// <returns>MvcHtmlString.</returns>
        private static MvcHtmlString GridHeaderHelperFor<TModel, TValue>(HtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, TValue>> expression, string labelText, object koAttributes, object htmlAttributes)
        {
            var metadata = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData);
            var htmlDictionary = HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes);
            var koDictionary = HtmlHelper.AnonymousObjectToHtmlAttributes(koAttributes);

            var sanitizedName = TagBuilder.CreateSanitizedId(ExpressionHelper.GetExpressionText(expression));

            var control = CommonExtensions.CustomizedDictionary(ControlType.GridHeader, htmlHelper,
                sanitizedName, htmlDictionary, koDictionary, metadata);

            if (control != null && !string.IsNullOrEmpty(control.Label))
            {
                labelText = control.Label;
            }

            htmlDictionary.Add("data-sage300uicontrol", "type:" + ControlType.GridHeader.ToString() + ",name: " + sanitizedName);
            
            if (koDictionary.Count > 0)
            {
                var databind = CommonExtensions.GetKoBindings(koDictionary);
                htmlDictionary.Add("data-bind", databind);
            }

            return htmlHelper.LabelFor(expression, string.IsNullOrEmpty(labelText) ? null : labelText, htmlDictionary);
        }

        /// <summary>
        /// To create label using model property and knockout bindings
        /// </summary>
        /// <typeparam name="TModel">The type of the t model.</typeparam>
        /// <typeparam name="TValue">The type of the t value.</typeparam>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="expression">The expression.</param>
        /// <param name="labelText">The label text.</param>
        /// <param name="koAttributes">The ko attributes.</param>
        /// <param name="htmlAttributes">The HTML attributes.</param>
        /// <returns>MvcHtmlString.</returns>
        public static MvcHtmlString KoSageLabelFor<TModel, TValue>(this HtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, TValue>> expression, string labelText, object koAttributes,
            object htmlAttributes = null)
        {
            return LabelHelperFor(htmlHelper, expression, labelText, koAttributes, htmlAttributes);
        }

        /// <summary>
        /// To create label with hamburger using model property and knockout bindings
        /// </summary>
        /// <typeparam name="TModel">The type of the t model.</typeparam>
        /// <typeparam name="TValue">The type of the t value.</typeparam>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="expression">The expression.</param>
        /// <param name="labelText">The label text.</param>
        /// <param name="koAttributes">The ko attributes.</param>
        /// <param name="htmlAttributes">The HTML attributes.</param>
        /// <param name="burgerUrl">href</param>
        /// <param name="burgerValue">Inner Text</param>
        /// <param name="burgerKoAttributes">Burger KO Attributes</param>
        /// <param name="burgerHtmlAttributes">Burger The HTML attributes</param>
        /// <returns>MvcHtmlString</returns>
        private static MvcHtmlString LabelHelperForWithHamburger<TModel, TValue>(HtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, TValue>> expression, string labelText, object koAttributes, object htmlAttributes,
            string burgerUrl, string burgerValue, object burgerKoAttributes = null, object burgerHtmlAttributes = null)
        {
            var htmlFieldName = ExpressionHelper.GetExpressionText(expression);
            var labelFor = htmlHelper.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(htmlFieldName);
            var labelTag = new TagBuilder("label");
            labelTag.Attributes["for"] = TagBuilder.CreateSanitizedId(labelFor);

            var htmlDictionary = HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes);
            var koDictionary = HtmlHelper.AnonymousObjectToHtmlAttributes(koAttributes);

            if (koDictionary.Count > 0)
            {
                var databind = CommonExtensions.GetKoBindings(koDictionary);
                htmlDictionary.Add("data-bind", databind);
            }

            foreach (var item in htmlDictionary)
            {
                labelTag.Attributes[item.Key] = item.Value.ToString();
            }

            var bugerMvcHtmlString = htmlHelper.SageHamburger(burgerUrl, burgerValue, burgerKoAttributes, burgerHtmlAttributes);

            if (string.IsNullOrEmpty(labelText))
            {
                var metadata = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData);
                labelText = metadata.DisplayName ?? metadata.PropertyName ?? htmlFieldName.Split('.').Last();
            }

            labelTag.InnerHtml = labelText + bugerMvcHtmlString.ToHtmlString();

            return MvcHtmlString.Create(labelTag.ToString());
        }

        /// <summary>
        /// To create knockout bindings
        /// </summary>
        /// <typeparam name="TModel">The type of the t model.</typeparam>
        /// <typeparam name="TValue">The type of the t value.</typeparam>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="expression">The expression.</param>
        /// <param name="labelText">The label text.</param>
        /// <param name="koAttributes">The ko attributes.</param>
        /// <param name="htmlAttributes">The HTML attributes.</param>
        /// <returns>MvcHtmlString.</returns>
        private static MvcHtmlString LabelHelperFor<TModel, TValue>(HtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, TValue>> expression, string labelText, object koAttributes, object htmlAttributes)
        {
            var metadata = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData);
            var htmlDictionary = HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes);
            var koDictionary = HtmlHelper.AnonymousObjectToHtmlAttributes(koAttributes);

            var sanitizedName = TagBuilder.CreateSanitizedId(ExpressionHelper.GetExpressionText(expression));

            var control = CommonExtensions.CustomizedDictionary(ControlType.Label, htmlHelper,
                sanitizedName, htmlDictionary, koDictionary, metadata);
            
            if (control != null && !string.IsNullOrEmpty(control.Label))
            {
                labelText = control.Label;
            }

            if (koDictionary.Count > 0)
            {
                var databind = CommonExtensions.GetKoBindings(koDictionary);
                htmlDictionary.Add("data-bind", databind);
            }

            htmlDictionary.Add("data-sage300uicontrol", "type:" + ControlType.Label.ToString() + ",name:" + sanitizedName);

            return htmlHelper.LabelFor(expression, string.IsNullOrEmpty(labelText) ? null : labelText, htmlDictionary);
        }

        /// <summary>
        /// To create label
        /// </summary>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="expression">The expression.</param>
        /// <param name="labelText">The label text.</param>
        /// <param name="htmlAttributes">The HTML attributes.</param>
        /// <returns>MvcHtmlString.</returns>
        private static MvcHtmlString LabelHelper(HtmlHelper htmlHelper, string expression, string labelText,
            object htmlAttributes)
        {
            var htmlDictionary = HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes);

            if (!string.IsNullOrEmpty(expression))
            {
                var sanitizedName = TagBuilder.CreateSanitizedId(expression);

                var control = CommonExtensions.CustomizedDictionary(ControlType.Label, htmlHelper, sanitizedName,
                    htmlDictionary);

                htmlDictionary.Add("data-sage300uicontrol", "type:" + ControlType.Label.ToString() + ",name:" + sanitizedName);
                
                if (control != null && !string.IsNullOrEmpty(control.Label))
                {
                    labelText = control.Label;
                }
            }


            return htmlHelper.Label(expression, labelText, htmlDictionary);
        }
    }
}