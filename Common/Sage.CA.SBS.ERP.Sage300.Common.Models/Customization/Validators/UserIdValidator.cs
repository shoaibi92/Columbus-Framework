using Sage.CA.SBS.ERP.Sage300.Common.Resources;
using System;
using System.ComponentModel.DataAnnotations;

namespace Sage.CA.SBS.ERP.Sage300.Common.Models.Customization.Validators
{
    /// <summary>
    /// Class UserIdValidator.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class UserIdValidator : ValidationAttribute
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="UserIdValidator"/> class.
        /// </summary>
        public UserIdValidator() : base(() => AnnotationsResx.MaxLength) { }

        /// <summary>
        /// Provide a different implementaiton for IsValid function
        /// </summary>
        /// <param name="value">Object</param>
        /// <returns>Function Result</returns>
        public override bool IsValid(object value)
        {
            if (value != null)
            {
                var userId = value as string;
                if (string.IsNullOrEmpty(userId) || (userId.Length > 8 && userId != CommonResx.Default))
                {
                    return false;
                }
                return true;
            }
            return false;
        }

        /// <summary>
        /// Format the error message
        /// </summary>
        /// <param name="name">Input message</param>
        /// <returns>Formatted message</returns>
        public override string FormatErrorMessage(string name)
        {
            //as this method checks for User ID length, hardcoding value 8
            var errorMessage = String.Format(ErrorMessageString, name, 8);
            return errorMessage;
        }
    }
}
