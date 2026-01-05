var builder = WebApplication.CreateBuilder(args);


var app = builder.Build();

app.MapGet("/wether/{cityName}", (string cityName) =>
{
    var wetherService = new WetherService();
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