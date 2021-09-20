// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using Shared.Interfaces;

namespace Shared.Events
{
    public class OrderRequestFailedEvent : IOrderRequestFailedEvent
    {
        public int OrderId { get; set; }
        public string Reason { get; set; }
    }
}
