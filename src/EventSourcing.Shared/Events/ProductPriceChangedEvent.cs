// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;

namespace EventSourcing.Shared.Events
{
    public class ProductPriceChangedEvent : IEvent
    {
        public Guid Id { get; set; }
        public decimal ChangedPrice { get; set; }
    }
}
