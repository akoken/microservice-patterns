using System;
using System.Collections.Generic;
using Shared.Interfaces;

namespace Shared.Events
{
    public class OrderCreatedEvent : IOrderCreatedEvent
    {
        public OrderCreatedEvent(Guid correlationId)
        {
            CorrelationId = correlationId;
        }

        public List<OrderItemMessage> OrderItems { get; set; } = new List<OrderItemMessage>();

        public Guid CorrelationId { get; }
    }
}
