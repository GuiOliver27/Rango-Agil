using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RangoAgilAPI.DbContexts;

var webApp = WebApplication.CreateBuilder(args);

webApp.Services.AddDbContext<RangoDbContext>(
    o => o.UseSqlite(webApp.Configuration["ConnectionStrings:RangoDbConStr"]));

// Add services to the container.

var app = webApp.Build();

// Configure the HTTP request pipeline.

app.MapGet("/", () => "Hello World!");

app.MapGet("/rango/{nome}", async (RangoDbContext rangoDbContext, string nome) => {
    return await rangoDbContext.Rangos.FirstOrDefaultAsync(x => x.Nome == nome);
});

app.MapGet("/rango", async (RangoDbContext rangoDbContext, [FromHeader(Name = "RangoId")]int id) => {
    return await rangoDbContext.Rangos.FirstOrDefaultAsync(x => x.Id == id);
});

app.MapGet("/rangos", async (RangoDbContext rangoDbContext) => {
    return await rangoDbContext.Rangos.ToListAsync();
});

app.Run();

