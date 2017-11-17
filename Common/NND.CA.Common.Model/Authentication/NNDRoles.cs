using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NND.CA.Common.Model.Authentication
{
    public enum NNDRoles
    {
        /// <summary>
        /// None
        /// </summary>
        //[EnumValue("SecurityType_None", typeof(EnumerationsResx))]
        [StringValue("Admin")]
        Admin = 1,

        /// <summary>
        /// Add
        /// </summary>
        //[EnumValue("SecurityType_Add", typeof(EnumerationsResx))]
        [StringValue("FranchisePartner")]
        FranchisePartner = 2,

        /// <summary>
        /// Delete
        /// </summary>
        //[EnumValue("SecurityType_Delete", typeof(EnumerationsResx))]
        [StringValue("CareGiver")]
        CareGiver = 3


    }
}
