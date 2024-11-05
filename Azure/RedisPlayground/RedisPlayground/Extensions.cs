using System.IO.Compression;
using System.Text;

namespace RedisPlayground;

public static class Extensions
{
    public static string Decompress(string s)
    {
        var bytes = Convert.FromBase64String(s);
        using var memoryStreamInput = new MemoryStream(bytes);
        using var memoryStreamOutput = new MemoryStream();
        using var gzipStream = new GZipStream(memoryStreamInput, CompressionMode.Decompress);
        gzipStream.CopyTo(memoryStreamOutput);
        return Encoding.Unicode.GetString(memoryStreamOutput.ToArray());
    }
}