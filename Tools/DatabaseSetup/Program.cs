// Copyright (c) 1994-2015 Sage Software, Inc.  All rights reserved. 

#region Namespaces

using System;
using System.Diagnostics;
using System.Linq;
using Sage.CA.SBS.ERP.Sage300.LandlordDatabaseSetup.Resources;
#endregion

namespace Sage.CA.SBS.ERP.Sage300.LandlordDatabaseSetup
{
    #region Public Enums
    /// <summary> Processing Results </summary>
    public enum ProcessingResult
    {
        Success = 0,
        UnknownException = 1,
        InsufficientParameters = 2,
        ErrorProcessingScript = 3,
        ErrorRollingBack = 4,
        ErrorEstablishingConnection = 5,
        NullParameters = 6
    }
    #endregion

    /// <summary> Setup for Landlord Database to include
    ///  landlord schema and worker role schema and data. 
    /// </summary>
    class Program
    {
        /// <summary> Main entry point 
        /// </summary>
        /// <param name="args">Utility arguments</param>
        /// <remarks>Return Value 0 is for success</remarks>
        /// <remarks>Return Value 1 is for unknown exception</remarks>
        /// <remarks>Return Value 2 is for insufficient parameters</remarks>
        /// <remarks>Return Value 3 is for error processing script</remarks>
        /// <remarks>Return Value 4 is for error rollingback transaction</remarks>
        /// <remarks>Return Value 5 is for error establishing connection</remarks>
        /// <remarks>Return Value 6 is for null parameters</remarks>
        /// <returns>Return zero for success otherwise non-zero</returns>
        static int Main(string[] args)
        {
            try
            {
                Console.WriteLine(LandlordDatabaseSetupResx.LandlordDatabaseSetup);
                Console.WriteLine("");

                // For Debugger
                if (Debugger.IsAttached)
                {
                    // Change values as needed.
                    //args = new[] { "{serverName}", "1433", "Sage.Landlord", "sa", "{password}" };
                }

                // Validations
                if (!args.Length.Equals(5))
                {
                    // Incorrect parameters
                    Console.WriteLine(LandlordDatabaseSetupResx.InsufficientParameters);
                    return (int) ProcessingResult.InsufficientParameters;
                }
                else if (args.Any(string.IsNullOrEmpty))
                {
                    // Null Parameters
                    Console.WriteLine(LandlordDatabaseSetupResx.NullParameters);
                    return (int) ProcessingResult.NullParameters;
                }

                // Process the scripts
                var retVal = LandlordDatabaseSetup.Process(args);
                
                // re-start the worker role service?
                if (retVal.Equals((int) ProcessingResult.Success))
                {
                    LandlordDatabaseSetup.RestartWorkerRole();
                }

                return retVal;
            }
            catch
            {
                Console.WriteLine(LandlordDatabaseSetupResx.UnknownException);
                return (int) ProcessingResult.UnknownException;
            }
        }

    }
}
