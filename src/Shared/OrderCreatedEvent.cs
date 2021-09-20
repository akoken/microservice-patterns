using System.Collections.Generic;

namespace Shared
{
    public class OrderCreatedEvent
    {
        public int OrderId { get; set; }

        public string BuyerId { get; set; }
        public PaymentMessage Payment { get; set; }

        public List<OrderItemMessage> OrderItems { get; set; } = new List<OrderItemMessage>();
    }
}
