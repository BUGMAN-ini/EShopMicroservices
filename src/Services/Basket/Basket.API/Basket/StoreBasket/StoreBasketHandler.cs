namespace Basket.API.Basket.StoreBasket
{
    public record StoreBasketCommand(ShoppingCart Cart) : ICommand<StoreBasketResult>;
    public record StoreBasketResult(string userName);

    public class CommandValidator : AbstractValidator<StoreBasketCommand>
    {
        public CommandValidator()
        {
            RuleFor(x => x.Cart).NotNull().WithMessage("Cart can not be null");
            RuleFor(x => x.Cart.UserName).NotEmpty().WithMessage("USername is required");
        }
    }
    public class StoreBasketHandler(IBasketRepository repo)
        : ICommandHandler<StoreBasketCommand, StoreBasketResult>
    {
        public async Task<StoreBasketResult> Handle(StoreBasketCommand command, CancellationToken cancellationToken)
        {
            await repo.StoreBasket(command.Cart, cancellationToken);

            return new StoreBasketResult("swn");
        }
    }
}
