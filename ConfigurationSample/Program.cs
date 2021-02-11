using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;

namespace ConfigurationSample
{
    class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((hostContext, service) =>
                {
                    service.AddJsonFile("appsettings.json");
                })
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddHostedService<StartUp>();
                });
    }

    class StartUp : IHostedService
    {
        public StartUp(IConfiguration test)
        {
            IConfiguration _test = test;

            Console.WriteLine("Hello World!");
            Console.WriteLine(test.GetSection("MyConfig")["ApplicationName"]);
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}