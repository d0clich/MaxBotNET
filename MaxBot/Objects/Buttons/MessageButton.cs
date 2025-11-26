using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace MaxBot.Objects.Buttons
{
    public class MessageButton: Button
    {
        public MessageButton(string text)
        {
            Text = text;
        }

        [JsonPropertyName("text")]
        public string Text { get; set; }

    }
}
