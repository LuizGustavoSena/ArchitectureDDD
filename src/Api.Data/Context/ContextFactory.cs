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
            var user = Environment.GetEnvironmentVariable("USER");
            var password = Environment.GetEnvironmentVariable("PASSWORD");

            var connecctionString = $"server='{server}','{port}';database=dbApi;user='{user}';password='{password}'";
            var optionBuilder = new DbContextOptionsBuilder<MyContext>();
            optionBuilder.UseSqlServer(connecctionString);
            return new MyContext(optionBuilder.Options);
        }
    }
}