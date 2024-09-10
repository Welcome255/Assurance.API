using Microsoft.EntityFrameworkCore;
using Assurance.Infrastructure.Context;
using Assurance.ApplicationCore.Interfaces;
using Assurance.Infrastructure;
using Assurance.ApplicationCore.Services;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen( config =>
{
    config.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, "api.xml"));
    config.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "API Assurance",
        Version = "v1",
        Description = "API pour la gestion d'une assurance bancaire",
        License = new OpenApiLicense
        {
            Name = "Apache 2.0",
            Url = new Uri("http://www.apache.org")
        },
        Contact = new OpenApiContact
        {
            Name = "Bienvenu Kouassi & Derrick",
            Email = "parfaitkouess@gmail.com",
            Url = new Uri("https://modern-ti.com/")
        }
    });
} );

builder.Services.AddDbContext<AssuranceContext>(options =>
options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnexion")));

// Injection dans le conteneur IOC
builder.Services.AddScoped(typeof(IAsyncRepository<>), typeof(AsyncRepository<>));
builder.Services.AddScoped<IAssuranceService, AssuranceService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
