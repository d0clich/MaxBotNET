using System.Text.Json.Serialization;
using MaxBot.Objects.Users;

namespace MaxBot.Objects.Updates;

public class BotStopped:Update  
{
    [JsonPropertyName("chat_id")]
    public long ChatId { get; set; }
    [JsonPropertyName("user")]
    public User User { get; set; }
    [JsonPropertyName("user_locale")]
    public string UserLocale{get; set;}
}