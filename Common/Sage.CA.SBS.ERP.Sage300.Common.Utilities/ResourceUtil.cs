/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

#region

using System.Reflection;
using System.Resources;

#endregion

namespace Sage.CA.SBS.ERP.Sage300.Common.Utilities
{
    /// <summary>
    /// Class ResourceUtil.
    /// </summary>
    public static class ResourceUtil
    {
        /// <summary>
        /// Get the String from thre Resource file
        /// </summary>
        /// <param name="resourceAssemblyType">FullyQualifiedFileName and Assembly name for example
        /// Sage.CA.SBS.ERP.Sage300.Common.Resources.AP, Sage.CA.SBS.ERP.Sage300.Common.Resources</param>
        /// <param name="resourceId">Resource Id</param>
        /// <returns>Resource String</returns>
        public static string GetString(string resourceAssemblyType, string resourceId)
        {
            if (string.IsNullOrEmpty(resourceAssemblyType) || string.IsNullOrEmpty(resourceId))
            {
                return string.Empty;
            }
            var resources = resourceAssemblyType.Split(',');
            if (resources.Length != 2)
            {
                return string.Empty;
            }
            var resourceAssembly = Assembly.Load(resources[1]);
            var resourceManager = new ResourceManager(resources[0], resourceAssembly);
            return resourceManager.GetString(resourceId);
        }
    }
}