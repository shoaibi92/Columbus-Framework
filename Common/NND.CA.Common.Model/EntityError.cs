using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NND.CA.Common.Model
{
    /// <summary>
    /// Class for Validation Detail
    /// </summary>
    public class EntityError
    {
        /// <summary>
        /// Gets or sets Messages
        /// </summary>
        /// <value>The message.</value>
        public string Message { get; set; }

        /// <summary>
        /// Gets or sets Priority
        /// </summary>
        /// <value>The priority.</value>
        public Priority Priority { get; set; }

        /// <summary>
        /// Gets Priority as string
        /// </summary>
        /// <value>The priority string.</value>
        public string PriorityString
        {
            get { return EnumUtility.GetStringValue(Priority); }
        }

        /// <summary>
        /// Gets or Sets Tag
        /// </summary>
        /// <value>The Tag.</value>
        public object Tag
        {
            get;
            set;
        }
    }

    /// <summary>
    /// Class for Validation Detail
    /// </summary>
    public class EntityError<T> where T : ModelBase
    {
        /// <summary>
        /// Gets or sets Messages
        /// </summary>
        /// <value>The message.</value>
        public string Message { get; set; }

        /// <summary>
        /// Gets or sets Priority
        /// </summary>
        /// <value>The priority.</value>
        public Priority Priority { get; set; }

        /// <summary>
        /// Gets or sets Data
        /// </summary>
        /// <value>The priority.</value>
        public T Data { get; set; }

        /// <summary>
        /// Gets Priority as string
        /// </summary>
        /// <value>The priority string.</value>
        public string PriorityString
        {
            get { return EnumUtility.GetStringValue(Priority); }
        }
    }

    /// <summary>
    /// Enums for Priority
    /// </summary>
    public enum Priority
    {
        /// <summary>
        /// The severe error
        /// </summary>
        //[EnumValue("EntityError_Priority_SevereError", typeof(EnumerationsResx))]
        SevereError = 0,

        /// <summary>
        /// The message
        /// </summary>
        //[EnumValue("EntityError_Priority_Message", typeof(EnumerationsResx))]
        Message = 1,

        /// <summary>
        /// The warning
        /// </summary>
        //[EnumValue("EntityError_Priority_Warning", typeof(EnumerationsResx))]
        Warning = 2,

        /// <summary>
        /// The error
        /// </summary>
        //[EnumValue("EntityError_Priority_Error", typeof(EnumerationsResx))]
        Error = 3,

        /// <summary>
        /// The security
        /// </summary>
        //[EnumValue("EntityError_Priority_Security", typeof(EnumerationsResx))]
        Security = 4,
    }
}
