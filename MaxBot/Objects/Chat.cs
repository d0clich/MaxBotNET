using System.Text.Json.Serialization;
using MaxBot.Objects.Users;

namespace MaxBot.Objects;

public class Chat
{
    [JsonPropertyName("chat_id")]
    public long ChatId { get; set; }

    [JsonPropertyName("type")]
    public string Type { get; set; }

    [JsonPropertyName("status")]
    public string Status { get; set; }

    [JsonPropertyName("title")]
    public string Title { get; set; }

    [JsonPropertyName("icon")]
    public Icon Icon { get; set; }

    [JsonPropertyName("last_event_time")]
    public long LastEventTime { get; set; }

    [JsonPropertyName("participants_count")]
    public int ParticipantsCount { get; set; }

    [JsonPropertyName("owner_id")]
    public long OwnerId { get; set; }

    [JsonPropertyName("is_public")]
    public bool IsPublic { get; set; }

    [JsonPropertyName("link")]
    public string Link { get; set; }

    [JsonPropertyName("description")]
    public string Description { get; set; }

    [JsonPropertyName("chat_message_id")]
    public string ChatMessageId { get; set; }
    
    [JsonPropertyName("dialog_with_user")]
    public UserWithPhoto DialogWithUser { get; set; }
    
    [JsonPropertyName("pinned_message")]
    public Message PinnedMessage {get; set;}    
    
    //TODO: participants Участники чата с временем последней активности. Может быть null, если запрашивается список чатов. Какая структура - хз
}