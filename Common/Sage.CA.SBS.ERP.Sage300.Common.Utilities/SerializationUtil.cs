/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

#region

using System.IO;
using System.Runtime.Serialization;
using System.Text;
using System.Xml;

#endregion

namespace Sage.CA.SBS.ERP.Sage300.Common.Utilities
{
    /// <summary>
    /// Class SerializationUtil.
    /// </summary>
    public static class SerializationUtil
    {
        /// <summary>
        /// Makes a deep copy of an XML serializable type by serializing and then deserializing
        /// It Notice data that is not serialized is not copyied!
        /// </summary>
        /// <typeparam name="T">Type must be XML Serializable</typeparam>
        /// <param name="instance">Instance to deep copy</param>
        /// <returns>Deep copy of object</returns>
        public static T DeepCopy<T>(T instance) where T : new()
        {
            string serializedStr = TypeToString(instance);
            return StringToType<T>(serializedStr);
        }

        /// <summary>
        /// Convert a string into a UTF8 array of bytes
        /// </summary>
        /// <param name="inText">string to convert</param>
        /// <returns>Byte array</returns>
        public static byte[] StringToByteArrayByUtf8(string inText)
        {
            return Encoding.UTF8.GetBytes(inText);
        }

        /// <summary>
        /// Converts a serialized xml string to a type
        /// </summary>
        /// <typeparam name="T">Type must be XML Serializable</typeparam>
        /// <param name="serializedText">string containing xml</param>
        /// <returns>Materialized type</returns>
        public static T StringToType<T>(string serializedText) where T : new()
        {
            var dcs = new DataContractSerializer(typeof (T));
            using (var memoryStream = new MemoryStream(StringToByteArrayByUtf8(serializedText)))
            {
                memoryStream.Position = 0;
                var reader = XmlDictionaryReader.CreateTextReader(memoryStream, new XmlDictionaryReaderQuotas());
                return (T) dcs.ReadObject(reader, true);
            }
        }

        /// <summary>
        /// Type to string
        /// </summary>
        /// <typeparam name="T">Materialized type</typeparam>
        /// <param name="instance">Instance</param>
        /// <returns>string</returns>
        public static string TypeToString<T>(T instance) where T : new()
        {
            var dcs = new DataContractSerializer(typeof (T));
            using (var stringWriter = new StringWriter())
            {
                var textWriter = new XmlTextWriter(stringWriter);
                dcs.WriteObject(textWriter, instance);
                textWriter.Flush();
                return stringWriter.ToString();
            }
        }
    }
}