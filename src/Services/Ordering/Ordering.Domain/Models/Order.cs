using Ordering.Domain.Events;

namespace Ordering.Domain.Models
{
    public class Order : Aggregate<OrderId>
    {
        private readonly List<OrderItem> _orderItems = new();
        public IReadOnlyList<OrderItem> OrderItems => _orderItems.AsReadOnly();

        public CustomerId CustomerId { get; private set; } = default!;
        public OrderName OrderName { get; private set; } = default!;
        public Address ShippingAddress { get; private set; } = default!;
        public Address BillingAddress { get; private set; } = default!;
        public Payment Payment { get; private set; } = default!;
        public OrderStatus Status { get; private set; } = OrderStatus.Pending;
        public decimal TotalPrice
        {
            get => _orderItems.Sum(x => x.Price * x.Quantity);
            private set { } // private setter to prevent external modification
        }

        public static Order Create(OrderId id, CustomerId customerId, OrderName orderName, Address shippingAddress, Address billingAddress, Payment payment)
        {
            ArgumentNullException.ThrowIfNull(customerId);
            ArgumentNullException.ThrowIfNull(orderName);
            ArgumentNullException.ThrowIfNull(shippingAddress);
            ArgumentNullException.ThrowIfNull(billingAddress);
            ArgumentNullException.ThrowIfNull(payment);
            var order = new Order
            {
                Id = id,
                CustomerId = customerId,
                OrderName = orderName,
                ShippingAddress = shippingAddress,
                BillingAddress = billingAddress,
                Payment = payment
            };
            order.AddDomainEvent(new OrderCreatedEvent(order));
            return order;
        }

        public void Update(OrderName orderName,Address shippingAddress, Address billingAddress, Payment payment, OrderStatus orderstatus)
        {
            OrderName = orderName;
            ShippingAddress = shippingAddress;
            BillingAddress = billingAddress;
            Payment = payment;
            Status = orderstatus;

            AddDomainEvent(new OrderUpdatedEvent(this));
        }

        public void Add(ProductId productId, int quantity, decimal price)
        {
            ArgumentOutOfRangeException.ThrowIfNegativeOrZero(quantity);
            ArgumentOutOfRangeException.ThrowIfNegativeOrZero(price);
            var orderItem = new OrderItem(Id, productId, quantity, price);
            _orderItems.Add(orderItem);
            AddDomainEvent(new OrderItemAddedDomainEvent(this, orderItem));
        }

        public void Remove(ProductId productId)
        {
            var orderItem = _orderItems.FirstOrDefault(x => x.ProductId == productId);
            if (orderItem is not null)
            {
                _orderItems.Remove(orderItem);
            }
            
            AddDomainEvent(new OrderItemRemovedDomainEvent(this, orderItem));
        }
    }
}
