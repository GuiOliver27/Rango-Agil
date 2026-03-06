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

app.MapGet("/rangos", async (RangoDbContext rangoDbContext, [FromQuery(Name = "name")]string rangoNome) => {
    return await rangoDbContext.Rangos
                                .Where(x => x.Nome.Contains(rangoNome))
                                .ToListAsync();
});

app.MapGet("/rango/{id:int}", async (RangoDbContext rangoDbContext, int id) => {
    return await rangoDbContext.Rangos.FirstOrDefaultAsync(x => x.Id == id);
});

app.Run();

