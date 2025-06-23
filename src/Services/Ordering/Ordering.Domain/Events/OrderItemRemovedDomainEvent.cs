using Ordering.Domain.Models;

namespace Ordering.Domain.Events
{
    public record OrderItemRemovedDomainEvent(Order order, OrderItem orderitem) : IDomainEvent;
}
