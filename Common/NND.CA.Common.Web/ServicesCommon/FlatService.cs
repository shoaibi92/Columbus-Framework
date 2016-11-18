using Microsoft.Practices.Unity;
using NND.CA.Common.Model;

namespace NND.CA.Common.Web.ServicesCommon
{
    public abstract class FlatService<T> : BaseClassService<T>
    {
        protected FlatService(IUnityContainer baseModelContext) : base(baseModelContext)
        {
        }
    }
}
