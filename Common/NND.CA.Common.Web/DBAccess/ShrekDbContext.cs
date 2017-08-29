using NND.CA.Common.Web.ServiceReferences;
using NND.WebApi.Models.Resources;
using System.Data.Entity;

namespace NND.CA.Common.Web.DBAccess
{
    public class ShrekDbContext : BaseDbContext
    {
        public const string DbContextConnectionString = "name=ShrekDbContextString";

        public ShrekDbContext() : base(DbContextConnectionString)
        {
           // Database.SetInitializer<ShrekDbContext>(null);
        }

        /// <summary>
        /// 
        /// </summary>
        public DbSet<UnbonceWebApiDataModel> UnbonceWebApiDataModels { get; set; }

        /// <summary>
        /// LiveChatWebApiDataModel table in the Sherk DataBase
        /// </summary>
        public DbSet<LiveChatWebApiDataModel> LiveChatWebApiDataModels { get; set; }

        /// <summary>
        /// CallTrackingMatrixWebApiDataModel
        /// </summary>
      //  public DbSet<CallTrackingMatrixWebApiDataModel> CallTrackingMatrixWebApiDataModels { get; set; }
    }
}
