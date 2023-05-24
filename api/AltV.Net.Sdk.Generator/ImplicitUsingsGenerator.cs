using System.Text.RegularExpressions;

namespace AltV.Net.Sdk.Generator
{
    public class ImplicitUsingsGenerator : IGenerator
    {
        private static readonly Regex NamespaceRegex = new Regex(@"namespace (?<ns>[^\s;\{]+)");
        private static readonly List<string> IgnoredNamespaces = new() { "AltV.Net.Async.RPC" };

        public string Generate(string[] args)
        {
            var usings = new HashSet<string>();

            foreach (var project in args)
            {
                // ([ \t]*)\<!-- ?#GENERATE# (.*?) ?-->
                foreach (var file in Directory.GetFiles("./" + project, "*.cs", SearchOption.AllDirectories))
                {
                    var content = File.ReadAllText(file);
                    var ns = NamespaceRegex.Matches(content);
                    foreach (Match match in ns)
                    {
                        var @namespace = match.Groups["ns"].ToString();
                        if (IgnoredNamespaces.Contains(@namespace)) continue;

                        usings.Add(@namespace);
                    }
                }
            }

            return string.Join("\n", usings.Select(e => @$"<Using Include=""{e}"" />"));
        }
    }
}