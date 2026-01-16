using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;
using System.Runtime.Intrinsics.X86;
var builder = WebApplication.CreateBuilder(args);

// DI Container (Service Registration) 
builder.Services.AddControllers();

var app = builder.Build();

// middlewares
app.MapGet("/product-minimal/{id:int}", (int id ) =>
{
    return Results.Ok(id);
});

app.MapGet("/product-minimal/{id:int}", ( [FromRoute(Name ="id")]int identifier) =>
{
    return Results.Ok(identifier);
});

app.MapControllers();

app.Run();
