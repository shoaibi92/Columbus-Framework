/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

using Sage.CA.SBS.ERP.Sage300.Common.BusinessRepository.Utilities;
using Sage.CA.SBS.ERP.Sage300.Common.Models;
using Sage.CA.SBS.ERP.Sage300.Common.Models.Enums;

namespace Sage.CA.SBS.ERP.Sage300.Common.BusinessRepository
{
    /// <summary>
    /// BusinessEntitySession Parameters
    /// </summary>
    public class BusinessEntitySessionParams
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public BusinessEntitySessionParams()
            : this(Helper.ApplicationIdentifier, Helper.ProgramName)
        {

        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="applicationIdentifer">Application Identifier</param>
        public BusinessEntitySessionParams(string applicationIdentifer)
            : this(applicationIdentifer, Helper.ProgramName)
        {

        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="applicationIdentifer">Application Identifier</param>
        /// <param name="programName">Program Name</param>
        public BusinessEntitySessionParams(string applicationIdentifer, string programName)
        {
            ApplicationIdentifier = applicationIdentifer;
            ProgramName = programName;
        }
        /// <summary>
        /// Application Identifier
        /// </summary>
        public string ApplicationIdentifier { get; set; }

        /// <summary>
        /// Program Name
        /// </summary>
        public string ProgramName { get; set; }

        /// <summary>
        /// GetBusinessEntitySessionParams
        /// </summary>
        /// <param name="context">Context</param>
        /// <returns>BusinessEntitySessionParams</returns>
        public static BusinessEntitySessionParams Get(Context context)
        {
            if (context.ScreenContext == null || context.ScreenContext.ScreenName == ScreenName.None)
            {
                return new BusinessEntitySessionParams();
            }
            return new BusinessEntitySessionParams(GetApplicationIdentifier(context.ScreenContext.ScreenName));
        }

        /// <summary>
        /// Get application identifier based on screen
        /// </summary>
        /// <param name="screenName">ScreenName</param>
        /// <returns></returns>
        private static string GetApplicationIdentifier(string screenName)
        {
            int i;
            if (!int.TryParse(screenName, out i))
            {
                return "XY";
            }

            if (i >= 1 && i <= 200)
            {
                return "AS";
            }

            if (i >= 201 && i <= 400)
            {
                return "CS";
            }

            if (i >= 401 && i <= 600)
            {
                return "GL";
            }

            if (i >= 601 && i <= 800)
            {
                return "AR";
            }

            if (i >= 801 && i <= 1000)
            {
                return "AP";
            }

            if (i >= 1001 && i <= 1200)
            {
                return "IC";
            }

            if (i >= 1201 && i <= 1400)
            {
                return "OE";
            }

            if (i >= 1401 && i <= 1600)
            {
                return "PO";
            }

            return "XY";
        }
    }
}
