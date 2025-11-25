using System.Text.Json.Serialization;

namespace MaxBot.Objects.Payloads
{
    public class ShareAttachmentPayload: Payload
    {
        [JsonPropertyName("url")]
        public string? Url { get; set; }
        [JsonPropertyName("token")]
        public string? Token { get; set; }
    }
}
