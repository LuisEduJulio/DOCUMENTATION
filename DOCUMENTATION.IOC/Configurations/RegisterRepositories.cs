using DOCUMENTATION.CORE.Repositories;
using DOCUMENTATION.INFRASTRUCTURE.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace DOCUMENTATION.IOC.Configurations
{
    public static class IoCExtension
    {
        public static void RegisterRepositories(this IServiceCollection services)
        {
            services
                .AddTransient<ITopicRepository, TopicRepository>()
                .AddTransient<IArchiveRepository, ArchiveRepository>();
        }
    }
}