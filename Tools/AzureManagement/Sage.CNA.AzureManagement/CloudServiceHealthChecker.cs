using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Management.Compute.Models;
using Microsoft.WindowsAzure.Management.Storage.Models;
using Sage.CNA.AzureManagement.Core;
using Sage.CNA.AzureManagement.Entities;
using System.Linq;
using System.Net;

namespace Sage.CNA.AzureManagement
{
    /// <summary>
    /// Cloud Service Health checker class
    /// </summary>
    public class CloudServiceHealthChecker : BaseAzureManagement
    {
        /// <summary>
        /// Initializes Credential info
        /// </summary>
        /// <param name="credentialInfo"></param>
        public CloudServiceHealthChecker(AzureCredential credentialInfo)
            : base(credentialInfo)
        {
        }

        /// <summary>
        /// Gets cloud service metadata
        /// </summary>
        /// <param name="serviceName">Cloud service Name to read</param>
        /// <param name="deploymentSlot">Deployment Slot to check</param>
        /// <param name="storageAccount">Storage Account Name</param>
        /// <returns>Cloud service metadata</returns>
        public CNAResource GetCloudServiceMetadata(string serviceName, string deploymentSlot, string storageAccount)
        {
            var cnaResource = new CNAResource
            {
                Name = string.Format("{0}-{1}, {2}", serviceName, deploymentSlot, storageAccount),
                Description = "All CNA Resources",
                ResourceType = CNAResourceType.None,
                ServiceType = CNAServiceType.None
            };

            var t1 = new Task<List<CNAResource>>(() => GetComputeResourceStatus(serviceName, deploymentSlot));
            var t2 = new Task<CNAResource>(() => GetStorageAccountResourceStatus(storageAccount));
            t1.Start();
            t2.Start();

            Task.WaitAll(t1, t2);
            cnaResource.ChildResources.AddRange(t1.Result);
            cnaResource.ChildResources.Add(t2.Result);

            ProcessChildStatus(cnaResource);

            return cnaResource;
        }

        private void ProcessChildStatus(CNAResource resource)
        {
            if (resource != null && resource.ChildResources.Count > 0)
            {
                foreach (var childResource in resource.ChildResources)
                {
                    ProcessChildStatus(childResource);
                }
                resource.Status = resource.ChildResources.TrueForAll(child => child.Status);
            }
        }

        private List<CNAResource> GetComputeResourceStatus(string serviceName, string deploymentSlot)
        {
            IList<RoleInstance> listOfRoleInstances = null;
            using (var computeClient = new AzureComputeClient(CloudCredential.Credentials))
            {
                var hostedService = computeClient.Instance.HostedServices.GetDetailed(serviceName);
                var depList = hostedService.Deployments.ToList();
                foreach (var deployment in depList)
                {
                    if (deploymentSlot.ToLower() == deployment.DeploymentSlot.ToString().ToLower())
                    {
                        listOfRoleInstances = deployment.RoleInstances;
                        break;
                    }
                }
            }

            if (listOfRoleInstances != null)
            {
                var t1 = new Task<CNAResource>(() => GetWebResourceStatus(listOfRoleInstances, serviceName, deploymentSlot));
                var t2 = new Task<CNAResource>(() => GetARRResourceStatus(listOfRoleInstances, serviceName, deploymentSlot));
                var t3 = new Task<CNAResource>(() => GetWorkerResourceStatus(listOfRoleInstances, serviceName, deploymentSlot));

                t1.Start();
                t2.Start();
                t3.Start();

                Task.WaitAll(t1, t2, t3);

                var res = new List<CNAResource> { t1.Result, t2.Result, t3.Result };
                return res;
            }

            return null;
        }

        private CNAResource GetWebResourceStatus(IList<RoleInstance> listOfRoleInstances, string serviceName, string deploymentSlot)
        {
            var webResource = new CNAResource
             {
                 Name = "Web",
                 Description = "All Web Roles",
                 ResourceType = CNAResourceType.CloudInstanceWeb,
                 ServiceType = CNAServiceType.None
             };

            try
            {
                Parallel.ForEach(listOfRoleInstances, roleInstance =>
                {
                    if (roleInstance.InstanceName.StartsWith("Sage.CA.SBS.ERP.Sage300.Web_"))
                    {
                        CNAResource res = CheckRole(roleInstance, CNAResourceType.CloudInstanceWeb, "Web Role");
                        webResource.ChildResources.Add(res);
                        //res = CheckIIS(roleInstance, CNAResourceType.CloudInstanceWeb, "Web Role");
                        //webResource.ChildResources.Add(res);
                    }
                });
            }
            catch (Exception ex)
            {
                webResource.MoreInfo = ex.Message;
            }

            return webResource;
        }
        private CNAResource GetARRResourceStatus(IList<RoleInstance> listOfRoleInstances, string serviceName, string deploymentSlot)
        {
            var webARRResource = new CNAResource
            {
                Name = "ARR Web",
                Description = "All ARR Web Roles",
                ResourceType = CNAResourceType.CloudInstanceWeb,
                ServiceType = CNAServiceType.None
            };

            try
            {
                Parallel.ForEach(listOfRoleInstances, roleInstance =>
                {
                    if (roleInstance.InstanceName.StartsWith("Sage.CA.SBS.ERP.Sage300.Web.ARR_"))
                    {
                        CNAResource res = CheckRole(roleInstance, CNAResourceType.CloudInstanceARR, "ARR Role");
                        webARRResource.ChildResources.Add(res);
                        //res = CheckIIS(roleInstance, CNAResourceType.CloudInstanceARR, "ARR Role");
                        //webARRResource.ChildResources.Add(res);
                    }
                });
            }
            catch (Exception ex)
            {
                webARRResource.MoreInfo = ex.Message;
            }

            return webARRResource;
        }

        private CNAResource GetWorkerResourceStatus(IList<RoleInstance> listOfRoleInstances, string serviceName, string deploymentSlot)
        {
            var webARRResource = new CNAResource
            {
                Name = "Worker",
                Description = "All Worker Roles",
                ResourceType = CNAResourceType.CloudInstanceWorker,
                ServiceType = CNAServiceType.None
            };

            try
            {
                Parallel.ForEach(listOfRoleInstances, roleInstance =>
                {
                    if (roleInstance.InstanceName.StartsWith("Sage.CA.SBS.ERP.Sage300.Worker"))
                    {
                        CNAResource res = CheckRole(roleInstance, CNAResourceType.CloudInstanceWorker, "Worker Role");
                        webARRResource.ChildResources.Add(res);
                        //res = CheckIIS(roleInstance, CNAResourceType.CloudInstanceARR, "ARR Role");
                        //webARRResource.ChildResources.Add(res);
                    }
                });
            }
            catch (Exception ex)
            {
                webARRResource.MoreInfo = ex.Message;
            }

            return webARRResource;
        }

        private CNAResource GetStorageAccountResourceStatus(string storageAccountName)
        {
            var storageResource = new CNAResource
            {
                Name = "StorageAccount",
                Description = string.Format("CNA Storage account", storageAccountName),
                ResourceType = CNAResourceType.CloudStorage,
                ServiceType = CNAServiceType.AllCloudStorage
            };

            if (string.IsNullOrEmpty(storageAccountName))
            {
                storageResource.Status = false;
                storageResource.MoreInfo = "Storage account name is empty";
                return storageResource;
            }

            try
            {
                using (var storageClient = new AzureStorageClient(CloudCredential.Credentials))
                {
                    var storageAccount = storageClient.Instance.StorageAccounts.Get(storageAccountName);
                    storageResource.Status = storageAccount.StorageAccount.Properties.StatusOfGeoPrimaryRegion == GeoRegionStatus.Available;
                }
            }
            catch (Exception ex)
            {
                storageResource.MoreInfo = ex.Message;
            }

            return storageResource;
        }

        private CNAResource CheckRole(RoleInstance roleInstance, CNAResourceType resourceType, string description)
        {
            var resource = new CNAResource
            {
                Name = roleInstance.InstanceName,
                Description = description,
                Status = roleInstance.InstanceStatus == "ReadyRole",
                ResourceType = resourceType,
                ServiceType = CNAServiceType.AzureRoleAgent
            };

            return resource;
        }

        private CNAResource CheckIIS(RoleInstance roleInstance, CNAResourceType resourceType, string description)
        {
            var iisResource = new CNAResource
            {
                Name = roleInstance.InstanceName,
                Description = description,
                ResourceType = resourceType,
                ServiceType = CNAServiceType.IIS,
            };

            var ipAddress = "localhost"; //roleInstance.IPAddress;
            string url = string.Format("http://{0}/HealthCheck.txt", ipAddress);

            HttpStatusCode statusCode;
            try
            {
                WebRequest request = WebRequest.Create(url);
                // If required by the server, set the credentials.
                request.Credentials = CredentialCache.DefaultCredentials;
                // Get the response.
                WebResponse response = request.GetResponse();
                // Display the status.

                statusCode = ((HttpWebResponse)response).StatusCode;
            }
            catch (Exception ex)
            {
                statusCode = HttpStatusCode.NotFound;
                iisResource.MoreInfo = ex.Message;
            }

            iisResource.Status = statusCode == HttpStatusCode.OK;
            return iisResource;
        }
    }
}
