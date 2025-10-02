namespace Domain.AskForPasta.Entities
{
    public class Payment : BaseEntity
    {
        public Payment(int purchaseId, DateTime paymentDate, int paymentMethodTypeId, decimal amount, DateTime createAt) : base(createAt)
        {
            PurchaseId = purchaseId;
            PaymentDate = paymentDate;
            PaymentMethodTypeId = paymentMethodTypeId;
            Amount = amount;
        }

        public int PurchaseId { get; private set; }
        public DateTime PaymentDate { get; private set; }
        public int PaymentMethodTypeId { get; private set; }
        public decimal Amount { get; private set; }
    }
}
