namespace Basket.API.Basket.DeleteBasket
{
    public record DeleteBasketCommand(string userName) : ICommand<DeleteBasketResult>;
    public record DeleteBasketResult(bool IsSuccess);

    public class DeleteBasketCommandValidator : AbstractValidator<DeleteBasketCommand>
    {
        public DeleteBasketCommandValidator()
        {
            RuleFor(x => x.userName).NotEmpty().WithMessage("Username is required");
        }
    }
    public class DeleteBasketCommandHandler(IBasketRepository repo)
        : ICommandHandler<DeleteBasketCommand, DeleteBasketResult>
    {
        public async Task<DeleteBasketResult> Handle(DeleteBasketCommand command, CancellationToken cancellationToken)
        {

            await repo.DeleteBasket(command.userName, cancellationToken);

            return new DeleteBasketResult(true);
        }
    }
}
