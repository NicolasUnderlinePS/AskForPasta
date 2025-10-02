namespace Domain.AskForPasta.Entities
{
    public class PurchaseProduct : BaseEntity
    {
        public PurchaseProduct(int purchaseId, int productId, int quantity, decimal unitPrice, DateTime createAt) : base(createAt)
        {
            PurchaseId = purchaseId;
            ProductId = productId;
            Quantity = quantity;
            UnitPrice = unitPrice;
            TotalPrice = unitPrice * quantity;
        }

        public int PurchaseId { get; private set; }
        public int ProductId { get; private set; }
        public int Quantity { get; private set; }
        public decimal UnitPrice { get; private set; }
        public decimal TotalPrice { get; private set; }
    }
}
