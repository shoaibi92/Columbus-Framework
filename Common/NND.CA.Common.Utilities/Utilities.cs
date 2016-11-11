using System;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Text;
using Newtonsoft.Json;
using NND.CA.Common.Model;


namespace NND.CA.Common.Utilities
{
    public static class Utilities
    {
        [DllImport("Kernel32.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        public static extern int GetUserDefaultLocaleName(StringBuilder lpBuffer, UInt32 uiSize);

        /// <summary>
        /// Gets the current application pool user Culture
        /// </summary>
        /// <returns>Default Culture set in Windows's regional setting</returns>
        public static CultureInfo GetUserDefaultCultureInfo()
        {
            var sbBuffer = new StringBuilder(1024);
            return GetUserDefaultLocaleName(sbBuffer, (UInt32)sbBuffer.Capacity) > 0 ? CultureInfo.GetCultureInfoByIetfLanguageTag(sbBuffer.ToString()) : null;
        }


        /// <summary>
        /// Converting model to JsonNetResult
        /// </summary>
        /// <typeparam name="T">Base model</typeparam>
        /// <param name="viewmodel">View model</param>
        /// <returns></returns>
        public static JsonNetResult JsonNet<T>(T viewmodel)
        { 
            var t = new JsonNetResult();
            return t; /*new JsonNetResult { Formatting = Formatting.None, Data = viewmodel };*/
        }

        
    }
}
