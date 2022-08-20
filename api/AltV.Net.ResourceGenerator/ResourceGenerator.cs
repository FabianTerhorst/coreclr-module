using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace AltV.Net.ResourceGenerator
{
    public abstract class ResourceGenerator
    {
        public abstract string[] Files { get; }

        public virtual string Type => "asset-pack";

        public abstract string Name { get; }

        public virtual string[] Deps { get; } = {Alt.Resource.Name};

        private string AssetResourcePath => $".{Path.DirectorySeparatorChar}resources{Path.DirectorySeparatorChar}{Name}-asset";
        
        private string AssetResourceConfigPath => $"{AssetResourcePath}{Path.DirectorySeparatorChar}resource.cfg";

        public virtual void Log(string log)
        {
            
        }
        
        public virtual void WriteConfig(Stream stream)
        {
            var config = @$"
type : {Type},
client-files : [
    {string.Join(Environment.NewLine, Files)}
]
deps: [
    {string.Join(Environment.NewLine, Deps)}
]";
            stream.Write(Encoding.UTF8.GetBytes(config).AsSpan());
        }

        public abstract Task WriteFile(string fileName, Stream stream);

        public virtual async Task Generate()
        {
            try
            {
                if (!Directory.Exists(AssetResourcePath))
                {
                    Directory.CreateDirectory(AssetResourcePath);
                }

                foreach (var file in Files)
                {
                    try
                    {
                        File.Delete(AssetResourcePath + Path.DirectorySeparatorChar + file);
                    }
                    catch (Exception exception)
                    {
                    }
                }

                try
                {
                    File.Delete(AssetResourceConfigPath);
                }
                catch (Exception exception)
                {
                }

                {
                    await using var streamWriter = new StreamWriter(AssetResourceConfigPath);
                    WriteConfig(streamWriter.BaseStream);
                    await streamWriter.FlushAsync();
                }

                foreach (var file in Files)
                {
                    try
                    {
                        await using var fileStream = File.Create(AssetResourcePath + Path.DirectorySeparatorChar + file);
                        {
                            await using var streamWriter = new StreamWriter(fileStream);
                            await WriteFile(file, streamWriter.BaseStream);
                            await streamWriter.FlushAsync();
                            Log($"{AssetResourcePath + Path.DirectorySeparatorChar + file} generated.");
                        }
                    }
                    catch (Exception exception)
                    {
                    }
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
        }
    }
}