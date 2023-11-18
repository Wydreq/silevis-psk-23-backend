namespace api_v3.Configuration
{
    public static class CorsInstaller
    {
        public static void AddCustomCors(this IServiceCollection services, string policyName, AppSettings corsSettings)
        {
            services.AddCors(opt => opt.AddPolicy(policyName,
                builder =>
                {
                    builder
                        .WithHeaders(corsSettings.CorsHeaders)
                        .WithMethods(corsSettings.CorsMethods)
                        .WithOrigins(corsSettings.CorsOrigins)
                        .AllowCredentials();
                }));
        }

        public static void UseCustomCors(this IApplicationBuilder app, string policyName)
        {
            app.UseCors(policyName);
        }

    }
}
