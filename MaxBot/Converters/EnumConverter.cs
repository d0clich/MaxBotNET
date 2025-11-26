using MaxBot.Attributes;
using System.ComponentModel;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace MaxBot.Converters;

public class EnumConverter<T> : JsonConverter<T> where T : Enum
{
    public override T Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var value = reader.GetString();
        var fields = typeof(T).GetFields();
        foreach (var fieldInfo in fields)
        {
            var attribute = fieldInfo.GetCustomAttribute<JsonPropertyValueAttribute>();
            if (attribute == null) continue;
            
            if (attribute!.StringValue == value)
                return (T)fieldInfo.GetValue(null);
        }

        throw new InvalidEnumArgumentException();
    }

    public override void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options)
    {
        var field = typeof(T).GetField(value.ToString());
        var attribute = field?.GetCustomAttribute<JsonPropertyValueAttribute>();

        if (attribute != null)
            writer.WriteStringValue(attribute.StringValue);
        else
            writer.WriteStringValue(value.ToString());
    }
}
