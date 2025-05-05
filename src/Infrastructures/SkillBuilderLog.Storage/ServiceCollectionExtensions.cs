using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace SkillBuilderLog.Storage
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddSkillBuilderLogStorage(this IServiceCollection services, IConfiguration configuration)
        {
            // Register your storage services here
            return services;
        }
    }
}
