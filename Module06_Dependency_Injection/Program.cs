
using Microsoft.Extensions.DependencyInjection.Extensions;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddKeyedTransient<IDependencyInversion, V1>("V1");
builder.Services.AddKeyedTransient<IDependencyInversion, V2>("V2");
// To control which service i want to use at runtime we use keyed services

var app = builder.Build();

app.MapGet("/v1", ([FromKeyedServices("V1")] IDependencyInversion service) =>
{
    return Results.Ok(service.doSomthing());
});

app.MapGet("/v2", ([FromKeyedServices("V2")] IDependencyInversion service) =>
{
    return Results.Ok(service.doSomthing());
});

// get number of registerd services under the IDependencyInversion
app.MapGet("/get-dependencies-count", (IServiceProvider service) =>
{
    return Results.Ok(service.GetServices<IDependencyInversion>().Count());

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