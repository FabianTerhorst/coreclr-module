using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace AltV.Net.ResourceGenerator;

public abstract class JsonResourceGenerator : ResourceGenerator
{
    public virtual JsonSerializerOptions JsonOptions => new();

    public abstract Task WriteJsonFile(string fileName, Utf8JsonWriter jsonWriter,
        JsonSerializerOptions jsonSerializerOptions);

    public override async Task WriteFile(string fileName, Stream stream)
    {
        await using var jsonWriter = new Utf8JsonWriter(stream);
        await WriteJsonFile(fileName, jsonWriter, JsonOptions);
        await jsonWriter.FlushAsync();
    }
}