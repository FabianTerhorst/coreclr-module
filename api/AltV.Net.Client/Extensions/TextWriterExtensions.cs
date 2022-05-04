using System.Text;

namespace AltV.Net.Client.Extensions;

public class AltTextWriter : TextWriter
{
    public override Encoding Encoding { get; } = Encoding.UTF8;

    private string buffer = "";
    public override void Write(char value)
    {
        if (value is '\n')
        {
            Alt.LogInfo(buffer);
            buffer = "";
            return;
        }

        buffer += value;
    }

    public override void WriteLine(string? value)
    {
        if (value == null) return;
        Alt.LogInfo(value);
    }
}
public class AltErrorTextWriter : TextWriter
{
    public override Encoding Encoding { get; } = Encoding.UTF8;

    private string buffer = "";
    public override void Write(char value)
    {
        if (value is '\n' or '\r')
        {
            Alt.LogError(buffer);
            buffer = "";
            return;
        }

        buffer += value;
    }

    public override void WriteLine(string? value)
    {
        if (value == null) return;
        Alt.LogError(value);
    }
}