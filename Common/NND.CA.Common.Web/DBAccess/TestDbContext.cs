using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NND.CA.Common.Web.ServiceReferences;
using System.Data.Entity;
using NND.CA.Common.Model;

// TODO: remove the magic letter for connection string: 

namespace NND.CA.Common.Web.DBAccess
{

    /// <summary>
    /// 
    /// </summary>
    public class TestDbContext : BaseDbContext
    {
        public const string TestDbContextConnectionString = "name=TestDataModelDbContextString";

        public TestDbContext() : base(TestDbContextConnectionString)
        {
            //Database.SetInitializer<TestDbContext>();
        }

        public DbSet<TestDataModel> TestDataModels { get; set; }

    }
}
