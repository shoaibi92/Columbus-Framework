/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

using System.Web.Mvc;

namespace Sage.CA.SBS.ERP.Sage300.Common.Web.HtmlHelperExtension
{
    /// <summary>
    /// Class FileExtension.
    /// </summary>
    public static class FileExtension
    {
        /// <summary>
        /// To create button without knockout binding
        /// </summary>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="name">The name.</param>
        /// <param name="koAttributes">KO Attributes</param>
        /// <param name="htmlAttributes">The HTML attributes.</param>
        /// <returns>MvcHtmlString.</returns>
        public static MvcHtmlString KoSageFileButton(this HtmlHelper htmlHelper, string name, object koAttributes = null, object htmlAttributes = null)
        {
            var buttonTag = new TagBuilder("input");
            var htmlDictionary = HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes);
            var koDictionary = HtmlHelper.AnonymousObjectToHtmlAttributes(koAttributes);

            if (!string.IsNullOrEmpty(name))
            {
                CommonExtensions.CustomizedDictionary(ControlType.File, htmlHelper, name, htmlDictionary);
            }

            if (koDictionary.Count > 0)
            {
                var databind = CommonExtensions.GetKoBindings(koDictionary);
                htmlDictionary.Add("data-bind", databind);
            }
            htmlDictionary.Add("type", "File");
            htmlDictionary.Add("name", name);
            buttonTag.MergeAttributes(htmlDictionary);
            return MvcHtmlString.Create(buttonTag.ToString());
        }
    }
}
