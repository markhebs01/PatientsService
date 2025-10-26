using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using PatientsService.Domain.Interfaces;
using PatientsService.Infrastructure.Repositories;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//SETUP MEDIATR
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(PatientsService.Application.Handlers.GetPatientByIdQueryHandler).Assembly));

//IN MEMORY REPOSITORY
builder.Services.AddSingleton<IPatientRepository, InMemoryPatientRepository>();

var app = builder.Build();

//SWAGGER FOR API DOCS
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Patients API v1");
    c.RoutePrefix = string.Empty; // Serve Swagger UI at "/"
});


app.MapControllers();
app.Run();
