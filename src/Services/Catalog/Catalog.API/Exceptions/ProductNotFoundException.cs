using BuildingBlocks.Exceptions;
using MediatR.Wrappers;

namespace Catalog.API.Exceptions
{
    [Serializable]
    internal class ProductNotFoundException : NotFoundException
    {
        public ProductNotFoundException(Guid id) : base("Product",id)
        {
        }

    }
}