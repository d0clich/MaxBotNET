using System.Text.Json.Serialization;
using MaxBot.Attributes;
using MaxBot.Converters;

namespace MaxBot.Objects.Types
{
    [JsonConverter(typeof(EnumConverter<FormatType>))]
    public enum FormatType
    {
        [JsonPropertyValue("html")]
        HTML,

        [JsonPropertyValue("markdown")]
        Markdown
    }
}
