using System.Text.Json.Serialization;
using MaxBot.Objects.Users;

namespace MaxBot.Objects;

public class Message
{
    [JsonPropertyName("sender")]
    public User Sender { get; set; } = null!;

    [JsonPropertyName("recipient")]
    public Recipient Recipient { get; set; } = null!;

    [JsonPropertyName("timestamp")]
    public long? Timestamp { get; set; }

    [JsonPropertyName("link")]
    public Link Link { get; set; } = null!;

    [JsonPropertyName("body")]
    public Body Body { get; set; } = null!;

    [JsonPropertyName("stat")]
    public Stat Stat { get; set; } = null!;

    [JsonPropertyName("url")]
    public string Url { get; set; } = null!;
}
