using Microsoft.Extensions.DependencyInjection;
using MindMateJourney.Application.Services;
using MindMateJourney.Infrastructure.Service;

namespace MindMateJourney.Infrastructure;

public static class Registration
{
    public static void AddInfrastructureServices(this IServiceCollection services)
    {
        services.AddHttpClient<IGeminiService, GeminiService>();
    }
}

