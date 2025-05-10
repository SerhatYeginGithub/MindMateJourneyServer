using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MindMateJourney.Application.Abstractions;
using MindMateJourney.Application.DTOS;
using MindMateJourney.Application.Services;
using MindMateJourney.Infrastructure.Authentication;
using MindMateJourney.Infrastructure.Service;
using MindMateJourney.Infrastructure.Services;

namespace MindMateJourney.Infrastructure;

public static class Registration
{
    public static void AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddHttpClient<IGeminiService, GeminiService>();
        services.Configure<MailSettings>(configuration.GetSection("MailSettings"));
        services.AddTransient<IMailService, MailService>();
        services.AddScoped<IJwtProvider, JwtProvider>();


    }
}

