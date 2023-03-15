using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace AltV.Net.CApi.Generator;

public struct CMethod
{
    public string ReturnType;
    public string Name;
    public ulong Hash;
    public string Target;
    public CMethodParam[] Params;
    public bool NoGc;
    public bool OnlyManual;
}

public struct CMethodParam
{
    public string Type;
    /** Used for method signature hashing */
    public string TypeId;
    public string Name;
}

public class Parser
{
    private static readonly Regex ExportRegex = new(@"EXPORT_(?<target>\w+)\s+(?:(?<nogc>NO_GC)\s+)?(?:(?<onlymanual>ONLY_MANUAL)\s+)?(?:(?:const\s+)?(?<type>\S+)\s+(?<name>\S+)\s*\((?<args>.*?)\)|(?<name>\S+)\s*=\s*(?<type>\S+)\s*\(\s*\*\s*\)\s*\((?<args>.*?)\))", RegexOptions.Compiled | RegexOptions.Singleline);
    private static readonly Regex ArgsRegex = new(@"(?:const\s+)?(?:\/\**\s*(?<typeOverride>.*?)\s*\*\/\s*)?(?<type>.*?)\s*(?<name>[\w\d_\-\[\]]+)(?:,\s*|$)", RegexOptions.Compiled | RegexOptions.Singleline);
    private static readonly Regex CommentRegex = new(@"//.*?(?:$|[\n\r]+)", RegexOptions.Compiled);
    private static readonly Regex TypeExtraSpaceRegex = new(@" {2,}| +(?=[\*\&]+$)", RegexOptions.Compiled);

    public static IEnumerable<CMethod> ParseMethods(string path)
    {
        var files = Directory.GetFiles(path, "*.h", SearchOption.AllDirectories);

        foreach (var file in files)
        {
            var text = CommentRegex.Replace(File.ReadAllText(file), "");

            foreach (Match match in ExportRegex.Matches(text))
            {
                var type = match.Groups["type"].Value;
                var name = match.Groups["name"].Value;
                var target = match.Groups["target"].Value;
                var nogc = match.Groups["nogc"].Length > 0;
                var onlyManual = match.Groups["onlymanual"].Length > 0;
                var csReturnType = TypeRegistry.CsTypes.FirstOrDefault(t => t.Key == type).Value;

                if (csReturnType is null) throw new Exception($"Unknown return type \"{type}\" in method \"{name}\"");


                var args = new List<CMethodParam>();
                var matches = ArgsRegex.Matches(match.Groups["args"].Value);
                for (var i = 0; i < matches.Count; i++)
                {
                    var matchArg = matches[i];
                    var argType = TypeExtraSpaceRegex.Replace(matchArg.Groups["type"].Value, "");
                    var argName = matchArg.Groups["name"].Value;
                    var csArgName = "_" + argName;
                    if (argName.EndsWith("[]"))
                    {
                        argType += "[]";
                        csArgName = argName[..^2];
                    }

                    var csArgType = matchArg.Groups.ContainsKey("typeOverride") && matchArg.Groups["typeOverride"].Value is not ""
                        ? matchArg.Groups["typeOverride"].Value
                        : TypeRegistry.CsTypes.FirstOrDefault(t => t.Key == argType).Value;

                    if (csArgType is null) throw new Exception($"Unknown arg type \"{argType}\" in method \"{argName}\" at index {i}");

                    args.Add(new CMethodParam
                    {
                        Name = csArgName,
                        Type = csArgType,
                        TypeId = argType.Replace("const", "").Replace(" ", "")
                    });
                }

                var argumentIds = string.Join("", args.Select(e => ";" + e.TypeId));

                Console.WriteLine($"{name}{argumentIds};{type}");
                yield return new CMethod
                {
                    Name = name,
                    Hash = FnvHash.Generate($"{name}{argumentIds};{type}"),
                    ReturnType = csReturnType,
                    Params = args.ToArray(),
                    Target = target,
                    NoGc = nogc,
                    OnlyManual = onlyManual
                };
            }
        }
    }
}