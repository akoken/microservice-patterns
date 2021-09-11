using System.Reflection;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using SagaOrchestrationService;
using SagaOrchestrationService.Data;
using SagaOrchestrationService.Models;
using Shared;

Microsoft.Extensions.Hosting.IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((hostContext, services) =>
    {
        services.AddMassTransit(cfg =>
        {
            cfg.AddSagaStateMachine<OrderStateMachine, OrderStateInstance>().EntityFrameworkRepository(options =>
            {
                options.AddDbContext<DbContext, OrderStateDbContext>((provider, builder) =>
                {
                    builder.UseSqlServer(hostContext.Configuration.GetConnectionString("SqlConnection"), m =>
                    {
                        m.MigrationsAssembly(Assembly.GetExecutingAssembly().GetName().Name);
                    });
                });
            });

            cfg.AddBus(provider => Bus.Factory.CreateUsingRabbitMq(config =>
            {
                config.Host(hostContext.Configuration.GetConnectionString("RabbitMQ"));

                config.ReceiveEndpoint(RabbitMQSettingsConst.OrderSaga, e =>
                {
                    e.ConfigureSaga<OrderStateInstance>(provider);
                });
            }));
        });

        services.AddHostedService<Worker>();
    })
    .Build();

await host.RunAsync();
