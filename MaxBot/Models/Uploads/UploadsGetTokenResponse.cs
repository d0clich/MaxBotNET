using System.Text.Json.Serialization;

namespace MaxBot.Models.Uploads;

public class UploadsGetTokenResponse
{
    [JsonPropertyName("token")]
    public string Token { get; set; } = null!;
}