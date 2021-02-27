using Quokka.Rollout;
using System.IO;
using System.Linq;

namespace rollout
{
    class Program
    {
        static void Main(string[] args)
        {
            var solutions = new[]
            {
                "qusoc",
                "Quokka",
                "QuokkaEvaluation"
            };

            RolloutProcess.Run(new RolloutConfig()
            {
                ProjectPath = Path.Combine(RolloutTools.SolutionLocation(), "Quokka.RTL", "Quokka.RTL.csproj"),
                LocalPublishLocation = @"c:\code\LocalNuget",
                Nuget = new NugetPushConfig()
                {
                    APIKeyLocation = @"c:\code\LocalNuget\nuget.key.zip",
                    APIKeyLocationRequiredPassword = true
                },
                ReferenceFolders = solutions.Select(s => Path.Combine(@"c:\code", s)).ToList()
            });
        }
    }
}
