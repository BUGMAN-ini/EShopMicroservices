using MediatR;

namespace Catalog.API.Products.CreateProduct
{
    public record CreateProductCommand(string Name, List<string> Category, string Description,string ImageFile, decimal price)
        : IRequest<CreateProductResponse>;
    public record CreateProductResponse(Guid id);
    internal class CreateProductHandler : IRequestHandler<CreateProductCommand, CreateProductResponse>
    {
        public Task<CreateProductResponse> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            //business Logic
            throw new NotImplementedException();
        }
    }
}
