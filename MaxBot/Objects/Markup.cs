using System.Text.Json.Serialization;

namespace MaxBotNET.Objects;
public class Markup
{
    [JsonPropertyName("type")]
    public string Type { get; set; }

    [JsonPropertyName("from")]
    public int? From { get; set; }

    [JsonPropertyName("length")]
    public int? Length { get; set; }
}
