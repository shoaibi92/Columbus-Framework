using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using System.Xml.Serialization;

namespace NND.CA.Common.Web.Customization
{
    /// <summary>
    /// Class Grid.
    /// </summary>
    public class Grid
    {
        /// <summary>
        /// Screen Name
        /// </summary>
        /// <value>The name.</value>
        [XmlAttribute]
        public string Name { get; set; }

        /// <summary>
        /// List of controls
        /// </summary>
        /// <value>The controls.</value>
        [XmlElement("Control", typeof(Control))]
        public List<Control> Controls { get; set; }
    }
}