/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

#region

using System;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using Sage.CA.SBS.ERP.Sage300.Common.Web.Customization;

#endregion

namespace Sage.CA.SBS.ERP.Sage300.Common.Web
{
    /// <summary>
    /// JsonNetResult Replaces the default JSonresult, Primarily to use JSON.NET serializer for faster searialization and correct date time handling 
    /// </summary>
    public class JsonNetResult : ActionResult
    {
        /// <summary>
        /// Gets or sets ContentEncoding
        /// </summary>
        public Encoding ContentEncoding { get; set; }

        /// <summary>
        /// Gets or sets ContentType
        /// </summary>
        public string ContentType { get; set; }

        /// <summary>
        /// Gets or sets Data
        /// </summary>
        public object Data { get; set; }

        /// <summary>
        ///  Gets or sets GridColumns
        /// </summary>
        public object GridColumns { get; set; }

        /// <summary>
        /// Gets or sets SerializerSettings
        /// </summary>
        public JsonSerializerSettings SerializerSettings { get; set; }

        /// <summary>
        ///  Gets or sets Formatting
        /// </summary>
        public Formatting Formatting { get; set; }

        /// <summary>
        /// initializes JsonSerializerSettings
        /// </summary>
        public JsonNetResult()
        {
            SerializerSettings = new JsonSerializerSettings { NullValueHandling = NullValueHandling.Include };

            // Add custom enum converter while parsing the value to Json.
            SerializerSettings.Converters.Add(new CustomJsonEnumConverter());

        }

        /// <summary>
        /// Executes Result based on Controller Context
        /// </summary>
        /// <param name="context"></param>
        public override void ExecuteResult(ControllerContext context)
        {
            if (context == null)
                throw new ArgumentNullException("context");

            HttpResponseBase response = context.HttpContext.Response;

            response.ContentType = !string.IsNullOrEmpty(ContentType) ? ContentType : "application/json";

            if (ContentEncoding != null)
                response.ContentEncoding = ContentEncoding;

            if (Data != null)
            {
                using (var writer = new JsonTextWriter(response.Output) { Formatting = Formatting })
                {
                    JsonSerializer serializer = JsonSerializer.Create(SerializerSettings);
                    serializer.Serialize(writer, Data);

                    writer.Flush();
                }
            }
        }
    }
}