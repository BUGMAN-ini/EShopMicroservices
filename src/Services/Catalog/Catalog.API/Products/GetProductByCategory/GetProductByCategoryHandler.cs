
using Catalog.API.Models;
using Catalog.API.Products.GetProductById;

namespace Catalog.API.Products.GetProductByCategory
{
    public record GetProductByCategoryQuery(Product Category) : IQuery<GetProductByCategoryResult>;
    public record GetProductByCategoryResult(Product Product);

    internal class GetProductByCategoryHandler(IDocumentSession session, ILogger<GetProductByCategoryHandler> logger) 
        : IQueryHandler<GetProductByCategoryQuery, GetProductByCategoryResult>
    {
        public async Task<GetProductByCategoryResult> Handle(GetProductByCategoryQuery request, CancellationToken cancellationToken)
        {
            logger.LogInformation("GetProductsBycategoryQueryHandler.Handle called with {@request}", request);
            var result = await session.LoadAsync<Product>(request.Category,cancellationToken);

            if (result is null)
            {
                throw new ProductNotFoundException();
            }

            return new GetProductByCategoryResult(result);
        }
    }
}
