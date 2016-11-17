using NND.CA.Common.Model;

namespace NND.CA.Common.Web
{
    public class InternalControllerBase<T>
    {
        #region private memebrs

        protected static T ServicesInLayer;

        #endregion

        #region  Constructor

        public InternalControllerBase(BaseModelContext baseModelContainer)
        {
            //ServicesInLayer = baseModelContainer.Container.Resolve<T>();
        }

        #endregion

        #region PublicMemebers

        public T ResolveService()
        {
            return ServicesInLayer;
        }

        #endregion
    }
}