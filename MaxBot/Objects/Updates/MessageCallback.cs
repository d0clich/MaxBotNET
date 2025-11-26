using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace MaxBot.Objects.Updates
{
    public class MessageCallback: Update
    {
        [JsonPropertyName("message")]
        public Message Message { get; set; } = null!;

        [JsonPropertyName("user_locale")]
        public string UserLocale { get; set; } = null!;
        [JsonPropertyName("callback")]
        public Callback Callback { get; set; }
    }
}
