var builder = WebApplication.CreateBuilder(args);
builder.Services.AddTransient<IWetherClient, WetherClient>();
builder.Services.AddTransient<IWetherService, WetherService>();



var app = builder.Build();

app.MapGet("/wether/{cityName}", (string cityName, IWetherService wetherService, ILogger<Program> logger) =>
{
    logger.LogInformation($"Temperature of {cityName} was read at {DateTime.Now}");
    return Results.Ok(wetherService.GetCurrentTemperature(cityName));
});

app.Run();



interface IWetherService
{
    string GetCurrentTemperature(string cityName);
}

class WetherService : IWetherService
{
    private readonly IWetherClient _wetherClient;

    public WetherService(IWetherClient wetherClient)
    {
        this._wetherClient = wetherClient;
    }
    public string GetCurrentTemperature(string cityName)
    {

        return _wetherClient.GetCurrentTemperature("Nablus");
    }

}


interface IWetherClient
{
    string GetCurrentTemperature(string cityName);
}

class WetherClient : IWetherClient
{
    public string GetCurrentTemperature(string cityName)
    {
        return $"The temperature in {cityName} is {Random.Shared.Next(-10, 40)}";
    }
}