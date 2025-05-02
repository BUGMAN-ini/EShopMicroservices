namespace Basket.API.Data
{
    public class ChachedBasketRepository(IBasketRepository repo
            , IDistributedCache chache) : IBasketRepository
    {
        public async Task<ShoppingCart> GetBasket(string username, CancellationToken cancellation = default)
        {
            var chachedBasket = await chache.GetStringAsync(username, cancellation);
            if (!string.IsNullOrEmpty(chachedBasket))
                return JsonSerializer.Deserialize<ShoppingCart>(chachedBasket)!;   

            var basket = await repo.GetBasket(username, cancellation);
            await chache.SetStringAsync(username, JsonSerializer.Serialize(basket), cancellation);
            return basket;
        }

        public async Task<ShoppingCart> StoreBasket(ShoppingCart basket, CancellationToken cancellation = default)
        {
            await repo.StoreBasket(basket, cancellation);

            await chache.SetStringAsync(basket.UserName, JsonSerializer.Serialize(basket), cancellation);
            
            return basket;
        }

        public async Task<bool> DeleteBasket(string username, CancellationToken cancellation = default)
        {
            await repo.DeleteBasket(username, cancellation);
            
            await chache.RemoveAsync(username, cancellation);

            return true;
        }
    }
}
