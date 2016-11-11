/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

#region

using System.Web.Mvc;

#endregion

namespace Sage.CA.SBS.ERP.Sage300.Common.Web.HtmlHelperExtension
{
    /// <summary>
    /// HTML Helper class for span
    /// </summary>
    public static class SpanExtensions
    {
        /// <summary>
        /// span extension with Knockout attributes
        /// </summary>
        /// <param name="htmlHelper">html</param>
        /// <param name="koAttributes">ko attributes</param>
        /// <param name="htmlAttributes">html attributes</param>
        /// <returns>MVCHtmlString</returns>
        public static MvcHtmlString KoSpan(this HtmlHelper htmlHelper, object koAttributes, object htmlAttributes = null)
        {
            var htmlDictionary = HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes);
            var koDictionary = HtmlHelper.AnonymousObjectToHtmlAttributes(koAttributes);
            var span = new TagBuilder("span");
            var name = koDictionary.ContainsKey("name") ? koDictionary["name"].ToString(): "";
            var text = koDictionary.ContainsKey("text") ? koDictionary["text"].ToString() : "";
            var id = htmlDictionary.ContainsKey("id") ? htmlDictionary["id"].ToString() : "";
            if (string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(id))
            {
                name = id;
            }
            if (string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(text))
            {
                name = text;
            }

            if (!string.IsNullOrEmpty(name))
            {
                var control = CommonExtensions.CustomizedDictionary(ControlType.Span, htmlHelper, name, htmlDictionary);
                htmlDictionary.Add("data-sage300uicontrol", "type:" + ControlType.Span.ToString() + ",name: " + name);
                koDictionary.Remove("name");
            }

            if (koDictionary.Count > 0)
            {
                var databind = CommonExtensions.GetKoBindings(koDictionary);
                htmlDictionary.Add("data-bind", databind);
            }
            span.MergeAttributes(htmlDictionary);
            return MvcHtmlString.Create(span.ToString());
        }
    }
}