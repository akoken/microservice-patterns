﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MassTransit;
using Microsoft.Extensions.Logging;
using OrderService.Models;
using Shared;

namespace OrderService.Consumers
{
    public class PaymentFailedEventConsumer : IConsumer<PaymentFailedEvent>
    {
        private readonly AppDbContext _context;

        private readonly ILogger<PaymentCompletedEventConsumer> _logger;

        public PaymentFailedEventConsumer(AppDbContext context, ILogger<PaymentCompletedEventConsumer> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task Consume(ConsumeContext<PaymentFailedEvent> context)
        {
            var order = await _context.Orders.FindAsync(context.Message.OrderId);

            if (order != null)
            {
                order.Status = OrderStatus.Fail;
                order.FailMessage = context.Message.Message;
                await _context.SaveChangesAsync();

                _logger.LogInformation($"Order (Id={context.Message.OrderId}) status changed : {order.Status}");
            }
            else
            {
                _logger.LogError($"Order (Id={context.Message.OrderId}) not found");
            }
        }
    }
}
