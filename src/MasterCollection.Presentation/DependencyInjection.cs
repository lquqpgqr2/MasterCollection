using MasterCollection.Presentation.Extensions;

namespace MasterCollection.Presentation;

public static class DependencyInjection
{
    extension(IServiceCollection services)
    {
        public IServiceCollection AddPresentation(IConfiguration configuration, IHostEnvironment environment)
        {
            services.AddPresentationOptions(configuration);
            services.AddCorsPolicy(configuration, environment);
            
            return services;
        }
    }
}