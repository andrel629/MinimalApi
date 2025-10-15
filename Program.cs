using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Minimal.Dominios.DTOs;
using Minimal.Dominios.entidades;
using Minimal.Dominios.Movies;
using Minimal.Dominios.serviços;
using Minimal.Infraestrutura.Db;
using Minimal.Infraestrutura.interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<iAdministradorServicos, AdmServices>();
builder.Services.AddScoped<iVeiculosServices, VeiculoServices>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<DBContext>(Options =>
{
    Options.UseMySql(
        builder.Configuration.GetConnectionString("mysql"),
        ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("mysql"))
    );
});


var app = builder.Build();




app.MapGet("/", () => Results.Json(new Home()));


app.MapPost("/login", (LoginDTO loginDTO, iAdministradorServicos admServices) =>
{
    if (admServices.Login(loginDTO) != null)
    {
        return Results.Ok("Login bem sucedito");
    }
    else
    {
        return Results.Unauthorized();
    }
});

app.MapPost("/IncluirADM", (Administrador Adm, iAdministradorServicos Admserv) =>
{
    Admserv.Criar(Adm);
    return Results.Ok($"O usuario {Adm.Email} foi adicionado com sucesso");
});

app.MapGet("/listarAdms", ([FromQuery] int pagination, iAdministradorServicos Admserv) =>
{
    var adms = Admserv.Listar(pagination);
    return Results.Ok(adms);

});


app.MapPost("/IncluirVeiculo", (Veiculo veiculo, iVeiculosServices veiculosServices) =>
{
    veiculosServices.Incluir(veiculo);
    return Results.Ok($"O veiculo {veiculo.Nome} foi adicionado com sucesso");
});

app.MapGet("/Buscar", ([FromQuery]int pagination, iVeiculosServices vservic) =>
{
    var veiculos = vservic.Todos(pagination);
    return Results.Ok(veiculos);
    
});

app.MapGet("/buscarID", (int id, iVeiculosServices vservic) =>
{
    if (vservic.BuscarPorId(id) != null)
    {
        return Results.Ok(vservic.BuscarPorId(id));
    }
    else
    {
        return Results.NotFound();
    }
});

app.MapPut("/Atualizar/{id}", (int id, Veiculo veiculo, iVeiculosServices vservic) =>
{
    Veiculo? veiculoexiste = vservic.BuscarPorId(id);

    if (veiculoexiste != null)
    {
        veiculoexiste.Marca = veiculo.Marca;
        veiculoexiste.Nome = veiculo.Nome;


        vservic.Atualizar(veiculoexiste);
        return Results.Ok("sucesso");
    }
    else
    {
        return Results.NotFound();
    }
    ;
});
app.MapDelete("/Deletar", (int id, iVeiculosServices vservices) =>
    {
    if (vservices.BuscarPorId(id) != null)
    {
        Veiculo? x = vservices.BuscarPorId(id);
        vservices.Apagar(x);
        return Results.Ok("sucesso");
    }else
        {
            return Results.NotFound();
             }
    });



app.UseSwagger();
app.UseSwaggerUI();

app.Run();


