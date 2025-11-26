using System.Text.Json;
using System.Text.Json.Serialization;
using MaxBot.Objects;
using MaxBot.Objects.Types;
using MaxBot.Objects.Updates;

namespace MaxBot.Converters
{
    public class UpdateConverter : JsonConverter<Update>
    {
        public override Update? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            using var doc = JsonDocument.ParseValue(ref reader);
            var root = doc.RootElement;

            if (!root.TryGetProperty("update_type", out var typeElement))
                throw new JsonException("Missing update_type");

            var updateType = typeElement.Deserialize<UpdateType>(options);

            return updateType switch
            {
                UpdateType.MessageCallback => root.Deserialize<MessageCallback>(options),
                UpdateType.MessageCreated => root.Deserialize<MessageCreated>(options),
                UpdateType.MessageEdited => root.Deserialize<MessageEdited>(options),
                UpdateType.MessageRemoved => root.Deserialize<MessageRemoved>(options),
                UpdateType.BotAdded => root.Deserialize<BotAdded>(options),
                UpdateType.BotRemoved => root.Deserialize<BotRemoved>(options),
                UpdateType.BotStarted => root.Deserialize<BotStarted>(options),
                UpdateType.BotStopped => root.Deserialize<BotStopped>(options),
                UpdateType.ChatTitleChanged => root.Deserialize<ChatTitleChanged>(options),
                UpdateType.MessageChatCreated => root.Deserialize<MessageChatCreated>(options),
                _ => throw new JsonException($"Unsupported update_type: {updateType}")
            };
        }

        public override void Write(Utf8JsonWriter writer, Update value, JsonSerializerOptions options)
        {
            JsonSerializer.Serialize(writer, value, value.GetType(), options);
        }
    }
}
