/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

using Newtonsoft.Json;
namespace Sage.CA.SBS.ERP.Sage300.Common.Utilities
{
    /// <summary>
    /// 
    /// </summary>
    public static class JsonSerializer
    {
        /// <summary>
        /// JsonSerializerSettings, to serialize all - Type as well as value
        /// </summary>
        private static readonly JsonSerializerSettings JsonSerializerSettings = new JsonSerializerSettings
        {
            TypeNameHandling = TypeNameHandling.All,
            DefaultValueHandling = DefaultValueHandling.Ignore
        };

        /// <summary>
        /// Serializes the model into JSON string compressed using GZIP
        /// </summary>
        /// <param name="model">Model to be serialized</param>
        /// <typeparam name="T">Type of ModelBase</typeparam>
        /// <returns>JSON string</returns>
        public static string SerializeWithCompression<T>(T model)
        {
            return Gzip.CompressJson(JsonConvert.SerializeObject(model, JsonSerializerSettings));
        }

        /// <summary>
        /// Deserialize the JSON GZIP compressed string into a model
        /// </summary>
        /// <param name="jsonModel">JSON string to be serialized</param>
        /// <typeparam name="T">Type of ModelBase</typeparam>
        /// <returns>Model</returns>
        public static T DeserializeCompressed<T>(string jsonModel)
        {
            return JsonConvert.DeserializeObject<T>(Gzip.DecompressJson(jsonModel), JsonSerializerSettings);
        }

        /// <summary>
        /// Serializes the model into JSON string
        /// </summary>
        /// <param name="model">Model to be serialized</param>
        /// <typeparam name="T">Type of ModelBase</typeparam>
        /// <returns>JSON string</returns>
        public static string Serialize<T>(T model)
        {
            return JsonConvert.SerializeObject(model, JsonSerializerSettings);
        }

        /// <summary>
        /// Deserialize the JSON string into a model
        /// </summary>
        /// <param name="jsonModel">JSON string to be serialized</param>
        /// <typeparam name="T">Type of ModelBase</typeparam>
        /// <returns>Model</returns>
        public static T Deserialize<T>(string jsonModel)
        {
            return JsonConvert.DeserializeObject<T>(jsonModel, JsonSerializerSettings);
        }

    }
}
