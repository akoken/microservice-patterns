﻿namespace Shared
{
    public class RabbitMQSettingsConst
    {
        public const string OrderSaga = "order-saga-queue";

        public const string StockRollbackQueueName = "stock-rollback-queue";

        public const string StockReservedEventQueueName = "stock-reserved-queue";
        public const string StockOrderCreatedEventQueueName = "stock-order-created-queue";
        public const string StockPaymentFailedEventQueueName = "stock-payment-failed-queue";

        public const string OrderRequestCompletedEventQueueName = "order-request-completed-queue";
        public const string OrderRequestFailedEventQueueName = "order-request-failed-queue";
        public const string OrderPaymentFailedEventQueueName = "order-payment-failed-queue";
        public const string OrderStockNotReservedEventQueueName = "order-stock-not-reserved-queue";

        public const string PaymentStockReservedRequestQueueName = "payment-stock-reserved-queue";
    }
}
