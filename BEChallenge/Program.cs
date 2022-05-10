using BEChallenge.Infrastructure;
using BEChallenge.Service;
using BEChallenge.Service.CommandHandler;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using BEChallenge.API.Shared.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
#region Services

IServiceCollection services = builder.Services;
IConfiguration configuration = builder.Configuration;

services.AddControllers();
services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();

services.AddServicesDependencies();
services.AddDataAccess();

services.AddDbContext<BEChallengeDbContext>(
    options => options.UseSqlServer(configuration.GetConnectionString(nameof(BEChallengeDbContext)),
    sqlOptions => 
    {
        sqlOptions.MigrationsAssembly(Assembly.GetExecutingAssembly().GetName().Name);
        sqlOptions.CommandTimeout(60);
    }));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#endregion

var app = builder.Build();
IWebHostEnvironment env = app.Environment;
IHostApplicationLifetime lifetime = app.Lifetime;
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.ConfigureCustomExceptionMiddleware();
app.MapControllers();

app.Run();