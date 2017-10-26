using NND.CA.Common.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NND.CA.Common.Model
{
    public partial class SystemUser
    {

        public SystemUser(SecurityType userAccessIncoming, UserAuthenticationMethod method ) {

            userAccess = userAccessIncoming;
            authentifcationmethod = method;

            if (userAccess == SecurityType.Admin) {

                authorizedMenuItems = new List<MenuItem>();

                authorizedMenuItems.Add(new MenuItem() { TitleString ="Kian's Profile", ControllerName = "Home", MethodName ="LoadDashBoard" });

            }

        }


        public SecurityType userAccess {get;set;}
		public UserAuthenticationMethod authentifcationmethod { get; set; }
		public List<MenuItem> authorizedMenuItems { get; set; }

    }
}
