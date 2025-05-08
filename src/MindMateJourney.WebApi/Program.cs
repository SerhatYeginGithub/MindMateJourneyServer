using MindMateJourney.Presentation;
using MindMateJourney.Persistance;
using MindMateJourney.Application;
using MyCar.WebApi.Middleware;
using MindMateJourney.WebApi;
using Microsoft.AspNetCore.Mvc;
using MindMateJourney.Infrastructure;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddControllers()
    .AddApplicationPart(typeof(MindMateJourney.Presentation.AssemblyReference).Assembly);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddPersistance(builder.Configuration);
builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices();
builder.Services.AddServices();
builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.InvalidModelStateResponseFactory = context =>
    {
        var errors = context.ModelState
            .Where(x => x.Value.Errors.Count > 0)
            .SelectMany(x => x.Value.Errors)
            .Select(x =>
            {
                // Eðer hata mesajý çok teknikse, gizle
                if (x.ErrorMessage.Contains("could not be converted"))
                    return "invalid data format";
                return x.ErrorMessage;
            })
            .ToArray();

        var result = new ValidationErrorDetails
        {
            Errors = errors,
            StatusCode = 400
        };

        return new BadRequestObjectResult(result);
    };
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseMiddlewareExtensions();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
