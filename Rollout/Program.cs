using Quokka.RTL;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace Rollout
{
    class Program
    {
        static string RTLProjectLocation => Path.Combine(RTLModuleHelper.SolutionLocation(), "Quokka.RTL");

        static string RTLProjectPath => Path.Combine(RTLProjectLocation, "Quokka.RTL.csproj");
        
        static string IncrementVersion()
        {
            var content = File.ReadAllText(RTLProjectPath);
            var xProject = XDocument.Parse(content);
            var version = xProject.Root
                .Elements("PropertyGroup")
                .SelectMany(g => g.Elements())
                .Where(e => e.Name == "Version")
                .First();
            var versionValue = version.Value;
            var versionParts = versionValue.Split(".");
            versionParts[versionParts.Length - 1] = $"{int.Parse(versionParts.Last()) + 1}";
            version.Value = string.Join(".", versionParts);
            xProject.Save(RTLProjectPath);
            return version.Value;
        }

        static void Build()
        {
            Directory.SetCurrentDirectory(RTLProjectLocation);

            var proc = Process.Start(new ProcessStartInfo()
            {
                FileName = @"dotnet",
                Arguments = "build -c:Release",
                UseShellExecute = true
            });
            proc.WaitForExit();
            if (proc.ExitCode != 0)
                throw new Exception($"Build failed");
        }

        static void Copy(string version)
        {
            var nupkg = Path.Combine(RTLProjectLocation, "bin", "Release", $"Quokka.RTL.{version}.nupkg");
            if (!File.Exists(nupkg))
                throw new FileNotFoundException(nupkg);
            File.Copy(nupkg, Path.Combine(@"c:\code\LocalNuget", Path.GetFileName(nupkg)));
        }

        static void Upgrade(string version)
        {
            var solutions = new[]
            {
                "qusoc",
                "Quokka",
                "QuokkaEvaluiation"
            };

            foreach (var solution in solutions)
            {
                var path = Path.Combine(@"c:\code", solution);
                if (!Directory.Exists(path))
                    continue;

                var projects = Directory.EnumerateFiles(path, "*.csproj", SearchOption.AllDirectories);
                foreach (var proj in projects)
                {
                    var xProj = XDocument.Load(proj);
                    var modified = false;
                    var itemGroups = xProj.Root.Elements("ItemGroup");
                    var packages = itemGroups.SelectMany(g => g.Elements("PackageReference"));
                    foreach (var rtl in packages.Where(p => p.Attribute("Include").Value == "Quokka.RTL"))
                    {
                        rtl.Attribute("Version").Value = version;
                        modified = true;
                    }
                    if (modified)
                    {
                        Console.WriteLine(proj);
                        xProj.Save(proj);
                    }
                }
            }
        }

        static void Main(string[] args)
        {
            var version = IncrementVersion();
            Build();
            Copy(version);
            Upgrade(version);
        }
    }
}
