using System.Text.Json.Serialization;

namespace MaxBotNET.Objects;

public class MessageBody
{
    [JsonPropertyName("mid")]
    public string Mid { get; set; }

    [JsonPropertyName("seq")]
    public int? Seq { get; set; }

    [JsonPropertyName("text")]
    public string Text { get; set; }

    [JsonPropertyName("attachments")]
    public List<Attachment> Attachments { get; set; }

    [JsonPropertyName("markup")]
    public List<Markup> Markup { get; set; }
}
