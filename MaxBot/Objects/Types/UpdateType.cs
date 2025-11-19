namespace MaxBotNET.Objects.Types;

public class UpdateType : IEquatable<UpdateType>
{
    public static readonly UpdateType MessageCreated = new UpdateType("message_created");
    public static readonly UpdateType MessageCallback = new UpdateType("message_callback");
    public static readonly UpdateType MessageEdited = new UpdateType("message_edited");
    public static readonly UpdateType MessageRemoved = new UpdateType("message_removed");
    public static readonly UpdateType BotAdded = new UpdateType("bot_added");
    public static readonly UpdateType BotRemoved = new UpdateType("bot_removed");
    public static readonly UpdateType DialogMuted = new UpdateType("dialog_muted");
    public static readonly UpdateType DialogUnmuted = new UpdateType("dialog_unmuted");
    public static readonly UpdateType DialogCleared = new UpdateType("dialog_cleared");
    public static readonly UpdateType DialogRemoved = new UpdateType("dialog_removed");
    public static readonly UpdateType UserAdded = new UpdateType("user_added");
    public static readonly UpdateType UserRemoved = new UpdateType("user_removed");
    public static readonly UpdateType BotStarted = new UpdateType("bot_started");
    public static readonly UpdateType BotStopped = new UpdateType("bot_stopped");
    public static readonly UpdateType ChatTitleChanged = new UpdateType("chat_title_changed");
    public static readonly UpdateType MessageChatCreated = new UpdateType("message_chat_created");

    private readonly string _value;

    private UpdateType(string value)
    {
        _value = value;
    }

    public override string ToString()
    {
        return _value;
    }

    public override bool Equals(object obj)
    {
        return obj is UpdateType other && _value.Equals(other._value);
    }

    public bool Equals(UpdateType other)
    {
        return other != null && _value.Equals(other._value);
    }

    public override int GetHashCode()
    {
        return _value.GetHashCode();
    }

    public static bool operator ==(UpdateType left, UpdateType right)
    {
        if (left is null) return right is null;
        return left.Equals(right);
    }

    public static bool operator !=(UpdateType left, UpdateType right)
    {
        return !(left == right);
    }
}
