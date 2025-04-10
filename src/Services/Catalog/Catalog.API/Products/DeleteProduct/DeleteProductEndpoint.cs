
using Catalog.API.Products.UpdateProduct;

namespace Catalog.API.Products.DeleteProduct
{
    //public record DeleteProductRequest(Guid Id);
    public record DeleteProductResponse(bool IsSuccess);
    public class DeleteProductEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapDelete("products/{id}", async (Guid id, ISender sender) =>
            {
                var response = await sender.Send(new DeleteProductCommand(id));
                var data = response.Adapt<DeleteProductResponse>();

                return Results.Ok(data);
            })
              .WithName("Delete Products")
              .Produces<DeleteProductResponse>(StatusCodes.Status201Created)
              .ProducesProblem(StatusCodes.Status400BadRequest)
              .ProducesProblem(StatusCodes.Status404NotFound)
              .WithSummary("Delete Product")
              .WithDescription("Delete Product");
        }
    }
}
