using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NND.CA.Common.Model.Enums;

namespace NND.CA.Common.Model
{
    /// <summary>
    /// User Access
    /// </summary>
    public class UserAccess
    {
        /// <summary>
        /// Type of security for the main view
        /// </summary>
        public SecurityType SecurityType;

        /// <summary>
        /// Dictionary that contains the entity name and security for the entity
        /// </summary>
        public Dictionary<string, UserAccess> ResourceSecurity;
    }
}
