using System;

namespace AltV.Net.ClientRuntime
{
    class Program
    {
        private static readonly string DefaultCode = @"
            using System;
            static class Program {
                static int Run() {
                    return 1337;
                }
            }
        ".Replace("            ", "").Trim();
        
        private static readonly string UntrustedCode = @"
            using System;
            using System.IO;
            using System.Reflection;
            static class Program {
                static int Run() {
                    string path = @""c:\temp\MyTest.txt"";
                    Console.WriteLine(""path:"" + path);
                    var bla = Activator.CreateInstance(typeof(object));
                    Console.WriteLine(bla);
                    if (!File.Exists(path)) return 1338;
                    return 1337;
                }
            }
        ".Replace("            ", "").Trim();

        static void Main(string[] args)
        {
            var result = Runtime.Execute(DefaultCode);
            Console.WriteLine("result:" + result);

            Console.WriteLine(UntrustedCode);
            result = Runtime.Execute(UntrustedCode);
            Console.WriteLine("result2:" + result);
        }
    }
}