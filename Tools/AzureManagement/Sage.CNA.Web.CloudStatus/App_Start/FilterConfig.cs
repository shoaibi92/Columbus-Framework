using System.Web;
using System.Web.Mvc;

namespace Sage.CNA.Web.CloudStatus
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
