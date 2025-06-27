using BuildingBlocks.CQRS;

namespace Ordering.Application.Orders.Command.CreateOrder
{
    public class CreateOrderHandler : ICommandHandler<CreateOrderCommand, CreateOrderResult>
    {
        public async Task<CreateOrderResult> Handle(CreateOrderCommand command, CancellationToken cancellationToken)
        {
            var order = new Order(
                OrderId.Of(command.OrderId),
                command.CustomerId,
                command.OrderItems.Select(item => new OrderItem(
                    OrderItemId.Of(item.Id),
                    item.ProductId,
                    item.Quantity,
                    item.Price
                )).ToList(),
                Payment.Of(
                    command.Payment.CardName,
                    command.Payment.CardNumber,
                    command.Payment.Expiration,
                    command.Payment.CVV,
                    command.Payment.PaymentMethod
                )
            );
        }
    }
}
