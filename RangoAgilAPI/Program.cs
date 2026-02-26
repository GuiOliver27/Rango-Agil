using Microsoft.EntityFrameworkCore;
using RangoAgilAPI.DbContexts;

var webApp = WebApplication.CreateBuilder(args);

webApp.Services.AddDbContext<RangoDbContext>(
    o => o.UseSqlite(webApp.Configuration["ConnectionStrings:RangoDbConStr"]));

// Add services to the container.

var app = webApp.Build();

// Configure the HTTP request pipeline.

app.MapGet("/", () => "Hello World!");

app.MapGet("/rangos/{numero}/{nome}", (int numero, string nome) => {
    
    return nome + " " + numero;
});

app.MapGet("/rangos", () => {
    return "Está funcionando MUITO bem!!!";
});

app.Run();

