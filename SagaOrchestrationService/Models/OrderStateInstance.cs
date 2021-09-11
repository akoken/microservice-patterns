// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using System.Linq;
using System.Text;
using Automatonymous;

namespace SagaOrchestrationService.Models
{
    public class OrderStateInstance : SagaStateMachineInstance
    {
        public Guid CorrelationId { get; set; }

        public string CurrentState { get; set; }

        public string BuyerId { get; set; }

        public int OrderId { get; set; }

        public string CardName { get; set; }

        public string CardNumber { get; set; }

        public string Expiration { get; set; }

        public string CVV { get; set; }

        public decimal TotalPrice { get; set; }

        public DateTime CreateDate { get; set; }

        public override string ToString()
        {
            var properties = GetType().GetProperties();
            var builder = new StringBuilder();

            properties.ToList().ForEach(p =>
            {
                var value = p.GetValue(this, null);
                builder.Append($"{p.Name}:{value}");
            });
            builder.Append("-----------------");
            return builder.ToString();
        }
    }
}
