using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sage.CNA.AzureInfo.Models
{
    public class BaseModel
    {
        /// <summary>
        /// Is scuccessfull
        /// </summary>
        public bool IsSuccssful { get; set; }

        /// <summary>
        /// Error message
        /// </summary>
        public string ErrorMessage { get; set; }

        /// <summary>
        /// Error Description
        /// </summary>
        public string ErrorDescription { get; set; }
    }
}