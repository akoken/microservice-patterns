namespace Shared
{
    public class RabbitMQSettings
    {
        public const string OrderSaga = "order-saga-queue";
        public const string StockRollbackQueueName = "stock-rollback-queue";
        public const string StockOrderCreatedEventQueueName = "stock-order-created-queue";
        public const string OrderRequestCompletedEventQueueName = "order-request-completed-queue";
        public const string OrderRequestFailedEventQueueName = "order-request-failed-queue";
        public const string PaymentStockReservedRequestQueueName = "payment-stock-reserved-queue";
    }
}
