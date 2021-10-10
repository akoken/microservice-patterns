// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using EventSourcing.API.Data;
using EventSourcing.API.Data.Entities;
using EventSourcing.API.EventStores;
using EventSourcing.Shared.Events;
using EventStore.ClientAPI;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace EventSourcing.API.BackgroundServices
{
    public class ProductReadModelEventStore : BackgroundService
    {
        private readonly IEventStoreConnection _connection;
        private readonly ILogger<ProductReadModelEventStore> _logger;
        private readonly IServiceProvider _serviceProvider;

        public ProductReadModelEventStore(IEventStoreConnection connection, ILogger<ProductReadModelEventStore> logger, IServiceProvider serviceProvider)
        {
            _connection = connection;
            _logger = logger;
            _serviceProvider = serviceProvider;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await _connection.ConnectToPersistentSubscriptionAsync(ProductStream.StreamName, ProductStream.GroupName, EventAppeared, autoAck: false);
        }

        private async Task EventAppeared(EventStorePersistentSubscriptionBase arg1, ResolvedEvent arg2)
        {
            var type = Type.GetType($"{Encoding.UTF8.GetString(arg2.Event.Metadata)}, EventSourcing.Shared");
            _logger.LogInformation($"The message is processing... => {type.ToString()}");
            var eventData = Encoding.UTF8.GetString(arg2.Event.Data);
            var @event = JsonSerializer.Deserialize(eventData, type);

            using var scope = _serviceProvider.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

            Product product = null;
            switch (@event)
            {
                case ProductCreatedEvent createdEvent:
                    product = new Product
                    {
                        Id = createdEvent.Id,
                        Name = createdEvent.Name,
                        Price = createdEvent.Price,
                        Stock = createdEvent.Stock,
                        UserId = createdEvent.UserId
                    };
                    context.Products.Add(product);
                    break;
                case ProductNameChangedEvent nameChangedEvent:
                    product = await context.Products.FindAsync(nameChangedEvent.Id);
                    if (product is not null)
                    {
                        product.Name = nameChangedEvent.ChangedName;
                    }
                    break;
                case ProductPriceChangedEvent priceChangedEvent:
                    product = await context.Products.FindAsync(priceChangedEvent.Id);
                    if (product is not null)
                    {
                        product.Price = priceChangedEvent.ChangedPrice;
                    }
                    break;
                case ProductDeletedEvent deletedEvent:
                    product = await context.Products.FindAsync(deletedEvent.Id);
                    if (product is not null)
                    {
                        context.Products.Remove(product);
                    }
                    break;
            }

            await context.SaveChangesAsync();
            arg1.Acknowledge(arg2.Event.EventId);
        }
    }
}
