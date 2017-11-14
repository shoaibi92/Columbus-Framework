using NND.CA.Common.Model.Authentication;
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

        public DbSet<GoogleDataModel> GoogleUserModels { get; set; }

        /// <summary>
        /// CallTrackingMatrixWebApiDataModel
        /// </summary>
        public DbSet<CallTrackingMatrixWebApiDataModel> CallTrackingMatrixWebApiDataModels { get; set; }

        /// <summary>
        /// This is the data model for the NND User 
        /// Author: Kian D.Rad
        /// Data Nov 10th 2017
        /// README: using this as a test user model 
        /// </summary>
        public virtual DbSet<NNDUser> NNDUsers { get; set; }
    }
}
