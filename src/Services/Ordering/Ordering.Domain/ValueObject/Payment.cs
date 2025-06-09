namespace Ordering.Domain.ValueObject
{
    public record Payment
    {
        public string? CardName { get; } = default!;
        public string CardNumber { get; } = default!;
        public string Expiration { get; } = default!;
        public string CVV { get; } = default!;
        public int PaymentMethod { get; } = default!; // Assuming this is an enum or int representing the payment method

        private Payment(string cardName, string cardNumber, string expiration, string cvv, int paymentMethod)
        {
            CardName = cardName;
            CardNumber = cardNumber;
            Expiration = expiration;
            CVV = cvv;
            PaymentMethod = paymentMethod;
        }
        public static Payment Of(string cardName, string cardNumber, string expiration, string cvv, int paymentMethod)
        {
            ArgumentNullException.ThrowIfNullOrWhiteSpace(cardName);
            ArgumentNullException.ThrowIfNullOrWhiteSpace(cardNumber);
            ArgumentNullException.ThrowIfNullOrWhiteSpace(cvv);
            ArgumentOutOfRangeException.ThrowIfGreaterThan(cvv.Length, 3);

            return new Payment(cardName, cardNumber, expiration, cvv, paymentMethod);
        }

    }
}
