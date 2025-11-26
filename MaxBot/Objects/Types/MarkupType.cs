using MaxBot.Converters;
using System.Text.Json.Serialization;

namespace MaxBot.Objects.Types;

[JsonConverter(typeof(EnumConverter<MarkupType>))]
public enum MarkupType
{
    [JsonPropertyValue("strong")]
    Strong,

    [JsonPropertyValue("emphasized")]
    Emphasized,

    [JsonPropertyValue("monospaced")]
    Monospaced,

    [JsonPropertyValue("link")]
    Link,

    [JsonPropertyValue("strikethrough")]
    Strikethrough,

    [JsonPropertyValue("underline")]
    Underline,

    [JsonPropertyValue("user_mention")]
    UserMention
}