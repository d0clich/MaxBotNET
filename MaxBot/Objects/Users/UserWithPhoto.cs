using System.Text.Json.Serialization;

namespace MaxBot.Objects.Users;

public class UserWithPhoto:User
{
    [JsonPropertyName("description")]
    public string Description { get; set; }
    [JsonPropertyName("avatar_url")]
    public string AvatarUrl { get; set; }
    [JsonPropertyName("full_avatar_url")]
    public string FullAvatarUrl { get; set; }
}