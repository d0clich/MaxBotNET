using MaxBot.Objects.Types;
using System.Text.Json.Serialization;


namespace MaxBot.Objects;
public class Update
{
    [JsonPropertyName("update_type")]
    public UpdateType UpdateType { get; set; } = null!;

    [JsonPropertyName("timestamp")]
    public int Timestamp { get; set; }

    [JsonPropertyName("message")]
    public Message Message { get; set; } = null!;

    [JsonPropertyName("user_locale")]
    public string UserLocale { get; set; } = null!;
}
