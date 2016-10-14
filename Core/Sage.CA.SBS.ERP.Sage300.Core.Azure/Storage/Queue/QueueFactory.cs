using Microsoft.WindowsAzure.Storage.Queue;
using Sage.CA.SBS.ERP.Sage300.Core.Configuration;
using Sage.CA.SBS.ERP.Sage300.Core.Interfaces.Storage.Queue;

namespace Sage.CA.SBS.ERP.Sage300.Core.Azure.Storage.Queue
{
    /// <summary>
    /// Provides an easy way to select the right implementation
    /// </summary>
    public class QueueFactory
    {
        /// <summary>
        /// Not instantiable
        /// </summary>
        private QueueFactory()
        {
        }

        /// <summary>
        /// Determines what instance to instantiate
        /// </summary>
        /// <returns></returns>
        public static IQueue Create()
        {
            return ConfigurationHelper.IsOnPremise ? MsmqQueueFactory.Create() : AzureQueueFactory.Create();
        }
    }
}
