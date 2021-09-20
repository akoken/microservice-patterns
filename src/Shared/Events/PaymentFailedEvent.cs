using System;
using System.Collections.Generic;
using Shared.Interfaces;

namespace Shared.Events
{
    public class PaymentFailedEvent : IPaymentFailedEvent
    {
        public PaymentFailedEvent(Guid correlationId)
        {
            CorrelationId = correlationId;
        }

        public string Reason { get; set; }

        public List<OrderItemMessage> OrderItems { get; set; } = new List<OrderItemMessage>();

        public Guid CorrelationId { get; }
    }
}
