using MaxBot.Models;
using MaxBot.Models.Subscriptions;
using MaxBot.Models.Subscriptions.Http;
using MaxBot.Objects;
using MaxBot.Objects.Additional;
using MaxBot.Objects.Types;
using System;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Text;
using System.Web;

namespace MaxBot
{
    public partial class MaxBotClient
    {
        public async Task<UpdatesWithMarker> GetUpdates(UpdateType[]? types = null, int? limit = null, int? timeout = null, int? marker = null, CancellationToken cts = default)
        {
            if (_disposed) throw new ObjectDisposedException(nameof(MaxBotClient));

            var model = new UpdatesGet(types, limit, timeout, marker);
            var updates = await _httpClient.GetFromJsonAsync<GetUpdatesResponse>("updates", cts).ConfigureAwait(false);

            return new UpdatesWithMarker() { Marker = updates!.Marker, Updates = updates!.Updates };
        }

        public async Task RemoveSubscription(string url, CancellationToken cts = default)
        {
            if (_disposed) throw new ObjectDisposedException(nameof(MaxBotClient));
            if (url == null) throw new ArgumentNullException(nameof(url));

            var query = HttpUtility.ParseQueryString(string.Empty);
            query["url"] = url;

            var response = await _httpClient.DeleteFromJsonAsync<SuccessResponse>($"subscriptions?{query}", cts).ConfigureAwait(false);

            if (response is not { Success: true })
                throw new MaxBotException(response?.Message ?? "unknown error");
        }

        public async Task<Subscription[]?> GetSubscriptions(CancellationToken cts = default)
        {
            if (_disposed) throw new ObjectDisposedException(nameof(MaxBotClient));

            var subscriptions = await _httpClient.GetFromJsonAsync<Subscription[]>("subscriptions", cts).ConfigureAwait(false);

            return subscriptions;
        }

        public async Task Subscribe(string url, UpdateType[]? types = null, string? secret = null, CancellationToken cts = default)
        {
            if (_disposed) throw new ObjectDisposedException(nameof(MaxBotClient));
            if (url == null) throw new ArgumentNullException(nameof(url));

            var model = new SubscriptionsPost(url, types, secret);
            var response = await _httpClient.PostAsJsonAsync("subscriptions", model, cts).ConfigureAwait(false);
            var jsonResponse = await response.Content.ReadFromJsonAsync<SuccessResponse>().ConfigureAwait(false);

            if (jsonResponse is not { Success: true })
                throw new MaxBotException(jsonResponse?.Message ?? "unknown error");
        }
    }
}
