
using System.Data.Entity;
using NND.WebApi.Models.Resources;

namespace NND.CA.Common.Web.DbAccessLayerContext
{
    public class ShrekDataBaseContext: DbContext
    {
        /// <summary>
        /// Please go to C:\git\sln\Columbus-Web\NND.CA.Web\Web.config to adjust the connection string on your wish.
        /// </summary>
        private const string ConnectionString = "ShrekDbContextString";

        /// <summary>
        /// ShrekDataBaseContext is a constroctor class that connects the Unbounce DataModel into the ShrekDataBase
        /// </summary>

        public ShrekDataBaseContext(): base (ConnectionString)
        {
        }

        /// <summary>
        /// UnBounce WebApi, please review the "C:\git\sln\Columbus-NNDWebApi\NNDWebApi.Models\Resources\UnbonceWebApiDataModel.cs"
        /// to identify the detail of this class. The data is being generated on the verndor's server. This class will be dumped 
        /// into a dummy table as well as a mapping table desgined by Herbet. 
        /// </summary>
        public DbSet<UnbonceWebApiDataModel> TestDataModels { get; set; }
    }
}
