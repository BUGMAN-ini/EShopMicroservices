namespace Ordering.Application.DTOs
{
    public record PaymentDto(
        Guid Id,
        Guid OrderId,
        string CardNumber,
        string CardHolderName,
        DateTime ExpirationDate,
        string Cvv,
        decimal Amount);
}