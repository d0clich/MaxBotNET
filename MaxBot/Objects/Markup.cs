using MaxBot.Objects.Types;
using System.Text.Json.Serialization;

namespace MaxBot.Objects;
public class Markup
{
    [JsonPropertyName("type")]
    public MarkupType Type { get; set; }

    [JsonPropertyName("from")]
    public int? From { get; set; }

    [JsonPropertyName("length")]
    public int? Length { get; set; }
}
