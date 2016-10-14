using Sage.CA.SBS.ERP.Sage300.Common.Models;
using Sage.CA.SBS.ERP.Sage300.Core.Interfaces.Storage.Blob;
using Sage.CA.SBS.ERP.Sage300.Core.Configuration;

namespace Sage.CA.SBS.ERP.Sage300.Core.Azure.Storage.Blob
{
    public class BlobFactory
    {
        /// <summary>
        /// Not instantiable
        /// </summary>
        private BlobFactory()
        {
        }

        /// <summary>
        /// Determines what blob instance to get
        /// </summary>
        /// <returns></returns>
        public static IBlob GetBlob(string blobName, Context context)
        {
            return ConfigurationHelper.IsOnPremise ? OnPremiseBlob.GetBlob(blobName, context) : AzureBlockBlob.GetBlob(blobName, context);
        }
    }
}
