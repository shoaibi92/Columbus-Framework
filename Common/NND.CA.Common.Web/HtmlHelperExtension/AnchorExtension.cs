/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

using System.Web.Mvc;

namespace Sage.CA.SBS.ERP.Sage300.Common.Web.HtmlHelperExtension
{
    /// <summary>
    /// HTML Extension for anchor tag
    /// </summary>
    public static class AnchorExtension
    {
        /// <summary>
        /// To create an anchor tag
        /// </summary>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="url">href</param>
        /// <param name="value">Inner Text</param>
        /// <param name="koAttributes">KO Attributes</param>
        /// <param name="htmlAttributes">The HTML attributes.</param>
        /// <returns>MvcHtmlString.</returns>
        public static MvcHtmlString KoSageAnchor(this HtmlHelper htmlHelper, string url, string value, object koAttributes = null,
            object htmlAttributes = null)
        {
            var htmlDictionary = HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes);
            var koDictionary = HtmlHelper.AnonymousObjectToHtmlAttributes(koAttributes);
            var anchorTag = new TagBuilder("a");
            var name = htmlDictionary.ContainsKey("id") ? htmlDictionary["id"].ToString() : "";

            if (!string.IsNullOrEmpty(name))
            {
                var control = CommonExtensions.CustomizedDictionary(ControlType.Button, htmlHelper, name, htmlDictionary);
                htmlDictionary.Add("data-sage300uicontrol", "type:" + ControlType.Button.ToString() + ",name: " + name);
            }

            if (koDictionary.Count > 0)
            {
                var databind = CommonExtensions.GetKoBindings(koDictionary);
                htmlDictionary.Add("data-bind", databind);
            }
            anchorTag.SetInnerText(value);
            anchorTag.Attributes.Add("href", url);
            anchorTag.MergeAttributes(htmlDictionary);
            return MvcHtmlString.Create(anchorTag.ToString());
        }

        /// <summary>
        /// To create an anchor tag
        /// </summary>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="url">href</param>
        /// <param name="value">Inner Text</param>
        /// <param name="koAttributes">KO Attributes</param>
        /// <param name="htmlAttributes">The HTML attributes.</param>
        /// <returns>MvcHtmlString.</returns>
        public static MvcHtmlString SageHamburger(this HtmlHelper htmlHelper, string url, string value, object koAttributes = null,
            object htmlAttributes = null)
        {
            var htmlDictionary = HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes);
            var koDictionary = HtmlHelper.AnonymousObjectToHtmlAttributes(koAttributes);
            var anchorTag = new TagBuilder("a");
            var name = htmlDictionary.ContainsKey("id") ? htmlDictionary["id"].ToString() : "";
            if (!string.IsNullOrEmpty(name))
            {
                var control = CommonExtensions.CustomizedDictionary(ControlType.Button, htmlHelper, name, htmlDictionary);
                htmlDictionary.Add("data-sage300uicontrol", "type:" + ControlType.Button.ToString() + ",name: " + name);
            }

            if (koDictionary.Count > 0)
            {
                var databind = CommonExtensions.GetKoBindings(koDictionary);
                htmlDictionary.Add("data-bind", databind);
            }
            anchorTag.SetInnerText(value);
            //anchorTag.Attributes.Add("href", url);
            anchorTag.Attributes.Add("class", "label-menu");
            anchorTag.MergeAttributes(htmlDictionary);
            return MvcHtmlString.Create(anchorTag.ToString());
        }
    }
}
