using Ordering.Application.Orders.Query.GetOrders;

namespace Ordering.API.Endpoints
{
    public record GetOrdersResult(PaginatedResult<OrderDto> Orders);
    public class GetOrders : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/orders", async ([AsParameters] PaginationRequest request, ISender sender) =>
            {
                var result = await sender.Send(new GetOrdersQuery(request));

                var response = result.Adapt<GetOrdersResult>();

                return Results.Ok(response);
            }).WithName("GetOrders")
              .Produces<GetOrdersResult>(StatusCodes.Status200OK)
              .ProducesProblem(StatusCodes.Status400BadRequest)
              .ProducesProblem(StatusCodes.Status404NotFound)
              .WithSummary("GetOrders")
              .WithDescription("GetOrders");
        }
    }
}
