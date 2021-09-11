namespace Shared
{
    public class PaymentCompletedEvent
    {
        public int orderId { get; set; }

        public string BuyerId { get; set; }
    }
}