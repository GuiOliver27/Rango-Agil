using Microsoft.EntityFrameworkCore;
using RangoAgilAPI.DbContexts;

var webApp = WebApplication.CreateBuilder(args);

webApp.Services.AddDbContext<RangoDbContext>(
    o => o.UseSqlite(webApp.Configuration["ConnectionStrings:RangoDbConStr"]));

// Add services to the container.

var app = webApp.Build();

// Configure the HTTP request pipeline.

app.MapGet("/", () => "Hello World!");

app.MapGet("/rango/{nome}", (RangoDbContext rangoDbContext, string nome) => {
    return rangoDbContext.Rangos.FirstOrDefault(x => x.Nome == nome);
});

app.MapGet("/rango/{id:int}", (RangoDbContext rangoDbContext, int id) => {
    return rangoDbContext.Rangos.FirstOrDefault(x => x.Id == id);
});

app.MapGet("/rangos", (RangoDbContext rangoDbContext) => {
    return rangoDbContext.Rangos;
});

app.Run();

