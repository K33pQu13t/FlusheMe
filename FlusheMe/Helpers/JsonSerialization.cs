using System.Text;
using System.Text.Json;

namespace FlusheMe.FlusheMe.Helpers;

public static class JsonSerialization
{
    private static JsonSerializerOptions _defaultOptions = new()
    {
        PropertyNameCaseInsensitive = true,
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        WriteIndented = true,
        IncludeFields = true,
        AllowTrailingCommas = true
    };

    public static object? Deserialize(string filePath, Type type)
    {
        using (StreamReader file = File.OpenText(Path.GetFullPath(filePath)))
        {
            return JsonSerializer.Deserialize(file.BaseStream, type, _defaultOptions);
        }
    }

    public static void Serialize(string filePath, object obj)
    {
        if (obj == null)
        {
            return;
        }

        using (FileStream fs = new FileStream(filePath, FileMode.Create))
        {
            string json = JsonSerializer.Serialize(obj, typeof(object), _defaultOptions);
            fs.Write(new UTF8Encoding(true).GetBytes(json));
        }
    }
}