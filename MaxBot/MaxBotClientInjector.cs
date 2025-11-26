using Microsoft.Extensions.DependencyInjection;

namespace MaxBot
{
    public static class MaxBotClientInjector
    {
        public static IServiceCollection AddMaxBotClient(this IServiceCollection services, string token)
        {
            services.AddHttpClient<MaxBotClient>(x=>new MaxBotClient(token, x));
            return services;
        }
    }
}
