using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;
using System.Runtime.Intrinsics.X86;
var builder = WebApplication.CreateBuilder(args);

// DI Container (Service Registration) 
builder.Services.AddControllers();

var app = builder.Build();

// middlewares
//app.MapGet("/product-minimal", (int page , int pageSize ) =>
//{
//    return Results.Ok($"showing {pageSize} of page #{page}");
//});
app.MapGet("/product-minimal", ([FromQuery(Name ="page")]int p ,[FromQuery(Name ="pageSize")] int ps ) =>
{
    return Results.Ok($"showing {ps} of page #{p}");
});



app.MapControllers();

app.Run();
