using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace MaxBot.Objects.Additional
{
    internal class MessageWrapper
    {
        [JsonPropertyName("message")]
        public Message Message { get; set; }
    }
}
