
var builder = WebApplication.CreateBuilder(args);


builder.Services.AddTransient<IDependencyInversion, V1>();
builder.Services.AddTransient<IDependencyInversion, V2>();
// 📝 when Registering more than one Service to the same Abstraction, the last one is seen 

var app = builder.Build();

app.MapGet("/service", (IDependencyInversion service) =>
{
    return Results.Ok(service.doSomthing());
});

app.Run();


interface IDependencyInversion
{
    string doSomthing();
}


public class V1 : IDependencyInversion
{
    public string doSomthing()
    {
        return "inside V1 service";
    }
}


public class V2 : IDependencyInversion
{
    public string doSomthing()
    {
        return "inside V2 Service";
    }
}


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