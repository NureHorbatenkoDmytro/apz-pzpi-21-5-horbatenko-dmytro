using FloraSense.Constants;
using FloraSense.Pages;
using FloraSense.ViewModels;
using FloraSense.ViewModels.AppViewModels;
using FloraSense.ViewModels.PageViewModels;
using FloraService.Abstractions.Pages;
using FloraService.ApiLayer.Entities.AuthorizationConfigurations;
using Microsoft.Extensions.Configuration;

namespace FloraSense
{
    public static class DependencyInjector
    {
        public static void Inject(IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.AddAutoMapper(typeof(MauiProgram));

            serviceCollection.AddScoped<AppShell>();

            RegisterPages(serviceCollection);
            RegisterViewModels(serviceCollection);

            serviceCollection.AddSingleton(_ =>
            {
                return new AuthorizationConfiguration
                {
                    AccessToken = Preferences.Get(PreferenceConstants.AccessToken, null)
                };
            });

            ApiLayer.DependencyInjector.Inject(serviceCollection, configuration);
        }

        private static void RegisterPages(IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IEntityWithGuards, LoginPage>();
            serviceCollection.AddScoped<IEntityWithGuards, RegistrationPage>();
            serviceCollection.AddScoped<IEntityWithGuards, PlantsPage>();
            serviceCollection.AddScoped<IEntityWithGuards, PlantTypesPage>();
            serviceCollection.AddScoped<IEntityWithGuards, LogoutPage>();
        }

        private static void RegisterViewModels(IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped(typeof(EntityBaseViewModel<,,,>));
            serviceCollection.AddScoped<AppShellViewModel>();
            serviceCollection.AddScoped<LoginViewModel>();
            serviceCollection.AddScoped<RegistrationViewModel>();
            serviceCollection.AddScoped<LogoutViewModel>();
            serviceCollection.AddScoped<PlantTypeViewModel>();
            serviceCollection.AddScoped<PlantViewModel>();
        }
    }
}
