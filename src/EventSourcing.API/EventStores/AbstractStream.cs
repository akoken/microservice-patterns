// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using EventSourcing.Shared.Events;
using EventStore.ClientAPI;

namespace EventSourcing.API.EventStores
{
    public abstract class AbstractStream
    {
        protected readonly List<IEvent> Events = new List<IEvent>();
        private readonly string _streamName;
        private readonly IEventStoreConnection _eventStoreConnection;

        protected AbstractStream(string streamName, IEventStoreConnection eventStoreConnection)
        {
            _streamName = streamName;
            _eventStoreConnection = eventStoreConnection;
        }

        public async Task SaveAsync()
        {
            var newEvents = Events.Select(x => new EventData(
                Guid.NewGuid(),
                x.GetType().Name,
                true,
                Encoding.UTF8.GetBytes(JsonSerializer.Serialize(x, inputType: x.GetType())),
                Encoding.UTF8.GetBytes(x.GetType().FullName)
                )).ToList();

            await _eventStoreConnection.AppendToStreamAsync(_streamName, ExpectedVersion.Any, newEvents);
            Events.Clear();
        }
    }
}
