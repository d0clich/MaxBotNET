using MaxBot.Objects;
using MaxBot.Objects.Types;
using System.Text.Json.Serialization;

namespace MaxBot.Models.Messages
{
    public class SendMessageRequest
    {
        [JsonPropertyName("text")]
        public string? Text { get; set; }
        [JsonPropertyName("attachments")]
        public IEnumerable<Attachment>? Attachments { get; set; }
        [JsonPropertyName("link")]
        public Link? Link { get; set; }
        [JsonPropertyName("notify")]
        public bool Notify = true;
        public FormatType? FormatType { get; set; }
    }
}
