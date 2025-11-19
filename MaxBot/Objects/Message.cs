using System.Text.Json.Serialization;

namespace MaxBotNET.Objects;

public class Message
{
    [JsonPropertyName("sender")]
    public Sender Sender { get; set; }

    [JsonPropertyName("recipient")]
    public Recipient Recipient { get; set; }

    [JsonPropertyName("timestamp")]
    public int? Timestamp { get; set; }

    [JsonPropertyName("link")]
    public Link Link { get; set; }

    [JsonPropertyName("body")]
    public Body Body { get; set; }

    [JsonPropertyName("stat")]
    public Stat Stat { get; set; }

    [JsonPropertyName("url")]
    public string Url { get; set; }
}
