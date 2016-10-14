/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Text;

namespace Sage.CA.SBS.ERP.Sage300.Core.Logging.ExceptionHandler
{
    /// <summary>
    /// Formats Error strings for Reporting in logs 
    /// </summary>
    public static class ExceptionFormatter
    {
        /// <summary>
        /// Formats an Exception to a string
        /// </summary>
        /// <param name="ex"></param>
        /// <returns>Formatted string</returns>
        public static string ExceptionToString(Exception ex)
        {
            StringBuilder strBuilder = new StringBuilder();

            // Log the inner exceptions
            if (ex.InnerException != null)
            {
                strBuilder.Append("(Inner Exception)");
                strBuilder.Append(Environment.NewLine);
                strBuilder.Append(ExceptionToString(ex.InnerException));
                strBuilder.Append(Environment.NewLine);
                strBuilder.Append("(Outer Exception)");
                strBuilder.Append(Environment.NewLine);
            }

            strBuilder.Append("Exception Source:      ");
            try
            {
                strBuilder.Append(ex.Source);
            }
            catch (Exception e)
            {
                strBuilder.Append(e.Message);
            }

            strBuilder.Append(Environment.NewLine);
            strBuilder.Append("Exception Type:        ");
            try
            {
                strBuilder.Append(ex.GetType().FullName);
            }
            catch (Exception e)
            {
                strBuilder.Append(e.Message);
            }
            strBuilder.Append(Environment.NewLine);

            strBuilder.Append("Exception Message:     ");
            try
            {
                strBuilder.Append(ex.Message);
            }
            catch (Exception e)
            {
                strBuilder.Append(e.Message);
            }
            //NOTE: Removing stack trace info for Cloud

            try
            {
                StackTrace stackTrace = new StackTrace(ex, true);
                strBuilder.Append(StackTraceToString(stackTrace));
            }
            catch (Exception e)
            {
                strBuilder.Append(e.Message);
            }
            strBuilder.Append(Environment.NewLine);
            return strBuilder.ToString();
        }

        #region Private methods
        ///// <summary>
        ///// Converts The entire stack trace to string for logging
        ///// </summary>
        ///// <param name="stackTrace"></param>
        ///// <returns></returns>
        private static string StackTraceToString(StackTrace stackTrace)
        {
            var sb = new StringBuilder();

            sb.Append(Environment.NewLine);
            sb.AppendLine("---- Stack Trace ----");
            var stackFrames = stackTrace.GetFrames();
            if (stackFrames != null)
                foreach (StackFrame sf in stackFrames)
                {
                    sb.Append(StackFrameToString(sf));
                }
            sb.Append(Environment.NewLine);
            return sb.ToString();
        }

        ///// <summary>
        ///// Converts the StackFrame into a string
        ///// </summary>
        ///// <param name="sf"></param>
        ///// <returns></returns>
        private static string StackFrameToString(StackFrame sf)
        {
            var sb = new StringBuilder();
            MemberInfo mi = sf.GetMethod();

            // Write out the method with namespace
            if (mi.DeclaringType != null)
                sb.AppendFormat("   {0}.{1}.{2}",
                    mi.DeclaringType.Namespace,
                    mi.DeclaringType.Name,
                    mi.Name);

            // Write out the parameters to the method
            int nIndex = 0;
            sb.Append("(");
            foreach (ParameterInfo param in sf.GetMethod().GetParameters())
            {
                if (nIndex > 0)
                    sb.Append(", ");

                sb.AppendFormat("{0} {1}",
                    param.ParameterType.Name,
                    param.Name);
                nIndex++;
            }
            sb.Append(")");

            sb.AppendFormat(" in {0}", mi.Module.Name);
            // if source code is available, append location info
            if (!string.IsNullOrEmpty(sf.GetFileName()))
            {
                sb.AppendFormat(",file: {0},line: {1:#0000}",
                    System.IO.Path.GetFileName(sf.GetFileName()),
                    sf.GetFileLineNumber());
            }
            sb.Append(Environment.NewLine);
            return sb.ToString();
        }
        #endregion

    }

}
