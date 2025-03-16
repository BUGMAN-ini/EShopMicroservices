namespace Catalog.API.Products.CreateProduct
{
    public record CreateProductRequest(string Name, List<string> Category, string Description, string ImageFile, decimal price);
    public record CreateProductResponse(Guid id);
    public class CreateProductEndpoint
    {

    }
}
