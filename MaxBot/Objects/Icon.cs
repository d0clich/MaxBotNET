using System.Text.Json.Serialization;

namespace MaxBot.Objects;

public class Icon
{
    [JsonPropertyName("url")]
    public string Url { get; set; }
}