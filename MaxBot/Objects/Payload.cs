using System.Text.Json.Serialization;

namespace MaxBot.Objects;

public class Payload
{
    [JsonPropertyName("photo_id")]
    public int? PhotoId { get; set; }

    [JsonPropertyName("token")]
    public string Token { get; set; } = null!;

    [JsonPropertyName("url")]
    public string Url { get; set; } = null!;
}
