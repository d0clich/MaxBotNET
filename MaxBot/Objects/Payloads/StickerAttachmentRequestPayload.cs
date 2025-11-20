using System.Text.Json.Serialization;

namespace MaxBot.Objects.Payloads
{
    public class StickerAttachmentRequestPayload : Payload
    {
        [JsonPropertyName("code")]
        public string Code { get; set; } = null!;
    }
}
