using System;

namespace AltV.Net.Mock2.Example
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                new Mock();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }

            Console.WriteLine("Hello World!");
        }
    }
}