using Microsoft.WindowsAzure.Storage.Table;

namespace Sage.CA.SBS.ERP.Sage300.Core.Azure.Storage.Table
{
    /// <summary>
    /// Base Class
    /// </summary>
    public abstract class AzureBaseRepository
    {
        /// <summary>
        /// CloudTable
        /// </summary>
        protected CloudTable CloudTable { get; private set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="tableName">Name of the table</param>
        protected AzureBaseRepository(string tableName)
        {
            Helper.VerifyTableName(tableName);
            CloudTableClient tableClient =
                Helper.CreateCloudStorageAccount().CreateCloudTableClient();
            CloudTable = tableClient.GetTableReference(tableName);
            CloudTable.CreateIfNotExists();
        }
    }
}
