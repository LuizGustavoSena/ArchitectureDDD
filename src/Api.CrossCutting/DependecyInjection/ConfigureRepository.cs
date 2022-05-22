using System;
using Api.Data.Context;
using Api.Data.Implementations;
using Api.Data.Repository;
using Api.Domain.Interfaces;
using Api.Domain.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Api.CrossCutting.DependecyInjection
{
    public class ConfigureRepository
    {
        public static void ConfigureDependenciesService(IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
            serviceCollection.AddScoped<IUserRepository, UserImplementations>();

            serviceCollection.AddScoped<IStateRepository, StateImplementations>();
            serviceCollection.AddScoped<ICityRepository, CityImplementations>();
            serviceCollection.AddScoped<IZipCodeRepository, ZipCodeImplementations>();

            var connectionString = Environment.GetEnvironmentVariable("DB_CONNECTION");

            serviceCollection.AddDbContext<MyContext>(
                options => options.UseSqlServer(connectionString)
            );
        }
    }
}