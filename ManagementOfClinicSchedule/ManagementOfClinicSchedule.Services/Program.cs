using Autofac;
using Autofac.Extensions.DependencyInjection;
using ManagementOfClinicSchedule.Application;
using ManagementOfClinicSchedule.Application.Interfaces;
using ManagementOfClinicSchedule.Application.Interfaces.Mapper;
using ManagementOfClinicSchedule.Application.Mapper;
using ManagementOfClinicSchedule.Domain.Core.Interfaces.Repositories;
using ManagementOfClinicSchedule.Domain.Core.Interfaces.Services;
using ManagementOfClinicSchedule.Domain.Services;
using ManagementOfClinicSchedule.Infrastructure.CrossCutting.IOC;
using ManagementOfClinicSchedule.Infrastructure.Data;
using ManagementOfClinicSchedule.Infrastructure.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

var connection = builder.Configuration.GetConnectionString("defaultConnection");

builder.Services.AddDbContext<DataContext>(options => options.UseSqlServer(connection, b => b.MigrationsAssembly("ManagementOfClinicSchedule.Services")));

builder.Services.AddControllers();
builder.Services.AddSwaggerGen(s =>
{
    s.SwaggerDoc("v1", new OpenApiInfo { Title = "Cubos Academy Test", Version = "v1" });
});

builder.Services.AddScoped<IApplicationServiceRule, ApplicationServiceRule>();
builder.Services.AddScoped<IMapperServiceRule, MapperServiceRule>();
builder.Services.AddScoped<IRepositoryServiceRule, RepositoryServiceRule>();
builder.Services.AddScoped<IServiceServiceRule, ServiceServiceRule>();

//var containerBuilder = new ContainerBuilder();
//containerBuilder.RegisterModule(new ModuleIOC());

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI( s => s.SwaggerEndpoint("/swagger/v1/swagger.json", "Cubos Academy Test"));
app.UseHttpsRedirection();
app.MapControllers();

app.Run();