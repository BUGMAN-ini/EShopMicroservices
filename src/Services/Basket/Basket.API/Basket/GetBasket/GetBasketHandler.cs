namespace Basket.API.Basket.GetBasket
{
    public record GetBasketQuery(string UserName) : IQuery<GetBasketResult>;
    public record GetBasketResult(ShoppingCart Cart);
    public class GetBasketHandler(IBasketRepository repo)
        : IQueryHandler<GetBasketQuery, GetBasketResult>
    {
        public async Task<GetBasketResult> Handle(GetBasketQuery query, CancellationToken cancellationToken)
        {
            // TODO: get basket from database
            //var basket = await _repository.GetBasket(request.Username)

            var basket = await repo.GetBasket(query.UserName);

            return new GetBasketResult(basket);
        }
    }
}
