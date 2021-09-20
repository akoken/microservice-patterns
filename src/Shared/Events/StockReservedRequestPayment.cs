// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using System.Collections.Generic;
using Shared.Interfaces;

namespace Shared.Events
{
    public class StockReservedRequestPayment : IStockReservedRequestPayment
    {
        public StockReservedRequestPayment(Guid correlationId)
        {
            CorrelationId = correlationId;
        }

        public PaymentMessage Payment { get; set; }

        public List<OrderItemMessage> OrderItems { get; set; } = new List<OrderItemMessage>();

        public Guid CorrelationId { get; }
        public string BuyerId { get; set; }
    }
}
