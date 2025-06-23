using Ordering.Domain.Models;

namespace Ordering.Domain.Events
{
    public record OrderItemAddedDomainEvent(Order order, OrderItem orderitem) : IDomainEvent;
}
