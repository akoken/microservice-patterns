// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using EventSourcing.API.Models;
using EventSourcing.Shared.Events;
using EventStore.ClientAPI;

namespace EventSourcing.API.EventStores
{
    public class ProductStream : AbstractStream
    {
        public static string StreamName => "ProductStream";
        public static string GroupName => "ProductGroup";

        public ProductStream(IEventStoreConnection eventStoreConnection) : base(StreamName, eventStoreConnection)
        {
        }

        public void Created(CreateProductRequest request)
        {
            Events.Add(new ProductCreatedEvent
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                Price = request.Price,
                Stock = request.Stock,
                UserId = request.UserId
            });
        }

        public void NameChanged(ChangeProductNameRequest request)
        {
            Events.Add(new ProductNameChangedEvent
            {
                Id = request.Id,
                ChangedName = request.Name
            });
        }

        public void PriceChanged(ChangeProductPriceRequest request)
        {
            Events.Add(new ProductPriceChangedEvent
            {
                Id = request.Id,
                ChangedPrice = request.Price
            });
        }

        public void Deleted(Guid id)
        {
            Events.Add(new ProductDeletedEvent { Id = id });
        }
    }
}
