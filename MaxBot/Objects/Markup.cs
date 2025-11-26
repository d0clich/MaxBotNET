using System.Text.Json.Serialization;
using MaxBot.Objects.Types;

namespace MaxBot.Objects;
public class Markup
{
    [JsonPropertyName("type")]
    public MarkupType Type { get; set; }

    [JsonPropertyName("from")]
    public long? From { get; set; }

    [JsonPropertyName("length")]
    public long? Length { get; set; }
}
