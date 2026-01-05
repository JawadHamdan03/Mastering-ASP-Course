var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<WetherService>();
var app = builder.Build();

app.MapGet("/wether/{cityName}", (string cityName, WetherService wetherService) =>
{
    return Results.Ok(wetherService.GetCurrentTemperature(cityName));
});

app.Run();

class WetherService
{

    public string GetCurrentTemperature(string cityName)
    {
        int temp = Random.Shared.Next(-10, 40);
        return $"the temperature of {cityName} is {temp}";
    }

}