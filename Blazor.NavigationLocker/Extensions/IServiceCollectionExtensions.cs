using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.DependencyInjection;

namespace Blazor.NavigationLocker
{
    public static class IServiceCollectionExtensions
    {
        public static void AddBlazrNavigationLockerServerServices(this IServiceCollection services)
        {
            services.AddScoped<BlazrNavigationManager>();
        }

        public static void AddBlazrNavigationLockerWASMServices(this IServiceCollection services)
        {
            var navService = services.FirstOrDefault(item => item.ServiceType.FullName == "Microsoft.AspNetCore.Components.NavigationManager");

            if (navService is not null)
            {
                services.Remove(navService);
                var blazrNavigationManager = new BlazrNavigationManager((NavigationManager)navService.ImplementationInstance!);
                services.AddSingleton<NavigationManager>(sp => blazrNavigationManager);
                services.AddSingleton<BlazrNavigationManager>(sp => blazrNavigationManager);
            }
        }
    }
}
