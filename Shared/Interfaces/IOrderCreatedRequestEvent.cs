// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Collections.Generic;

namespace Shared.Interfaces
{
    public interface IOrderCreatedRequestEvent
    {
        public int OrderId { get; set; }

        public string BuyerId { get; set; }

        public List<OrderItemMessage> OrderItems { get; set; }

        public PaymentMessage Payment { get; set; }
    }
}
