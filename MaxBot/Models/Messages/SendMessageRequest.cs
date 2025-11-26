using System.Text.Json.Serialization;
using MaxBot.Objects;
using MaxBot.Objects.Types;

namespace MaxBot.Models.Messages
{
    internal class SendMessageRequest
    {
        [JsonPropertyName("text")]
        public string? Text { get; set; }
        [JsonPropertyName("attachments")]
        public IEnumerable<Attachment>? Attachments { get; set; }
        [JsonPropertyName("link")]
        public Link? Link { get; set; }
        [JsonPropertyName("notify")]
        public bool Notify = true;
        [JsonPropertyName("format")]
        public FormatType? Format { get; set; }
    }
}
