namespace Catalog.API.Products.CreateProduct
{
    public record CreateProductCommand(string Name, List<string> Category, string Description,string ImageFile, decimal price)
        : ICommand<CreateProductResult>;
    public record CreateProductResult(Guid id);
    internal class CreateProductHandler(IDocumentSession session) 
        : ICommandHandler<CreateProductCommand, CreateProductResult>
    {
        public async Task<CreateProductResult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
        {
            //business Logic
            //Create Product
            //Save to DataBase
            //return CreateProductResult result

            var product = new Product
            {
                Name = command.Name,
                Category = command.Category,
                Description = command.Description,
                ImageFile = command.ImageFile,
                Price = command.price
            };
            session.Store(product);
            await session.SaveChangesAsync(cancellationToken);
            

            return new CreateProductResult(product.Id);
        }
    }
}
