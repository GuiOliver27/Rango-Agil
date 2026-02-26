using Microsoft.EntityFrameworkCore;
using RangoAgilAPI.DbContexts;

var webApp = WebApplication.CreateBuilder(args);

webApp.Services.AddDbContext<RangoDbContext>(
    o => o.UseSqlite(webApp.Configuration["ConnectionStrings:RangoDbConStr"]));

// Add services to the container.

var app = webApp.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/", () => "Hello World!");

app.MapGet("/rangos", () => {
    
    return "Está funcionando muito bem!!";
});

app.Run();

internal record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary) {
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
