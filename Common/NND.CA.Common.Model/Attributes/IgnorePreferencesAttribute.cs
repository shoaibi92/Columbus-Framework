using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NND.CA.Common.Model.Attributes
{
    /// <summary>
    /// If this attribute is applied this property will no be used while saving user preferences
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class IgnorePreferencesAttribute : Attribute
    {
    }
}
