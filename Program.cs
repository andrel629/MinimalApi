using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Minimal.Dominios.DTOs;
using Minimal.Infraestrutura.Db;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

builder.Services.AddDbContext<DBContext>(Options =>
{
    Options.UseMySql(
        builder.Configuration.GetConnectionString("mysql"),
        ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("mysql"))
    );
});

app.MapGet("/", () => "Hello World!");

app.MapPost("/login", (LoginDTO loginDTO) =>
{
    if (loginDTO.Login == "adm@gmail.com" && loginDTO.Senha == "123456")
    {
        return Results.Ok("Login bem sucedito");
    }
    else
    {
        return Results.Unauthorized();
    }
});

app.Run();


