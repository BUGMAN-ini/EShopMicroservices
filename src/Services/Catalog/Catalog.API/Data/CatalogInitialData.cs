namespace Catalog.API.Data
{
    public class CatalogInitialData : IInitialData
    {
        public async Task Populate(IDocumentStore store, CancellationToken cancellation)
        {
            using var session = store.LightweightSession();
            if (await session.Query<Product>().AnyAsync())
                return;

            session.Store<Product>(GetPreconfiguredProducts());
            await session.SaveChangesAsync();

        }

        private static IEnumerable<Product> GetPreconfiguredProducts() => new List<Product>()
        {
            new Product
            {
                Id = new Guid("01961a87-384a-4e05-bba2-b40305184bbd"),
                Name = "simona",
                Category = ["c1", "c2"],
                Description = "Description Product A",
                ImageFile = "ImageFile Product A",
                Price = 199
            }

        };

    };
}
