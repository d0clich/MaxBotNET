using System.Text.Json.Serialization;

namespace MaxBotNET.Objects;

public class Payload
{
    [JsonPropertyName("photo_id")]
    public int? PhotoId { get; set; }

    [JsonPropertyName("token")]
    public string Token { get; set; }

    [JsonPropertyName("url")]
    public string Url { get; set; }
}
