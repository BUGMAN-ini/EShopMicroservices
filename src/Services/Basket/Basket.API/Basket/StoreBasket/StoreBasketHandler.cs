namespace Basket.API.Basket.StoreBasket
{
    public record StoreBasketCommand(ShoppingCart cart) : ICommand<StoreBasketResult>;
    public record StoreBasketResult(bool IsSuccess);

    public class CommandValidator : AbstractValidator<StoreBasketCommand>
    {
        public CommandValidator()
        {
            RuleFor(x => x.cart).NotNull().WithMessage("Cart can not be null");
            RuleFor(x => x.cart.UserName).NotEmpty().WithMessage("USername is required");
        }
    }
    public class StoreBasketHandler : ICommandHandler<>
    {
    }
}
