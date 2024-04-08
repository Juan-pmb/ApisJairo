using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using profectefjm;

var builder = WebApplication.CreateBuilder(args);


//Si da error, Anotar, el error de UseInMemoryDataBase, anotar a using Microsoft.EntityFrameworkCore;
//builder.Services.AddDbContext<TareasContext>(p=>p.UseInMemoryDatabase("TarasDB"));
builder.Services.AddSqlServer<TareasContext>(builder.Configuration.GetConnectionString("cnTareas"));  
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGet("/dbconexion", async ([FromServices] TareasContext dbContext) => {

    try{
        dbContext.Database.EnsureCreated();
        return Results.Ok("Base de datos en memoria: " + dbContext.Database.IsInMemory());
    }catch (Exception e) {
        return Results.Ok("Error al verificar la base de datos en memoria" +  e.Message);
    }
});

app.Run();
