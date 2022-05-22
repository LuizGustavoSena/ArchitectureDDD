using Api.Domain.Interfaces.Service.City;
using Api.Domain.Interfaces.Service.State;
using Api.Domain.Interfaces.Service.User;
using Api.Domain.Interfaces.Service.ZipCode;
using Api.Service.Service;
using Microsoft.Extensions.DependencyInjection;

namespace Api.CrossCutting.DependecyInjection
{
    public class ConfigureService
    {
        public static void ConfigureDependenciesService(IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IUserService, UserService>();
            serviceCollection.AddTransient<ILoginService, LoginService>();

            serviceCollection.AddTransient<IStateService, StateService>();
            serviceCollection.AddTransient<ICityService, CityService>();
            serviceCollection.AddTransient<IZipCodeService, ZipCodeService>();
        }
    }
}