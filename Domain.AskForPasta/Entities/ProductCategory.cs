namespace Domain.AskForPasta.Entities
{
    public class ProductCategory : BaseEntity
    {
        public ProductCategory(int id, string code, string categoryDescription, DateTime createAt) : base(id, createAt)
        {
            Code = code;
            CategoryDescription = categoryDescription;
        }

        public string Code { get; set; }
        public string CategoryDescription { get; set; }
    }
}
