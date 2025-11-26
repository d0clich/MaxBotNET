using System.Text.Json.Serialization;
using MaxBot.Attributes;
using MaxBot.Converters;

namespace MaxBot.Objects.Types;

[JsonConverter(typeof(EnumConverter<ButtonType>))]
public enum ButtonType
{
    [JsonPropertyValue("callback")]
    Callback,
    [JsonPropertyValue("link")]
    Link,
    [JsonPropertyValue("message")]
    Message,
}