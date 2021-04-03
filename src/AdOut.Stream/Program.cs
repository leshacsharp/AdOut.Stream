using AdOut.Extensions.Communication;
using AdOut.Extensions.Infrastructure;
using AdOut.Stream.Core.Consumers;
using AdOut.Stream.Core.Services;
using AdOut.Stream.Model.Config;
using AdOut.Stream.Model.Interfaces;
using AdOut.Stream.Model.Models;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdOut.Stream
{
    static class Program
    {
        private static void Test(ITimeLineService timeLineService)
        {
            var plans = new List<PlanTime>()
            {
                new PlanTime()
                {
                    Ads = new List<AdPlanTime>()
                    {
                        new AdPlanTime() { Title = "plan1-test1ad", Path = "path", Order = 1 },
                        new AdPlanTime() { Title = "plan1-test2ad", Path = "path", Order = 2 }
                    },
                    Schedules = new List<SchedulePeriod>()
                    {
                        new SchedulePeriod()
                        {
                            Dates = new List<DateTime>()
                            {
                                new DateTime(2021, 4, 1),
                                new DateTime(2021, 4, 2),
                                new DateTime(2021, 4, 3)
                            },
                            TimeRanges = new List<TimeRange>()
                            {
                                new TimeRange() { Start = TimeSpan.Parse("10:00"), End = TimeSpan.Parse("10:05") },
                                new TimeRange() { Start = TimeSpan.Parse("10:10"), End = TimeSpan.Parse("10:15") },
                                new TimeRange() { Start = TimeSpan.Parse("10:20"), End = TimeSpan.Parse("10:25") },
                                new TimeRange() { Start = TimeSpan.Parse("10:30"), End = TimeSpan.Parse("10:35") }
                            }
                        },
                        new SchedulePeriod()
                        {
                            Dates = new List<DateTime>()
                            {
                                new DateTime(2021, 4, 2),
                                new DateTime(2021, 4, 3),
                                new DateTime(2021, 4, 4)
                            },
                            TimeRanges = new List<TimeRange>()
                            {
                                new TimeRange() { Start = TimeSpan.Parse("16:30"), End = TimeSpan.Parse("16:35") },
                                new TimeRange() { Start = TimeSpan.Parse("16:40"), End = TimeSpan.Parse("16:45") },
                                new TimeRange() { Start = TimeSpan.Parse("16:50"), End = TimeSpan.Parse("16:55") },
                                new TimeRange() { Start = TimeSpan.Parse("17:00"), End = TimeSpan.Parse("17:05") }
                            }
                        }
                    }
                },
                new PlanTime()
                {
                    Ads = new List<AdPlanTime>()
                    {
                        new AdPlanTime() { Title = "plan2-test1ad", Path = "path", Order = 2 },
                        new AdPlanTime() { Title = "plan2-test2ad", Path = "path", Order = 1 }
                    },
                    Schedules = new List<SchedulePeriod>()
                    {
                        new SchedulePeriod()
                        {
                            Dates = new List<DateTime>()
                            {
                                new DateTime(2021, 4, 1),
                                new DateTime(2021, 4, 2),
                                new DateTime(2021, 4, 3)
                            },
                            TimeRanges = new List<TimeRange>()
                            {
                                new TimeRange() { Start = TimeSpan.Parse("10:05"), End = TimeSpan.Parse("10:10") },
                                new TimeRange() { Start = TimeSpan.Parse("10:15"), End = TimeSpan.Parse("10:20") }
                            }
                        },
                        new SchedulePeriod()
                        {
                            Dates = new List<DateTime>()
                            {
                                new DateTime(2021, 4, 2),
                                new DateTime(2021, 4, 3),
                                new DateTime(2021, 4, 4),
                                new DateTime(2021, 4, 8)
                            },
                            TimeRanges = new List<TimeRange>()
                            {
                                new TimeRange() { Start = TimeSpan.Parse("16:55"), End = TimeSpan.Parse("17:00") },
                                new TimeRange() { Start = TimeSpan.Parse("17:05"), End = TimeSpan.Parse("17:10") }
                            }
                        }
                    }
                }
            };

            //var a = timeLineService.GenerateTimeAdBlocks(plans[0], new DateTime(2021, 4, 4), new DateTime(2021, 4, 4));
            //var b = timeLineService.GenerateTimeLine(plans, new DateTime(2021, 4, 2), new DateTime(2021, 4, 2));
            var b = timeLineService.GenerateTimeLine(plans, new DateTime(2021, 4, 8), new DateTime(2021, 4, 8));
        }

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static async Task Main()
        { 
            var host = CreateHostBuilder().Build();
            using var scope = host.Services.CreateScope();
            var initializationTasks = scope.ServiceProvider.GetServices<IInitialization>();

            Test(scope.ServiceProvider.GetRequiredService<ITimeLineService>());

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
                   services.AddScoped<ITimeLineService, TimeLineService>();
                   services.Configure<RabbitConfig>(hostContext.Configuration.GetSection(nameof(RabbitConfig)));
                   services.Configure<AdPointConfig>(hostContext.Configuration.GetSection(nameof(AdPointConfig)));
                   services.AddTransient<Form1>();
               });    
    }
}
