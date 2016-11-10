using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NND.CA.Common.Model
{
    public class EnumItem
    {
        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// DisplayOrder
        /// </summary>
        public int DisplayOrder { get; set; }

        /// <summary>
        /// Value
        /// </summary>
        public object Value { get; set; }
    }
}
