using Microsoft.EntityFrameworkCore;
using ShiftTracker.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.services.AddDbContext<DataContext>(opt =>
    opt.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Initial Catalog=Shifts; Intergrated Security=true;"));

builder.Services.AddEndpointsApiExplorer();
builder.services.AddSwaggerGen();

var app = builder.Build();

if (app.environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUi(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Shifts v1");
        char.RoutePrefix = string.Empty;
    });
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
