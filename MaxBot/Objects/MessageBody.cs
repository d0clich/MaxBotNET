using System.Text.Json.Serialization;

namespace MaxBot.Objects;

public class MessageBody
{
    [JsonPropertyName("mid")]
    public string Mid { get; set; } = null!;

    [JsonPropertyName("seq")]
    public int? Seq { get; set; }

    [JsonPropertyName("text")]
    public string Text { get; set; } = null!;

    [JsonPropertyName("attachments")]
    public IEnumerable<Attachment> Attachments { get; set; } = null!;

    [JsonPropertyName("markup")]
    public IEnumerable<Markup> Markup { get; set; } = null!;
}
