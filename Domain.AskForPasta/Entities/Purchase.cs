namespace Domain.AskForPasta.Entities
{
    public class Purchase : BaseEntity
    {
        public Purchase(int id, DateTime purchaseDate, int clientId, int addressId, int purchaseStatusId, DateTime createAt) : base(id, createAt)
        {
            PurchaseDate = purchaseDate;
            ClientId = clientId;
            AddressId = addressId;
            PurchaseStatusId = purchaseStatusId;
        }

        public DateTime PurchaseDate { get; private set; }
        public int ClientId { get; private set; }
        public int AddressId { get; private set; }
        public int PurchaseStatusId { get; private set; }
    }
}
