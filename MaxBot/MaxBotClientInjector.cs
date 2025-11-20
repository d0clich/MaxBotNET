using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
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
