using Ordering.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Domain.Models
{
    public class Order : Aggregate<Guid>
    {
        private readonly List<OrderItem> _orderItems = new();
        public IReadOnlyList<OrderItem> OrderItems => _orderItems.AsReadOnly();
        public Guid CustomerId { get; private set; } = default!;
        public string OrderName { get; private set; } = default!;
        public Address ShippingAddress { get; private set; } = default!;
        public Address BillingAddress { get; private set; } = default!;
        public Payment Payment { get; private set; } = default!;
        public OrderStatus Status { get; private set; } = OrderStatus.Pending;
        public decimal TotalPric
        {
            get => _orderItems.Sum(x => x.Price * x.Quantity);
            private set { } // private setter to prevent external modification
        }
    }
}
