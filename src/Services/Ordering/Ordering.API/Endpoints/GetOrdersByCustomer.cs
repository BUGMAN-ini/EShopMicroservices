namespace Ordering.API.Endpoints
{
    public record GetOrderByCustomerRequest(Guid Id);
    public record GetOrdersByCustomerResponse(IEnumerable<OrderDto> Orders);
    public class GetOrdersByCustomer : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/orders/{Id}", async (GetOrderByCustomerRequest request, ISender sender) =>
            {
                var customer = request.Adapt<GetOrderByCustomerQuery>();
                var result = await sender.Send(customer);
                var response = result.Adapt<GetOrdersByCustomerResponse>();
                return Results.Ok(response);

            }).WithName("GetOrdersByName")
              .Produces<GetOrdersByCustomerResponse>(StatusCodes.Status200OK)
              .ProducesProblem(StatusCodes.Status400BadRequest)
              .ProducesProblem(StatusCodes.Status404NotFound)
              .WithSummary("GetOrdersByName")
              .WithDescription("GetOrdersByName");
        }
    }
}
