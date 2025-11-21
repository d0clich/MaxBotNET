using System.Text.Json.Serialization;

namespace MaxBot.Models.Uploads;

public class UploadsGetUrlResponse
{
    [JsonPropertyName("url")]
    public string Url { get; set; } = null!;
    [JsonPropertyName("token")]
    public string? Token { get; set; }
}