﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using System.Collections.Generic;
using MassTransit;

namespace Shared.Interfaces
{
    public interface IStockReservedRequestPayment : CorrelatedBy<Guid>
    {
        PaymentMessage Payment { get; set; }

        List<OrderItemMessage> OrderItems { get; set; }

        public string BuyerId { get; set; }
    }
}
