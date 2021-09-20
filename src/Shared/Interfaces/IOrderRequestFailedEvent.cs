// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace Shared.Interfaces
{
    public interface IOrderRequestFailedEvent
    {
        public int OrderId { get; set; }

        public string Reason { get; set; }
    }
}
