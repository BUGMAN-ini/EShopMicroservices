using FluentValidation;

namespace Catalog.API.Products.CreateProduct
{
    public record CreateProductCommand(string Name, List<string> Category, string Description,string ImageFile, decimal price)
        : ICommand<CreateProductResult>;
    public record CreateProductResult(Guid id);

    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateProductCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name Is Required");
            RuleFor(x => x.Category).NotEmpty().WithMessage("Category is Required");
            RuleFor(x => x.ImageFile).NotEmpty().WithMessage("ImageFile is Required");
            RuleFor(x => x.price).GreaterThan(0).WithMessage("Price must be great than 0");

        }
    }

    internal class CreateProductHandler(IDocumentSession session) 
        : ICommandHandler<CreateProductCommand, CreateProductResult>
    {
        public async Task<CreateProductResult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
        {
            //business Logic
            //Create Product
            //Save to DataBase
            //return CreateProductResult result

            //var result = await validator.ValidateAsync(command, cancellationToken);
            //var msg = result.Errors.Select(x => x.ErrorMessage).ToList();
            //if (msg.Any())
            //{
            //    throw new ValidationException(msg.FirstOrDefault());
            //}

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
