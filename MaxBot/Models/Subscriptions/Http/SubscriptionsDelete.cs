using System.Text.Json.Serialization;

namespace MaxBot.Models.Subscriptions.Http
{
    internal class SubscriptionsDelete
    {
        public SubscriptionsDelete(string url)
        {
            Url = url;
        }

        [JsonPropertyName("url")]
        public string Url { get; set; }

    }
}
