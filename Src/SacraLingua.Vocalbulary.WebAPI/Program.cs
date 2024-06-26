using SacraLingua.Vocalbulary.WebAPI.Extensions;
using SacraLingua.Vocalbulary.Domain;
using SacraLingua.Vocalbulary.Infrastructure;
using Serilog;
using SacraLingua.Vocalbulary.WebAPI.Middleware;
using SacraLingua.Vocalbulary.WebAPI.Authorization;

public class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Host.UseSerilog((context, configuration) =>
            configuration.ReadFrom.Configuration(context.Configuration));

        // Add services to the container.

        builder.Services.ConfigureAuthentication(builder.Configuration);

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.ConfigureSwaggerUI();
        builder.Services.RegisterWebApiAssemblies();
        builder.Services.RegisterDomainAssemblies();
        builder.Services.RegisterInfrastructureAssemblies(builder.Configuration);

        builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
            app.MapControllers().AllowAnonymous();
        }

        app.UseMiddleware<ExceptionMiddleware>();

        app.UseSerilogRequestLogging();

        app.UseHttpsRedirection();

        app.UseAuthentication();
        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}