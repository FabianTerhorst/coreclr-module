using System;
using System.Linq;

namespace AltV.Net.CApi.Generator;

public static class StringExtensions
{
    public static string ForceCapitalize(this string input)
    {
        ArgumentNullException.ThrowIfNull(input);
        if (input.Length < 2) return input.ToUpper();
        return input.First().ToString().ToUpper() + input[1..].ToLower();
    }
}