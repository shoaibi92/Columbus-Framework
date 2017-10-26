using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NND.CA.Common.Web.Menu
{
    /// <summary>
    /// Author: Kian D.Rad
    /// Date: Oct 27th 2017
    /// ReadMe: This class holds the actionlink contnet 
    /// that are being used on navbar to build the menu.
    /// </summary>
    public partial class MenuDataModel
    {
        /// <summary>
        /// Controller name such as Home
        /// </summary>
        public string controllerName { get; set; }
        /// <summary>
        /// Method Name in controller such as index
        /// </summary>
        public string actionMethod { get; set; }
        /// <summary>
        /// String showed on the html to the viewer
        /// </summary>
        public string textname { get; set; }
        /// <summary>
        /// This is the array that contains all the components
        /// </summary>
        public List<MenuDataModel> MenuDataModels { get; set; }
    }
}
