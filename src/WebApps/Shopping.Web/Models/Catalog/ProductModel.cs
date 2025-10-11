namespace Shopping.Web.Models.Catalog
{
    public class ProductModel
    {
        public Guid id { get; set; }
        public string Name { get; set; } = default!;
        public List<string> Category { get; set; } = new();
        public string Description { get; set; } = default!;
        public string ImageFile { get; set; } = default!;
        public decimal Price { get; set; }

    }

    public record GetProductsRequest(int? PageNumber = 1, int? PageSize = 10);
    public record GetProductsResponse(IEnumerable<ProductModel> Products);
    public record GetProductByIdResponse(ProductModel Product);
}
