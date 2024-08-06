using TestApi.Config;
using TestApi.Tarea.Repositories;
using TestApi.Tarea.Services;

namespace TestApi.Extensions;

public static class ServiceExtensions
{
    public static void ConfigureCors(this IServiceCollection services)
    {
        services.AddCors(options =>
        {
            options.AddPolicy("CorsPolicy", builder =>
            {
                builder
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
            });
        });
    }

    public static void ConfigureRepositories(this IServiceCollection services)
    {
        services.AddScoped<ITareaRepository, TareaRepository>();
    }
    
    public static void ConfigureServices(this IServiceCollection services)
    {
        services.AddScoped<ITareaService, TareaService>();
    }
    
    public static void ConfigureDapper(this IServiceCollection services) =>
        services.AddSingleton<DapperContext>();
}