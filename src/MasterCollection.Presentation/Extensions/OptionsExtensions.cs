using MasterCollection.Presentation.Options;

namespace MasterCollection.Presentation.Extensions;

public static class OptionsExtensions
{
    extension(IServiceCollection services)
    {
        public IServiceCollection AddPresentationOptions(IConfiguration configuration)
        {
            services.AddOptions<CorsOptions>()
                .Bind(configuration.GetSection(CorsOptions.SectionName))
                .ValidateOnStart();

            return services;
        }
    }
}