﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using EventSourcing.API.Models;
using MediatR;

namespace EventSourcing.API.Commands
{
    public class CreateProductCommand : IRequest
    {
        public CreateProductRequest CreateProductRequest { get; set; }
    }
}
