using System.Text.Json.Serialization;
using MaxBot.Attributes;
using MaxBot.Converters;

namespace MaxBot.Objects.Types;

[JsonConverter(typeof(EnumConverter<MessageLinkType>))]
public enum MessageLinkType
{
    [JsonPropertyValue("forward")]
    Forward,

    [JsonPropertyValue("reply")] // ← обрати внимание: "reply", а не "Reply"
    Reply
}