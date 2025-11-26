using System.Text.Json.Serialization;
using MaxBot.Objects.Types;

namespace MaxBot.Objects.Buttons
{
    public class LinkButton:Button
    {
        public LinkButton(string text, string url)
        {
            Text = text;
            Url = url;
            Type = ButtonType.Link;
        }

        [JsonPropertyName("text")]
        public string Text { get; set; }
        [JsonPropertyName("url")]
        public string Url { get; set; }
    }
}
