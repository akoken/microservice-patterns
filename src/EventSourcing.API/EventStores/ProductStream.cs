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
    }
}
