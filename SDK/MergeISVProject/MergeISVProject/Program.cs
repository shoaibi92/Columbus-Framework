using Microsoft.VisualBasic.FileIO;
using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.IO;

namespace MergeISVProject
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length < 5)
            {
                Console.WriteLine("Missing parameters");
                Console.WriteLine("Usage: MergeISVProject.exe solutionFileName WebProjectPath MenuFileName ConfigurationName FrameworkDir");
                return;
            }
            string pathFrom = args[1];
            string menuFileName = args[2];
            string configName = args[3];
            string pathFramework = args[4];
            string moduleId = menuFileName.Substring(0, 2);

            var pathSageWeb = GetSage300OnlinePath();

            // compile the views and copy to sage web
            if (configName.ToLower() == "release" && !string.IsNullOrEmpty(pathSageWeb))
            {
                CopyFiles(pathFrom, pathSageWeb, menuFileName);
                CompiledCopyFiles(pathFrom, moduleId, pathSageWeb, pathFramework);
            }

        }
        /// <summary>
        /// Copy files to Sage online web directories
        /// </summary>
        /// <param name="pathFrom"></param>
        /// <param name="pattern"></param>
        /// <param name="pathTo"></param>
        /// <param name="overwrite"></param>
        private static void CopyFiles(string pathFrom, string pattern, string pathTo, bool overwrite)
        {
            foreach (var file in Directory.GetFiles(pathFrom, pattern))
            {
                var fileName = Path.GetFileName(file);
                var pathFile = Path.Combine(pathTo, fileName);
                File.Copy(file, pathFile, overwrite);
            }
        }

        /// <summary>
        /// Compiled the views and copy compiled files to Sage online web directories
        /// </summary>
        /// <param name="pathFrom"></param>
        /// <param name="moduleId"></param>
        /// <param name="pathSageWeb"></param>
        /// <param name="pathFramework"></param>
        private static void CompiledCopyFiles(string pathFrom, string moduleId, string pathSageWeb, string pathFramework)
        {
            var pathDeploy = Path.Combine(pathFrom, "Deploy");
            if (Directory.Exists(pathDeploy))
            {
                Directory.Delete(pathDeploy, true);
            }
            Directory.CreateDirectory(pathDeploy);

            var pathSource = Path.Combine(pathDeploy, "Source");
            var pathBuild = Path.Combine(pathDeploy, "Build");
            var pathBinFrom = Path.Combine(pathFrom, "Bin");
            var pathBinTo = Path.Combine(pathSource, "Bin");
            var pathAreas = Path.Combine(pathSource, "Areas");
            var pathAreaFrom = Path.Combine(pathFrom, @"Areas\" + moduleId + @"\Views");
            var pathAreaTo = Path.Combine(pathSource, @"Areas\" + moduleId + @"\Views");

            // prepare compiled directories and files
            Directory.CreateDirectory(pathSource);
            Directory.CreateDirectory(pathBinTo);
            Directory.CreateDirectory(pathAreas);
            Directory.CreateDirectory(pathAreaTo);

            File.Copy(Path.Combine(pathFrom, "Web.config"), Path.Combine(pathSource, "Web.config"));
            FileSystem.CopyDirectory(pathAreaFrom, pathAreaTo);

            string[] patterns = { "System.*.dll", "Sage.CA.SBS.ERP.*.dll", "*.Web.dll", "*." + moduleId + ".*.dll" };
            foreach (var pattern in patterns)
            {
                CopyFiles(pathBinFrom, pattern, pathBinTo, true);
            }

            // compile the razors views 
            var p = new Process();
            p.StartInfo.FileName = Path.Combine(pathFramework, "aspnet_compiler.exe");
            p.StartInfo.Arguments = "-v / -p \"" + pathSource + "\" -c -fixednames \"" + pathBuild + "\"";
            p.Start();
            p.WaitForExit();

            //copy compiled files to sage online web area and bin directory
            var pathBuildView = Path.Combine(pathBuild, @"Areas\" + moduleId + @"\Views");
            var pathSageView = Path.Combine(pathSageWeb, @"Online\Web\Areas\" + moduleId + @"\Views");
            FileSystem.CopyDirectory(pathBuildView, pathSageView, true);

            var pathBuildBin = Path.Combine(pathBuild, "bin");
            var pathSageBin = Path.Combine(pathSageWeb, @"Online\Web\bin");

            string[] ps = { "*.compiled", "App_Web_*.dll", "*.Web.dll", "*." + moduleId + ".*.dll" };
            foreach (var pattern in ps)
            {
                CopyFiles(pathBuildBin, pattern, pathSageBin, true);
            }

            // remove temp deploy build directory
            Directory.Delete(pathDeploy, true);
        }

        /// <summary>
        /// Get Sage online installed path
        /// </summary>
        /// <returns></returns>
        private static string GetSage300OnlinePath()
        {
            const string sageRegKey = "SOFTWARE\\ACCPAC International, Inc.\\ACCPAC\\Configuration";
            var key = Registry.LocalMachine.OpenSubKey(sageRegKey);
            return (key == null) ? string.Empty : key.GetValue("Programs").ToString();
        }

        /// <summary>
        /// Copy bootStrapper, menuDetails and scripts files
        /// </summary>
        /// <param name="pathFrom"></param>
        /// <param name="pathTo"></param>
        /// <param name="menuFileName"></param>
        private static void CopyFiles(string pathFrom, string pathTo, string menuFileName)
        {
            const string searhPattern = "*bootstrapper.xml";
            var pathWeb = Path.Combine(pathTo, "OnLine", "Web");
            if (!Directory.Exists(pathWeb))
            {
                return;
            }

            // Copy bootstrapper.xml file
            string[] bootFiles = Directory.GetFiles(pathFrom, searhPattern);
            foreach (var srcfile in bootFiles)
            {
                var fileName = Path.GetFileName(srcfile);
                var desFile = Path.Combine(pathWeb, fileName);
                File.Copy(srcfile, desFile, true);
            }

            // Copy menu file to App_Data menuDetails and all sub directory
            string pathMenuFrom = Path.Combine(pathFrom, menuFileName);
            string pathMenuDir = Path.Combine(pathWeb, "App_Data", "MenuDetail");
            string pathMenuTo = Path.Combine(pathMenuDir, menuFileName);
            if (Directory.Exists(pathMenuDir))
            {
                File.Copy(pathMenuFrom, pathMenuTo, true);
                foreach (var dir in Directory.GetDirectories(pathMenuDir))
                {
                    var pathMenuSubTo = Path.Combine(dir, menuFileName);
                    File.Copy(pathMenuFrom, pathMenuSubTo, true);
                }
            }

            // Copy areas scripts files
            string pathAreaDir = Path.Combine(pathFrom, "Areas");
            if (Directory.Exists(pathAreaDir))
            {
                foreach (var dir in Directory.GetDirectories(pathAreaDir))
                {
                    if (!dir.EndsWith("Core") && !dir.EndsWith("Shared"))
                    {
                        var paths = dir.Split('\\');
                        var pathSubArea = Path.Combine(pathWeb, "Areas", paths[paths.Length - 1]);
                        var pathFromScripts = Path.Combine(dir, "Scripts");
                        var pathToScripts = Path.Combine(pathSubArea, "Scripts");
                        FileSystem.CopyDirectory(pathFromScripts, pathToScripts, true);
                    }
                }
            }
        }

    }
}
