using System;
using Api.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Api.Data.Test
{
    public abstract class NewBaseType
    {
        public void BaseTest()
        {

        }
    }

    public abstract class BaseTest : NewBaseType
    {
    }

    public class DbTeste : IDisposable
    {
        private string dataBaseName = $"dbApiTest_{ Guid.NewGuid().ToString().Replace("-", string.Empty)}";
        public ServiceProvider ServiceProvider { get; private set; }

        public DbTeste()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddDbContext<MyContext>(o =>
            o.UseMySql($"Persist security Info=True;Server=localhost;Database={dataBaseName};User=root;Password=aluno123"),
                ServiceLifetime.Transient
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
