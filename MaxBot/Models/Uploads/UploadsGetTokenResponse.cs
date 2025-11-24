using System.Text.Json.Serialization;

namespace MaxBot.Models.Uploads;

internal class UploadsGetTokenResponse
{
    [JsonPropertyName("token")]
    public string Token { get; set; } = null!;
}