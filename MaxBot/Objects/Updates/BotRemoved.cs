using MaxBot.Objects.Users;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace MaxBot.Objects.Updates
{
    public class BotRemoved:Update
    {
        [JsonPropertyName("chat_id")]
        public long ChatId { get; set; }
        [JsonPropertyName("user")]
        public User User { get; set; }
        [JsonPropertyName("is_channel")]
        public bool IsChannel { get; set; }
    }
}
