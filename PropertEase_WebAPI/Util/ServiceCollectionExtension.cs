using MediatR;
using Microsoft.AspNetCore.Mvc;
using PropertEase_Commends.PropertyCommends.Commend;
using PropertEase_Commends.PropertyCommends.CommendHandler;
using PropertEase_Commends.PropertyCommends.Query;
using PropertEase_Commends.PropertyCommends.QueryHandler;
using System.Reflection;

namespace PropertEase_WebAPI.Util;

public static class ServiceCollectionExtension
{
    public static void ConfigureControllers(this IServiceCollection services)
    {
        _ = services.AddControllers(config =>
        {
            config.CacheProfiles.Add("30SecondsCaching", new CacheProfile
            {
                Duration = 30
            });
        });
    }
    public static void ConfigureResponseCaching(this IServiceCollection services)
    {
        services.AddResponseCaching();
    }
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        Assembly assembly = Assembly.GetExecutingAssembly();
        return services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(assembly));
    }
    public static void AddCommendTransients(this IServiceCollection services)
    {
        services.AddTransient<IRequestHandler<PropertyPredictionCommend, int>, PropertyPredictionCommendHandler>();
        services.AddTransient<IRequestHandler<GetAllAreasQuery, List<string>>, GetAllAreasQueryHandler>();
        services.AddTransient<IRequestHandler<GetAllQualitiesQuery, List<string>>, GetAllQualitiesQueryHandler>();
    }
}
