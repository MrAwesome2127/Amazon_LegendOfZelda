
namespace Amazon_LegendOfZelda.Rest_Base;

public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services
            .AddSingleton<IRestLibrary, RestLibrary>()
            .AddScoped<IRestBuilder, RestBuilder>()
            .AddScoped<IRestFactory, RestFactory>();
    }
}