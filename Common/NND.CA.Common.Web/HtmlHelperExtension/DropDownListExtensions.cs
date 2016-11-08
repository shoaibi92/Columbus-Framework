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
    /// Class DropDownListExtensions.
    /// </summary>
    public static class DropDownListExtensions
    {
        /// <summary>
        /// To create select list
        /// TODO - ADD method Which takes MVC Select List as input so there is no conversion.
        /// </summary>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="name">The name.</param>
        /// <param name="selectList">The select list.</param>
        /// <param name="optionLabel">The option label.</param>
        /// <param name="htmlAttributes">The HTML attributes.</param>
        /// <param name="trimNewLine">Removes new lines from return string</param>
        /// <returns>MvcHtmlString.</returns>
        public static MvcHtmlString SageDropDownList(this HtmlHelper htmlHelper, string name,
            IEnumerable<CustomSelectList> selectList, string optionLabel = null, object htmlAttributes = null, bool trimNewLine = false)
        {
            var htmlString = htmlHelper.DropDownList(name, CommonExtensions.ConvertCustomSelectListToMvcSelectList(selectList), optionLabel, htmlAttributes);
            return !trimNewLine ? htmlString : MvcHtmlString.Create(htmlString.ToString().Replace(System.Environment.NewLine, "\""));
        }

        /// <summary>
        /// To create Options menu
        /// </summary>
        /// <param name="htmlHelper">The HTML helper</param>
        /// <returns>MvcHtmlString.</returns>
        public static MvcHtmlString SageOptionsReport(this HtmlHelper htmlHelper)
        {
            string htmlOutput = string.Empty;

            htmlOutput += "<ul class='dropDown-Menu push_4'>";
            htmlOutput += "<li> <a>Options</a>";
            htmlOutput += "<ul class='sub-menu'>";

            htmlOutput += "<li id='SaveUserPreference'> <a>";
            htmlOutput += "Save Settings as Default";
            htmlOutput += "</a></li>";

            htmlOutput += "<li id='ClearUserPreference'> <a>";
            htmlOutput += "Clear Saved Settings";
            htmlOutput += "</a></li>";

            htmlOutput += "</ul>";
            htmlOutput += "</li>";
            htmlOutput += "</ul>";

            return MvcHtmlString.Create(htmlOutput);

        }

        /// <summary>
        /// To create select list
        /// </summary>
        /// <typeparam name="TModel">The type of the t model.</typeparam>
        /// <typeparam name="TProperty">The type of the t property.</typeparam>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="expression">The expression.</param>
        /// <param name="selectList">The select list.</param>
        /// <param name="htmlAttributes">The HTML attributes.</param>
        /// <returns>MvcHtmlString.</returns>
        public static MvcHtmlString SageDropDownListFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, TProperty>> expression, IEnumerable<CustomSelectList> selectList,
            object htmlAttributes = null)
        {
            return SageDropDownListFor(htmlHelper, expression, selectList, null, htmlAttributes);
        }

        /// <summary>
        /// To create select list
        /// </summary>
        /// <typeparam name="TModel">The type of the t model.</typeparam>
        /// <typeparam name="TProperty">The type of the t property.</typeparam>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="expression">The expression.</param>
        /// <param name="selectList">The select list.</param>
        /// <param name="optionLabel">The option label.</param>
        /// <param name="htmlAttributes">The HTML attributes.</param>
        /// <returns>MvcHtmlString.</returns>
        public static MvcHtmlString SageDropDownListFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, TProperty>> expression, IEnumerable<CustomSelectList> selectList,
            string optionLabel = null, object htmlAttributes = null)
        {
            return htmlHelper.DropDownListFor(expression, CommonExtensions.ConvertCustomSelectListToMvcSelectList(selectList), optionLabel, htmlAttributes);
        }

        /// <summary>
        /// To create select list with knockout binding
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
        public static MvcHtmlString KoSageDropDownListFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, TProperty>> expression, IEnumerable<CustomSelectList> selectList, string optionsLabel,
            object koAttributes, object htmlAttributes = null)
        {
            return DropDownListHelperFor(htmlHelper, expression, selectList, optionsLabel, koAttributes, htmlAttributes);
        }

        /// <summary>
        /// To create select list
        /// </summary>
        /// <typeparam name="TModel">The type of the t model.</typeparam>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="name">The name.</param>
        /// <param name="koAttributes">The ko attributes.</param>
        /// <param name="htmlAttributes">The HTML attributes.</param>
        /// <returns>MvcHtmlString.</returns>
        public static MvcHtmlString KoSageDropDownList<TModel>(this HtmlHelper<TModel> htmlHelper, string name,
            object koAttributes, object htmlAttributes = null)
        {
            return DropDownListHelper(htmlHelper, name, null, string.Empty, koAttributes, htmlAttributes);
        }

        /// <summary>
        /// Helper select list
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
        private static MvcHtmlString DropDownListHelperFor<TModel, TProperty>(HtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, TProperty>> expression, IEnumerable<CustomSelectList> selectList, string optionsLabel,
            object koAttributes = null, object htmlAttributes = null)
        {
            var metadata = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData);
            var htmlDictionary = HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes);
            var koDictionary = HtmlHelper.AnonymousObjectToHtmlAttributes(koAttributes);
            var sanitizedName = TagBuilder.CreateSanitizedId(ExpressionHelper.GetExpressionText(expression));

            var control = CommonExtensions.CustomizedDictionary(ControlType.Dropdown, htmlHelper, sanitizedName, htmlDictionary, koDictionary, metadata);
            if (koDictionary.Count > 0)
            {
                var databind = CommonExtensions.GetKoBindings(koDictionary);
                htmlDictionary.Add("data-bind", databind);
            }

            var list = selectList.ToList();
            var selectListItems = selectList ?? list;
            var tagOpen ="<div data-sage300uicontrol=\"type:" + ControlType.Dropdown.ToString() + ",name:" + sanitizedName + "\" >";
            var tagEnd = "</div>";
            var element = htmlHelper.DropDownListFor(expression, CommonExtensions.ConvertCustomSelectListToMvcSelectList(selectListItems), optionsLabel, htmlDictionary);
            return MvcHtmlString.Create(tagOpen + element.ToString() + tagEnd);
        }

        /// <summary>
        /// Helper select list
        /// </summary>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="name">The name.</param>
        /// <param name="selectList">The select list.</param>
        /// <param name="optionsLabel">The options label.</param>
        /// <param name="koAttributes">The ko attributes.</param>
        /// <param name="htmlAttributes">The HTML attributes.</param>
        /// <returns>MvcHtmlString.</returns>
        private static MvcHtmlString DropDownListHelper(HtmlHelper htmlHelper, string name,
            IEnumerable<CustomSelectList> selectList, string optionsLabel, object koAttributes = null,
            object htmlAttributes = null)
        {
            var htmlDictionary = HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes);
            var koDictionary = HtmlHelper.AnonymousObjectToHtmlAttributes(koAttributes);
            var sanitizedName = TagBuilder.CreateSanitizedId(name);

            var control = CommonExtensions.CustomizedDictionary(ControlType.Dropdown, htmlHelper, sanitizedName, htmlDictionary, koDictionary);
            if (koDictionary.Count > 0)
            {
                var databind = CommonExtensions.GetKoBindings(koDictionary);
                htmlDictionary.Add("data-bind", databind);
            }

            var items = selectList != null ? selectList.ToList() : new List<CustomSelectList>();
            var cssDisplay = (control != null && control.Hide) ? " style = 'display:none'" :"";
            var tagOpen = "<div data-sage300uicontrol=\"type:" + ControlType.Dropdown.ToString() + ",name:" + sanitizedName + "\"" + cssDisplay + " >";
            var tagEnd = "</div>";
            var element = htmlHelper.DropDownList(name, CommonExtensions.ConvertCustomSelectListToMvcSelectList(items), optionsLabel, htmlDictionary);
            return MvcHtmlString.Create(tagOpen + element.ToString() + tagEnd);
        }
    }
}