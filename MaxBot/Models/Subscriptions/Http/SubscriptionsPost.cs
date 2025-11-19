using MaxBot.Objects.Types;

namespace MaxBot.Models.Subscriptions.Http;

internal class SubscriptionsPost
{
    public SubscriptionsPost(string url, UpdateType[]? updateTypes = null, string? secret = null)
    {
        Url = url;
        UpdateTypes = updateTypes;
        Secret = secret;
    }

    public string Url { get; set; }
    public UpdateType[]? UpdateTypes { get; set; }
    public string? Secret { get; set; }
}
