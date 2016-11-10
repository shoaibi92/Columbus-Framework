using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NND.CA.Common.Model
{
    public class SelectList
    {
        /// <summary>
        /// Gets or sets a value that indicates whether this <see cref="T:System.Web.Mvc.CustomSelectList"/> is selected.
        /// </summary>
        /// 
        /// <returns>
        /// true if the item is selected; otherwise, false.
        /// </returns>
        public bool Selected { get; set; }

        /// <summary>
        /// Gets or sets the text of the selected item.
        /// </summary>
        /// 
        /// <returns>
        /// The text.
        /// </returns>
        public string Text { get; set; }

        /// <summary>
        /// Gets or sets the value of the selected item.
        /// </summary>
        /// 
        /// <returns>
        /// The value.
        /// </returns>
        public int Value { get; set; }
    }
}
