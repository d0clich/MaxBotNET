using System.Text.Json.Serialization;

namespace MaxBot.Objects.Payloads
{
    public class PhotoAttachmentRequestPayload: Payload
    {
        [JsonPropertyName("url")]
        public string? Url { get; set; }
        [JsonPropertyName("token")]
        public string? Token { get; set; }
        [JsonPropertyName("photos")]
        public string? Photos { get; set; } // object Nullable optional?????
    }
}
