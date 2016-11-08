// Copyright (c) 1994-2015 Sage Software, Inc.  All rights reserved.

#region

using Newtonsoft.Json;
using Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Service.Base;
using Sage.CA.SBS.ERP.Sage300.Common.Models;
using Sage.CA.SBS.ERP.Sage300.Common.Models.Authentication;
using Sage.CA.SBS.ERP.Sage300.Common.Web.AreaConstants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Script.Serialization;
using Sage.CA.SBS.ERP.Sage300.Common.Web.Utilities;
using Sage.CA.SBS.ERP.Sage300.Core.Configuration;
using JsonSerializer = Sage.CA.SBS.ERP.Sage300.Common.Utilities.JsonSerializer;
using System.Web.Mvc.Html;

#endregion

namespace Sage.CA.SBS.ERP.Sage300.Common.Web.HtmlHelperExtension
{
    /// <summary>
    /// Class CommonExtensions.
    /// </summary>
    public static class CommonExtensions
    {
        /// <summary>
        /// Converts to JsVariable
        /// </summary>
        /// <param name="htmlHelper">html Helper</param>
        /// <param name="varName">Var Name</param>
        /// <param name="thingToConvert">Thing To Convert</param>
        /// <returns>MvcHtmlString.</returns>
        public static MvcHtmlString ConvertToJsVariable(this HtmlHelper htmlHelper, string varName,
            object thingToConvert)
        {
            var js = string.Format("var {0} = {1};", varName, new JavaScriptSerializer().Serialize(thingToConvert));
            return MvcHtmlString.Create(js);
        }

        /// <summary>
        /// Converts To JsVariable UsingNewtonSoft
        /// </summary>
        /// <param name="htmlHelper">html Helper</param>
        /// <param name="varName">Var Name</param>
        /// <param name="thingToConvert">Thing To Convert</param>
        /// <returns>MvcHtmlString.</returns>
        public static MvcHtmlString ConvertToJsVariableUsingNewtonSoft(this HtmlHelper htmlHelper, string varName,
            object thingToConvert)
        {
            //Add escape values to prevent XSS.
            var settings = new JsonSerializerSettings { StringEscapeHandling = StringEscapeHandling.EscapeHtml };
            var js = string.Format("var {0} = {1};", varName, JsonConvert.SerializeObject(thingToConvert, settings));

            return MvcHtmlString.Create(js);
        }

        /// <summary>
        /// Converts Model To JSon
        /// </summary>
        /// <param name="model">Model to be converted</param>
        /// <returns>System.String.</returns>
        public static string ConvertModelToJSon(this object model)
        {
            return Json.Encode(model);
        }

        /// <summary>
        /// Returns Grid Preferences. List is converted into JSON.
        /// List contains all the information about the columns.
        /// </summary>
        /// <param name="htmlHelper">HTML Helper</param>
        /// <param name="key">Key</param>
        /// <returns>JSON string</returns>
        public static string GridPreference(this HtmlHelper htmlHelper, string key)
        {
            var context = (Context) htmlHelper.ViewContext.HttpContext.Items["Context"];
            var service = Utilities.Utilities.Resolve<ICommonService>(context);
            var result = service.GetUserPreference(key);
            if (result != null)
            {
                return ConvertModelToJSon(JsonSerializer.DeserializeCompressed<List<GridColumn>>(result));
            }
            return string.Empty;
        }

        /// <summary>
        /// Gets the ko bindings.
        /// </summary>
        /// <param name="koDictionary">The ko dictionary.</param>
        /// <returns>System.String.</returns>
        internal static string GetKoBindings(IEnumerable<KeyValuePair<string, object>> koDictionary)
        {
            var attributes =
                koDictionary.Select(item => string.Format("{0}:{1}", item.Key, item.Value.ToString())).ToList();
            return string.Join(",", attributes);
        }

        /// <summary>
        /// Customize html and KO Dictionaries
        /// </summary>
        /// <param name="controlType">Type of the control.</param>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="name">The name.</param>
        /// <param name="htmlDictionary">The HTML dictionary.</param>
        /// <param name="koDictionary">The ko dictionary.</param>
        /// <param name="metadata">The metadata.</param>
        /// <returns>Common.Models.Customization.Control.</returns>
        internal static Common.Models.Customization.Control CustomizedDictionary(ControlType controlType,
            HtmlHelper htmlHelper, string name, RouteValueDictionary htmlDictionary,
            RouteValueDictionary koDictionary = null, ModelMetadata metadata = null)
        {
            var context = (Context)htmlHelper.ViewContext.HttpContext.Items["Context"];
            if (context.ScreenContext == null || context.ScreenContext.Screen == null || context.ScreenContext.Screen.Controls == null)
            {
                return null;
            }

            var control = context.ScreenContext.Screen.Controls.Find(ctl => ctl.Name == name && ctl.Type == controlType.ToString());
            if (control == null)
            {
                return null;
            }
            if (control != null && htmlDictionary == null)
            {
                return control;
            }
            
            if (control.Hide)
            {
                //No need to have privously added styles as it anyway going to make the control invisible
                if (controlType != ControlType.GridHeader && controlType != ControlType.DatePicker)
                {
                    if (htmlDictionary.ContainsKey("style"))
                    {
                        htmlDictionary["style"] = "display:none";
                    }
                    else
                    {
                        htmlDictionary.Add("style", "display:none");
                    }
                }
                else if (controlType != ControlType.DatePicker)
                {
                    htmlDictionary.Add("hidden", control.Hide.ToString().ToLower());
                }
            
                //Remove the KO bindings if it exists
                if (koDictionary != null)
                {
                    if (koDictionary.ContainsKey("visible"))
                    {
                        koDictionary.Remove("visible");
                    }
                    else if (koDictionary.ContainsKey("sagevisible"))
                    {
                        koDictionary.Remove("sagevisible");
                    }
                }
            }

            if (control.Disable)
            {
                if (htmlDictionary.ContainsKey("disabled"))
                {
                    htmlDictionary["disabled"] = "disabled";
                }
                else
                {
                    htmlDictionary.Add("disabled", "disabled");
                }
                //Remove the KO bindings if it exists
                if (koDictionary != null)
                {
                    if (koDictionary.ContainsKey("disable"))
                    {
                        koDictionary.Remove("disable");
                    }
                    else if (koDictionary.ContainsKey("sagedisable"))
                    {
                        koDictionary.Remove("sagedisable");
                    }
                }
            }

            if (controlType == ControlType.Button)
            {
                if (!string.IsNullOrEmpty(control.Label))
                {
                    if (htmlDictionary.ContainsKey("value"))
                    {
                        htmlDictionary["value"] = control.Label;
                    }
                    else
                    {
                        htmlDictionary.Add("value", control.Label);
                    }
                    //Remove the KO bindings if it exists
                    if (koDictionary != null && koDictionary.ContainsKey("value"))
                    {
                        koDictionary.Remove("value");
                    }
                }
            }
            return control;
        }

        /// <summary>
        /// Customize Kendo Grid from ScreenDefinitions XML
        /// </summary>
        /// <param name="htmlHelper">HTML Helper</param>
        /// <param name="gridName">Name of the Grid</param>
        /// <returns>Common.Models.Customization.Grid.</returns>
        internal static Common.Models.Customization.Grid CustomizedGrid(HtmlHelper htmlHelper, string gridName)
        {
            var context = (Context)htmlHelper.ViewContext.HttpContext.Items["Context"];
            if (context.ScreenContext == null || context.ScreenContext.Screen == null)
            {
                return null;
            }

            var grid = context.ScreenContext.Screen.Grids.Find(ctl => ctl.Name == gridName);
            if (grid == null)
            {
                return null;
            }
            return grid;
        }

        /// <summary>
        /// Build hidden control
        /// </summary>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="name">The name.</param>
        /// <param name="value">The value.</param>
        /// <param name="htmlAttributes">The HTML attributes.</param>
        /// <returns>MvcHtmlString.</returns>
        public static MvcHtmlString SageHidden(this HtmlHelper htmlHelper, string name, object value,
            IDictionary<string, Object> htmlAttributes)
        {
            var attributes = new RouteValueDictionary(htmlAttributes);
            return htmlHelper.Hidden(name, value, attributes);
        }

        /// <summary>
        /// Generate server url
        /// </summary>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="htmlAttributes">The HTML attributes.</param>
        /// <returns>MvcHtmlString.</returns>
        public static MvcHtmlString SageUrl(this HtmlHelper htmlHelper, IDictionary<string, Object> htmlAttributes)
        {
            // Get Tenant & Company Alias names from selected tenant object to have it in all URL's
            // When sage id is disabled we will be setting default values thats added in OnAuthorization method of MultitenantControllerBase
            var session = Utilities.Utilities.GetStoredUserSignOnResult();

            var attributes = new RouteValueDictionary(htmlAttributes);
           
            var tenantAlias = (session != null && session.SelectedTenant != null)
                ? session.SelectedTenant.TenantAlias.Trim()
                : string.Empty;

            var url = htmlHelper.ViewContext.HttpContext.Request.ApplicationPath != "/" ? htmlHelper.ViewContext.HttpContext.Request.ApplicationPath: string.Empty;
            url += !string.IsNullOrEmpty(tenantAlias) ? string.Format("/{0}/", tenantAlias) : "/";
            attributes.Add("value", url);
            return SageHidden(htmlHelper, attributes["name"].ToString(), attributes["value"].ToString(), attributes);
        }

        /// <summary>
        /// Click Jack fix
        /// </summary>
        /// <param name="hh">The hh.</param>
        /// <returns>MvcHtmlString.</returns>
        public static MvcHtmlString SetClickJackFix(this HtmlHelper hh)
        {
            var scriptBlock = new TagBuilder("script");
            scriptBlock.Attributes.Add("type", "text/javascript");
            scriptBlock.InnerHtml = @"if( self == top ) {
                    document.documentElement.style.display = 'block' ; 
                } else {
                    top.location = self.location ; 
                }";
            return MvcHtmlString.Create(scriptBlock.ToString());
        }

        /// <summary>
        /// Only allows page from IFrame
        /// </summary>
        /// <param name="hh"></param>
        /// <param name="url">url to load if screen which invoked the script is not in an iframe</param>
        /// <returns></returns>
        public static MvcHtmlString OnlyAllowFromIFrame(this HtmlHelper hh, string url)
        {
            var scriptBlock = new TagBuilder("script");
            scriptBlock.Attributes.Add("type", "text/javascript");
            if (ConfigurationHelper.IsPortalIntegrationEnabled)
            {
                scriptBlock.InnerHtml = string.Format(@"if( self.location === top.location ) {{
                    top.location.href = ""{0}"";
                }}", url);
            }
            return MvcHtmlString.Create(scriptBlock.ToString());
        }

        /// <summary>
        /// Extend Partial to include new identifier
        /// </summary>
        /// <param name="htmlHelper"></param>
        /// <param name="partialViewName"></param>
        /// <param name="model"></param>
        /// <param name="viewData"></param>
        /// <param name="genericIdentifier"></param>
        /// <returns></returns>
        public static MvcHtmlString Partial(this HtmlHelper htmlHelper, string partialViewName, object model,
            ViewDataDictionary viewData, string genericIdentifier)
        {
            var genericViewData = new ViewDataDictionary(viewData);
            genericViewData.Add(ViewItemSemantic.GenericButton, genericIdentifier);
            return htmlHelper.Partial(partialViewName, model, genericViewData);
        }

        /// <summary>
        /// This custom method introduced, to return actual HTML fragment
        /// that is not encoded.
        /// </summary>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="value">The value.</param>
        /// <returns>
        /// Raw Html Output
        /// </returns>
        public static IHtmlString SageRaw(this HtmlHelper htmlHelper, string value)
        {
            //Added to support ' in resource files. For javascript variables defined in cshtml, the literal (') will be treated as end of variable.
            if (value.Contains("'"))
            {
                value = value.Replace("'", @"\'");
            }

            return new HtmlString(value);
        }

        /// <summary>
        /// This custom method is to set amount into proper format with 
        /// currency symbol in front.
        /// </summary>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="currencySymbol">The currency symbol</param>
        /// <param name="amount">The amount.</param>
        /// <returns>
        /// Raw Html Output
        /// </returns>
        public static IHtmlString DisplayAmount(this HtmlHelper htmlHelper, string currencySymbol, decimal amount)
        {
            string result = "";
            if (amount >= 0)
            {
                result = currencySymbol + amount.ToString("N");
            }
            else
            {
                result = "(" + currencySymbol + Math.Abs(amount).ToString("N") + ")";
            }
            return new HtmlString(result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="customSelectList"></param>
        /// <returns></returns>
        public static IEnumerable<SelectListItem> ConvertCustomSelectListToMvcSelectList(IEnumerable<CustomSelectList> customSelectList)
        {
            var result = new List<SelectListItem>();
            foreach (var item in customSelectList)
            {
                result.Add(new SelectListItem { Selected = item.Selected, Text = item.Text, Value = item.Value });
            }
            return result;
        }

        /// <summary>
        /// This method sets the variables used for automatic session logout after x amount of inactivity and starts the timer
        /// </summary>
        /// <param name="htmlHelper"></param>
        /// <returns></returns>
        public static MvcHtmlString SetSessionVariables(this HtmlHelper htmlHelper)
        {
            var scriptBlock = new TagBuilder("script");
            scriptBlock.Attributes.Add("type", "text/javascript");
            scriptBlock.InnerHtml = string.Format(@"$(function () {{
                    SessionManager.Initialize('{0}');
                }});"
              ,  HttpContext.Current.Session.Timeout);
            return MvcHtmlString.Create(scriptBlock.ToString());
        }

    }
}