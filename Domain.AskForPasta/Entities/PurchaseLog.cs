namespace Domain.AskForPasta.Entities
{
    public class PurchaseLog : BaseEntity
    {
        public PurchaseLog(int purchaseId, int oldStatusId, int newStatusId, DateTime createAt) : base(createAt)
        {
            PurchaseId = purchaseId;
            OldStatusId = oldStatusId;
            NewStatusId = newStatusId;
        }

        public int PurchaseId { get; private set; }
        public int OldStatusId { get; private set; }
        public int NewStatusId { get; private set; }
    }
}
