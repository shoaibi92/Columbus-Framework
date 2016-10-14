using System;
using System.Diagnostics;
using System.IO;


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

            try
            {


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

                    Console.WriteLine("Started - Robo Copy");

                    string moduleFolder = new DirectoryInfo(moduleProjectFolder).FullName;
                    string webFolder = new DirectoryInfo(webProjectFolder).FullName;

                    RoboCopy(moduleFolder + @"Views", webFolder + @"\Areas\" + areaName + @"\Views");
                    RoboCopy(moduleFolder + @"Scripts", webFolder + @"\Areas\" + areaName + @"\Scripts");

                    Console.WriteLine("Completed - Robo Copy");
                }
                else
                {
                    Console.WriteLine(
                        "Usage: MergeContentToWebProject.Exe /area:<area name> /projectfolder:<Module Web Project Folder> /projectfile:<Module Web Project File Name> /websolutionfolder:<Web Project Folder> /webprojectfile:<Web Project File Name>");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error " + ex.Message);

                Console.WriteLine(ex);
            }
        }

        private static void RoboCopy(string source, string destination)
        {
            Console.WriteLine("Source Folder : " + source);

            Console.WriteLine("Destination Folder : " + destination);

            var proc = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "robocopy.exe",
                    Arguments = string.Format("{0} {1} *.* /MIR ^& IF %ERRORLEVEL% GTR 1 exit %ERRORLEVEL%", source, destination),
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    CreateNoWindow = true
                }
            };

           
            proc.Start();

            while (!proc.StandardOutput.EndOfStream)
            {
                string line = proc.StandardOutput.ReadLine();

                // write the out to console.
                Console.WriteLine(line);
            }

            proc.Close();
        }

    }
}
