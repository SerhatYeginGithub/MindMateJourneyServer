using CleanArchitecture.WebApi.Middleware;

namespace MindMateJourney.WebApi;

public static class Registration
{
    public static void AddServices(this IServiceCollection services) =>
        services.AddTransient<ExceptionMiddleware>();
}
