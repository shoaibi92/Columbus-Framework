using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NND.CA.Common.Model.Enums
{
    /// <summary>
    /// Security types
    /// </summary>
    [Flags]
    public enum UserAuthenticationMethod
    {
        /// <summary>
        /// None
        /// </summary>
        //[EnumValue("SecurityType_None", typeof(EnumerationsResx))]
        [StringValue("Google")]
        Google = 1,

        /// <summary>
        /// Add
        /// </summary>
        //[EnumValue("SecurityType_Add", typeof(EnumerationsResx))]
        [StringValue("Email")]
        Email = 2,

        /// <summary>
        /// Delete
        /// </summary>
        //[EnumValue("SecurityType_Delete", typeof(EnumerationsResx))]
        [StringValue("Facebook")]
        FaceBook = 4,

       
    }
}
