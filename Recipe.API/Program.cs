using Recipe.Infrastructure;
using Recipe.Application;
using Recipe.Domain;
using Recipe.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Recipe.API.Common.Mapping;
using BuberDinner.Api;

var builder = WebApplication.CreateBuilder(args);

var configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .Build();

// Add services to the container.

// builder.Services.AddControllers(options => options.Filters.Add<ErrorHandlingFilterAttribute>());

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(MenuMappingConfig));
var connectionString = configuration.GetConnectionString("Postgress");

builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseNpgsql(connectionString));
builder.Services
    .AddPresentation()
    .AddInfrastructure()
    .AddApplication()
    .AddDomain();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    // app.UseMiddleware<ErrorHandlingMiddleware>();
}

app.UseExceptionHandler("/error");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
