/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

#region

using System.Collections.Generic;
using System.Text;
using System.Web.Mvc;
using System.Web.Script.Serialization;

using Sage.CA.SBS.ERP.Sage300.Common.Models.Customization;
using Sage.CA.SBS.ERP.Sage300.Common.Models;

#endregion

namespace Sage.CA.SBS.ERP.Sage300.Common.Web.HtmlHelperExtension
{
    /// <summary>
    /// Kendo KO Grid extensions
    /// </summary>
    public static class KendoGridExtensions
    {
        private static Grid _customGrid;

        /// <summary>
        /// To create a Kendo Grid with a KO datasource
        /// </summary>
        /// <param name="helper">HTML Helper extension</param>
        /// <param name="gridName">Name of the Kendo Grid</param>
        /// <param name="koDataSource">Knockout datasource of the Kendo Grid</param>
        /// <param name="key">Unique identification key for the row of the grid</param>
        /// <param name="gridOptions">Kendo grid options</param>
        /// <param name="hasIsCustomDelete">To perform softdelete o</param>
        /// <param name="className">Class for the grid- Different class are there based on grid</param>
        /// <returns></returns>
        public static MvcHtmlString KoKendoGrid(this HtmlHelper helper, string gridName, string koDataSource, string key,
            string gridOptions, bool hasIsCustomDelete = false, string className = "gh320")
        {
            var gridTags = new StringBuilder();
            string customSchemaName = string.Concat("custSchema", gridName);
            string customColumnsName = string.Concat("custColumns", gridName);
            var cusomizeTag = @"data-sage300uicontrol = ""type: Grid ,name:" + gridName + "\"";
            const string scriptStart = "<script>";
            const string endScript = "</script>";
            var context = (Context)helper.ViewContext.HttpContext.Items["Context"];
            var screen = context.ScreenContext.Screen;
            var style = "";
            
            if (screen != null && screen.Controls != null)
            {
                var control = screen.Controls.Find(ctl => ctl.Name == gridName);
                if (control != null)
                {
                    if (control.Hide)
                    {
                        style= " style = 'display:none'";
                    }
                }

            }

            string gridDiv = string.Format(
                @"<div id={0} class='{4}' {5} {6} data-bind=""SagekendoGrid: {1}, key: '{2}', gridOptions: {3} ", gridName, koDataSource,
                key, gridOptions, className, cusomizeTag, style);
            if (hasIsCustomDelete)
            {
                gridDiv = gridDiv + " , hasIsCustomDelete: true ";
            }

            //Get the customized data from the XML
            _customGrid = CommonExtensions.CustomizedGrid(helper, gridName);

            //Build the output from the customized data
            string customSchema = BuildCustomSchemaJson(customSchemaName);
            string customColumns = BuildCustomColumnJson(customColumnsName);

            if (customSchema != string.Empty)
            {
                BuildSchemaScript(gridTags, scriptStart, endScript, customSchema);
            }
            if (customColumns != string.Empty)
            {
                BuildColumnScript(gridTags, scriptStart, endScript, customColumns);
            }

            BuildGrid(gridTags, customSchemaName, customColumnsName, gridDiv);

            return MvcHtmlString.Create(gridTags.ToString());
        }

        #region Helper methods

        /// <summary>
        /// Builds the final output for the Grid
        /// </summary>
        /// <param name="gridTags">The customized grid tags</param>
        /// <param name="customSchemaName">The JSON variable name for customized schema definition</param>
        /// <param name="customColumnsName">The JSON variable name for customized columns definition</param>
        /// <param name="gridDiv"></param>
        private static void BuildGrid(StringBuilder gridTags, string customSchemaName, string customColumnsName,
            string gridDiv)
        {
            gridTags.Append(gridDiv);
            if (customSchemaName != null)
            {
                gridTags.Append(string.Format(@" ,schema: {0}", customSchemaName));
            }
            if (customColumnsName != null)
            {
                gridTags.Append(string.Format(@" , columns: {0}", customColumnsName));
            }

            gridTags.Append(@"""></div>");
        }

        /// <summary>
        /// Builds the customized column definition
        /// </summary>
        /// <param name="gridTags">The customized grid tags</param>
        /// <param name="scriptStart">Start script tag</param>
        /// <param name="endScript">End script tag</param>
        /// <param name="customColumns">Custom columns</param>
        private static void BuildColumnScript(StringBuilder gridTags, string scriptStart, string endScript,
            string customColumns)
        {
            gridTags.Append(scriptStart);
            gridTags.Append(customColumns);
            gridTags.Append(endScript);
        }

        /// <summary>
        /// Builds the customized schema definition
        /// </summary>
        /// <param name="gridTags">THe customized grid tags</param>
        /// <param name="scriptStart">Start script tag</param>
        /// <param name="endScript">End script tag</param>
        /// <param name="customSchema">Custom schema</param>
        private static void BuildSchemaScript(StringBuilder gridTags, string scriptStart, string endScript,
            string customSchema)
        {
            gridTags.Append(scriptStart);
            gridTags.Append(customSchema);
            gridTags.Append(endScript);
        }

        /// <summary>
        /// Builds the customized JSON for column definition
        /// </summary>
        /// <param name="customColumnsName">Custom column name generated</param>
        /// <returns></returns>
        private static string BuildCustomColumnJson(string customColumnsName)
        {
            string custColumns = GetCustomColumns();
            if (custColumns != null)
            {
                var customColumns = string.Format("var {0}=  ", customColumnsName);
                customColumns = string.Concat("{", customColumns, custColumns, "};");

                return customColumns;
            }

            return string.Empty;
        }

        /// <summary>
        /// Builds the customized JSON for schema definition
        /// </summary>
        /// <param name="customSchemaName">Custom schema name generated</param>
        /// <returns></returns>
        private static string BuildCustomSchemaJson(string customSchemaName)
        {
            string custSchema = GetCustomValidation();
            var customSchema = string.Format("var {0} = ", customSchemaName);
            customSchema = string.Concat(customSchema, "{", custSchema, "};");
            return customSchema;
        }

        /// <summary>
        /// Builds the customized validation script
        /// </summary>
        /// <returns></returns>
        private static string GetCustomValidation()
        {
            var validators = new StringBuilder();
            if (_customGrid != null)
            {
                foreach (var control in _customGrid.Controls)
                {
                    //if (control.Validations != null)
                    //{
                    //    foreach (var validation in control.Validations)
                    //    {
                    //        if (validation is Common.Models.Customization.Validators.Required)
                    //        {
                    //            if (validators.Length != 0)
                    //            {
                    //                validators.Append(", ");
                    //            }
                    //            validators.Append(control.Name + @" : { validation: { required: { message: """ +
                    //                              validation.ErrorMessage + @"""} } } ");
                    //        }
                    //    }
                    //}
                }
                if (validators.Length != 0)
                {
                    var customValidation = new StringBuilder();
                    customValidation.Append("model : { fields: {");
                    customValidation.Append(validators);
                    customValidation.Append("}}");
                    return customValidation.ToString();
                }
                return string.Empty;
            }
            return string.Empty;
        }

        /// <summary>
        /// Gets the customized columns as JSON
        /// </summary>
        /// <returns></returns>
        private static string GetCustomColumns()
        {
            var customColumnsList = new List<CustomColumns>();

            if (_customGrid != null)
            {
                foreach (var control in _customGrid.Controls)
                {
                    var columnsMetadata = new CustomColumns();
                    columnsMetadata.field = control.Name;
                    columnsMetadata.title = control.Label;
                    if (control.Disable)
                    {
                        columnsMetadata.attributes = new Attributes {disabled = control.Disable.ToString().ToLower()};
                    }
                    customColumnsList.Add(columnsMetadata);
                }
                return new JavaScriptSerializer().Serialize(customColumnsList);
            }
            return "{}";
        }

        #endregion
    }

    /// <summary>
    /// Class to convert the customized columns from XML to JSON
    /// </summary>
    internal class CustomColumns
    {
        public string field { get; set; }
        public string title { get; set; }
        public Attributes attributes { get; set; }
    }

    /// <summary>
    /// Class to convert custom attributes from XML to JSON
    /// </summary>
    internal class Attributes
    {
        public string disabled { get; set; }
    }
}