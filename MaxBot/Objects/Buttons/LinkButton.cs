using System.Text.Json.Serialization;

namespace MaxBot.Objects.Buttons
{
    public class LinkButton:Button
    {
        public LinkButton(string text, string url)
        {
            Text = text;
            Url = url;
        }

        [JsonPropertyName("text")]
        public string Text { get; set; }
        [JsonPropertyName("url")]
        public string Url { get; set; }
    }
}
