using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Management.Compute.Models;
using Sage.CNA.AzureManagement.Core;
using Sage.CNA.AzureManagement.Entities;

namespace Sage.CNA.AzureManagement
{
    /// <summary>
    /// Cloud Service Reader
    /// </summary>
    public class CloudServiceReader : BaseAzureManagement
    {
        /// <summary>
        /// Initializes Credential info
        /// </summary>
        /// <param name="credentialInfo"></param>
        public CloudServiceReader(AzureCredential credentialInfo) : base (credentialInfo)
        {
        }

        /// <summary>
        /// Gets cloud service metadata
        /// </summary>
        /// <param name="serviceNames">Cloud service Names to read</param>
        /// <returns>Cloud service metadata</returns>
        public List<CloudServiceMetadataEntity> GetCloudServiceMetadata(List<string> serviceNames)
        {
            var metaDataList = new List<CloudServiceMetadataEntity>();

            using (var computeClient = new AzureComputeClient(CloudCredential.Credentials))
            {
                foreach (var serviceName in serviceNames)
                {
                    var hostedService = computeClient.Instance.HostedServices.GetDetailed(serviceName);
                    var depList = hostedService.Deployments.ToList();
                    foreach (var deployment in depList)
                    {
                        var metaData = new CloudServiceMetadataEntity
                        {
                            Name = serviceName,
                            DeploymentType = deployment.DeploymentSlot.ToString(),
                            Url = deployment.Uri.ToString(),
                            Status = Enum.GetName(typeof (DeploymentStatus), deployment.Status),
                            CreatedDate = deployment.CreatedTime,
                            LastModifiedDate = deployment.LastModifiedTime,
                            DeploymentLabel = deployment.Label,
                            RoleStatus = "Ready"
                        };

                        foreach (var roleInstance in deployment.RoleInstances)
                        {
                            if (roleInstance.InstanceStatus != "ReadyRole")
                            {
                                metaData.RoleStatus = roleInstance.InstanceStatus;
                                break;
                            }
                        }
                        metaDataList.Add(metaData);
                    }
                }
            }

            return metaDataList;
        }
    }
}
