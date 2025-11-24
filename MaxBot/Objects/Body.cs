using System.Text.Json.Serialization;

namespace MaxBot.Objects;

public class Body
{
    [JsonPropertyName("mid")]
    public string Mid { get; set; }

    [JsonPropertyName("seq")]
    public long? Seq { get; set; }

    [JsonPropertyName("text")]
    public string Text { get; set; }

    [JsonPropertyName("attachments")]
    public List<Attachment> Attachments { get; set; }

    [JsonPropertyName("markup")]
    public List<Markup> Markup { get; set; }
}
