using System.Text.Json.Serialization;

namespace MaxBotNET.Objects;

public class Sender
{
    [JsonPropertyName("user_id")]
    public int? UserId { get; set; }

    [JsonPropertyName("first_name")]
    public string FirstName { get; set; }

    [JsonPropertyName("last_name")]
    public string LastName { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("username")]
    public string Username { get; set; }

    [JsonPropertyName("is_bot")]
    public bool? IsBot { get; set; }

    [JsonPropertyName("last_activity_time")]
    public int? LastActivityTime { get; set; }
}
