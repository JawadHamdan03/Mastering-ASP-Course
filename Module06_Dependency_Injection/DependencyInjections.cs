namespace Microsoft.Extensions.DependencyInjection;


public static class DependencyInjections
{
    public static IServiceCollection AddWetherServices(this IServiceCollection service)
    {
        service.AddTransient<IWetherService, WetherService>();
        service.AddTransient<IWetherClient, WetherClient>();
        return service;
    }
}