using System.Reflection;
using MassTransit;
using IHost = Microsoft.Extensions.Hosting.IHost;
using Microsoft.Extensions.Hosting;
using static MassTransit.MessageHeaders;
using Host = Microsoft.Extensions.Hosting.Host;
using Serilog;
using Serilog.Formatting.Json;
using MassTransit.Configuration;
using NotificationService.Consumers;

namespace MM.MS.EcrProxyListener
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try {
                IHost host = Host.CreateDefaultBuilder(args)

     // Add Serilog configuration
             .UseSerilog((context, logger) =>
             {
                 logger.MinimumLevel.Debug().Enrich.FromLogContext();
                 if (context.HostingEnvironment.IsDevelopment())
                     logger.WriteTo.File("../../../../log.txt");
                 else
                     logger.WriteTo.File(new JsonFormatter(), "../../../../log.txt");

             })
                .ConfigureServices((hostContext, services) =>
                {
                    // services.AddHostedService<Worker>();

                    #region MassTransit - Bus Configuration
                    services.AddMassTransit(config =>
                    {
                        config.SetKebabCaseEndpointNameFormatter();

                        config.AddConsumer<NewCustomerConsumer>();
                        config.AddConsumer<ActivateCustomerConsumer>();
                        config.AddConsumer<AccountTransactionConsumer>();

                        config.UsingRabbitMq((ctx, cfg) =>
                        {
                            cfg.Host("localhost", hostConfigurator => { });
                            cfg.ConfigureEndpoints(ctx);
                        });

                        config.AddConsumers(Assembly.GetExecutingAssembly());


                    });
                    //.AddMassTransitHostedService();

                    #endregion


                    // Add DI and extensions

                })
                .Build();
                host.Run();
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, $"Error in {typeof(Program).Namespace}");
            }
            finally
            {
                Log.CloseAndFlush();
            } 
        } 
    } 
}


