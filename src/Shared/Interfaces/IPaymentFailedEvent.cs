// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using System.Collections.Generic;
using MassTransit;

namespace Shared.Interfaces
{
    public interface IPaymentFailedEvent : CorrelatedBy<Guid>
    {
        public string Reason { get; set; }

        public List<OrderItemMessage> OrderItems { get; set; }
    }
}
