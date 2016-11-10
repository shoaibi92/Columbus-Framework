using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NND.CA.Common.Model
{
    public class EnumValue : Attribute
    {
        /// <summary>
        /// The _value
        /// </summary>
        private string _value;

        /// <summary>
        /// Display Order
        /// </summary>
        public int DisplayOrder { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the type of the resource.
        /// </summary>
        /// <value>The type of the resource.</value>
        public Type ResourceType { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="EnumValue"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="resourceType">Type of the resource.</param>
        public EnumValue(string name, Type resourceType)
        {
            Name = name;
            ResourceType = resourceType;
        }

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="name"></param>
        /// <param name="resourceType"></param> 
        /// <param name="displayOrder"></param>
        public EnumValue(string name, Type resourceType, int displayOrder) : this(name, resourceType)
        {
            DisplayOrder = displayOrder;
        }

        /// <summary>
        /// Gets the value.
        /// </summary>
        /// <value>The value.</value>
        public string Value
        {
            get
            {
                if (!string.IsNullOrEmpty(_value))
                {
                    return _value;
                }

                //TODO -caching
                var property = ResourceType.GetProperty(Name);
                _value = (string)property.GetValue(null, null);
                return _value;
            }
        }
    }
}
