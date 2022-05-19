using System;
using Microsoft.Extensions.DependencyInjection;
using Api.Data.Context;
namespace Api.Data.Test
{
    public abstract class BaseTest
    {
        public BaseTest()
        {

        }
    }

    public class DbTest : IDisposable
    {
        public string dataBaseName = $"dbApi_{Guid.NewGuid().ToString().Replace("-", string.Empty)}";
        public ServiceProvider ServiceProvider { get; private set; }

        public DbTest()
        {
            var serviceCollection = new ServiceCollection();
            var connectionString = $"Persist Security Info-True;Server=localhost;Database={dataBaseName};User=root;Password=mudar@123";
            serviceCollection.AddDbContext<MyContext>(
                options => options.UseSqlServer(connectionString),
                serviceLifeTime.Transient
            );

            ServiceProvider = serviceCollection.BuildServiceProvider();
            using (var context = ServiceProvider.GetService<MyContext>())
            {
                context.Database.EnsureCreated();
            }
        }

        public void Dispose()
        {
            using (var context = ServiceProvider.GetService<MyContext>())
            {
                context.Database.EnsureDeleted();
            }
        }
    }
}