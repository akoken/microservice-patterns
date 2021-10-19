// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace EventSourcing.API.Models
{
    public class CreateProductRequest
    {
        public int UserId { get; set; }

        public string Name { get; set; }

        public int Stock { get; set; }

        public decimal Price { get; set; }

        public CreateProductRequest()
        {
        }
    }
}
