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
    public  enum  ScreenNameLocalized
    {
        /// <summary>
        /// None
        /// </summary>
        //[EnumValue("SecurityType_None", typeof(EnumerationsResx))]
        [StringValue("Home")]
        Home = 1,

        /// <summary>
        /// Add
        /// </summary>
        //[EnumValue("SecurityType_Add", typeof(EnumerationsResx))]
        [StringValue("Index")]
        Index = 2,

        /// <summary>
        /// Delete
        /// </summary>
        //[EnumValue("SecurityType_Delete", typeof(EnumerationsResx))]
        [StringValue("Dashbord")]
        Dashbord = 3

       
    }
}
