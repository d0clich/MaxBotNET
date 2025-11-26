using System.Text.Json.Serialization;
using MaxBot.Objects;

namespace MaxBot.Models.Messages
{
    internal class MessageWrapper
    {
        [JsonPropertyName("message")]
        public Message Message { get; set; }
    }
}
