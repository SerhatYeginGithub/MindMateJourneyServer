﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MindMateJourney.Application.Repositories;
using MindMateJourney.Application.Services;
using MindMateJourney.Persistance.Abstractions;
using MindMateJourney.Persistance.Context;
using MindMateJourney.Persistance.Repositories;
using MindMateJourney.Persistance.Services;

namespace MindMateJourney.Persistance;

public static class Registration
{
    public static void AddPersistance(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("SqlServer")));
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<ICategoryService, CategoryService>();
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<IContentRepository, ContentRepository>();
        services.AddScoped<IContentService, ContentService>();
        services.AddAutoMapper(typeof(MindMateJourney.Persistance.AssemblyReference).Assembly);

        services.AddScoped<IRoleService, RoleService>();
        services.AddScoped<IUserRoleService, UserRoleService>();
        services.AddScoped<IUserRoleRepository, UserRoleRepository>();
    }
}
