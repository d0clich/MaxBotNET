using System.Text.Json.Serialization;

namespace MaxBot.Objects.Payloads
{
    public class UploadedInfoPayload: Payload
    {
        [JsonPropertyName("token")]
        public string? Token { get; set; }
    }
}
