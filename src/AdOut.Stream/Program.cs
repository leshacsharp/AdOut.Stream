using AdOut.Extensions.Communication;
using AdOut.Extensions.Infrastructure;
using AdOut.Stream.Core.Consumers;
using AdOut.Stream.Core.Services;
using AdOut.Stream.Model.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdOut.Stream
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static async Task Main()
        { 
            var host = CreateHostBuilder().Build();
            using var scope = host.Services.CreateScope();
            var initializationTasks = scope.ServiceProvider.GetServices<IInitialization>();

            foreach (var t in initializationTasks)
            {
                await t.InitAsync();
            }

            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(host.Services.GetRequiredService<Form1>());
        }

        private static IHostBuilder CreateHostBuilder() =>
           Host.CreateDefaultBuilder()
               .UseConsoleLifetime()
               .ConfigureServices((hostContext, services) =>
               {
                   services.AddMessageBrokerServices();
                   services.AddSingleton<IPlanHandledConsumer, PlanHandledConsumer>();
                   services.AddScoped<IInitialization, PlanHandledQueueInitialization>();
                   services.Configure<RabbitConfig>(hostContext.Configuration.GetSection(nameof(RabbitConfig)));
                   services.AddTransient<Form1>();
               });
    }
}
