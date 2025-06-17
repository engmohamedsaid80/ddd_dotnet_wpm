using Microsoft.EntityFrameworkCore;
using Wpm.Management.Api.Application;
using Wpm.Management.Api.Infrastructure;
using Wpm.Management.Domain.Services.Interfaces;
using Swashbuckle.AspNetCore.SwaggerGen; // Ensure this using directive is present
using Swashbuckle.AspNetCore.Swagger;
using Microsoft.AspNetCore.Builder; // Ensure this using directive is present
using Microsoft.Extensions.DependencyInjection; // Add this using directive
using Microsoft.OpenApi.Models; // Add this using directive

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Wpm.Management.Api", Version = "v1" });
});
builder.Services.AddScoped<IBreedService, BreedService>();
builder.Services.AddScoped<ManagemantApplicationService>();
builder.Services.AddDbContext<ManagementDbContext>(options =>
{
    //options.UseInMemoryDatabase("ManagementDb");
    options.UseSqlite("Data Source=WpmManagement.db");
});

var app = builder.Build();
app.EnsureDbIsCreated();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Wpm.Management.Api v1");
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
