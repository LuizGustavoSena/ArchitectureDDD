using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Api.Data.Context
{
    public class ContextFactory : IDesignTimeDbContextFactory<MyContext>
    {
        public MyContext CreateDbContext(string[] args)
        {
            DotNetEnv.Env.Load();
            var server = Environment.GetEnvironmentVariable("SERVER");
            var port = Environment.GetEnvironmentVariable("PORT");

            var connecctionString = $"Server='{server}';Port='{port}';Database=DbApi;Uid=root;";
            var optionBuilder = new DbContextOptionsBuilder<MyContext>();
            optionBuilder.UseMySql(connecctionString);
            return new MyContext(optionBuilder.Options);
        }
    }
}