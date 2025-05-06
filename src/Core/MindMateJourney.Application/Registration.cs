using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using MindMateJourney.Application.Behaviors;

namespace MindMateJourney.Application;

public static class Registration
{
    public static void AddApplicationServices(this IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(AssemblyReference.Assembly));
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        services.AddValidatorsFromAssembly(typeof(AssemblyReference).Assembly);
    }
}
