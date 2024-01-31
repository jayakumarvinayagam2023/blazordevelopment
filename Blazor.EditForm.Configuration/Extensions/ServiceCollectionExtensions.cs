

namespace Blazor.EditForm.Configuration
{
    public static class ServiceCollectionExtensions
    {
        public static void AddAppBlazorServerServices(this IServiceCollection services)
        {
            services.AddSingleton<WeatherForecastDataStore>();
            services.AddSingleton<IWeatherForecastDataBroker, WeatherForecastServerDataBroker>();
            services.AddScoped<WeatherForecastsViewService>();
            services.AddScoped<WeatherForecastViewService>();
            services.AddBlazrNavigationLockerServerServices();

        }

        public static void AddAppBlazorWASMServices(this IServiceCollection services)
        {
            services.AddScoped<IWeatherForecastDataBroker, WeatherForecastAPIDataBroker>();
            services.AddScoped<WeatherForecastViewService>();
            services.AddScoped<WeatherForecastsViewService>();
            services.AddBlazrNavigationLockerWASMServices();
        }

        public static void AddAppWASMServerServices(this IServiceCollection services)
        {
            services.AddSingleton<WeatherForecastDataStore>();
            services.AddSingleton<IWeatherForecastDataBroker, WeatherForecastServerDataBroker>();
        }
    }
}
