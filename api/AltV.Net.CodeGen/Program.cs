using System;
using System.IO;
using System.Linq;

namespace AltV.Net.CodeGen
{
    class Program
    {
        static void Main(string[] args)
        {
            var files = Directory.GetFiles(
                Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.Parent.Parent.FullName +
                Path.DirectorySeparatorChar + "runtime" + Path.DirectorySeparatorChar + "src" +
                Path.DirectorySeparatorChar + "altv-c-api/");

            var genDirectory = Directory.GetCurrentDirectory() + Path.DirectorySeparatorChar + "gen" +
                               Path.DirectorySeparatorChar;
            if (Directory.Exists(genDirectory))
            {
                Directory.Delete(genDirectory, true);
            }

            Directory.CreateDirectory(genDirectory);
            try
            {
                foreach (var file in files)
                {
                    if (!file.EndsWith(".h")) continue;
                    var methods = ParseExports.Parse(File.ReadAllText(file));
                    var methodsOutput = WritePInvokes.Write(methods);
                    if (methodsOutput.Length == 0) continue;
                    File.WriteAllText(
                        genDirectory + GetAltNativeFileName(Path.GetFileName(file)),
                        methodsOutput);
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
        }

        private static string GetAltNativeFileName(string fileName)
        {
            var newFileName = fileName.Replace(".h", ".cs").FirstCharToUpper();
            var indexOf = newFileName.IndexOf("_", StringComparison.Ordinal);
            //TODO: only works with one _ in string
            if (indexOf != -1)
            {
                var oldNoneUpperCase = newFileName[indexOf + 1];
                var upperCaseString = char.ToUpper(oldNoneUpperCase).ToString();
                newFileName = newFileName.Replace("_" + oldNoneUpperCase, upperCaseString);
            }

            return "AltV." + newFileName;
        }
    }
}

public static class StringExtensions
{
    public static string FirstCharToUpper(this string input) =>
        input switch
        {
            null => throw new ArgumentNullException(nameof(input)),
            "" => throw new ArgumentException($"{nameof(input)} cannot be empty", nameof(input)),
            _ => input.First().ToString().ToUpper() + input.Substring(1)
        };
}