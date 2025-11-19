using MaxBot.Models.Subscriptions;
using MaxBot.Models.Subscriptions.Http;
using MaxBot.Objects;
using MaxBot.Objects.Types;
using System.Net.Http.Json;

namespace MaxBot;

public class MaxBot : IDisposable, IAsyncDisposable
{
    private bool _disposed = false;
    private readonly string _maxDefaultUrl = "https://platform-api.max.ru";
    private readonly string _token;
    private readonly HttpClient _httpClient;    

    public MaxBot(string token, HttpClient? httpClient = null)
    {
        _token = token;
        _httpClient = httpClient ?? new HttpClient();

        if (httpClient == null)
        {
            _httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", _token);
            _httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json");

            _httpClient.BaseAddress = new Uri(_maxDefaultUrl);
        }

    }

    
    public void Dispose()
    {
        if (!_disposed)
        {
            _httpClient?.Dispose();
        
            _disposed = true;
        }
    }

    public async ValueTask DisposeAsync()
    {
        Dispose();
    }

    public async Task<GetUpdatesResponse> GetUpdates(UpdateType[]? types = null, int? limit = null, int? timeout = null, int? marker = null, CancellationToken cts = default)
    {
        var model = new UpdatesGet(types, limit, timeout, marker);
        var updates = await _httpClient.GetFromJsonAsync<GetUpdatesResponse>("updates",cts);

        return updates!;
    }

    public async Task RemoveSubscription(CancellationToken cts = default)
    {
        var response = await _httpClient.DeleteAsync("subscriptions",cts);

        if (!response.IsSuccessStatusCode)
            throw new MaxBotException(await response.Content.ReadAsStringAsync());
    }

    public async Task<Subscription[]?> GetSubscriptions(CancellationToken cts = default)
    {
        var subscriptions = await _httpClient.GetFromJsonAsync<Subscription[]>("subscriptions", cts);

        return subscriptions;
    }

    public async Task Subscribe(string url, UpdateType[]? types = null, string? secret = null, CancellationToken cts = default)
    {
        var model = new SubscriptionsPost(url,types,secret);
        var response = await _httpClient.PostAsJsonAsync("subscriptions", model, cts);
        
        if (!response.IsSuccessStatusCode)
            throw new MaxBotException(await response.Content.ReadAsStringAsync());
    }

}
