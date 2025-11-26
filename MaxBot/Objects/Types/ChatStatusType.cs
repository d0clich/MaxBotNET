using System.Text.Json.Serialization;
using MaxBot.Attributes;
using MaxBot.Converters;

namespace MaxBot.Objects.Types;

[JsonConverter(typeof(EnumConverter<ChatStatusType>))]
public enum ChatStatusType
{
    [JsonPropertyValue("active")]
    Active,
    [JsonPropertyValue("removed")]
    Removed,
    [JsonPropertyValue("left")]
    Left,
    [JsonPropertyValue("closed")]
    Closed
}