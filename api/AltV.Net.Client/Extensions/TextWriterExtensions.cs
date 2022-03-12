using System.Text;
using AltV.Net.Client.Events;

namespace AltV.Net.Client.Extensions;

public class AltTextWriter : TextWriter
{
    public override Encoding Encoding { get; } = Encoding.UTF8;
    
    public override void WriteLine(string? value)
    {
        if (value == null) return;
        Alt.LogInfo(value);
    }
}

public class AltErrorTextWriter : TextWriter
{
    public override Encoding Encoding { get; } = Encoding.UTF8;
    
    public override void WriteLine(string? value)
    {
        if (value == null) return;
        Alt.LogError(value);
    }
}