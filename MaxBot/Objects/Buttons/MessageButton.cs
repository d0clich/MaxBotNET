using System.Text.Json.Serialization;
using MaxBot.Objects.Types;

namespace MaxBot.Objects.Buttons
{
    public class MessageButton: Button
    {
        public MessageButton(string text)
        {
            Text = text;
            Type = ButtonType.Message;
        }

        [JsonPropertyName("text")]
        public string Text { get; set; }

    }
}
