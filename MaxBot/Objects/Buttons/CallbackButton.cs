using MaxBot.Objects.Types;
using System.Text.Json.Serialization;

namespace MaxBot.Objects.Buttons
{
    public class CallbackButton : Button
    {
        public CallbackButton(string text, string payload, CallbackButtonIntent intent = CallbackButtonIntent.Default)
        {
            Text = text;
            Payload = payload;
            Intent = intent;
        }

        [JsonPropertyName("text")]
        public string Text { get; set; }
        [JsonPropertyName("payload")]
        public string Payload {get;set;}
        [JsonPropertyName("intent")]
        public CallbackButtonIntent Intent { get; set;}
    }
}
