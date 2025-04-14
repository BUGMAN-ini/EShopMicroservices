
using Basket.API.Basket.GetBasket;

namespace Basket.API.Basket.StoreBasket
{
    public record StoreBasketRequest(ShoppingCart cart);
    public record StoreBasketResponse(string userName);
    public class StoreBasketEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("/basket", async (StoreBasketRequest request, ISender sender ) =>
            {
                var command = request.Adapt<StoreBasketCommand>();

                var result = await sender.Send(command);

                var response = result.Adapt<StoreBasketResponse>();

                return Results.Created($"/basket/{response.userName}", response);
            })
                .WithName("PostBasket")
                .Produces<StoreBasketResponse>(StatusCodes.Status201Created)
                .ProducesProblem(StatusCodes.Status400BadRequest)
                .WithSummary("Add Basket")
                .WithDescription("Add Basket");
        }
    }
}
