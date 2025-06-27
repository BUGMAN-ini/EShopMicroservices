using BuildingBlocks.CQRS;
using FluentValidation;
using Ordering.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Ordering.Application.Orders.Command.CreateOrder
{
    public record CreateOrderResult(Guid OrderId);
    public record CreateOrderCommand(OrderDto order) : ICommand<CreateOrderResult>;

    public class CreateOrderCommandValidator : AbstractValidator<CreateOrderCommand>
    {
        public CreateOrderCommandValidator()
        {
            RuleFor(x => x.order.OrderName)
                .NotNull()
                .WithMessage("Order cannot be null.");
            RuleFor(x => x.order.CustomerId)
                .NotEmpty()
                .WithMessage("CustomerId is required.");
            RuleFor(x => x.order.OrderItems)
                .NotEmpty()
                .WithMessage("OrderName is required.");
        }
    }

}
