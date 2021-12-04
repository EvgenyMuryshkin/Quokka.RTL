using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Quokka.RTL.SourceGenerators
{
    class Tools
    {
        public static List<string> AllTypes = new List<string>() { "bool", "byte", "sbyte", "ushort", "short", "uint", "int", "ulong", "long" };
        public static List<string> OpTypes => new List<string>() { "bool", "byte", "sbyte", "ushort", "short", "uint", "int" };
        public static HashSet<string> signedTypes = new HashSet<string>() { "sbyte", "short", "int", "long" };

        public static string BoundingType(string op1, string op2)
        {
            var idx1 = AllTypes.IndexOf(op1);
            var idx2 = AllTypes.IndexOf(op2);
            return AllTypes[Math.Max(idx1, idx2)];
        }

        static string PathToSolution(string start = null)
        {
            start = start ?? Environment.CurrentDirectory;

            if (Path.GetPathRoot(start) == start)
                throw new Exception("Solution folder not found");

            if (Directory.EnumerateFiles(start, "*.sln").Any())
            {
                return start;
            }

            return PathToSolution(Path.GetDirectoryName(start));
        }

        public static void EnsureDirectoryExists(string path)
        {
            if (string.IsNullOrWhiteSpace(path))
                return;

            EnsureDirectoryExists(Path.GetDirectoryName(path));

            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
        }

        public static void WriteAllTextIfChanged(string path, string content)
        {
            EnsureDirectoryExists(Path.GetDirectoryName(path));

            var existingContent = File.Exists(path) ? File.ReadAllText(path) : null;

            if (existingContent != content)
            {
                Console.WriteLine($"Writing {path}, {content.Length} bytes");
                File.WriteAllText(path, content);
            }

        }
        public static string BitArraySourcePath => Path.Combine(PathToSolution(), @"Quokka.RTL/RTLBitArray");
        public static string VerilogSourcePath => Path.Combine(PathToSolution(), @"Quokka.RTL/Verilog/generated");
        public static string TestsPath => Path.Combine(PathToSolution(), @"Quokka.RTL.Tests/RTLBitArrayTests");
    }
}
