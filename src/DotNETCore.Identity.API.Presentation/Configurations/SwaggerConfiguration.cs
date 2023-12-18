using Microsoft.OpenApi.Models;

namespace DotNETCore.Identity.API.Presentation.Configurations;

internal static class SwaggerConfiguration
{
    public static void AddSwagger(this IServiceCollection services, IConfiguration configuration) =>
        services.AddSwaggerGen(sgo =>
        {
            sgo.SwaggerDoc("v1", BuildOpenApiInfo(configuration));
            sgo.AddSecurityDefinition("Bearer", BuildOpenApiSecurityScheme());
            sgo.AddSecurityRequirement(BuildOpenApiSecurityRequirement());
        });

    public static void UseSwagger(this IApplicationBuilder app, IConfiguration configuration)
    {
        app.UseSwagger();
        app.UseSwaggerUI(a => a.SwaggerEndpoint("/swagger/v1/swagger.json", $".NET Core Identity API - {configuration["Environment"]}"));
    }

    private static OpenApiInfo BuildOpenApiInfo(IConfiguration configuration) =>
        new()
        {
            Title = $".NET Core Identity API - {configuration["Environment"]}",
            Version = "1.0.0",
            Description = "Template fot .NET Core APIs that uses Identity.",
            Contact = new OpenApiContact
            {
                Name = configuration["Contact:Name"],
                Email = configuration["Contact:Email"],
                Url = new Uri(configuration["Contact:GitHub"])
            },
            License = new OpenApiLicense()
            {
                Name = configuration["License:Name"],
                Url = new Uri(configuration["License:Url"])
            }
        };

    private static OpenApiSecurityScheme BuildOpenApiSecurityScheme() =>
        new()
        {
            Name = "Authorization",
            Type = SecuritySchemeType.ApiKey,
            Scheme = "Bearer",
            BearerFormat = "JWT",
            In = ParameterLocation.Header,
            Description = "Authorization header using the Bearer scheme."
        };

    private static OpenApiSecurityRequirement BuildOpenApiSecurityRequirement() =>
        new()
        {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    }
                },
                Array.Empty<string>()
            }
        };
}
