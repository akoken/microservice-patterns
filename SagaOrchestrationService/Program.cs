using System.Reflection;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SagaOrchestrationService.Data;
using SagaOrchestrationService.Models;
using Shared;

namespace SagaOrchestrationService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddMassTransit(cfg =>
                    {
                        cfg.AddSagaStateMachine<OrderStateMachine, OrderStateInstance>().EntityFrameworkRepository(opt =>
                        {
                            opt.AddDbContext<DbContext, OrderStateDbContext>((provider, builder) =>
                            {
                                builder.UseSqlServer(hostContext.Configuration.GetConnectionString("SqlConnection"), m =>
                                {
                                    m.MigrationsAssembly(Assembly.GetExecutingAssembly().GetName().Name);
                                });
                            });
                        });

                        cfg.AddBus(provider => Bus.Factory.CreateUsingRabbitMq(configure =>
                        {
                            configure.Host(hostContext.Configuration.GetConnectionString("RabbitMQ"));

                            configure.ReceiveEndpoint(RabbitMQSettingsConst.OrderSaga, e =>
                            {
                                e.ConfigureSaga<OrderStateInstance>(provider);
                            });
                        }));
                    });
                    services.AddMassTransitHostedService();
                    services.AddHostedService<Worker>();
                });
    }
}
