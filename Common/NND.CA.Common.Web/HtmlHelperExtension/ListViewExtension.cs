/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

#region Using Directives

using System.Runtime.InteropServices;
using System.Text;
using System.Web;
using System.Web.Mvc;

#endregion

namespace Sage.CA.SBS.ERP.Sage300.Common.Web.HtmlHelperExtension
{
    /// <summary>
    /// Kendo List View Extension for wrapping Html around for extension
    /// </summary>
    public static class ListViewExtension
    {
        /// <summary>
        /// To create HtmlHelper extenstion for wrapping Kendo list view
        /// </summary>
        /// <param name="helper">HTML Helper Class</param>
        /// <param name="listViewName">Name of the Kendo List View</param>
        /// <param name="propertyName">Name of the Property to bind the list view</param>
        /// <returns>the Html wrapper string for Kendo List View</returns>
        public static MvcHtmlString KoSageListView(this HtmlHelper helper, string listViewName, string propertyName)
        {
            var listviewHtml = new StringBuilder();

            var cusomizeTag = @"data-sage300uicontrol = ""type:" + ControlType.ListBox.ToString() + ",name:" + listViewName + "\"";
            var control = CommonExtensions.CustomizedDictionary(ControlType.ListBox, helper, listViewName, null);
            var cssDisplay = (control != null && control.Hide) ? " style = 'display:none'" : "";

            // Listview html wrapper element to hold Kendo Listview
            listviewHtml.Append(string.Format(@"<div id=""{0}"" {1} {2} class=""multilist""></div>", listViewName, cusomizeTag, cssDisplay));

            // Data item html template for Kendo Listview 
            listviewHtml.Append(
                string.Format(@"<script type=""text/x-kendo-tmpl"" id=""{0}_Template""> <div class=""item""> ${{{1}()}}</div></script>"
                , listViewName
                , propertyName));

            return MvcHtmlString.Create(listviewHtml.ToString());
        }

        /// <summary>
        /// To create HtmlHelper extension for wrapping Kendo list view
        /// </summary>
        /// <param name="helper">HTML Helper Class</param>
        /// <param name="kendoAttributes">Kendo attributes</param>
        /// <param name="htmlAttributes">Html attributes</param>
        /// <returns>the Html wrapper string for Kendo List View</returns>
        public static MvcHtmlString KoSageListView(this HtmlHelper helper, object kendoAttributes, object htmlAttributes)
        {
            var sb = new StringBuilder();
            var htmlDictionary = HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes);
            var kendoDictionary = HtmlHelper.AnonymousObjectToHtmlAttributes(kendoAttributes);
            htmlDictionary.Add("data-sage300uicontrol", "type:" + ControlType.ListBox.ToString() + ",name: lvListView");
            var divTag = new TagBuilder("div");
            divTag.MergeAttributes(htmlDictionary);
            var scriptTag = new TagBuilder("script");
            scriptTag.MergeAttribute("type", "text/x-kendo-tmpl");
            scriptTag.MergeAttribute("id", htmlDictionary["id"] + "_Template");
            var divOptionsValueTag = new TagBuilder("div");
            divOptionsValueTag.MergeAttribute("id", string.Format(@"${{{0}()}}", kendoDictionary["optionsValue"]));
            divOptionsValueTag.MergeAttribute("class", kendoDictionary["class"].ToString());
            var optionsText = string.Format(@"${{{0}()}}", kendoDictionary["optionsText"]);
            divOptionsValueTag.SetInnerText(optionsText);
            scriptTag.InnerHtml += divOptionsValueTag;
            sb.Append(divTag);
            sb.Append(scriptTag);

            return MvcHtmlString.Create(sb.ToString());
        }
    }
}
