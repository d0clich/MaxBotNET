using System.Text.Json.Serialization;
using MaxBot.Converters;
using MaxBot.Objects.Types;
using MaxBot.Objects.Updates;

namespace MaxBot.Objects;

[JsonConverter(typeof(UpdateConverter))]
public class Update
{
    [JsonPropertyName("update_type")]
    public UpdateType UpdateType { get; set; }

    [JsonPropertyName("timestamp")]
    public long Timestamp { get; set; }

    [JsonIgnore]
    public MessageEdited? MessageEdited => this as MessageEdited;
    [JsonIgnore]
    public MessageRemoved? MessageRemoved => this as MessageRemoved;
    [JsonIgnore]
    public MessageCreated? MessageCreated => this as MessageCreated;
    [JsonIgnore]
    public MessageCallback? MessageCallback => this as MessageCallback;
    [JsonIgnore]
    public BotAdded? BotAdded => this as BotAdded;
    [JsonIgnore]
    public BotRemoved? BotRemoved => this as BotRemoved;
}
