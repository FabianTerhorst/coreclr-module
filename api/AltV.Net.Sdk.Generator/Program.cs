using System.Reflection;
using System.Text.RegularExpressions;
using AltV.Net.Sdk.Generator;

Directory.SetCurrentDirectory(Path.Combine(Path.GetDirectoryName(Assembly.GetEntryAssembly()!.Location)!, "../../../../"));

var generatorRegex = new Regex(@"(?<indent>[ \t]*)\<!-- ?#GENERATE# (?<args>.*?) ?-->");
var files = new[] {"AltV.Net.Sdk.Client/Sdk/Sdk.props", "AltV.Net.Sdk.Server/Sdk/Sdk.props", "AltV.Net.Sdk.Shared/Sdk/Sdk.props"};

foreach (var file in files)
{
    Console.WriteLine("Generating code for " + file);
    
    var content = File.ReadAllText(file);
    
    var newContent = generatorRegex.Replace(content, (match) =>
    {
        var indent = match.Groups["indent"];
        var args = match.Groups["args"].ToString().Split(" ");

        var command = args.First();
        var generator = command switch
        {
            "ImplicitUsings" => new ImplicitUsingsGenerator(),
            _ => throw new Exception($"Generator {command} not found")
        };

        var newContent = generator.Generate(args.Skip(1).ToArray());
        return indent + newContent.ReplaceLineEndings("\n" + indent);
    });

    File.WriteAllText(file, newContent);

}