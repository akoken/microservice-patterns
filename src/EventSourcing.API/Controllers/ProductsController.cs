// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using System.Threading.Tasks;
using EventSourcing.API.Commands;
using EventSourcing.API.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EventSourcing.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateProductRequest request)
        {
            await _mediator.Send(new CreateProductCommand { CreateProductRequest = request });
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> ChangeName(ChangeProductNameRequest request)
        {
            await _mediator.Send(new ChangeProductNameCommand { ChangeProductNameRequest = request });
            return NoContent();
        }

        [HttpPut]
        public async Task<IActionResult> ChangePrice(ChangeProductPriceRequest request)
        {
            await _mediator.Send(new ChangeProductPriceCommand { ChangeProductPriceRequest = request });
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _mediator.Send(new DeleteProductCommand { Id = id });
            return NoContent();
        }
    }
}
