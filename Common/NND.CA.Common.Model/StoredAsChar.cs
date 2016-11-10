using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NND.CA.Common.Model
{
    public class StoredAsChar : Attribute
    {
        /// <summary>
        /// This property is true iff the enum stores its value as a char.
        /// By default, assume that all enums are stored as an int instead.
        /// </summary>
        public bool IsChar { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="StoredAsChar"/> class.
        /// </summary>
        public StoredAsChar()
        {
            IsChar = true;
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="StoredAsChar"/> class.
        /// </summary>
        /// <param name="isChar">True iff this value is stored as a char.</param>
        public StoredAsChar(bool isChar)
        {
            IsChar = isChar;
        }
    }
}
