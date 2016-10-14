using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace MergeContentToWebProject
{
    public class Program
    {
        public static void Main(string[] args)
        {

            string moduleProjectFolder = null;
            string webProjectFolder =null;
            string moduleProjectFileName =null;
            string webProjectFileName =null;
            string areaName = null;

            foreach (var arg in args)
            {
                if (arg.StartsWith("/area:", StringComparison.InvariantCultureIgnoreCase))
                {
                    areaName = arg.Substring(arg.IndexOf(':') + 1);
                    Console.WriteLine("Area : " + areaName);
                }
                else if (arg.StartsWith("/projectfolder:", StringComparison.InvariantCultureIgnoreCase))
                {
                    moduleProjectFolder = arg.Substring(arg.IndexOf(':') + 1);
                    Console.WriteLine("Project Folder : " + moduleProjectFolder);
                }
                else if (arg.StartsWith("/websolutionfolder:", StringComparison.InvariantCultureIgnoreCase))
                {
                    webProjectFolder = arg.Substring(arg.IndexOf(':') + 1);
                    Console.WriteLine("Web Project Folder : " + webProjectFolder);
                }
                else if (arg.StartsWith("/projectfile:", StringComparison.InvariantCultureIgnoreCase))
                {
                    moduleProjectFileName = arg.Substring(arg.IndexOf(':') + 1);
                    Console.WriteLine("Project File : " + moduleProjectFileName);

                }
                else if (arg.StartsWith("/webprojectfile:", StringComparison.InvariantCultureIgnoreCase))
                {
                    webProjectFileName = arg.Substring(arg.IndexOf(':') + 1);
                    Console.WriteLine("Web Project File : " + webProjectFileName);

                }

            }


            if (!string.IsNullOrEmpty(moduleProjectFolder) && !string.IsNullOrEmpty(moduleProjectFileName) &&
                !string.IsNullOrEmpty(webProjectFolder) && !string.IsNullOrEmpty(webProjectFileName) &&
                !string.IsNullOrEmpty(areaName))
            {

                string moduleFolder  = new DirectoryInfo(moduleProjectFolder).FullName;
                string webFolder = new DirectoryInfo(webProjectFolder).FullName;

                Program controller = new Program();
                controller.UpdateWebProject(moduleFolder, webFolder, moduleProjectFileName, webProjectFileName, areaName);
                
            }
            else
            {
                Console.WriteLine("Usage: MergeContentToWebProject.Exe /area:<area name> /projectfolder:<Module Web Project Folder> /projectfile:<Module Web Project File Name> /websolutionfolder:<Web Project Folder> /webprojectfile:<Web Project File Name>");
            }
        }

        
        private void UpdateWebProject(
            string sourceProjectFolder, 
            string webSolutionProjectFolder, 
            string moduleProjectFileName, 
            string webProjectFileName,
            string areaName)
        {

            
            var sourceProject = new XmlDocument();

            var webProject = new XmlDocument();

            try
            {
                
                string sourceFilePath = Path.Combine(sourceProjectFolder, moduleProjectFileName);
                string targetFileName = Path.Combine(webSolutionProjectFolder, webProjectFileName);
                sourceProject.Load(sourceFilePath);
                webProject.Load(targetFileName);
                var changedWebProject = MergeSourceProjectContent(sourceProject, webProject, areaName);

                if (changedWebProject)
                {
                    webProject.Save(targetFileName);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                
            }

        }

        private string searchKeyFormat = @"areas\{0}\{1}";
        private string newKeyFormat = @"Areas\{0}\{1}";
        private string areaKeyFormat = @"areas\{0}";
        private string xmlnamespace = @"http://schemas.microsoft.com/developer/msbuild/2003";
        
        private bool MergeSourceProjectContent(XmlDocument sourceDocument,
            XmlDocument targetDocument, string areaName)
        {
            XmlNamespaceManager sourcensmgr = new XmlNamespaceManager(sourceDocument.NameTable);
            XmlNamespaceManager targetnsmgr = new XmlNamespaceManager(targetDocument.NameTable);
            
            sourcensmgr.AddNamespace("msns",xmlnamespace);
            targetnsmgr.AddNamespace("msns",xmlnamespace);

            var sourceContentNodes = sourceDocument.DocumentElement.SelectNodes("//msns:Content", sourcensmgr);
            var targetContentNodes = targetDocument.DocumentElement.SelectNodes("//msns:Content", targetnsmgr);
            var targetParentNodeSelector = targetDocument.SelectSingleNode("//msns:Content", targetnsmgr);
            bool dataModified = false;

            Dictionary<string, XmlNode> currentTargetContent = new Dictionary<string, XmlNode>();
            
            if (targetParentNodeSelector != null)
            {
                var targetParentNode = targetParentNodeSelector.ParentNode;

                if (targetParentNode != null)
                {
                    
                    // Construct a searchable Dictionary of nodes
                    // This speeds up searching nodes in the next loop
                    foreach (XmlNode currentNode in targetContentNodes)
                    {
                        string includeText = currentNode.Attributes["Include"].InnerText.ToLower();
                        currentTargetContent[includeText] = currentNode;
                    }

                    foreach (XmlNode currentNode in sourceContentNodes)
                    {
                        string includeText = currentNode.Attributes["Include"].InnerText;

                        if (includeText.IndexOf(".cshtml", StringComparison.InvariantCultureIgnoreCase) >= 0 ||
                            includeText.IndexOf(".js", StringComparison.InvariantCultureIgnoreCase) >= 0)
                        {
                            string searchKey = string.Format(searchKeyFormat, areaName.ToLower(), includeText.ToLower());
                            
                            if (currentTargetContent.ContainsKey(searchKey))
                            {
                                currentTargetContent.Remove(searchKey);
                            }
                            else 
                            {
                                string newKey = string.Format(newKeyFormat, areaName, includeText);
                                XmlElement element = targetDocument.CreateElement("Content", xmlnamespace);
                                var includeAttribute = targetDocument.CreateAttribute("Include");
                                includeAttribute.InnerText = newKey;
                                element.Attributes.Append(includeAttribute);
                                targetParentNode.AppendChild(element);
                                Console.WriteLine("Content Added " + includeText);
                                dataModified = true;
                            }
                        }
                    }

                    // Delete Content nodes from Web Project that are no longer used
                    string areaKey = string.Format(areaKeyFormat, areaName);
                    foreach (string keyToRemove in currentTargetContent.Keys)
                    {

                        if (keyToRemove.IndexOf(areaKey, StringComparison.InvariantCultureIgnoreCase) >= 0 &&
                            (keyToRemove.IndexOf(".cshtml", StringComparison.InvariantCultureIgnoreCase) >= 0 ||
                             keyToRemove.IndexOf(".js", StringComparison.InvariantCultureIgnoreCase) >= 0))
                        {
                            currentTargetContent[keyToRemove].ParentNode.RemoveChild(currentTargetContent[keyToRemove]);
                            dataModified = true;
                            Console.WriteLine("Content Deleted " + keyToRemove);
                        }
                    }
                }
            }

            return dataModified;
        }
    }
}
