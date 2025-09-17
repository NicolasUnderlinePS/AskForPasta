namespace Domain.AskForPasta.Entities
{
    public class PurchaseStatus : BaseEntity
    {
        public PurchaseStatus(int id, string code, string statusDescription, DateTime createAt) : base(id, createAt)
        {
            Code = code;
            StatusDescription = statusDescription;
        }

        public string Code { get; private set; }
        public string StatusDescription { get; private set; }
    }
}
