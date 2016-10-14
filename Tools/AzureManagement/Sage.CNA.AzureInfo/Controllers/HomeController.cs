using Sage.CNA.AzureInfo.Helper;
using Sage.CNA.AzureInfo.Models;
using Sage.CNA.AzureManagement;
using Sage.CNA.AzureManagement.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Web.Mvc;
using System.Xml.Linq;

namespace Sage.CNA.AzureInfo.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            try
            {
                // Azure credentials
                var azureCredential = new AzureCredential(
                    ConfigurationHelper.SubscriptionId,
                    ConfigurationHelper.CertificateData);

                // Get cloud service information
                var serviceInfo = new CloudServiceReader(azureCredential);
                var serviceList = serviceInfo.GetCloudServiceMetadata(ConfigurationHelper.CloudServiceList);

                // Get Xml metadata information
                List<ServiceMetadataXmlEntity> xmlMetadata = GetXmlMetadata();

                var model = new CloudServiceMetadataModel
                {
                    IsSuccssful = true
                };

                // Process metadata and map to the model
                foreach (var service in serviceList)
                {
                    if (service.DeploymentLabel.Contains("TC_Build_"))
                    {
                        service.DeploymentLabel = service.DeploymentLabel.Replace("TC_Build_", string.Empty);
                    }
                    else if (service.DeploymentLabel.Contains("Azure1"))
                    {
                        service.DeploymentLabel = string.Empty;
                    }
                    var metadataEntityModel = new CloudServiceMetadataEntityModel
                    {
                        Name = service.Name,
                        DeploymentType = service.DeploymentType,
                        DeploymentLabel = service.DeploymentLabel,
                        Status = service.Status,
                        ConsolidatedRoleStatus = service.RoleStatus,
                        Url = service.Url.Replace("http:", "https:")
                    };
                    var indianZone = TimeZoneInfo.FindSystemTimeZoneById(ConfigurationHelper.TimeZone);
                    DateTime utcDateTime = service.CreatedDate.ToUniversalTime();
                    metadataEntityModel.CreatedDate = TimeZoneInfo.ConvertTimeFromUtc(utcDateTime, indianZone);
                    metadataEntityModel.LastModifiedDate = service.LastModifiedDate;

                    string serviceKey = string.Format("{0}_{1}", service.Name.ToLower(),
                        service.DeploymentType.ToLower());

                    var serviceXmlMetadata = xmlMetadata.FirstOrDefault(x => x.Name == serviceKey);

                    if (serviceXmlMetadata != null)
                    {
                        if (!string.IsNullOrEmpty(serviceXmlMetadata.CNameUrl))
                        {
                            metadataEntityModel.Url = serviceXmlMetadata.CNameUrl;
                        }

                        metadataEntityModel.Description = serviceXmlMetadata.Description;
                    }
                    switch (!metadataEntityModel.Name.Contains("r2") && !metadataEntityModel.Name.Contains("r3"))
                    {
                        case true:
                            if (!metadataEntityModel.Name.Contains("r2") && !metadataEntityModel.Name.Contains("r3"))
                            {
                                model.CloudServiceList.Add(metadataEntityModel);
                            }
                            break;
                        case false:
                            if (metadataEntityModel.Name.Contains("r2"))
                            {
                                model.R2CloudServiceList.Add(metadataEntityModel);
                            }
                            if (metadataEntityModel.Name.Contains("r3"))
                            {
                                model.R3CloudServiceList.Add(metadataEntityModel);
                            }
                            break;
                    }
                }

                var latestService = model.CloudServiceList.OrderByDescending(x => x.CreatedDate).FirstOrDefault();
                if (latestService != null)
                {
                    latestService.HighlightCssClass = "highlight-green";
                }

                model.CloudServiceList = model.CloudServiceList.OrderBy(x => x.Name).ThenBy(x => x.DeploymentType).ToList();

                foreach(var item  in model.CloudServiceList)
                {
                    if (item.ConsolidatedRoleStatus !="Ready")
                    {
                        item.HighlightCssClass = "highlight-red";
                    }
                }
                
                var latestServiceR2 = model.R2CloudServiceList.OrderByDescending(x => x.CreatedDate).FirstOrDefault();
                if (latestServiceR2 != null)
                {
                    latestServiceR2.HighlightCssClass = "highlight-green";
                }

                model.R2CloudServiceList = model.R2CloudServiceList.OrderBy(x => x.Name).ThenBy(x => x.DeploymentType).ToList();

                foreach (var item in model.R2CloudServiceList)
                {
                    if (item.ConsolidatedRoleStatus != "Ready")
                    {
                        item.HighlightCssClass = "highlight-red";
                    }
                }

                var latestServiceR3 = model.R3CloudServiceList.OrderByDescending(x => x.CreatedDate).FirstOrDefault();
                if (latestServiceR3 != null)
                {
                    latestServiceR3.HighlightCssClass = "highlight-green";
                }

                model.R3CloudServiceList = model.R3CloudServiceList.OrderBy(x => x.Name).ThenBy(x => x.DeploymentType).ToList();

                foreach (var item in model.R3CloudServiceList)
                {
                    if (item.ConsolidatedRoleStatus != "Ready")
                    {
                        item.HighlightCssClass = "highlight-red";
                    }
                }

                return View(model);
            }
            catch (Exception ex)
            {
                // Return exception if any
                var model = new CloudServiceMetadataModel
                {
                    IsSuccssful = false,
                    ErrorMessage = ex.Message
                };

                return View(model);
            }
        }

        public ActionResult BuildPlan()
        {
            return View();
        }


        public ActionResult DeveloperScreenMap()
        {
            return View();
        }

        /// <summary>
        /// Get Xml metadata from application cache or reads it from file
        /// </summary>
        /// <returns></returns>
        public List<ServiceMetadataXmlEntity> GetXmlMetadata()
        {
            ObjectCache cache = MemoryCache.Default;
            var xmlMetaData = cache["ServiceMetadataCache"] as List<ServiceMetadataXmlEntity>;

            if (xmlMetaData != null)
            {
                return xmlMetaData;
            }
            XDocument serviceMetadataXml = XDocument.Load(Server.MapPath(@"~\Models\CloudServiceMetadata.xml"));
            //List<XElement> serviceElements =
            //    serviceMetadataXml.XPathSelectElements("CloudServices/CloudService").ToList();
            var cloudServiceElementList = (from cloudServiceXml in serviceMetadataXml.Root.Elements("CloudService")
                                           select new ServiceMetadataXmlEntity
                                           {
                                               Name =
                                                   cloudServiceXml.Element("Name") == null ? string.Empty : cloudServiceXml.Element("Name").Value,
                                               CNameUrl =
                                                   cloudServiceXml.Element("CNameUrl") == null
                                                       ? string.Empty
                                                       : cloudServiceXml.Element("CNameUrl").Value,
                                               Description =
                                                   cloudServiceXml.Element("Description") == null
                                                       ? string.Empty
                                                       : cloudServiceXml.Element("Description").Value
                                           }).ToList();

            cache["ServiceMetadataCache"] = cloudServiceElementList;

            return cloudServiceElementList;
        }
    }
}