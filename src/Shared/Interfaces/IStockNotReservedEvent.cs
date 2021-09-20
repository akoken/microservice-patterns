// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using MassTransit;

namespace Shared.Interfaces
{
    public interface IStockNotReservedEvent : CorrelatedBy<Guid>
    {
        string Reason { get; set; }
    }
}
