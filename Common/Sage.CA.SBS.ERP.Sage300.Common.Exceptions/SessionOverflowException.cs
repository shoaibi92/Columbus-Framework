using System;

namespace Sage.CA.SBS.ERP.Sage300.Common.Exceptions
{
    /// <summary>
    /// This exception is thrown when number of session objects created per user exceeeds 
    /// the limit defined in configuration (MaxAllowedSessions)
    /// </summary>
    public class SessionOverflowException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SessionOverflowException"/> class.
        /// </summary>
        public SessionOverflowException()
        {
        }
        
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="message">Message</param>
        /// <param name="exception">Exception</param>
        public SessionOverflowException(string message, Exception exception) : base(message, exception)
        {
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="message">Message</param>
        public SessionOverflowException(string message) : base(message)
        {
        }
    }
}
