/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

#region

using Sage.CA.SBS.ERP.Sage300.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web.Mvc;
using System.Web.Mvc.Html;

#endregion

namespace Sage.CA.SBS.ERP.Sage300.Common.Web.HtmlHelperExtension
{
    /// <summary>
    /// Class ListBoxExtensions.
    /// </summary>
    public static class ListBoxExtensions
    {
        /// <summary>
        /// To create list box
        /// </summary>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="name">The name.</param>
        /// <param name="selectList">The select list.</param>
        /// <param name="optionLabel">The option label.</param>
        /// <param name="htmlAttributes">The HTML attributes.</param>
        /// <returns>MvcHtmlString.</returns>
        public static MvcHtmlString SageListBox(this HtmlHelper htmlHelper, string name,
            IEnumerable<CustomSelectList> selectList, string optionLabel = null, object htmlAttributes = null)
        {
            return htmlHelper.ListBox(name, CommonExtensions.ConvertCustomSelectListToMvcSelectList(selectList), htmlAttributes);
        }

        /// <summary>
        /// To create list box
        /// </summary>
        /// <typeparam name="TModel">The type of the t model.</typeparam>
        /// <typeparam name="TProperty">The type of the t property.</typeparam>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="expression">The expression.</param>
        /// <param name="selectList">The select list.</param>
        /// <param name="htmlAttributes">The HTML attributes.</param>
        /// <returns>MvcHtmlString.</returns>
        public static MvcHtmlString SageListBoxFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, TProperty>> expression, IEnumerable<CustomSelectList> selectList,
            object htmlAttributes = null)
        {
            return SageListBoxFor(htmlHelper, expression, selectList, null, htmlAttributes);
        }

        /// <summary>
        /// To create list box
        /// </summary>
        /// <typeparam name="TModel">The type of the t model.</typeparam>
        /// <typeparam name="TProperty">The type of the t property.</typeparam>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="expression">The expression.</param>
        /// <param name="selectList">The select list.</param>
        /// <param name="optionLabel">The option label.</param>
        /// <param name="htmlAttributes">The HTML attributes.</param>
        /// <returns>MvcHtmlString.</returns>
        public static MvcHtmlString SageListBoxFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, TProperty>> expression, IEnumerable<CustomSelectList> selectList,
            string optionLabel = null, object htmlAttributes = null)
        {
            return htmlHelper.ListBoxFor(expression, CommonExtensions.ConvertCustomSelectListToMvcSelectList(selectList), htmlAttributes);
        }

        /// <summary>
        /// To create list box with knockout binding
        /// </summary>
        /// <typeparam name="TModel">The type of the t model.</typeparam>
        /// <typeparam name="TProperty">The type of the t property.</typeparam>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="expression">The expression.</param>
        /// <param name="selectList">The select list.</param>
        /// <param name="optionsLabel">The options label.</param>
        /// <param name="koAttributes">The ko attributes.</param>
        /// <param name="htmlAttributes">The HTML attributes.</param>
        /// <returns>MvcHtmlString.</returns>
        public static MvcHtmlString KoSageListBoxFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, TProperty>> expression, IEnumerable<CustomSelectList> selectList, string optionsLabel,
            object koAttributes, object htmlAttributes = null)
        {
            return ListBoxHelperFor(htmlHelper, expression, selectList, optionsLabel, koAttributes, htmlAttributes);
        }

        /// <summary>
        /// To create list box
        /// </summary>
        /// <typeparam name="TModel">The type of the t model.</typeparam>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="name">The name.</param>
        /// <param name="koAttributes">The ko attributes.</param>
        /// <param name="htmlAttributes">The HTML attributes.</param>
        /// <returns>MvcHtmlString.</returns>
        public static MvcHtmlString KoSageListBox<TModel>(this HtmlHelper<TModel> htmlHelper, string name,
            object koAttributes, object htmlAttributes = null)
        {
            return ListBoxHelper(htmlHelper, name, null, string.Empty, koAttributes, htmlAttributes);
        }

        /// <summary>
        /// Helper list box
        /// </summary>
        /// <typeparam name="TModel">The type of the t model.</typeparam>
        /// <typeparam name="TProperty">The type of the t property.</typeparam>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="expression">The expression.</param>
        /// <param name="selectList">The select list.</param>
        /// <param name="optionsLabel">The options label.</param>
        /// <param name="koAttributes">The ko attributes.</param>
        /// <param name="htmlAttributes">The HTML attributes.</param>
        /// <returns>MvcHtmlString.</returns>
        private static MvcHtmlString ListBoxHelperFor<TModel, TProperty>(HtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, TProperty>> expression, IEnumerable<CustomSelectList> selectList, string optionsLabel,
            object koAttributes = null, object htmlAttributes = null)
        {
            var metadata = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData);
            var htmlDictionary = HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes);
            var koDictionary = HtmlHelper.AnonymousObjectToHtmlAttributes(koAttributes);
            var sanitizedName = TagBuilder.CreateSanitizedId(ExpressionHelper.GetExpressionText(expression));

            CommonExtensions.CustomizedDictionary(ControlType.ListBox, htmlHelper, sanitizedName, htmlDictionary, koDictionary, metadata);
            if (koDictionary.Count > 0)
            {
                var databind = CommonExtensions.GetKoBindings(koDictionary);
                htmlDictionary.Add("data-bind", databind);
            }
            htmlDictionary.Add("data-sage300uicontrol", "type:" + ControlType.ListBox.ToString() + ", name:" + sanitizedName);

            var selectListItems = selectList as IList<CustomSelectList> ?? selectList.ToList();
            return htmlHelper.ListBoxFor(expression, CommonExtensions.ConvertCustomSelectListToMvcSelectList(selectListItems), htmlDictionary);
        }

        /// <summary>
        /// Helper list box
        /// </summary>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="name">The name.</param>
        /// <param name="selectList">The select list.</param>
        /// <param name="optionsLabel">The options label.</param>
        /// <param name="koAttributes">The ko attributes.</param>
        /// <param name="htmlAttributes">The HTML attributes.</param>
        /// <returns>MvcHtmlString.</returns>
        private static MvcHtmlString ListBoxHelper(HtmlHelper htmlHelper, string name,
            IEnumerable<CustomSelectList> selectList, string optionsLabel, object koAttributes = null,
            object htmlAttributes = null)
        {
            var htmlDictionary = HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes);
            var koDictionary = HtmlHelper.AnonymousObjectToHtmlAttributes(koAttributes);
            var sanitizedName = TagBuilder.CreateSanitizedId(name);

            CommonExtensions.CustomizedDictionary(ControlType.ListBox, htmlHelper, sanitizedName, htmlDictionary, koDictionary);
            if (koDictionary.Count > 0)
            {
                var databind = CommonExtensions.GetKoBindings(koDictionary);
                htmlDictionary.Add("data-bind", databind);
            }
            htmlDictionary.Add("data-sage300uicontrol", "type:" + ControlType.ListBox.ToString() + ", name:" + sanitizedName);

            var items = selectList != null ? selectList.ToList() : new List<CustomSelectList>();
            return htmlHelper.ListBox(name, CommonExtensions.ConvertCustomSelectListToMvcSelectList(items), htmlDictionary);
        }
    }
}