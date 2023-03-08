using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace FlusheMe.Services.Converters;

public class NullableDateTimeJsonConverter : JsonConverter<DateTime?>
{
    private const string Format = "dd.MM.yyyy HH:mm:ss";

    public override DateTime? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        return reader.GetString() is string value
            && DateTime.TryParseExact(value, Format, CultureInfo.InvariantCulture, DateTimeStyles.None, out var result)
                ? result : null;
    }

    public override void Write(Utf8JsonWriter writer, DateTime? dateTime, JsonSerializerOptions options)
    {
        if (dateTime is null)
        {
            writer.WriteNullValue();
            return;
        }
        
            writer.WriteStringValue(dateTime.Value.ToString(Format, CultureInfo.InvariantCulture));
    }
}

