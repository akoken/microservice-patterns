// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;

namespace EventSourcing.API.Models
{
    public class ChangeProductPriceRequest
    {
        public Guid Id { get; set; }
        public decimal Price { get; set; }
    }
}
