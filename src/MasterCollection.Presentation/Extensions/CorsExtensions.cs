using MasterCollection.Presentation.Options;

namespace MasterCollection.Presentation.Extensions;

public static class CorsExtensions
{
    private const string PolicyName = "AllowSpecificOrigins";

    extension(IServiceCollection services)
    {
        public IServiceCollection AddCorsPolicy(IConfiguration configuration, IHostEnvironment environment)
        {
            var validOrigins = (configuration.GetSection(CorsOptions.SectionName).Get<CorsOptions>()?.AllowedOrigins ?? [])
                .Where(o => !string.IsNullOrWhiteSpace(o) && !o.Contains("*"))
                .ToArray();

            services.AddCors(options =>
            {
                options.AddPolicy(PolicyName, policy =>
                {
                    policy.AllowAnyMethod().AllowAnyHeader();
                    
                    if (validOrigins.Any())
                    {
                        policy.WithOrigins(validOrigins).AllowCredentials();
                        return;
                    }
                    
                    if (environment.IsDevelopment())
                        policy.AllowAnyOrigin();
                    else
                        policy.WithOrigins("https://localhost");
                });
            });
            
            return services;
        }
    }
}