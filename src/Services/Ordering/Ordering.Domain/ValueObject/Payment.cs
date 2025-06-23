namespace Ordering.Domain.ValueObject
{
    public record Payment
    {
        public string? CardName { get; } = default!;
        public string CardNumber { get; } = default!;
        public string Expiration { get; } = default!;
        public string CVV { get; } = default!;
        public int PaymentMethod { get; } = default!; // Assuming this is an enum or int representing the payment method

        private Payment(string CardName, string CardNumber, string Expiration, string CVV, int PaymentMethod)
        {
            this.CardName = CardName;
            this.CardNumber = CardNumber;
            this.Expiration = Expiration;
            this.CVV = CVV;
            this.PaymentMethod = PaymentMethod;
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
