using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace MaxBot.Models
{
    internal class SuccessResponse
    {
        [JsonPropertyName("success")]
        public bool Success { get; set; }
        [JsonPropertyName("message")]
        public string? Message { get; set; }
    }
}
