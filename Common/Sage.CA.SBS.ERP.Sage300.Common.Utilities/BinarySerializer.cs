// /* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace Sage.CA.SBS.ERP.Sage300.Common.Utilities
{
    public static class BinarySerializer
    {
        /// <summary>
        /// Serialize
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        private static byte[] Serialize(object o)
        {
            if (o == null)
            {
                return null;
            }

            var binaryFormatter = new BinaryFormatter();
            using (var memoryStream = new MemoryStream())
            {
                binaryFormatter.Serialize(memoryStream, o);
                byte[] objectDataAsStream = memoryStream.ToArray();
                return objectDataAsStream;
            }
        }

        /// <summary>
        /// Deserialize
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="stream">Stream</param>
        /// <returns>T</returns>
        private static T Deserialize<T>(byte[] stream)
        {
            if (stream == null)
            {
                return default(T);
            }

            var binaryFormatter = new BinaryFormatter();
            using (var memoryStream = new MemoryStream(stream))
            {
                var result = (T)binaryFormatter.Deserialize(memoryStream);
                return result;
            }
        }


        /// <summary>
        /// Converts to byte array.
        /// </summary>
        /// <param name="value">The restart information.</param>
        /// <returns></returns>
        public static byte[] ConvertToByteArray(string value)
        {
            var encoding = Encoding.ASCII;
            return encoding.GetBytes(value);
        }

        /// <summary>
        /// Binaries to string.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns></returns>
        public static string BinaryToString(Byte[] data)
        {
            var binarytostring = "";
            var length = data.Length;

            var value = (char)data[0];

            // if the first value is \0 we can assume the binary value is empty, if so return empty string.
            if (value == 0)
            {
                return binarytostring;
            }

            for (var i = 0; i < length; i++)
            {
                binarytostring += (char)data[i];
            }

            return binarytostring;
        }
    }
}