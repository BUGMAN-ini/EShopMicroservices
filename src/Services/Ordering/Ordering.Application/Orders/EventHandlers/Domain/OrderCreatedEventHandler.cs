using MassTransit;
using Microsoft.FeatureManagement;

namespace Ordering.Application.Orders.EventHandlers.Domain
{
    public class OrderCreatedEventHandler(IPublishEndpoint publishEnpoint,
        IFeatureManager featuremanagement,ILogger<OrderCreatedEventHandler> logger) 
        : INotificationHandler<OrderCreatedEvent>
    {
        public async Task Handle(OrderCreatedEvent domainEvent, CancellationToken cancellationToken)
        {
            logger.LogInformation("DomainEvent handled: {DomainEvent}", domainEvent.GetType().Name);
            // Publish event to start order fullfillment process
            if (await featuremanagement.IsEnabledAsync("OrderFullfillment"))
            { 
                var orderIntegrationEvent = domainEvent.order.ToOrderDto();
                await publishEnpoint.Publish(orderIntegrationEvent, cancellationToken);
            }

        }
    }
}
