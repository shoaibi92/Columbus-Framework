/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

#region

using System.Web.Mvc;
using System.Web.Routing;

#endregion

namespace Sage.CA.SBS.ERP.Sage300.Common.Web.HtmlHelperExtension
{
    /// <summary>
    /// Class ButtonExtensions.
    /// </summary>
    public static class ButtonExtensions
    {
        /// <summary>
        /// To create finder control
        /// </summary>
        /// <param name="html">The HTML.</param>
        /// <param name="imageId">The image identifier.</param>
        /// <param name="imghtmlAttributes">The imghtml attributes.</param>
        /// <returns>MvcHtmlString.</returns>
        public static MvcHtmlString SearchFinder(this HtmlHelper html, string imageId, object imghtmlAttributes)
        {
            var imgBuilder = new TagBuilder("a");
            imgBuilder.Attributes.Add("id", imageId);
            imgBuilder.MergeAttributes(new RouteValueDictionary(imghtmlAttributes));

            return MvcHtmlString.Create(imgBuilder.ToString());
        }

        /// <summary>
        /// To create button without knockout binding
        /// </summary>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="name">The name.</param>
        /// <param name="htmlAttributes">The HTML attributes.</param>
        /// <returns>MvcHtmlString.</returns>
        public static MvcHtmlString SageButton(this HtmlHelper htmlHelper, string name, object htmlAttributes = null)
        {
            return ButtonHelper(htmlHelper, name, null, htmlAttributes);
        }

        /// <summary>
        /// To create button without knockout binding
        /// </summary>
        /// <param name="htmlHelper">The HTML helper</param>
        /// <param name="innerHtml">Display value</param>
        /// <param name="htmlAttributes">The HTML attributes</param>
        /// <returns></returns>
        public static MvcHtmlString SageButtonNoName(this HtmlHelper htmlHelper, string innerHtml, object htmlAttributes = null)
        {
            return ButtonNoNameHelper(htmlHelper, innerHtml, htmlAttributes);
        }

        /// <summary>
        /// To create button
        /// </summary>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="name">The name.</param>
        /// <param name="koAttributes">The ko attributes.</param>
        /// <param name="htmlAttributes">The HTML attributes.</param>
        /// <returns>MvcHtmlString.</returns>
        public static MvcHtmlString KoSageButton(this HtmlHelper htmlHelper, string name, object koAttributes,
            object htmlAttributes = null)
        {
            return ButtonHelper(htmlHelper, name, koAttributes, htmlAttributes);
        }
         /// <summary>
        /// To create button
        /// </summary>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="innerHtml">Display value</param>
        /// <param name="koAttributes">The ko attributes.</param>
        /// <param name="htmlAttributes">The HTML attributes.</param>
        /// <returns>MvcHtmlString.</returns>
        public static MvcHtmlString KoSageButtonNoName(this HtmlHelper htmlHelper, string innerHtml, object koAttributes,
            object htmlAttributes = null)
        {
            return ButtonNoNameHelper(htmlHelper, innerHtml, htmlAttributes, koAttributes);
        }

        /// <summary>
        /// To create button
        /// </summary>
        /// <param name="htmlHelper"></param>
        /// <param name="innerHtml">Display value</param>
        /// <param name="htmlAttributes">The HTML attributes.</param>
        /// <returns></returns>
        private static MvcHtmlString ButtonNoNameHelper(HtmlHelper htmlHelper, string innerHtml, object htmlAttributes = null, object koAttributes = null)
        {
            var buttonTag = new TagBuilder("button");
            var htmlDictionary = HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes);
            var koDictionary = HtmlHelper.AnonymousObjectToHtmlAttributes(koAttributes);

            if (koDictionary.Count > 0)
            {
                var databind = CommonExtensions.GetKoBindings(koDictionary);
                htmlDictionary.Add("data-bind", databind);
            }
            
            htmlDictionary.Add("type", "button");
            buttonTag.MergeAttributes(htmlDictionary);
            buttonTag.InnerHtml = innerHtml;
            return MvcHtmlString.Create(buttonTag.ToString());

        }

        /// <summary>
        /// Button helper with knockout binding
        /// </summary>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="name">The name.</param>
        /// <param name="koAttributes">The ko attributes.</param>
        /// <param name="htmlAttributes">The HTML attributes.</param>
        /// <returns>MvcHtmlString.</returns>
        private static MvcHtmlString ButtonHelper(HtmlHelper htmlHelper, string name, object koAttributes = null,
            object htmlAttributes = null)
        {
            var buttonTag = new TagBuilder("input");
            var htmlDictionary = HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes);
            var koDictionary = HtmlHelper.AnonymousObjectToHtmlAttributes(koAttributes);
            
            if (!string.IsNullOrEmpty(name))
            {
                var sanitizedName = TagBuilder.CreateSanitizedId(name);
                CommonExtensions.CustomizedDictionary(ControlType.Button, htmlHelper, sanitizedName, htmlDictionary);
                htmlDictionary.Add("data-sage300uicontrol", "type:" + ControlType.Button.ToString() + ",name:" + sanitizedName);
            }

            if (koDictionary.Count > 0)
            {
                var databind = CommonExtensions.GetKoBindings(koDictionary);
                htmlDictionary.Add("data-bind", databind);
            }

            htmlDictionary.Add("type", "button");
            htmlDictionary.Add("name", name);
            buttonTag.MergeAttributes(htmlDictionary);
            return MvcHtmlString.Create(buttonTag.ToString());
        }
    }
}