using System;

namespace AltV.Net.CodeGen
{
    class Program
    {
        static void Main(string[] args)
        {
            var methods = ParseExports.Parse(@"");
            try
            {
                WritePInvokes.Write(methods);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
        }
    }
}