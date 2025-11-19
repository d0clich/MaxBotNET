using System.Collections.Concurrent;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace MaxBot.Objects.Types;

public abstract class BaseType<T> : IEquatable<T> where T : BaseType<T>
{
    private readonly string _value;
    private static readonly Dictionary<string, T> _instances = new();

    protected BaseType(string value)
    {
        _value = value ?? throw new ArgumentNullException(nameof(value));
        _instances[_value] = (T)this;
    }

    public override string ToString() => _value;

    public override bool Equals(object obj) => obj is BaseType<T> other && _value.Equals(other._value);
    public bool Equals(T other) => other != null && _value.Equals(other._value);
    public override int GetHashCode() => _value.GetHashCode();

    public static bool operator ==(BaseType<T> left, BaseType<T> right)
    {
        if (left is null) return right is null;
        return left.Equals(right);
    }

    public static bool operator !=(BaseType<T> left, BaseType<T> right)
    {
        return !(left == right);
    }

    public static implicit operator string(BaseType<T> enumValue) => enumValue?._value;
    public static explicit operator BaseType<T>(string value) => FromString(value);

    public static T FromString(string value)
    {
        if (string.IsNullOrEmpty(value)) return null;

        if (_instances.TryGetValue(value, out var instance))
            return instance;

        throw new ArgumentException($"Invalid value '{value}' for enum {typeof(T).Name}");
    }

    public static T FromString(string value, T defaultValue)
    {
        if (string.IsNullOrEmpty(value)) return defaultValue;

        if (_instances.TryGetValue(value, out var instance))
            return instance;

        return defaultValue;
    }
}

public class BaseTypeConverter<T> : JsonConverter<T> where T : BaseType<T>
{
    public override T Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var value = reader.GetString();
        return BaseType<T>.FromString(value, null);
    }

    public override void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value?.ToString());
    }
}