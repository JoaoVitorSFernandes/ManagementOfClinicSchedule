using ManagementOfClinicSchedule.Infrastructure.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<DataContext>()

var app = builder.Build();

app.UseHttpsRedirection();

app.Run();