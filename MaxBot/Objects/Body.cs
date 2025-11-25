using System.Text.Json.Serialization;

namespace MaxBot.Objects;

public class Body
{
    [JsonPropertyName("mid")]
    public string MessageId { get; set; }

    [JsonPropertyName("seq")]
    public long? Seq { get; set; }

    [JsonPropertyName("text")]
    public string Text { get; set; }

    [JsonPropertyName("attachments")]
    public IEnumerable<Attachment> Attachments { get; set; }

    [JsonPropertyName("markup")]
    public IEnumerable<Markup> Markup { get; set; }
}
