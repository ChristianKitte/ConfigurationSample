using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;

namespace ConfigurationSample
{
    /// <summary>
    /// Die Anwendung
    /// </summary>
    class Program
    {
        /// <summary>
        /// Der Einstiegspunkt der Anwendung mit der statischen Main Methode
        /// </summary>
        /// <param name="args">Die Parameterliste</param>
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        /// <summary>
        /// CreateHostBuilder erzeugt eine Instanz vo IHostBuilder. Das .NET Core 5 Framework verfügt von zu Hause aus über
        /// die Fähigkeit, JSON Konfigurationsdateien zu verwenden. Im Fall der Benamung mit appsetting.json wird dies File
        /// automatisch verwendet und müsste eigentlich nicht wie hier geschehen extra hinzugefügt werden. Die Konfiguration
        /// ist durch DI verfügbar.
        ///
        /// Grundsätzlich können hier auch andere DI Lösungen wie Autofac initialisiert werden.
        /// </summary>
        /// <param name="args">Die Parameterliste</param>
        /// <returns></returns>
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((hostContext, service) => { service.AddJsonFile("appsettings.json"); })
                .ConfigureServices((hostContext, services) => { services.AddHostedService<StartUp>(); });
    }

    /// <summary>
    /// Die StartUp Klasse, welche die Anwendung quasi nach dem Start repräsentiert. Die Anwendung als Ganzes läuft
    /// hierdurch als ein gehosteter Service
    /// </summary>
    class StartUp : IHostedService
    {
        /// <summary>
        /// Der Konstruktor der Klasse. Das .NET Core 5 Framework verfügt von zu Hause aus über einen DI Mechanismus, der
        /// hier im Rahmen einer Constructor Injection genutzt wird
        /// </summary>
        /// <param name="config">Eine Instanz von IConfiguration</param>
        public StartUp(IConfiguration config)
        {
            IConfiguration _config = config;

            Console.Clear();
            Console.WriteLine(_config.GetSection("MyConfig")["ApplicationName"]);
        }

        /// <summary>
        /// Wird aufgerufen, wenn die Anwendung startet
        /// </summary>
        /// <param name="cancellationToken">Token mit Abbruchmöglichkeit</param>
        /// <returns>Ein CompletedTask</returns>
        public Task StartAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        /// <summary>
        /// Wird aufgerufen, wenn die Anwendung beendet wird
        /// </summary>
        /// <param name="cancellationToken">Token mit Abbruchmöglichkeit</param>
        /// <returns>Ein CompletedTask</returns>
        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}