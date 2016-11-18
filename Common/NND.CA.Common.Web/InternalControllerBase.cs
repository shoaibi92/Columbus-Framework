using System.Runtime.Remoting.Contexts;
using System.Web.UI.WebControls;
using Microsoft.Practices.Unity;
using NND.CA.Common.Model;

namespace NND.CA.Common.Web
{
    public class InternalControllerBase<T>
    {
        #region private memebrs

        //protected  T ServicesInLayer;
        protected  BaseModelContext BaseModelContainer;
        protected  T ServicesInternalController;

        #endregion

        #region  Constructor

        public InternalControllerBase(IUnityContainer baseModelContainer)
        {
           
        }

        #endregion

        #region PublicMemebers



        #endregion
    }
}