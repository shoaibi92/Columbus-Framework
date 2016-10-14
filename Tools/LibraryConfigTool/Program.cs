/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

using System;
using System.IO;

namespace LibraryConfigTool
{
    class Program
    {
        private static string _projectDebugOrReleaseFolder;
        private static string _projectName;
        private static string _solutionFolder;

        /// <summary>
        /// Main
        /// </summary>
        /// <param name="args"></param>
        private static void Main(string[] args)
        {
            try
            {
                foreach (var arg in args)
                {
                    if (arg.StartsWith("/projectFolder:", StringComparison.InvariantCultureIgnoreCase))
                    {
                        _projectDebugOrReleaseFolder = arg.Substring(arg.IndexOf(':') + 1);
                    }
                    else if (arg.StartsWith("/projectName:", StringComparison.InvariantCultureIgnoreCase))
                    {
                        _projectName = arg.Substring(arg.IndexOf(':') + 1);
                    }
                    else if (arg.StartsWith("/solutionFolder:", StringComparison.InvariantCultureIgnoreCase))
                    {
                        _solutionFolder = arg.Substring(arg.IndexOf(':') + 1);
                    }
                }
                var projectDll = _projectName + ".dll";
                var projectExe = _projectName + ".exe";
                var projectPdb = _projectName + ".pdb";


                #region - Commented for now. Do not remove. Copies all dlls to Assemblies 

                var projectRootFolder = Directory.GetParent(_solutionFolder + @"..\").FullName;
                var targetFolder = projectRootFolder + @"\Assemblies\";

                // To copy a folder's contents to a new location: 
                // Create a new target folder, if necessary. 
                if (!Directory.Exists(targetFolder))
                {
                    Directory.CreateDirectory(targetFolder);
                }

                // To copy a file to another location and  
                // overwrite the destination file if it already exists.
                CopyFile(_projectDebugOrReleaseFolder + projectDll, targetFolder + projectDll);
                CopyFile(_projectDebugOrReleaseFolder + projectExe, targetFolder + projectExe);
                CopyFile(_projectDebugOrReleaseFolder + projectPdb, targetFolder + projectPdb);

                //copy resource files
                CopyResources(targetFolder);

                #endregion
            }
            catch (Exception ex)
            {
                Console.Out.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// This is required to cpoy all resource files
        /// </summary>
        /// <param name="targetFolder"></param>
        private static void CopyResources(string targetFolder)
        {
            var resourceName = _projectName + ".resources.dll";
            foreach (string directory in Directory.GetDirectories(_projectDebugOrReleaseFolder))
            {
                var folder = targetFolder + new DirectoryInfo(directory).Name + @"\";
                CreateDirectory(folder);
                //Console.Out.WriteLine(folder);
                //Console.Out.WriteLine("Resource file : [{0}]", directory + @"\" + resourceName);
                CopyFile(directory + @"\" + resourceName, folder + resourceName);
            }
        }

        /// <summary>
        /// Create directory if does not exists
        /// </summary>
        /// <param name="path"></param>
        private static void CreateDirectory(string path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }
        /// <summary>
        /// copies file from souce to destination
        /// </summary>
        /// <param name="source"></param>
        /// <param name="target"></param>
        private static void CopyFile(string source, string target)
        {
            //Console.Out.WriteLine("Source : [{0}]", source);
            //Console.Out.WriteLine("Target : [{0}]", target);
            if (File.Exists(source))
            {
                File.Copy(source, target, true);
            }
        }
    }
}
