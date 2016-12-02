using System.Data.Entity;

namespace NND.CA.Common.Web.ServiceReferences
{
    public abstract class BaseDbContext : DbContext
    {
        /// <summary>
        /// Send Connection String as defined in webconfig file to open a connection pool to that particular database
        /// Pre-requisite, you have defined the conection string int he Webconfig. 
        /// This supposed to be consued at Controller layer to keep a pool alive as long as one is interacting with DV module
        /// </summary>
        /// <param name="nameOrConnectionString"></param>
        protected BaseDbContext(string nameOrConnectionString) : base(nameOrConnectionString)
        {
        }
    }

}