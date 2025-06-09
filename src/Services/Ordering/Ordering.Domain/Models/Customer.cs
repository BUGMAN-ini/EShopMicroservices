namespace Ordering.Domain.Models
{
    public class Customer : Entity<CustomerId>
    {
        public string Name { get; private set; } = default!;
        public decimal Price { get; private set; } = default!;

    }
}
